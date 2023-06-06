using baseballcards.Models;
using System;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace baseballcards
{
    public class CardRepository : ICardRepository
    {
        private readonly IDbConnection _conn;

        public CardRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Cards> GetAllCards()
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards;");
        }
        public Cards GetCard(int id)
        {
            return _conn.QuerySingle<Cards>("SELECT * FROM cardcollection.cards WHERE CardID = @id", new { id = id });
        }
        public IEnumerable<Cards> GetSet(string setname)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE SetName = @setname", new { setname = setname });
        }
        public void UpdateCard(Cards card)
        {
            _conn.Execute("UPDATE cards SET TotalNumber = @totalnumber WHERE CardID = @id", new {totalnumber = card.TotalNumber, id = card.CardID });
        }
    }
}
