using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApitwo.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime Created { get; set; }
        public string Lastname { get; set; }
        public string SocEmail { get; set; }
    }
}
