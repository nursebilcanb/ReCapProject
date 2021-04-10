﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForUpdateDto : UserForRegisterDto, IDto
    {
        public int CustomerId { get; set; }

        public int UserId { get; set; }

    }
}
