using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Commands.PatchSchool
{
    public class PatchSchoolCommand : ApplicationRequest<School, PatchSchoolCommandResponse>
    {
        public PatchSchoolCommand()
        {
            ConfigKeys(x => x.SchoolID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Classes);
            ConfigSuppressedResponseProperties(x => x.Classes);
        }
    }
}
