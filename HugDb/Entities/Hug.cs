using System;
using System.Collections.Generic;
using System.Text;

namespace HugDb.Entities
{
    public class Hug
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public User FromUserId{ get; set; }
        public User ToUserId{ get; set; }
        public DateTime Created { get; set; }
        public bool Used { get; set; }
    }
}
