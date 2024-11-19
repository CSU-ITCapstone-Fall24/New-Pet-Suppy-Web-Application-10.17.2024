using PayPal.Api;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Azure.Core;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public static class PayPalController
    {
        public static APIContext GetAPIContext(IConfiguration configuration)
        {
            // Read settings from configuration
            var clientId = configuration["PayPal:ATgHTh7lkh2Lc8wo1XIIRTdcOf5tHSud3G9M88t-KPcPHi7VOLKqVpF8bLFcAi-mwkN5PmWnbmIKHtTP"];
            var clientSecret = configuration["PayPal:EM8E-p0EgG5tsb1yuTaC56zcHq_NtDLEog3OhZMoAlZCAJn2avZiS3BvPGZAwmWobQ-ugZyR1GCL8QuE"];
            var mode = configuration["PayPal:Mode"];

            // Create a dictionary for PayPal configuration
            var config = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(mode))
            {
                config.Add("mode", mode);
            }

            // Get access token
            var accessToken = new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken();

            // Return API context
            return new APIContext(accessToken) { Config = config };
        }
    }
}