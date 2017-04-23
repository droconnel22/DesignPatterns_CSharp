using System;

namespace CodeWars.CSharp.GenericCollections.BuildingGenericCode
{
    class Product
    {
        public int ProductId { get; }

        public string ProductName { get; }

        public string Description { get; }

        public decimal Cost { get; set; }


        public Product()
        {
            string[] colorOptions = {"Red", "Espresso", "White"};

            var brownIndex = Array.IndexOf(colorOptions, "Expresso");

            colorOptions.SetValue("Blue",3);
            for (int i = 0; i < colorOptions.Length; i++)
            {
                colorOptions[i] = colorOptions[i].ToLower();
            }

            foreach (var color in colorOptions)
            {
                Console.WriteLine($"The color is {color}");
            }   
        }

        public Product(int productId, string productName, string description):this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }

        public decimal CalculateSuggestedPrice(decimal markupPrecent) => this.Cost + (this.Cost*markupPrecent/100);

        public override string ToString() => this.ProductName + " (" + this.ProductId + ")";
    }
}