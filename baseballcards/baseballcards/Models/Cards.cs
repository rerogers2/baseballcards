using System;
using System.Collections.Generic;

namespace baseballcards.Models
{
    public class Cards
    {
        public Cards() { }
        public string SetName { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Subset { get; set; } = string.Empty;
        public string Cardnumber { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public int TotalNumber { get; set; }
        public string Info { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Autograph { get; set; } = string.Empty;
        public string Relic { get; set; } = string.Empty;
        public int CardID { get; set; }
    }
}
