namespace Wink.Api.Models
{
    public abstract class Response<T> : BaseModel
    {
        public T data { get; set; }
        public object[] errors { get; set; }
        public Pagination pagination { get; set; }
    }

    public sealed class Pagination
    {
    }
}