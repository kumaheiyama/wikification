﻿using System.Collections.Generic;
using Wikification.Business.Dto.Model;

namespace Wikification.Business.Dto.Response
{
    public class UserBadgeResponseDto
    {
        public UserBadgeResponseDto()
        {
            Badges = new List<UserBadgeDto>();
        }

        public ICollection<UserBadgeDto> Badges { get; set; }
    }
    public class UserBadgeDto
    {
        public UserDto User { get; set; }
        public BadgeDto Badge { get; set; }
    }
}
