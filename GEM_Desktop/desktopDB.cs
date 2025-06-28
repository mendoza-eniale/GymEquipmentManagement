using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;


namespace GEM_Desktop
{
    public class desktopDB
    {
        private static string connectionString =
           "Data Source=ELAINEJOY\\SQLEXPRESS;Initial Catalog=GymEquipmentManagement;Integrated Security=True;TrustServerCertificate=True; Persist Security Info=False";

        public List<Dashboard.EquipmentItem> GetAll()
        {
            var list = new List<Dashboard.EquipmentItem>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Name, Status, Quantity FROM equipmentList", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Dashboard.EquipmentItem
                        {
                            Id = reader.IsDBNull(0) ? 0 : int.TryParse(reader.GetString(0), out var id) ? id : 0,
                            Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Status = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Quantity = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                        });
                    }
                }
            }
            return list;
        }


        public void addEquipment(Dashboard.EquipmentItem item)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO equipmentList (Name, Status, Quantity) VALUES (@Name, @Status, @Quantity)", conn);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.ExecuteNonQuery();
            }
        }

        public void update(Dashboard.EquipmentItem item)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE equipmentList SET Name=@Name, Status=@Status, Quantity=@Quantity WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.ExecuteNonQuery();
            }
        }

       public void delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM equipmentList WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<historyRecord> GetHistory()
{
    var list = new List<historyRecord>();
    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        var cmd = new SqlCommand("SELECT EquipmentId, Action, Name, Status, Quantity, Timestamp FROM EquipmentHistoryForm ORDER BY Timestamp DESC", conn);
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                list.Add(new historyRecord
                {
                    EquipmentId = reader.GetInt32(0),
                    Action = reader.GetString(1),
                    Name = reader.GetString(2),
                    Status = reader.GetString(3),
                    Quantity = reader.GetInt32(4),
                    Timestamp = reader.GetDateTime(5)
                });
            }
        }
    }
    return list;
}

        public class historyRecord
        {
            public DateTime Timestamp { get; set; }
            public string Action { get; set; }
            public int EquipmentId { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public int Quantity { get; set; }
        }
    }
}

