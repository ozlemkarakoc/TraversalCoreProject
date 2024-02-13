using BusinessLayer.Abstract.AbstractUow;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Context context = new Context();
            List<SelectListItem> id = (from x in context.Accounts.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.Name,
                                           Value = x.AccountID.ToString()
                                       }).ToList();
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            Context context = new Context();
            List<SelectListItem> id = (from x in context.Accounts.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.Name,
                                           Value = x.AccountID.ToString()
                                       }).ToList();
            ViewBag.id = id;

            var valueSender = _accountService.TGetByID(model.SenderID);
            var valuesReceiver = _accountService.TGetByID(model.ReceiverID);
            //senderid,receiverid,amount

            valueSender.Balance -= model.Amount;
            valuesReceiver.Balance += model.Amount;

            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valuesReceiver
            };
            _accountService.TMultiUpdate(modifiedAccounts);
            return View();
        }
    }
}
