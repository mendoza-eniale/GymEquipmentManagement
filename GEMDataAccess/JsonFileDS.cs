
﻿
using System.Text.Json;
using GEMCommon;

namespace GEMDataAccess
{
    public class JsonFileDataService : IGEMDataService
    {
        private readonly string equipmentFile = "equipment.json";
        private readonly string historyFile = "history.json";

        public JsonFileDataService()
        {
            ReadJsonDataFromFile();
        }

        public bool LogIn(string inputUsername, string inputPassword)
        {
            return inputUsername == "admin" && inputPassword == "123456";
        }
        private void ReadJsonDataFromFile()
        {
            if (!File.Exists(equipmentFile))
                SaveList(equipmentFile, new List<EquipmentItem>());

            if (!File.Exists(historyFile))
                SaveList(historyFile, new List<string>());
        }

        private List<EquipmentItem> LoadEquipmentList()
        {
            try
            {
                var content = File.ReadAllText(equipmentFile);
                return string.IsNullOrWhiteSpace(content)
                    ? new List<EquipmentItem>()
                    : JsonSerializer.Deserialize<List<EquipmentItem>>(content) ?? new List<EquipmentItem>();
            }
            catch
            {
                return new List<EquipmentItem>();
            }
        }

        private List<string> LoadHistoryList()
        {
            try
            {
                var content = File.ReadAllText(historyFile);
                return string.IsNullOrWhiteSpace(content)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(content) ?? new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        private void SaveList<T>(string file, List<T> list)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(file, JsonSerializer.Serialize(list, options));
        }

        public string GetEquipmentData()
        {
            var list = LoadEquipmentList();
            return list.Count == 0 ? "" : string.Join("\n\n", list);
        }

        public string GetHistoryData()
        {
            var list = LoadHistoryList();
            return list.Count == 0 ? "" : string.Join("\n", list);
        }

        public void SetEquipmentData(EquipmentItem equip)
        {
            var list = LoadEquipmentList();
            list.Add(equip);
            SaveList(equipmentFile, list);
        }

        public void SetHistoryData(string data)
        {
            var list = LoadHistoryList();
            list.Add(data);
            SaveList(historyFile, list);
        }

        public string SearchEquipment(int id)
        {
            var list = LoadEquipmentList();
            var equipment = list.FirstOrDefault(e => e.Id == id);
            return equipment != null ? equipment.ToString() : $"No equipment found with ID: {id}";
        }

        public void ReplaceEquipmentData(string newData)
        {
            var entries = newData.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
            var newList = new List<EquipmentItem>();
            foreach (var entry in entries)
            {
                var lines = entry.Split('\n');
                var item = new EquipmentItem();
                foreach (var line in lines)
                {
                    if (line.StartsWith("ID: ")) item.Id = int.Parse(line[4..]);
                    else if (line.StartsWith("\nName: ")) item.Name = line[6..].Trim();
                    else if (line.StartsWith("\nStatus: ")) item.Status = line[8..].Trim();
                    else if (line.StartsWith("\nQuantity: \n\n")) item.Quantity = int.Parse(line[10..]);
                }
                newList.Add(item);
            }
            SaveList(equipmentFile, newList);
        }
    }
}