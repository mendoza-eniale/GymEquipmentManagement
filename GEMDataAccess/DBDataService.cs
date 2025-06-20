//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Text.Json;

//namespace GEMDataAccess
//{
//    public class DBDataService : IGEMDataService
//    {
//        private static string connectionString = "Data Source =elainejoy\\SQLEXPRESS; 
//        static SqlConnection sqlConnection;

//        public DBDataService()
//        {
//            sqlConnection = new SqlConnection(connectionString);
//        }

//        public string GetEquipmentData()
//        {
//        var equipmentList = new List<string>();

//            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
//            sqlConnection.Open();
//            SqlDataReader reader = selectCommand.ExecuteReader();



//            using (var sqlConnection = new SqlConnection(connectionString))
//        {
//            sqlConnection.Open();
//            string query = "SELECT * FROM Equipment"; 

//            using (var command = new SqlCommand(query, sqlConnection))
//            {
//                using (var reader = command.ExecuteReader())
//                {
//                while (reader.Read())
//                {
//                    var equipment = new
//                    {
//                        Id = reader["Id"],
//                        Name = reader["Name"],
//                        Status = reader["Status"],
//                        Quantity = reader["Quantity"]
//                    };
//                    equipmentList.Add(JsonSerializer.Serialize(equipment));
//                }
//            }
//            }
//        }

//            return string.Join(Environment.NewLine, equipmentList);
//        }

//        public string GetHistoryData()
//        {
//            var historyList = new List<string>();

//            using (var sqlConnection = new SqlConnection(connectionString))
//            {
//                sqlConnection.Open();
//                string query = "SELECT * FROM History"; 

//                using (var command = new SqlCommand(query, sqlConnection))
//                {
//                    using (var reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            // Assuming the History table has a column: Action
//                            historyList.Add(reader["Action"].ToString());
//                        }
//                    }
//                }
//            }

//            return string.Join(Environment.NewLine, historyList);
//        }

//        public void SetEquipmentData(string data)
//        {
//            using (var sqlConnection = new SqlConnection(connectionString))
//            {
//                sqlConnection.Open();
//                string query = "INSERT INTO Equipment (Name, Status, Quantity) VALUES (@Name, @Status, @Quantity)";

//                using (var command = new SqlCommand(query, sqlConnection))
//                {
//                    var equipment = JsonSerializer.Deserialize<EquipmentItem>(data);
//                    command.Parameters.AddWithValue("@Name", equipment.Name);
//                    command.Parameters.AddWithValue("@Status", equipment.Status);
//                    command.Parameters.AddWithValue("@Quantity", equipment.Quantity);
//                    command.ExecuteNonQuery();
//                }
//            }
//        }

//        public void SetHistoryData(string data)
//        {
//            using (var sqlConnection = new SqlConnection(connectionString))
//            {
//                sqlConnection.Open();
//                string query = "INSERT INTO History (Action) VALUES (@Action)";

//                using (var command = new SqlCommand(query, sqlConnection))
//                {
//                    command.Parameters.AddWithValue("@Action", data);
//                    command.ExecuteNonQuery();
//                }
//            }
//        }

//        public void ReplaceEquipmentData(string newData)
//        {
//            var equipmentList = JsonSerializer.Deserialize<List<EquipmentItem>>(newData);

//            using (var sqlConnection = new SqlConnection(connectionString))
//            {
//                sqlConnection.Open();
//                string deleteQuery = "DELETE FROM Equipment"; 
//                using (var deleteCommand = new SqlCommand(deleteQuery, sqlConnection))
//                {
//                    deleteCommand.ExecuteNonQuery();
//                }

//                string insertQuery = "INSERT INTO Equipment (Name, Status, Quantity) VALUES (@Name, @Status, @Quantity)";
//                foreach (var equipment in equipmentList)
//                {
//                    using (var insertCommand = new SqlCommand(insertQuery, sqlConnection))
//                    {
//                        insertCommand.Parameters.AddWithValue("@Name", equipment.Name);
//                        insertCommand.Parameters.AddWithValue("@Status", equipment.Status);
//                        insertCommand.Parameters.AddWithValue("@Quantity", equipment.Quantity);
//                        insertCommand.ExecuteNonQuery();
//                    }
//                }
//            }
//            sqlConnection.Close();

//        }
//    }

  
//}
