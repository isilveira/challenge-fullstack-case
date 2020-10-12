using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Schools.Commands.PostSchool
{
    public class PostSchoolCommand : ApplicationRequest<School, PostSchoolCommandResponse>
    {
        public PostSchoolCommand()
        {
            ConfigKeys(x => x.SchoolID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Classes);
            ConfigSuppressedResponseProperties(x => x.Classes);
        }
    }
}
