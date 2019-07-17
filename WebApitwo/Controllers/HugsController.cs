using System.Collections.Generic;
using System.Linq;
using Db;
using Microsoft.AspNetCore.Mvc;
using Infastructure;
using WebApitwo.Model;
using Infrastructure;
using HugDb.Repositories;

namespace WebApitwo.Controllers
{


    [Route("api/[controller]")]
    [ApiController]// tai passako kad tai bus api controller
    public class HugsController : ControllerBase //jeigu noretume view, tai butu tiesiog controller
    {
        private readonly DbService _dbService = new DbService();
        private UserRepository _repository;
        /*private readonly DbService _dbService;
        readonly private IMyLogger _logger;
        readonly private IMyTime _time;
        */
        public HugsController(UserRepository repository)
        {
            _repository = repository;
            //_time = new MyTime();
            //_dbService = new DbService(_logger);
            //_logger = new DebugLogger(_time);
        }


        [HttpGet]//jeigu nenurodom [get/post] tai musu metodas turi taip vadinits get/post
        public ActionResult<IEnumerable<HugModel>> Get() //actionResult kaip wraperis papildomos info duoda
        {
           
           // _logger.Log("Get Started");

            var hugs = _dbService.GetHugs();
            var mappedHugs = hugs.Select(h => new HugModel
                                {
                                    Id = h.Id,
                                    From = h.From,
                                    To = h.To,
                                    Reason = h.Reason,
                                    Created = h.Created
                                })
                                .ToList();

            return mappedHugs;
        }


        [HttpDelete("{id}")]
        public ActionResult<string> Delete(long id)
        {
            
            //_logger.Log("Delete Started");


            //predikata paduodam ir randam kur hugs atitinka
            var hugs = _dbService.GetHugs();
            var deletedHugs = hugs.Find(x => x.Id == id);
            _dbService.DeleteHug(deletedHugs);

            return "Hug deleted";
        }

        [HttpPost]
        public string Post([FromBody]HugModel model)
        {
            
            //_logger.Log("Post Started");

            var hugs = _dbService.GetHugs();
            int exist = hugs.Where(x => x.Id == model.Id).Count();
            
            if (exist == 0) {

                Hug newHug = new Hug();
                newHug.Id = model.Id;
                newHug.To = model.To;
                newHug.From = model.From;
                newHug.Reason = model.Reason;
                newHug.Created = model.Created;

                _dbService.AddHug(newHug);

                return "Hug added";
            }
            else
                return "Hug exists already";
        }



        [HttpPut]
        public string Put([FromBody]HugModel model)
        {
           
            //_logger.Log("Put Started");

            var hugs = _dbService.GetHugs();
            int isthere = hugs.Where(x => x.Id == model.Id).Count();

            if (isthere == 1)
            {
                Hug exists = hugs.Find(x => x.Id == model.Id);
                exists.Reason = model.Reason;
                exists.To = model.To;
                exists.From = model.From;
                exists.Created = model.Created;

                return "Hug updated";
            }
            else
                return "Hug does not exist that you want to update";
        }


        public static bool CheckNullOrEmpty<T>(T value)
        {
            if (typeof(T) == typeof(string))
                return string.IsNullOrEmpty(value as string);

            return value == null || value.Equals(default(T));
        }

        [HttpPatch]
        public string Patch([FromBody]HugModel model)
        {
            
            //_logger.Log("Patch Started");

            var hugs = _dbService.GetHugs();
            int isthere = hugs.Where(x => x.Id == model.Id).Count();

            if (isthere == 1)
            {
                Hug exists = hugs.Find(x => x.Id == model.Id);
                if(!CheckNullOrEmpty(model.Reason))
                    exists.Reason = model.Reason;
                if (!CheckNullOrEmpty(model.To))
                    exists.To = model.To;
                if (!CheckNullOrEmpty(model.From))
                    exists.From = model.From;
                if (!CheckNullOrEmpty(model.Created))
                    exists.Created = model.Created;

                return "Hug updated";
            }
            else
                return "Hug does not exist that you want to update";
        }

    }
}
