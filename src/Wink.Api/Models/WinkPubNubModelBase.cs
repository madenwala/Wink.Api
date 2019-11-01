using System;
using System.Collections.Generic;
using System.Text;

namespace Wink.Api.Models
{
    public abstract class WinkPubNubModelBase : WinkModelBase
    {
        public Pubnub pubnub { get; set; }
    }

    public class Pubnub
    {
        public string subscribe_key { get; set; }
        public string channel { get; set; }
        public string origin { get; set; }
    }
}