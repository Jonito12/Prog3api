using System;

namespace Negocio
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product() { }

       public Product(int id, string title, string description, string category, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            Price = price;

        } 
    }
}