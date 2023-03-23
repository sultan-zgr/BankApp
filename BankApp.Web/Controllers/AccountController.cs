using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;

        //public AccountController(IUserMapper userMapper, IApplicationUserRepository applicationUserRepository, IAccountMapper accountMapper)
        //{
        //    _userMapper = userMapper;
        //    _applicationUserRepository = applicationUserRepository;
        //    _accountMapper = accountMapper;
        //}

        private readonly IGenericRepository<Account> _accountRepository;
        private readonly IGenericRepository<ApplicationUser> _userRepository;

        public AccountController(IGenericRepository<Account> accountRepository, IGenericRepository<ApplicationUser> userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }
        public IActionResult Create(int id)
        {
            var userInfo = _userRepository.GetById(id);
            return View(new UserListModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }
        [HttpPost]
        public IActionResult Create (AccountCreateModel model)
        {
            _accountRepository.Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            });
            return RedirectToAction("Index", "Home");
        }

    }
}

