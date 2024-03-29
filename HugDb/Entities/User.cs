﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HugDb.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocEmail { get; set; }
        public DateTime Created { get; set; }

        public List<UserCommittee> UserCommittees { get; set; }
        public List<Hug> Hugs { get; set; }

    }
}
