using MediatR;
using MFA.OHIO.BACK.Application.DTO.Response;
using MFA.OHIO.BACK.Application.Helpers;
using MFA.OHIO.BACK.Application.Interfaces;
using MFA.OHIO.BACK.Core.Constants;
using MFA.OHIO.BACK.Core.Enums;
using MFA.OHIO.BACK.Core.Repositories;

namespace MFA.OHIO.BACK.Application.UseCases.Token.Command.ValidateToken
{
    public class ValidateTokenCommandHandler : IRequestHandler<ValidateTokenCommand, ResponseDTO>
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IGrantedUserRepository _grantedUserRepository;
        private readonly ISystemVariablesRepository _systemVariablesRepository;
        private readonly EmailHelper _emailHelper;
        private readonly Ipv4Helper _ipv4Helper;
        private readonly DateHelper _dateHelper;
        private readonly TokenHelper _tokenHelper;

        public ValidateTokenCommandHandler(ITokenRepository tokenRepository, EmailHelper emailHelper, Ipv4Helper ipv4Helper, DateHelper dateHelper,
            IApplicationRepository applicationRepository, IGrantedUserRepository grantedUserRepository, TokenHelper tokenHelper,
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
        }

        public async Task<ResponseDTO> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
        {
            ResponseDTO response = new ResponseDTO();

            if (string.IsNullOrEmpty(request.validateTokenRequestDTO.user) || !_emailHelper.validateEmail(request.validateTokenRequestDTO.email)
                || !_ipv4Helper.validateIpv4(request.validateTokenRequestDTO.ipv4) || !_dateHelper.validateDate(request.validateTokenRequestDTO.req_date))
            {
                response.statusCode = (int)ResponseStatusEnum.ERROR;
                response.detail = "Mensaje incompleto o mal formado";
            }
            if (!_dateHelper.validateServerTime(request.validateTokenRequestDTO.req_date))
            {
                response.statusCode= (int)ResponseStatusEnum.UNAUTHORIZED;
                response.detail = "Fecha de Solicitud inválida";
            }

            var application = await _applicationRepository.GetApplicationByIdAsync(request.validateTokenRequestDTO.application_id);
            if (application == null)
            {
                response.statusCode = (int)ResponseStatusEnum.UNAUTHORIZED;
                response.detail = "Aplicación no existente";
            }

            var grantedUser = await _grantedUserRepository.GetGrantedUserByUserAsync(request.validateTokenRequestDTO.user);

            if (grantedUser == null)
            {
                response.statusCode = (int)ResponseStatusEnum.UNAUTHORIZED;
                response.detail = "Granted User no existente";
            }

            var tokenEntity = await _tokenRepository.GetTokenByGrantedUserIdAsync(grantedUser.granteduserId);
            if (tokenEntity.status.Equals(StatusConstant.ACTIVO))
            {
                if (tokenEntity.token.Equals(request.validateTokenRequestDTO.token))
                {
                    tokenEntity.status = StatusConstant.VALIDADO;
                    tokenEntity.fechaHoraCambioEstado = DateTime.Now;
                    await _tokenRepository.UpdateTokenAsync(tokenEntity);
                    
                    response.statusCode = (int) ResponseStatusEnum.SUCCESS;
                    response.detail = "successful";
                }
                else
                {
                    tokenEntity.failCounts++;
                    if(tokenEntity.failCountsSet > tokenEntity.failCounts)
                    {
                        tokenEntity.status = StatusConstant.RECHAZADO;
                        tokenEntity.fechaHoraCambioEstado = DateTime.Now;
                        tokenEntity.failCounts = tokenEntity.failCounts--;
                        await _tokenRepository.UpdateTokenAsync(tokenEntity);

                        response.statusCode = (int) (ResponseStatusEnum.UNAUTHORIZED);
                        response.detail = "Token rechazado";
                    }
                    else
                    {
                        response.statusCode = (int) (ResponseStatusEnum.UNAUTHORIZED);
                        response.detail = "Token rechazado";
                    }
                }
            }
            else
            {
                response.statusCode = (int)ResponseStatusEnum.UNAUTHORIZED;
                response.detail = "Token expirado";
            }

            throw new NotImplementedException();
        }
    }
}
