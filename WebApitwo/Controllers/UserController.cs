using System.Collections.Generic;
using System.Linq;
using Db;
using Microsoft.AspNetCore.Mvc;
using Infastructure;
using WebApitwo.Model;
using Infrastructure;
using HugDb.Repositories;
using HugDb.Entities;

namespace WebApitwo.Controllers
{


    [Route("api/[controller]")]
    [ApiController]// tai passako kad tai bus api controller
    public class UserController : ControllerBase //jeigu noretume view, tai butu tiesiog controller
    {
       
        private UserRepository _repository;
        /*private readonly DbService _dbService;
        readonly private IMyLogger _logger;
        readonly private IMyTime _time;
        */
        public UserController(UserRepository repository)
        {
            _repository = repository;
            //_time = new MyTime();
            //_dbService = new DbService(_logger);
            //_logger = new DebugLogger(_time);
        }


        [HttpGet]//jeigu nenurodom [get/post] tai musu metodas turi taip vadinits get/post
        public ActionResult<IEnumerable<User>> Get() //actionResult kaip wraperis papildomos info duoda
        {

            // _logger.Log("Get Started");
            var users = _repository.GetAllUsers();
            return users;
        }

    }
}
