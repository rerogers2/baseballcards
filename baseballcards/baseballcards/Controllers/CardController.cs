using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baseballcards.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardRepository repo;
        public CardController(ICardRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var cards = repo.GetAllCards();
            return View(cards);
        }
    }
}
