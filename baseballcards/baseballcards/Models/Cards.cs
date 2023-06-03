using System;
using System.Collections.Generic;

namespace baseballcards.Models
{
    public class Cards
    {
        public Cards() { }
        public string SetName { get; set; } = "";
        public string Year { get; set; } = "";
        public string Subset { get; set; } = "";
        public string Cardnumber { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public int TotalNumber { get; set; }
        public string Info { get; set; } = "";
        public string SerialNumber { get; set; } = "";
        public string Autograph { get; set; } = "";
        public string Relic { get; set; } = "";
    }
}
