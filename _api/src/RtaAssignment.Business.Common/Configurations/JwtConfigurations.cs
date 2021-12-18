using System;

namespace RtaAssignment.Business.Common.Configurations
{
    public class JwtConfigurations
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}