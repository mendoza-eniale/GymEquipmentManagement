using System;
using GEMBusinessLogic;

namespace GymEquipmentManagement
{
    class Program
    {
        static GEMProcess gemProcess = new GEMProcess();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n===== GYM EQUIPMENT MANAGEMENT =====");
                Console.WriteLine("1. Add Equipment");
                Console.WriteLine("2. Update Equipment");
                Console.WriteLine("3. Delete Equipment");
                Console.WriteLine("4. View Equipment List");
                Console.WriteLine("5. View History");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Invalid choice! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case "1": AddEquipment(); break;
                    case "2": UpdateEquipment(); break;
                    case "3": DeleteEquipment(); break;
                    case "4": ViewEquipmentList(); break;
                    case "5": ViewHistory(); break;
                    case "6": return;
                    default: Console.WriteLine("Invalid choice! Try again."); break;
                }
            }
        }

        static void AddEquipment()
        {
            Console.Write("Enter Equipment Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Status (Working/Needs Repair): ");
            string status = Console.ReadLine();
            if (status != "Working" && status != "Needs Repair")
            {
                Console.WriteLine("Invalid status! Enter 'Working' or 'Needs Repair'.");
                return;
            }

            Console.Write("Enter Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
            {
                gemProcess.AddEquipment(name, status, quantity);
                Console.WriteLine("Equipment added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid quantity! Enter a positive number.");
            }
            Console.ReadKey();
        }

        static void UpdateEquipment()
        {
            Console.Write("Enter Equipment ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID! Enter a valid number.");
                return;
            }

            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter New Status (Working/Needs Repair): ");
            string newStatus = Console.ReadLine();
            if (newStatus != "Working" && newStatus != "Needs Repair")
            {
                Console.WriteLine("Invalid status! Enter 'Working' or 'Needs Repair'.");
                return;
            }

            Console.Write("Enter New Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int newQuantity) && newQuantity > 0)
            {
                gemProcess.UpdateEquipment(id, newName, newStatus, newQuantity);
                Console.WriteLine("Equipment updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid quantity! Enter a positive number.");
            }
            Console.ReadKey();
        }

        static void DeleteEquipment()
        {
            Console.Write("Enter Equipment ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID! Enter a valid number.");
                return;
            }

            bool deleted = gemProcess.DeleteEquipment(id);
            if (deleted)
                Console.WriteLine("Equipment deleted successfully!");
            else
                Console.WriteLine("Failed to delete. Equipment ID not found.");

            Console.ReadKey();
        }

        static void ViewEquipmentList()
        {
            Console.WriteLine("\n===== Equipment List =====");
            string equipmentList = gemProcess.ViewEquipmentList();
            Console.WriteLine(equipmentList);
            Console.ReadKey();
        }

        static void ViewHistory()
        {
            Console.WriteLine("\n===== History =====");
            string history = gemProcess.ViewHistory();
            Console.WriteLine(history);
            Console.ReadKey();
        }
    }
}
