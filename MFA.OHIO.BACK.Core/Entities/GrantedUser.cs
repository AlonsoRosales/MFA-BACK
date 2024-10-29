
namespace MFA.OHIO.BACK.Core.Entities
{
    public class GrantedUser
    {
        public int granteduserId {  get; set; }
        public string? user {  get; set; }  
        public string? email { get; set; }
        public string? applicationId { get; set;}
        public int userStatus { get; set; }
        public DateTime fechaHoraCreacion { get; set; }
    }
}
