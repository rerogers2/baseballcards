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

        public IActionResult ViewSet(string setname)
        {
            // it's not reading in the string setname, so it runs else instead of if
            /*if (setname == "Leaf") 
            {
                
                var cards = repo.GetSet(setname);
                return View(cards);
            } 
            else
            {
                var cards = repo.GetSet("Donruss");
                return View(cards);
            }*/
            var cards = repo.GetSet(setname.ToString);
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
