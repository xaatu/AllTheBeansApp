namespace AllTheBeansApp.Models
{           

    public class Bean
    {
        public required string Name { get; set; }
        public double CostPer100g { get; set; }
        public required string Aroma { get; set; }
        public required string Colour { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }
        public required string ImageUrl { get; set; }
    }
}
