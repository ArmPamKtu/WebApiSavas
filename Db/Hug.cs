﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Db
{
    public class Hug
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime Created { get; set; }
        public string To { get; set; }
        public string From { get; set; }

    }
}
