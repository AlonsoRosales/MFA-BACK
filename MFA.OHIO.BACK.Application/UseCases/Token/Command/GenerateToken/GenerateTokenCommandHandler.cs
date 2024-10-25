using MediatR;
using MFA.OHIO.BACK.Application.DTO.Response;
using MFA.OHIO.BACK.Application.Helpers;
using MFA.OHIO.BACK.Core.Enums;
using Entity = MFA.OHIO.BACK.Core.Entity;
using MFA.OHIO.BACK.Core.Repositories;
using MFA.OHIO.BACK.Core.Constants;
using MFA.OHIO.BACK.Application.Interfaces;

namespace MFA.OHIO.BACK.Application.UseCases.Token.Command.GenerateToken
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, ResponseDTO>
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IGrantedUserRepository _grantedUserRepository;
        private readonly EmailHelper _emailHelper;
        private readonly Ipv4Helper _ipv4Helper;
        private readonly DateHelper _dateHelper;
        private readonly TokenHelper _tokenHelper;
        private readonly INotificationService _notificationService;
        public GenerateTokenCommandHandler(ITokenRepository tokenRepository, EmailHelper emailHelper, Ipv4Helper ipv4Helper, DateHelper dateHelper,
            IApplicationRepository applicationRepository, IGrantedUserRepository grantedUserRepository, TokenHelper tokenHelper, INotificationService notificationService)
        {
            _tokenRepository = tokenRepository;
            _applicationRepository=applicationRepository;
            _grantedUserRepository=grantedUserRepository;
            _emailHelper = emailHelper;
            _ipv4Helper = ipv4Helper;
            _dateHelper=dateHelper;
            _tokenHelper=tokenHelper;
            _notificationService=notificationService;
        }

        public async Task<ResponseDTO> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            ResponseDTO response = new ResponseDTO();
            
            if(string.IsNullOrEmpty(request.generateTokenRequestDTO.user) || !_emailHelper.validateEmail(request.generateTokenRequestDTO.email)
                || !_ipv4Helper.validateIpv4(request.generateTokenRequestDTO.ipv4) || !_dateHelper.validateDate(request.generateTokenRequestDTO.req_date))
            {
                response.statusCode = (int) ResponseStatusEnum.ERROR;
                response.detail = "Mensaje incompleto o mal formado";
            }
            if(!_dateHelper.validateServerTime(request.generateTokenRequestDTO.req_date))
            {
                response.statusCode= (int) ResponseStatusEnum.UNAUTHORIZED;
                response.detail = "Fecha de Solicitud inválida";
            }

            var application = await _applicationRepository.GetApplicationByIdAsync(request.generateTokenRequestDTO.application_id);
            if (application == null)
            {
                response.statusCode = (int) ResponseStatusEnum.UNAUTHORIZED;
                response.detail = "Aplicación no existente";
            }

            var grantedUser = await _grantedUserRepository.GetGrantedUserByUserAsync(request.generateTokenRequestDTO.user);
            if(grantedUser == null)
            {
                await _grantedUserRepository.CreateGrantedUserAsync(new Entity.GrantedUser {user = request.generateTokenRequestDTO.user
                        , email = request.generateTokenRequestDTO.email, applicationId = request.generateTokenRequestDTO.application_id
                        , userStatus = (int) UserStatusEnum.ACTIVO, fechaHoraCreacion = DateTime.Now});
            }
            else
            {
                if (!grantedUser.applicationId.Equals(request.generateTokenRequestDTO.application_id))
                {
                    response.statusCode = (int)ResponseStatusEnum.UNAUTHORIZED;
                    response.detail = "Aplicación no autorizado";
                }
                var tokenEntity = await _tokenRepository.GetTokenByGrantedUserIdAsync(grantedUser.granteduserId);
                if(tokenEntity.status.Equals(StatusConstant.ACTIVO))
                {
                    await _notificationService.SendMailAsync(tokenEntity.token);
                }
            }

            string tokenGenerated = _tokenHelper.generateRandomTokenString();

            await _tokenRepository.CreateTokenAsync(new Entity.Token { token = tokenGenerated, grantedUserId = grantedUser.granteduserId, status = StatusConstant.ACTIVO
                        , fechaHoraCreacion = DateTime.Now, fechaHoraExpiracion = DateTime.Now, fechaHoraCambioEstado = DateTime.Now, ttlConfig = 1
                        , failCounts = 0, failCountsSet = 3});

            await _notificationService.SendMailAsync(tokenGenerated);

            throw new NotImplementedException();
        }
    }
}
