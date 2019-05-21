using System;
using System.Collections.Generic;
using System.Text;

namespace Wink.Api.Models
{
    public sealed class WinkList<T> : List<T> where T : WinkModelBase
    {
    }
}
