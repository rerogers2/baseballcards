using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baseballcards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardRepository repo;
        public CardsController(ICardRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var cards = repo.GetAllCards();
            return View(cards);
        }

        public IActionResult ViewCard(int id)
        {
            var card = repo.GetCard(id);
            return View(card);
        }
    }
}
