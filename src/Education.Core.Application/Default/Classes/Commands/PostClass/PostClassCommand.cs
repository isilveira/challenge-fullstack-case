using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Commands.PostClass
{
    public class PostClassCommand : ApplicationRequest<Class, PostClassCommandResponse>
    {
        public PostClassCommand()
        {
            ConfigKeys(x => x.ClassID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.School);
            ConfigSuppressedProperties(x => x.Students);
            ConfigSuppressedResponseProperties(x => x.School);
            ConfigSuppressedResponseProperties(x => x.Students);
        }
    }
}
