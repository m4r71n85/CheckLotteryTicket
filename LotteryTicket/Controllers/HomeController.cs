using LotteryTicket.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace LotteryTicket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Check()
        {
            string lotteryNumbers = Request.Form["lottery_numbers"];
            string[] userNumbers = new string[4];
            for (int i = 0; i < 4; i++)
            {
                userNumbers[i] = Request.Form["user_numbers_" + (i + 1)];
            }
            
            Lottery lottery = new Lottery(lotteryNumbers, userNumbers);

            return View(lottery);
        }
    }
}