// add food item
// name
// category
// quantity
// expiration date
// delete food item
// pring list of current food items
// exit the program

using Mission3;
using System;


string action = "";


List<FoodBankTools> Items = new List<FoodBankTools>();


System.Console.WriteLine("Welcome to the food bank!");

do {
    System.Console.WriteLine("");
    System.Console.WriteLine("What would you like to do?");
    System.Console.WriteLine("");
    System.Console.WriteLine("Type \"Add\" to add an item.");
    System.Console.WriteLine("Type \"Delete\" to delete an item.");
    System.Console.WriteLine("Type \"List\" to list all items.");
    System.Console.WriteLine("Type \"Exit\" to leave the program.");
    System.Console.WriteLine("");

    action = System.Console.ReadLine().ToLower();

    // add a food item
    if (action == "add")
    {
        string itemName = "";
        string itemCategory = "";
        int itemqty = 0;
        DateTime expirationDate;

        System.Console.WriteLine("");
        System.Console.WriteLine("You've selected \"Add\" an item.");

        // item
        System.Console.WriteLine("What is the name of the item you would like to add?");
        itemName = System.Console.ReadLine();

        // category
        System.Console.WriteLine("What is the category of the item you would like to add?");
        itemCategory = System.Console.ReadLine();

        // quantity
        System.Console.WriteLine("How many of the item is being added?");
        while (!int.TryParse(System.Console.ReadLine(), out itemqty) || itemqty <= 0)
        {
            System.Console.WriteLine("Please enter a valid number for the quantity.");
        }

        // expiration date
        System.Console.WriteLine("What is the item expiration date? (YYYY-MM-DD)");
        while (!DateTime.TryParse(System.Console.ReadLine(), out expirationDate))
        {
            System.Console.WriteLine("Please enter a valid date (YYYY-MM-DD).");
        }

        // Add item to the list
        Items.Add(new FoodBankTools
        {
            ItemName = itemName,
            ItemCategory = itemCategory,
            Quantity = itemqty,
            ExpirationDate = expirationDate
        });

        System.Console.WriteLine("Item added successfully!");


    }
    // delete a food item
    else if (action == "delete")
    {
        string nameToDelete = "";

        System.Console.WriteLine("");
        System.Console.WriteLine("Enter the name of the item you'd like to delete:");
        System.Console.WriteLine("");

        nameToDelete = System.Console.ReadLine();

        // search for selected food name to see if we should remove it
        FoodBankTools itemToRemove = Items.Find(item => item.ItemName.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

        if (itemToRemove != null)
        {
            Items.Remove(itemToRemove);
            System.Console.WriteLine("Item removed successfully.");
        }
        else
        {
            System.Console.WriteLine("Item not found.");
        }

    }
    // list all items
    else if (action == "list")
    {
        System.Console.WriteLine("");
        System.Console.WriteLine("Listing all items!");
        System.Console.WriteLine("");

        // don't list if there aren't items, otherwise list them
        if(Items.Count == 0)
        {
            System.Console.WriteLine("No items in the food bank!");
        }
        else
        {
            System.Console.WriteLine("Food Bank Inventory:");
            foreach (var item in Items)
            {
                System.Console.WriteLine($"Name: {item.ItemName}, Category: {item.ItemCategory}, Quantity: {item.Quantity}, Expiration: {item.ExpirationDate}");
            }
        }

    }
    // message for exiting the food bank
    else if (action == "exit")
    {
        System.Console.WriteLine("Thank you for visiting the food bank!");
        System.Console.WriteLine("Goodbye!");
    }
    // error handling if they don't have a valid action
    else
    {
        System.Console.WriteLine(action + " is not a valid response.");
        System.Console.WriteLine("Try Again!");
    }

// exit the loop if they have typed exit
} while (action != "exit");