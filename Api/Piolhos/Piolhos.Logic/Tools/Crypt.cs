using Onsoft.Security;
using Onsoft.Security.Configuratios;

namespace Piolhos.Logic.Tools
{
    public class Crypt : OnCryptography
    {
        public Crypt()
        {
            Configuration = new OnCryptographyConfiguration
            {
                PasswordHash = "=P1@lH0$",
                SaltKey = "@Po1N7$%",
                VIKey = "#4!0lH@_&Po1N7$z"
            };
        }
    }
}
