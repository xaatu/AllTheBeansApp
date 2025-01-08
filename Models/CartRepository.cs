using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace AllTheBeansApp.Models
{
    public class CartRepository
    {
        private const string FilePath = "cart.json";
        private readonly List<CartItem> _cartItems;

        public CartRepository()
        {
            _cartItems = LoadCartItems() ?? new List<CartItem>();
        }

        // Get all cart items
        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        // Add an item to the cart
        public void AddToCart(CartItem item)
        {
            Console.WriteLine($"Adding to cart: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
            var existingItem = _cartItems.Find(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _cartItems.Add(item);
            }
            SaveCartItems();
        }

        // Update an item in the cart
        public void UpdateCartItem(CartItem item)
        {
            Console.WriteLine($"Updating cart item: {item.Name}, Quantity: {item.Quantity}");
            var existingItem = _cartItems.Find(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
            }
            SaveCartItems();
        }

        // Remove an item from the cart
        public void RemoveFromCart(string itemName)
        {
            Console.WriteLine($"Removing from cart: {itemName}");
            _cartItems.RemoveAll(i => i.Name == itemName);
            SaveCartItems();
        }

        // Load cart items from JSON file
        private static List<CartItem> LoadCartItems()
        {
            if (!File.Exists(FilePath))
            {
                return new List<CartItem>();
            }
            var jsonData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<CartItem>>(jsonData) ?? new List<CartItem>();
        }

        // Save cart items to JSON file
        private void SaveCartItems()
        {
            var jsonData = JsonConvert.SerializeObject(_cartItems, Formatting.Indented);
            File.WriteAllText(FilePath, jsonData);
            Console.WriteLine("Cart items saved to cart.json");
        }
    }

    public class CartItem
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
