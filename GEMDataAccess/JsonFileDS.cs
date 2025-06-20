using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GEMDataAccess
{
    public class JsonFileDataService : IGEMDataService
    {
        private readonly string equipmentFile = "equipment.json";
        private readonly string historyFile = "history.json";

        public JsonFileDataService()
        {
            // Ensure files exist with empty lists when service is created
            InitializeFiles();
        }

        private void InitializeFiles()
        {
            if (!File.Exists(equipmentFile))
            {
                SaveList(equipmentFile, new List<EquipmentItem>());
            }
            if (!File.Exists(historyFile))
            {
                SaveList(historyFile, new List<string>());
            }
        }

        private List<EquipmentItem> LoadEquipmentList()
        {
            try
            {
                if (File.Exists(equipmentFile))
                {
                    string content = File.ReadAllText(equipmentFile);
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        return JsonSerializer.Deserialize<List<EquipmentItem>>(content) ?? new List<EquipmentItem>();
                    }
                }
                return new List<EquipmentItem>();
            }
            catch (Exception ex) when (ex is JsonException || ex is IOException)
            {
                Console.WriteLine($"Error loading equipment data: {ex.Message}");
                return new List<EquipmentItem>();
            }
        }

        private List<string> LoadHistoryList()
        {
            try
            {
                if (File.Exists(historyFile))
                {
                    string content = File.ReadAllText(historyFile);
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        return JsonSerializer.Deserialize<List<string>>(content) ?? new List<string>();
                    }
                }
                return new List<string>();
            }
            catch (Exception ex) when (ex is JsonException || ex is IOException)
            {
                Console.WriteLine($"Error loading history data: {ex.Message}");
                return new List<string>();
            }
        }

        private void SaveList<T>(string file, List<T> list)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string json = JsonSerializer.Serialize(list, options);
                File.WriteAllText(file, json);
            }
            catch (Exception ex) when (ex is JsonException || ex is IOException)
            {
                Console.WriteLine($"Error saving to {file}: {ex.Message}");
                throw;
            }
        }

        public string GetEquipmentData()
        {
            var equipmentList = LoadEquipmentList();
            return string.Join(Environment.NewLine + Environment.NewLine, equipmentList);
        }

        public string GetHistoryData()
        {
            var historyList = LoadHistoryList();
            return string.Join(Environment.NewLine, historyList);
        }

        public void SetEquipmentData(EquipmentItem item)
        {
            var list = LoadEquipmentList();
            list.Add(item);
            SaveList(equipmentFile, list);
        }

        public void SetHistoryData(string data)
        {
            var list = LoadHistoryList();
            list.Add(data);
            SaveList(historyFile, list);
        }

        public void ReplaceEquipmentData(List<EquipmentItem> newData)
        {
            if (newData == null)
            {
                throw new ArgumentNullException(nameof(newData));
            }
            SaveList(equipmentFile, newData);
        }

        public void DeleteEquipment(int id)
        {
            var list = LoadEquipmentList();
            list.RemoveAll(item => item.Id == id);
            SaveList(equipmentFile, list);
        }

        public EquipmentItem SearchEquipment(int id)
        {
            var list = LoadEquipmentList();
            return list.Find(item => item.Id == id);
        }

        public void SetEquipmentData(string data)
        {
        }

        public void ReplaceEquipmentData(string newData)
        {
        }
    }

    public class EquipmentItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nStatus: {Status}\nQuantity: {Quantity}";
        }
    }
}
