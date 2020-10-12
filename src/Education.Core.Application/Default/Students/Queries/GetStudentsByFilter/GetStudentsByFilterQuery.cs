using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Students.Queries.GetStudentsByFilter
{
    public class GetStudentsByFilterQuery : ApplicationRequest<Student, GetStudentsByFilterQueryResponse>
    {
        public GetStudentsByFilterQuery()
        {
            ConfigKeys(x => x.StudentID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Class);
            ConfigSuppressedResponseProperties(x => x.Class);
        }
    }
}
