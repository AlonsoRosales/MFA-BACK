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
        private readonly ISystemVariablesRepository _systemVariablesRepository;
        private readonly EmailHelper _emailHelper;
        private readonly Ipv4Helper _ipv4Helper;
        private readonly DateHelper _dateHelper;
        private readonly TokenHelper _tokenHelper;
        private readonly INotificationService _notificationService;
        public GenerateTokenCommandHandler(ITokenRepository tokenRepository, EmailHelper emailHelper, Ipv4Helper ipv4Helper, DateHelper dateHelper,
            IApplicationRepository applicationRepository, IGrantedUserRepository grantedUserRepository, TokenHelper tokenHelper, INotificationService notificationService,
            ISystemVariablesRepository systemVariablesRepository)
        {
            _tokenRepository = tokenRepository;
            _applicationRepository=applicationRepository;
            _grantedUserRepository=grantedUserRepository;
            _systemVariablesRepository=systemVariablesRepository;
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

                    response.statusCode = (int) ResponseStatusEnum.SUCCESS;
                    response.detail = "successful";
                    response.fechaHoraExpiracion = tokenEntity.fechaHoraExpiracion;
                }
            }

            string tokenGenerated = _tokenHelper.generateRandomTokenString();

            var systemVariableTTLEntity = await _systemVariablesRepository.GetSystemVariableByNameAsync(SystemVariableConstant.TTL);
            var systemVariableFEntity = await _systemVariablesRepository.GetSystemVariableByNameAsync(SystemVariableConstant.FAILCOUNTSET);
            DateTime fechaHoraCreacion = DateTime.Now;
            DateTime fechaHoraExpiracion = fechaHoraCreacion.AddMinutes(systemVariableTTLEntity.scheduleInterval);

            await _tokenRepository.CreateTokenAsync(new Entity.Token { token = tokenGenerated, grantedUserId = grantedUser.granteduserId, status = StatusConstant.ACTIVO
                        , fechaHoraCreacion = fechaHoraCreacion, fechaHoraExpiracion = fechaHoraExpiracion
                        , fechaHoraCambioEstado = null, ttlConfig = systemVariableTTLEntity.scheduleInterval, failCounts = 0, failCountsSet = systemVariableFEntity.scheduleInterval});

            await _notificationService.SendMailAsync(tokenGenerated);

            response.statusCode = (int)ResponseStatusEnum.SUCCESS;
            response.detail = "successful";
            response.fechaHoraExpiracion = fechaHoraExpiracion;

            throw new NotImplementedException();
        }
    }
}
