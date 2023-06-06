using baseballcards.Models;
using System;
using System.Collections.Generic;

namespace baseballcards
{
    
    public interface ICardRepository
    {
        // view all cards
        public IEnumerable<Cards> GetAllCards();
        // view one card at a time
        public Cards GetCard(int id);
        public IEnumerable<Cards> GetSet(string setname);
        // update total amount of a card
        public void UpdateCard(Cards card);
    }
    
}
