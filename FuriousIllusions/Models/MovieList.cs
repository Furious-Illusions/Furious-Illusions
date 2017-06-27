using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuriousIllusions.Models
{
    public class MovieList
    {

        public Movie[] Movie { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Kijkwijzer { get; set; }
        public string PublicationYear { get; set; }
        public string Actors { get; set; }
        public string Trailer { get; set; }
    }

    
}