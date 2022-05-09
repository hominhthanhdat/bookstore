using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? Author { get; set; }
        public DateTime? Created { get; set; }
    }
}
