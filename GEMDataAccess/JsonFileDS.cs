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

        private List<string> LoadList(string file)
        {
            if (File.Exists(file))
            {
                string content = File.ReadAllText(file);
                List<string> result = JsonSerializer.Deserialize<List<string>>(content);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new List<string>();
                }
            }
            else
            {
                return new List<string>();
            }
        }

        private void SaveList(string file, List<string> list)
        {
            File.WriteAllText(file, JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true }));
        }
        public string GetEquipmentData() => string.Join("\n\n", LoadList(equipmentFile));
        public string GetHistoryData() => string.Join("\n", LoadList(historyFile));

        public void SetEquipmentData(string data)
        {
            var list = LoadList(equipmentFile);
            list.Add(data);
            SaveList(equipmentFile, list);
        }

        public void SetHistoryData(string data)
        {
            var list = LoadList(historyFile);
            list.Add(data);
            SaveList(historyFile, list);
        }

        public void ReplaceEquipmentData(string newData)
        {
            var list = newData.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            SaveList(equipmentFile, new List<string>(list));
        }
    }
}
