namespace Wikification.Business.Dto.Request
{
    public class RemoveUserRequestDto
    {
        public string SystemExternalId { get; set; }
        public string ExternalId { get; set; }
        public string Username { get; set; }
    }
}
