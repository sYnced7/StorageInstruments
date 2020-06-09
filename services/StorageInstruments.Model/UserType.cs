﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StorageInstruments.Model
{
    public class UserType : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
