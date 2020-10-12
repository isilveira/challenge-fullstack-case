using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Commands.PutSchool
{
    public class PutSchoolCommand : ApplicationRequest<School, PutSchoolCommandResponse>
    {
        public PutSchoolCommand()
        {
            ConfigKeys(x => x.SchoolID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Classes);
            ConfigSuppressedResponseProperties(x => x.Classes);
        }
    }
}
