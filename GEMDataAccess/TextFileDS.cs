

using GEMCommon;
using System.Text;

namespace GEMDataAccess
{
    public class TextFileDataService : IGEMDataService
    {
        private readonly string equipmentFile = "equipment.txt";
        private readonly string historyFile = "history.txt";

        public bool LogIn(string inputUsername, string inputPassword)
        {
            return inputUsername == "admin" && inputPassword == "123456";
        }
        public string GetEquipmentData()
        {
            return File.Exists(equipmentFile) ? File.ReadAllText(equipmentFile) : "\n\n";
        }

        public string GetHistoryData()
        {
            return File.Exists(historyFile) ? File.ReadAllText(historyFile) : "\n\n";
        }

        public void SetEquipmentData(EquipmentItem equip)
        {
            File.AppendAllText(equipmentFile, equip + "\n\n");
        }


        public void SetHistoryData(string data)
        {
            File.AppendAllText(historyFile, data + "\n\n");
        }
        public void ReplaceEquipmentData(string newData)
        {
            File.WriteAllText(equipmentFile, newData);
        }
        public string SearchEquipment(int id)
        {
            if (!File.Exists(equipmentFile))
            {
                return $"No equipment found with ID: {id}";
            }

            var lines = File.ReadAllLines(equipmentFile);
            var equipmentData = new StringBuilder();
            bool found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith($"ID: {id}"))
                {
                    found = true;
                    equipmentData.AppendLine(lines[i]);
                    while (i < lines.Length && !string.IsNullOrWhiteSpace(lines[i]))
                    {
                        equipmentData.AppendLine(lines[i]);
                        i++;
                    }
                    break;
                }
            }

            return found ? equipmentData.ToString().Trim() : $"No equipment found with ID: {id}";
        }


    }
}