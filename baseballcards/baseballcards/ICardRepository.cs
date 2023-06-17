using baseballcards.Models;
using System;
using System.Collections.Generic;

namespace baseballcards
{
    
    public interface ICardRepository
    {
        // Search cards (complex)
        public IEnumerable<Cards> ComplexSearch(string setName, string year, string subset, string cardnumber, string firstname, string lastname, string info, string serialNumber, string autograph, string relic);
        // Search cards (simple)
        public IEnumerable<Cards> SearchCard(string searchstring);
        // Give total count
        public int TotalCount(IEnumerable<Cards> cardList);
        // Unique total cards
        public int UniqueCount(IEnumerable<Cards> cardList);
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

        // insert a new card into the database
        public void InsertCard(Cards cards);

        // delete a card from the database
        public void DeleteCard(Cards cards);
    }
    
}
