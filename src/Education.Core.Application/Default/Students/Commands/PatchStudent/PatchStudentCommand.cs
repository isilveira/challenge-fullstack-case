using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Commands.PatchStudent
{
    public class PatchStudentCommand : ApplicationRequest<Student, PatchStudentCommandResponse>
    {
        public PatchStudentCommand()
        {
            ConfigKeys(x => x.StudentID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Class);
            ConfigSuppressedResponseProperties(x => x.Class);
        }
    }
}
