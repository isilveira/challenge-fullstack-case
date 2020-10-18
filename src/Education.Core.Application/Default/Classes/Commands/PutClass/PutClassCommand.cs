using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Classes.Commands.PutClass
{
    public class PutClassCommand : ApplicationRequest<Class, PutClassCommandResponse>
    {
        public PutClassCommand()
        {
            ConfigKeys(x => x.ClassID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.School);
            ConfigSuppressedResponseProperties(x => x.School);
        }
    }
}
