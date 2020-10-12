using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Commands.PostStudent
{
    public class PostStudentCommand : ApplicationRequest<Student, PostStudentCommandResponse>
    {
        public PostStudentCommand()
        {
            ConfigKeys(x => x.StudentID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Class);
            ConfigSuppressedResponseProperties(x => x.Class);
        }
    }
}
