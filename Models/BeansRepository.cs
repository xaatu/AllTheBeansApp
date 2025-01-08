// Newtonsoft.Json used to handle JSON file - I originally tried System.Text.Json, as many people online were recommending, but ran into issues.
using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AllTheBeansApp.Models
{
    public class BeansRepository
    {
        private const string FilePath = "beans.json";
        private readonly List<Bean> _beans;

        public BeansRepository()
        {
            _beans = LoadBeans() ?? new List<Bean>();
        }

        // Get all beans
        public List<Bean> GetAllBeans()
        {
            return _beans;
        }

        // Get bean of the day
        public Bean GetBeanOfTheDay(DayOfWeek day)
        {
            return _beans.FirstOrDefault(b => b.DayOfTheWeek == day) ?? throw new InvalidOperationException("Bean of the day not found.");
        }

        public decimal GetBeanPrice(string beanName)
        {
            var bean = _beans.FirstOrDefault(b => b.Name == beanName);
            return (decimal)(bean?.CostPer100g ?? 0);
        }

        public decimal GetBeanCostPer100g(string beanName)
        {
            var bean = _beans.FirstOrDefault(b => b.Name == beanName);
            return (decimal)(bean?.CostPer100g ?? 0);
        }

        // JSON Deserialising - Reads file and converts to my Bean object
        private static List<Bean> LoadBeans()
        {
            var jsonData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Bean>>(jsonData) ?? new List<Bean>();
        }

        // JSON Serialisation - Converts list of Bean object to JSON format then writes to file.
        private void SaveBeans()
        {
            var jsonData = JsonConvert.SerializeObject(_beans, Formatting.Indented);
            File.WriteAllText(FilePath, jsonData);
        }
    }
}
