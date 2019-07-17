using Infastructure;
using Infrastructure;
using System;
using System.Collections.Generic;


namespace Db
{
    public class DbService
    {
        private static List<Hug> _hugs = new List<Hug>();

        /*private readonly IMyLogger _logger;

        public DbService(IMyLogger logger)
        {
            _logger = logger;
        }*/
        static DbService()
        {
            
            _hugs.Add(new Hug { Id = 0, From = "A", To = "B", Reason = "Reason 1", Created = DateTime.Now });
            _hugs.Add(new Hug { Id = 1, From = "c", To = "D", Reason = "Reason 2", Created = DateTime.Now });
            _hugs.Add(new Hug { Id = 2, From = "E", To = "F", Reason = "Reason 3", Created = DateTime.Now });
            _hugs.Add(new Hug { Id = 3, From = "G", To = "H", Reason = "Reason 4", Created = DateTime.Now });
            _hugs.Add(new Hug { Id = 4, From = "I", To = "J", Reason = "Reason 6", Created = DateTime.Now });
            _hugs.Add(new Hug { Id = 5, From = "K", To = "L", Reason = "Reason 7", Created = DateTime.Now });

            
        }


        public List<Hug> GetHugs()
        {
            return _hugs;
        }
        public void DeleteHug(Hug hug)
        {
            _hugs.Remove(hug);
        }
         
        public void AddHug(Hug hug)
        {
            _hugs.Add(hug);
        }
    }
}
