

namespace GEMCommon
{
    public class LoginService
    {
        private string Username = "admin";
        private string Password = "123456";
        public bool LogIn(string inputUsername, string inputPassword)
        {
            return inputUsername == Username && inputPassword == Password;
        }
    }
    public class EquipmentItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} \nName: {Name}\n Quantity: {Quantity}\nStatus: {Status}";
        }
    }

}

