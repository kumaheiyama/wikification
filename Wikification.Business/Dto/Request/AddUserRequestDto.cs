using System;
using System.Collections.Generic;
using System.Text;

namespace Wikification.Business.Dto.Request
{
    public class AddUserRequestDto
    {
        public string SystemExternalId { get; set; }
        public string ExternalId { get; set; }
        public string Username { get; set; }
    }
}
