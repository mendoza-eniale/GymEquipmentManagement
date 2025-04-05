
using System;

namespace GEMBusinessLogic { 
    public class GEMProcess{

        public int idCounter = 1;

        public string equipmentData = "", historyData = "";

        public void AddEquipment(string name, string status, int quantity){
            string entry = "ID: " + idCounter + "\nName: " + name + "\nStatus: " + status + "\nQuantity: " + quantity;
            equipmentData += entry + "\n";
            historyData += "Added: \n" + entry + "\n";
            idCounter++;
        }

        public void UpdateEquipment(int id, string newName, string newStatus, int newQuantity) {

            string newData = "";
            bool updated = false;
            string[] lines = equipmentData.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
            string entry = lines[i];
            if (entry.Length > 0)
            {
                if (entry.Contains("ID: " + id + ","))
                {
                    string updatedEntry = "ID: " + id + "\nName: " + newName + "\nStatus: " + newStatus + "\nQuantity: " + newQuantity;
                    newData += updatedEntry + "\n";
                    historyData += "Updated: " + entry + " → " + updatedEntry + "\n";
                    updated = true;
                }
                else
                {
                    newData += entry + "\n";
                }
            }
        }

            if (updated)
                equipmentData = newData;
            else
                historyData += "Update Failed: Equipment ID " + id + " not found.\n";
        }

        public bool DeleteEquipment(int id){

            string newData = "";
            bool deleted = false;
            int index = 0;

            while (index < equipmentData.Length){

            int entryStart = index;
            int entryEnd = equipmentData.IndexOf("ID: ", index + 1);
            if (entryEnd == -1)
                entryEnd = equipmentData.Length;

            string entry = equipmentData.Substring(entryStart, entryEnd - entryStart).Trim();

            int idIndex = entry.IndexOf("ID: ");
            if (idIndex != -1)
            {
                int newlineIndex = entry.IndexOf("\n", idIndex);
                string idText = "";

                for (int i = idIndex + 4; i < entry.Length && (entry[i] >= '0' && entry[i] <= '9'); i++)
                {
                    idText += entry[i];
                }

                if (idText == id.ToString())
                {
                    historyData += "Deleted:\n" + entry + "\n";
                    deleted = true;
                }
                else
                {
                    newData += entry + "\n";
                }
            }

            index = entryEnd;
            }

            if (deleted)
            {
                equipmentData = newData;
            }
            else
            {
                historyData += "Delete Failed: Equipment ID " + id + " not found.\n";
            }
            return deleted;
        }

        public string ViewEquipmentList(){
            return equipmentData.Length > 0 ? equipmentData : "No equipment available.";
        }

        public string ViewHistory() {
            return historyData.Length > 0 ? historyData : "No history available.";
        }
    }
}
