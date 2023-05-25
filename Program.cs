using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Item> inventory = new List<Item>();
        inventory.Add(new Item("Aspirin", 2.99, 100));
        inventory.Add(new Item("Ibuprofen", 4.99, 50));
        inventory.Add(new Item("Vitamin C", 6.99, 30));

        string menuOption = "";
        while (menuOption != "4")
        {
            Console.WriteLine("Welcome to the pharmacy:");
            Console.WriteLine("1. View inventory");
            Console.WriteLine("2. Buy item");
            Console.WriteLine("3. Sell item");
            Console.WriteLine("4. Exit");

            menuOption = Console.ReadLine();
            switch (menuOption)
            {
                case "1":
                    ViewInventory(inventory);
                    break;
                case "2":
                    BuyItem(inventory);
                    break;
                case "3":
                    SellItem(inventory);
                    break;
                case "4":
                    Console.WriteLine("Thank you for visiting the pharmacy!");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    static void ViewInventory(List<Item> inventory)
    {
        Console.WriteLine("Current inventory:");
        foreach (Item item in inventory)
        {
            Console.WriteLine("{0} - {1} - {2} in stock", item.Name, item.Price, item.Quantity);
        }
    }

    static void BuyItem(List<Item> inventory)
    {
        Console.WriteLine("Enter the name of the item you want to buy:");
        string itemName = Console.ReadLine();
        Item item = FindItem(inventory, itemName);

        if (item != null)
        {
            Console.WriteLine("Enter the quantity you want to buy:");
            int quantity = int.Parse(Console.ReadLine());
            if (item.Quantity >= quantity)
            {
                double totalCost = item.Price * quantity;
                Console.WriteLine("Total cost: ${0}", totalCost);
                item.Quantity -= quantity;
            }
            else
            {
                Console.WriteLine("Sorry, we don't have enough {0} in stock.", itemName);
            }
        }
        else
        {
            Console.WriteLine("Sorry, we don't carry {0}.", itemName);
        }
    }

    static void SellItem(List<Item> inventory)
    {
        Console.WriteLine("Enter the name of the item you want to sell:");
        string itemName = Console.ReadLine();
        Item item = FindItem(inventory, itemName);

        if (item != null)
        {
            Console.WriteLine("Enter the quantity you want to buy:");
            int quantity = int.Parse(Console.ReadLine());
            if (item.Quantity >= quantity)
            {
                double totalCost = item.Price * quantity;
                Console.WriteLine("Total cost: ${0}", totalCost);
                item.Quantity -= quantity;
            }
            else
            {
                Console.WriteLine("Sorry, we don't have enough {0} in stock.", itemName);
            }
        }
    }

    static Item FindItem(List<Item> inventory, string itemName)
    {
        foreach (Item item in inventory)
        {
            if (item.Name.ToLower() == itemName.ToLower())
            {
                return item;
            }
        }
        return null;
    }
}

class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Item(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}