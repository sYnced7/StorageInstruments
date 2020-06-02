using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StorageInstruments.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(85)]
        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
