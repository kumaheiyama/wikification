﻿using System.Collections.Generic;

namespace Wikification.Business.Dto.Request
{
    public class CreateExternalSystemRequestDto
    {
        public string CallbackUrl { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public ICollection<CreateContentPageDto> Pages { get; set; }
        public ICollection<CreateUserRequestDto> Users { get; set; }
    }
}