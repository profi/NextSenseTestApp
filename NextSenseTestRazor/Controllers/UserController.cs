using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NextSenseTestRazor.ViewModels;
using ServiceLayer.Interface;

namespace NextSenseTestRazor.Controllers
{
    public class UserController : Controller
    {
        public IUserService _userService;
        public UserController(IUserService usersservice)
        {
            _userService = usersservice;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var allUsers = _userService.GetAllUsers();

            List<UserViewModel> usersList = new List<UserViewModel>();

            var TheListOfObjectsB = allUsers.Select(a => new UserViewModel()
            {
                Id = a.Id,
                FirstName = a.FirstName,
                Lastname = a.LastName,
                Address = a.Adress,
                City = a.City,
                DateOfBirth = a.DateOfBirth,
                Email = a.Email,
                Gender = a.Gender,
            });
            return View("/Views/Users/Index.cshtml", TheListOfObjectsB) ;
            
        }

        public ActionResult GetCreateUser()
        {
            return View("/Views/Users/CreateUser.cshtml", new UserViewModel());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = _userService.GetUser(id);

            var userModel = new UserViewModel();

            userModel.FirstName = user.FirstName;
            userModel.Lastname = user.LastName;
            userModel.Email = user.Email;
            userModel.Address = user.Adress;
            userModel.City = user.City;
            userModel.DateOfBirth = user.DateOfBirth;
            userModel.Gender = user.Gender;
            userModel.Id = user.Id;

            return View("/Views/Users/UserDeatils.cshtml", userModel);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User userModel)
        {
            if(!ModelState.IsValid)
            {
                GetCreateUser();
            }
            var exist = _userService.CheckUserExist(userModel.Email);

            if (exist)
            {
                return Json(new { status = "OK", value = false, message = "User with this email"+ userModel.Email +" is allready registered" });
            }

            var newUser = new User()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.LastName,
                Adress = userModel.Adress,
                City = userModel.City,
                Country = userModel.Country,
                DateOfBirth = userModel.DateOfBirth,
                Gender = userModel.Gender       
            };

            var created = _userService.AddUser(newUser);

            return Json(new { status = "OK", value = true, message ="Succesfuly Created User" });
        
    }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            if(id <= 0)
            {
                return Json(new { status = "OK", value = false, message = "User id is wrong please check....." });

            }

            var userModel = new UserViewModel();

            var user = _userService.GetUser(id);

            userModel.FirstName = user.FirstName;
            userModel.Lastname = user.LastName;
            userModel.Email = user.Email;
            userModel.Address = user.Adress;
            userModel.City = user.City;
            userModel.DateOfBirth = user.DateOfBirth;
            userModel.Gender = user.Gender;
            userModel.Id = user.Id;

            return View("/Views/Users/Edit.cshtml", userModel);

        }

        // POST: UserController/Edit/model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel editUserModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = "OK", value = false, message = "input fileds missing data or wrong for " + editUserModel.FirstName + " " + editUserModel.Lastname });
            }

            var editUser = new User()
            {
                Id = editUserModel.Id,
                FirstName = editUserModel.FirstName,
                LastName = editUserModel.Lastname,
                Email = editUserModel.Email,
                Adress = editUserModel.Address,
                City = editUserModel.City,
                DateOfBirth = editUserModel.DateOfBirth,
                Gender = editUserModel.Gender,
            };

            var edited = _userService.UpdateUser(editUser);

            return Json(new { status = "OK", value = true, message = "Succesfuly edited user " + edited.FirstName + " " + edited.LastName });

        }

        // GET: UserController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleted =  _userService.DeleteUser(id);

            return View("Index", Index());
        }

    }
}
