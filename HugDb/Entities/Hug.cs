using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HugDb.Entities
{
    public class Hug
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public int? FromUserId { get; set; }

        public int? ToUserId { get; set; }

        [ForeignKey("FromUserId")]
        public User FromUser{ get; set; }
        [ForeignKey("ToUserId")]
        public User ToUser{ get; set; }
        public DateTime Created { get; set; }
        public bool Used { get; set; }

        public Committee Committee { get; set; }
    }
}
