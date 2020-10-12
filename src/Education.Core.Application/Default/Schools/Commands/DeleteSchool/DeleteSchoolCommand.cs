using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Commands.DeleteSchool
{
    public class DeleteSchoolCommand : ApplicationRequest<School, DeleteSchoolCommandResponse>
    {
        public DeleteSchoolCommand()
        {
            ConfigKeys(x => x.SchoolID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Classes);
            ConfigSuppressedResponseProperties(x => x.Classes);
        }
    }
}
