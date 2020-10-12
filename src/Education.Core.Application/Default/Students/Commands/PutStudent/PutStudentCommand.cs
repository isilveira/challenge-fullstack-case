using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Commands.PutStudent
{
    public class PutStudentCommand : ApplicationRequest<Student, PutStudentCommandResponse>
    {
        public PutStudentCommand()
        {
            ConfigKeys(x => x.StudentID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Class);
            ConfigSuppressedResponseProperties(x => x.Class);
        }
    }
}
