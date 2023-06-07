using baseballcards.Models;
using System;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.X509;

namespace baseballcards
{
    public class CardRepository : ICardRepository
    {
        private readonly IDbConnection _conn;

        public CardRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        // THIS IS NOT READY TO BE USED
        public int TotalCount()
        {
            return Convert.ToInt32(_conn.Query<Cards>("SELECT sum(TotalNumber) FROM cardcollection.cards;"));
        }

        public IEnumerable<Cards> GetAllCards()
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards;");
        }
        public Cards GetCard(int id)
        {
            return _conn.QuerySingle<Cards>("SELECT * FROM cardcollection.cards WHERE CardID = @id", new { id = id });
        }
        
        // Get specific attribute displayed group
        public IEnumerable<Cards> GetSet(string setname)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE SetName = @setname", new { setname = setname });
        }
        public IEnumerable<Cards> GetYear(string year)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE Year = @year", new { year = year });
        }
        public IEnumerable<Cards> GetSubset(string subset)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE Subset = @subset", new { subset = subset });
        }
        public IEnumerable<Cards> GetCardnumber(string cardnumber)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE Cardnumber = @cardnumber", new { cardnumber = cardnumber });
        }
        public IEnumerable<Cards> GetFirstname(string firstname)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE Firstname = @firstname", new { firstname = firstname });
        }
        public IEnumerable<Cards> GetLastname(string lastname)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE Lastname = @lastname", new { lastname = lastname });
        }
        public IEnumerable<Cards> GetAutograph(string autograph)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE Autograph = @autograph", new { autograph = autograph });
        }
        public IEnumerable<Cards> GetRelic(string relic)
        {
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE Relic = @relic", new { relic = relic });
        }

        public void UpdateCard(Cards card)
        {
            _conn.Execute("UPDATE cards SET TotalNumber = @totalnumber WHERE CardID = @id", new {totalnumber = card.TotalNumber, id = card.CardID });
        }
    }
}
