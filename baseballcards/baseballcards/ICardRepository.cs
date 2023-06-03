using baseballcards.Models;
using System;
using System.Collections.Generic;

namespace baseballcards
{
    public interface ICardRepository
    {
        public IEnumerable<Cards> GetAllCards();
    }
}
