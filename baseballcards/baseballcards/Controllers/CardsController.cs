using baseballcards.Models;
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

        public IActionResult ViewSet(int id)
        {
            var setname = Convert.ToString(repo.GetCard(id).SetName);
            var cards = repo.GetSet(setname);
            return View(cards);
        }

        public IActionResult UpdateCard(int id)
        {
            Cards card = repo.GetCard(id);
            if (card == null)
            {
                return View("CardNotFound");
            }
            return View(card);
        }

        public IActionResult UpdateCardToDatabase(Cards card)
        {
            repo.UpdateCard(card);
            return RedirectToAction("ViewCard", new { id = card.CardID });
        }
    }
}
