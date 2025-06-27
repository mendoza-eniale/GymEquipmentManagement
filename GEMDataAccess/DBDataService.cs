using System;
using System.Text;
using GEMCommon;
using Microsoft.Data.SqlClient;

namespace GEMDataAccess
{
    public class DBDataService : IGEMDataService
    {
        private static string connectionString =
            "Data Source=ELAINEJOY\\SQLEXPRESS;Initial Catalog=GymEquipmentManagement;Integrated Security=True;Persist Security Info=False";
        public void SetEquipmentData(EquipmentItem equip)
        {
            using var conn = new SqlConnection(connectionString);
            string query = "INSERT INTO equipmentList (ID, Name, Quantity, Status) VALUES (@ID, @Name, @Quantity, @Status)";
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ID", equip.Id);
            cmd.Parameters.AddWithValue("@Name", equip.Name);
            cmd.Parameters.AddWithValue("@Quantity", equip.Quantity);
            cmd.Parameters.AddWithValue("@Status", equip.Status);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void ReplaceEquipmentData(string newData)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var deleteCmd = new SqlCommand("DELETE FROM equipmentList", conn);
            deleteCmd.ExecuteNonQuery();

            var entries = newData.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in entries)
            {
                var lines = entry.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                var item = new EquipmentItem();

                foreach (var line in lines)
                {
                    if (line.StartsWith("ID:"))
                        item.Id = int.Parse(line.Replace("ID:", "").Trim());
                    else if (line.StartsWith("Name:"))
                        item.Name = line.Replace("Name:", "").Trim();
                    else if (line.StartsWith("Quantity:"))
                        item.Quantity = int.Parse(line.Replace("Quantity:", "").Trim());
                    else if (line.StartsWith("Status:"))
                        item.Status = line.Replace("Status:", "").Trim();
                }

                SetEquipmentData(item);
            }
        }
        public string SearchEquipment(int id)
        {
            var result = new StringBuilder();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT * FROM equipmentList WHERE ID = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result.AppendLine($"ID: {reader["ID"]}");
                                result.AppendLine($"Name: {reader["Name"]}");
                                result.AppendLine($"Quantity: {reader["Quantity"]}");
                                result.AppendLine($"Status: {reader["Status"]}");
                            }
                            return result.ToString().Trim();
                        }
                        else
                        {
                            return $"No equipment found with ID: {id}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error searching equipment: {ex.Message}";
            }
        }

        public string GetEquipmentData()
        {
            var result = new StringBuilder();

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM equipmentList", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.AppendLine($"ID: {reader["ID"]}");
                result.AppendLine($"Name: {reader["Name"]}");
                result.AppendLine($"Quantity: {reader["Quantity"]}");
                result.AppendLine($"Status: {reader["Status"]}");
                result.AppendLine();
            }

            return result.ToString().Trim();
        }

        public string GetHistoryData()
        {
            var result = new StringBuilder();

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var cmd = new SqlCommand("SELECT entry FROM history", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.AppendLine(reader.GetString(0));
            }

            return result.ToString().Trim();
        }

        public void SetHistoryData(string data)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var cmd = new SqlCommand("INSERT INTO history (entry) VALUES (@entry)", conn);
            cmd.Parameters.AddWithValue("@entry", data);

            cmd.ExecuteNonQuery();
        }
    }
}
