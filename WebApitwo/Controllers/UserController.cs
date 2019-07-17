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
        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]//jeigu nenurodom [get/post] tai musu metodas turi taip vadinits get/post
        public ActionResult<IEnumerable<UserModel>> Get() //actionResult kaip wraperis papildomos info duoda
        {

            // _logger.Log("Get Started");
            var users = _repository.GetAllUsers();
            var result = users.Select(x => new UserModel
            {
                FirstName = x.FirstName,
                Lastname = x.LastName,
                Created = x.Created,
                Id = x.Id,
                SocEmail = x.SocEmail,
            }).ToList();
            
            return result;
        }

        public ActionResult<string> Delete(long id)
        {
            var userToDelete = _repository.GetUser((int)id);
            _repository.Delete(userToDelete);

            return ($"User: {id} deleted ");
        }

        [HttpPost]
        public string Post([FromBody]UserModel model)
        {
            var users = _repository.GetAllUsers();
            int exist = users.Where(x => x.Id == model.Id).Count();

            if (exist == 0)
            {

                User newUser = new User();
                newUser.FirstName = model.FirstName;
                newUser.LastName = model.Lastname;
                newUser.SocEmail = model.SocEmail;
                newUser.Created = model.Created;

                _repository.AddUser(newUser);
                return "User added";
            }
            else
                return "User exists already";
        }

    }
}
