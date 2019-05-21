namespace Wink.Api.Models
{
    public sealed class UserAuthentication : UserAuthenticationData
    {
        public UserAuthenticationData data { get; set; }
        public object[] errors { get; set; }
        public Pagination pagination { get; set; }
    }

    public class UserAuthenticationData : BaseModel
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string token_endpoint { get; set; }
        public string scopes { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }
        public string object_type { get; set; }
        public string object_id { get; set; }
    }
}