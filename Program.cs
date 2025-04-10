﻿
using GEMBusinessLogic;

namespace GymEquipmentManagement{
    class Program {

        static GEMActions actions = new GEMActions();
        static Login login = new Login();

        static void Main(){

            bool LoggedIn = false;

            while (!LoggedIn){
                Console.WriteLine("======== LOG IN ========\n");
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                LoggedIn = login.LogIn(username, password);
               
                if (!LoggedIn){
                    Console.WriteLine("\nInvalid username or password.\n\n");
                }
                else
                {
                    Console.WriteLine("\nLogin successful!\n");
                }
            }

            while (true) {
            Console.WriteLine("\n===== GYM EQUIPMENT MANAGEMENT =====");
            Console.WriteLine("1. Add Equipment");
            Console.WriteLine("2. Update Equipment");
            Console.WriteLine("3. Delete Equipment");
            Console.WriteLine("4. View Equipment List");
            Console.WriteLine("5. View History");
            Console.WriteLine("6. Search Equipment");
            Console.WriteLine("7. Exit");
                Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice)){
                Console.WriteLine("Invalid choice! Please enter a number.");
                continue;
            }

            switch (choice){
                case "1": AddEquipment();
                        break;
                case "2": UpdateEquipment();
                        break;
                case "3": DeleteEquipment(); 
                        break;
                case "4": ViewEquipmentList(); 
                        break;
                case "5": ViewHistory(); 
                        break;
                case "6": SearchEquipment();
                        break;
                    case "7": return;
                default: Console.WriteLine("Invalid choice! Try again."); 
                        break;
            }
            }
        }

        static void AddEquipment(){

            Console.Write("Enter Equipment Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Status (Working/Needs Repair): ");
            string status = Console.ReadLine();

            string statusLower = status.ToLower();
            if (statusLower == "working")
            {
                status = "Working";
            }
            else if (statusLower == "needs repair")
            {
                status = "Needs Repair";
            }
            else
            {
                Console.WriteLine("Invalid status! Enter 'Working' or 'Needs Repair'.");
                return;
            }

            Console.Write("Enter Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
            {
                actions.AddEquipment(name, status, quantity);
                Console.WriteLine("Equipment added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid quantity! Enter a positive number.");
            }
        }

        static void UpdateEquipment() {
           
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

            string statusLower = newStatus.ToLower();
            if (statusLower != "working")
            {
                newStatus = "Working";

            }
            else if (statusLower == "needs repair")
            {
                newStatus = "Needs Repair";
            }
            else
            {
                Console.WriteLine("Invalid status! Enter 'Working' or 'Needs Repair'.");
                return;
            }

            Console.Write("Enter New Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int newQuantity) && newQuantity > 0)
            {
                actions.UpdateEquipment(id, newName, newStatus, newQuantity);
                Console.WriteLine("Equipment updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid quantity! Enter a positive number.");
            }
           
        }

        static void DeleteEquipment(){
            Console.Write("Enter Equipment ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID! Enter a valid number.");
                return;
            }

            bool deleted = actions.DeleteEquipment(id);
            if (deleted)
            {
                Console.WriteLine("Equipment deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete. Equipment ID not found.");
            }
           
        }

        static void SearchEquipment() {

            Console.Write("Enter Equipment ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID! Enter a valid number.");
                return;
            }

            string result = actions.SearchEquipment(id);
            Console.WriteLine("\n===== SEARCH RESULT =====\n");
            Console.WriteLine(result);
        }

       
        static void ViewEquipmentList() {

            Console.WriteLine("\n===== Equipment List =====");
            string equipmentList = actions.ViewEquipmentList();
            Console.WriteLine(equipmentList);
            
        }

        static void ViewHistory() {
            Console.WriteLine("\n===== History =====");
            string history = actions.ViewHistory();
            Console.WriteLine(history);
           
        }
    }
}
