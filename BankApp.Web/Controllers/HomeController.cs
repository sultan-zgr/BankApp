using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;

        public HomeController(IApplicationUserRepository applicationUserRepository, IUserMapper userMapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_applicationUserRepository.GetAll()));
        }
    }
}
