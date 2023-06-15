using baseballcards.Models;
using System;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.Ocsp;

namespace baseballcards
{
    public class CardRepository : ICardRepository
    {
        private readonly IDbConnection _conn;

        public CardRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        // Card search
        public IEnumerable<Cards> SearchCard(string searchString)
        {
            searchString = $"%{searchString}%";
            return _conn.Query<Cards>("SELECT * FROM cardcollection.cards WHERE SetName LIKE @searchString OR Year LIKE @searchString OR Subset LIKE @searchString OR Cardnumber LIKE @searchString OR Firstname LIKE @searchString OR Lastname LIKE @searchString OR Info LIKE @searchString OR SerialNumber LIKE @searchString OR Autograph LIKE @searchString OR Relic LIKE @searchString", new { searchString = searchString });
        }

        // returns total number of cards
        public int TotalCount(IEnumerable<Cards> cardList)
        {
            var count = 0;
            foreach (var card in cardList) { count += card.TotalNumber; }
            return count; 
        }

        // returns unique instance of card (individual count, not duplicates)
        public int UniqueCount(IEnumerable<Cards> cardList)
        {
            var count = 0;
            foreach (var card in cardList) { count++; }
            return count;
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

        public void InsertCard(Cards cardToInsert)
        {
            _conn.Execute("INSERT INTO cardcollection.cards (SetName, Year, Subset, Cardnumber, Firstname, Lastname, TotalNumber, Info, SerialNumber, Autograph, Relic) " +
                "VALUES (@SetName, @Year, @Subset, @Cardnumber, @Firstname, @Lastname, @TotalNumber, @Info, @SerialNumber, @Autograph, @Relic);", 
                new { SetName = cardToInsert.SetName, Year = cardToInsert.Year, Subset = cardToInsert.Subset, Cardnumber = cardToInsert.Cardnumber, Firstname = cardToInsert.Firstname,
                Lastname = cardToInsert.Lastname, TotalNumber = cardToInsert.TotalNumber, Info = cardToInsert.Info, SerialNumber = cardToInsert.SerialNumber,
                Autograph = cardToInsert.Autograph, Relic = cardToInsert.Relic });
        }

        public void DeleteCard(Cards cards)
        {
            _conn.Execute("DELETE FROM cardcollection.cards WHERE CardID = @id", new { id = cards.CardID });
        }
    }
}
