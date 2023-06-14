﻿using baseballcards.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace baseballcards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardRepository repo;
        public CardsController(ICardRepository repo)
        {
            this.repo = repo;
        }

        //Does a search
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            ViewData["CurrentFilter"] = searchString;
            var cards = repo.SearchCard(searchString);
            // calculate page size
            int pageSize = 100;
            // calculate total number of pages
            int totalItems = cards.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
            // Set the current page number
            int pageNumber = (page ?? 1);
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));
            // Retrieve the items for the current page
            var pagedItems = cards.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            // Pass the paginated items and pagination information to the view
            ViewBag.Items = pagedItems;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber;

            return View();
        }


        // view all cards
        public IActionResult AllCards(int? page)
        {
            var cards = repo.GetAllCards();
            // calculate page size
            int pageSize = 1000;
            // calculate total number of pages
            int totalItems = cards.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
            // Set the current page number
            int pageNumber = (page ?? 1);
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));
            // Retrieve the items for the current page
            var pagedItems = cards.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            // Pass the paginated items and pagination information to the view
            ViewBag.Items = pagedItems;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber;
            return View();
        }
        // view single card
        public IActionResult ViewCard(int id)
        {
            var card = repo.GetCard(id);
            return View(card);
        }


        //view all cards by SetName
        public IActionResult ViewSet(int id, int? page)
        {
            var setname = Convert.ToString(repo.GetCard(id).SetName);
            var cards = repo.GetSet(setname);
            // calculate page size
            int pageSize = 1000;
            // calculate total number of pages
            int totalItems = cards.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
            // Set the current page number
            int pageNumber = (page ?? 1);
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));
            // Retrieve the items for the current page
            var pagedItems = cards.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            // Pass the paginated items and pagination information to the view
            ViewBag.Items = pagedItems;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber;
            return View();
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
