using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Queries.GetStudentByID
{
    public class GetStudentByIDQuery : ApplicationRequest<Student, GetStudentByIDQueryResponse>
    {
        public GetStudentByIDQuery()
        {
            ConfigKeys(x => x.StudentID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Class);
            ConfigSuppressedResponseProperties(x => x.Class);
        }
    }
}
