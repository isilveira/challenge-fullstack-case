using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : ApplicationRequest<Student, DeleteStudentCommandResponse>
    {
        public DeleteStudentCommand()
        {
            ConfigKeys(x => x.StudentID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Class);
            ConfigSuppressedResponseProperties(x => x.Class);
        }
    }
}
