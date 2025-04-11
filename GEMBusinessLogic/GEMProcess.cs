using System;
using GEMDataAccess;

namespace GEMBusinessLogic
{
    public class GEMProcess
    {
        private EquipStorage storage;
        private int idCounter = 1;

        public GEMProcess()
        {
            storage = new EquipStorage();

            AddEquipment("Treadmill", "Working", 5);
            AddEquipment("Dumbbell", "Working", 20);
            AddEquipment("Bench Press", "Needs Repair", 3);
            AddEquipment("Stationary Bike", "Working", 4);
            AddEquipment("Rowing Machine", "Needs Repair", 2); 
            AddEquipment("Pull-up Bar", "Working", 6);
            AddEquipment("Leg Press", "Needs Repair", 2);
            AddEquipment("Elliptical Trainer", "Working", 3);
        }

        
        public bool LogIn(string username, string password)
        {
            if (username == "admin" && password == "123456")
            {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                    return false;
                }
            }
           

        public void AddEquipment(string name, string status, int quantity)
        {
            string entry = "ID: " + idCounter + "\nName: " + name + "\nStatus: " + status + "\nQuantity: " + quantity;
            storage.SetEquipmentData(storage.GetEquipmentData() + entry + "\n");
            storage.SetHistoryData(storage.GetHistoryData() + "Added: \n" + entry + "\n");
            idCounter++;
        }

        public void UpdateEquipment(int id, string newName, string newStatus, int newQuantity)
        {
            string data = storage.GetEquipmentData();
            string[] newEntries = data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string newData = "";
            bool updated = true;

            for (int i = 0; i < newEntries.Length; i++)
            {
                string entry = newEntries[i];
                if (newEntries[i].StartsWith("ID: " + id))
                {

                    string oldEntry = newEntries[i] + "\n" + newEntries[i + 1] + "\n" + newEntries[i + 2] + "\n" + newEntries[i + 3];
                    string updatedEntry = "ID: " + id + "\nName: " + newName + "\nStatus: " + newStatus + "\nQuantity: " + newQuantity;

                    newData += updatedEntry + "\n";
                    storage.SetHistoryData(storage.GetHistoryData() + ("Updated: " + entry + " → " + updatedEntry + "\n"));

                    i += 3;

                    updated = true;
                }
                else
                {
                    newData += newEntries[i] + "\n\n";
                }
            }
            if (updated)
            {
                storage.ReplaceEquipmentData(newData);
            }
            else
            {
                storage.SetHistoryData(storage.GetHistoryData() + "Update Failed: Equipment ID " + id + " not found.\n");
            }
        }
        public bool DeleteEquipment(int id)
        {
            string equipmentData = storage.GetEquipmentData();
            string[] entries = equipmentData.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string newData = "";
            bool deleted = false;


            foreach (string entry in entries)
            {
                if (entry.Contains("ID: " + id))
                {
                    storage.SetHistoryData(storage.GetHistoryData() + "Deleted: " + entry + "\n");
                    deleted = true;
                }
                else
                {
                    newData += entry + "\n";
                }
            }
            if (deleted)
            {
                storage.ReplaceEquipmentData(newData);
            }
            else
            {
                storage.SetHistoryData(storage.GetHistoryData() + "Delete Failed: Equipment ID " + id + " not found.\n");
            }
            return deleted;
        }

        public string SearchEquipment(int ID)
        {
            string[] entries = storage.GetEquipmentData().Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string results = "";
            bool matchFound = false;

            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].StartsWith("ID: " + ID))
                {
                    matchFound = true;
                    results += entries[i] + "\n" + entries[i + 1] + "\n" + entries[i + 2] + "\n" + entries[i + 3] + "\n";
                    break; 
                }
            }

            return matchFound ? results : "No equipment found with ID: " + ID;
        }

       
        public string ViewEquipmentList()
        {
            string data = storage.GetEquipmentData();
            return string.IsNullOrWhiteSpace(data) ? "No equipment available." : data;
        }

        public string ViewHistory()
        {
            string data = storage.GetHistoryData();
            return string.IsNullOrWhiteSpace(data) ? "No history available." : data;
        }
    }
}