using System;

namespace Dsms.Model
{
    public class Connectioninfo
    {
        public string ID { get; set; }
        public string IsDefault { get; set; }
        public string USELOGIN { get; set; }
        public string DataSource { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string IntegratedSecurity { get; set; }
        public string Port { get; set; }
    }
}
