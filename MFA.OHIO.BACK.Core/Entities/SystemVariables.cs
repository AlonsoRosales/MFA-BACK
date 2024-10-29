
namespace MFA.OHIO.BACK.Core.Entities
{
    public class SystemVariables
    {
        public int systemVariableId {  get; set; }
        public string systemVariableName { get; set; }
        public string systemVariableDescription { get; set; }
        public int scheduleInterval {  get; set; }
        public string timeUnit {  get; set; }
        public char status {  get; set; }
        public int userIdMofication {  get; set; }
        public DateTime fechaHoraModificacion {  get; set; }
        
    }
}
