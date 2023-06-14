using baseballcards.Models;
using System;
using System.Collections.Generic;

namespace baseballcards
{
    
    public interface ICardRepository
    {
        // Search cards
        public IEnumerable<Cards> SearchCard(string searchstring);
        // Give total count
        public int TotalCount(IEnumerable<Cards> cardList);
        // view all cards
        public IEnumerable<Cards> GetAllCards();
        // view one card at a time
        public Cards GetCard(int id);

        // GET groups of cards for View based on attribute
        public IEnumerable<Cards> GetSet(string setname);
        public IEnumerable<Cards> GetYear(string year);
        public IEnumerable<Cards> GetSubset(string subset);
        public IEnumerable<Cards> GetCardnumber(string cardnumber);
        public IEnumerable<Cards> GetFirstname(string firstname);
        public IEnumerable<Cards> GetLastname(string lastname);
        public IEnumerable<Cards> GetAutograph(string autograph);
        public IEnumerable<Cards> GetRelic(string relic);

        
        // update total amount of a card
        public void UpdateCard(Cards card);
    }
    
}
