using System;
using System.Collections.Generic;
using System.Text;

namespace Wink.Api.Models
{
    public sealed class User : WinkModelBase
    {
        public string user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public UserAuthentication oauth2 { get; set; }
        public string locale { get; set; }
        public Units units { get; set; }
        public bool tos_accepted { get; set; }
        public bool confirmed { get; set; }
    }

    public sealed class Units : WinkModelBase
    {
    }
}