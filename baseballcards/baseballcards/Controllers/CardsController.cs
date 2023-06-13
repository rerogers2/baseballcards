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


        public async Task<IActionResult> Index(string searchString)
        {
            //var cards = repo.GetAllCards();
            ViewData["CurrentFilter"] = searchString;
            var cards = repo.SearchCard(searchString);
            return View(cards);
        }


        // view all cards
        public IActionResult AllCards()
        {
            var cards = repo.GetAllCards();
            return View(cards);
        }
        // view single card
        public IActionResult ViewCard(int id)
        {
            var card = repo.GetCard(id);
            return View(card);
        }
        
        
        // view all cards by SetName
        public IActionResult ViewSet(int id)
        {
            var setname = Convert.ToString(repo.GetCard(id).SetName);
            var cards = repo.GetSet(setname);
            return View(cards);
        }
        // view all cards by Year
        public IActionResult ViewYear(int id) 
        {
            var year = Convert.ToString(repo.GetCard(id).Year);
            var cards = repo.GetYear(year);
            return View(cards);
        }
        public IActionResult ViewSubset(int id)
        {
            var subset = Convert.ToString(repo.GetCard(id).Subset);
            var cards = repo.GetSubset(subset);
            return View(cards);
        }
        public IActionResult ViewCardnumber(int id)
        {
            var cardnumber = Convert.ToString(repo.GetCard(id).Cardnumber);
            var cards = repo.GetCardnumber(cardnumber);
            return View(cards);
        }
        public IActionResult ViewFirstname(int id)
        {
            var firstname = Convert.ToString(repo.GetCard(id).Firstname);
            var cards = repo.GetFirstname(firstname);
            return View(cards);
        }
        public IActionResult ViewLastname(int id)
        {
            var lastname = Convert.ToString(repo.GetCard(id).Lastname);
            var cards = repo.GetLastname(lastname);
            return View(cards);
        }
        public IActionResult ViewAutograph(int id)
        {
            var autograph = Convert.ToString(repo.GetCard(id).Autograph);
            var cards = repo.GetAutograph(autograph);
            return View(cards);
        }
        public IActionResult ViewRelic(int id)
        {
            var relic = Convert.ToString(repo.GetCard(id).Relic);
            var cards = repo.GetRelic(relic);
            return View(cards);
        }


        // view single card to update TotalNumber 
        public IActionResult UpdateCard(int id)
        {
            Cards card = repo.GetCard(id);
            if (card == null)
            {
                return View("CardNotFound");
            }
            return View(card);
        }
        // update card to database and send by to ViewCard with updated info
        public IActionResult UpdateCardToDatabase(Cards card)
        {
            repo.UpdateCard(card);
            return RedirectToAction("ViewCard", new { id = card.CardID });
        }
    }
}
