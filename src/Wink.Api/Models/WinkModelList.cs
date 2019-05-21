using System.Collections.Generic;

namespace Wink.Api.Models
{
    public sealed class WinkModelList<T> : List<T> where T : WinkModelBase
    {
    }
}