

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

    public interface IEquipmentItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Status { get; set; }
        int Quantity { get; set; }
    }
    public class EquipmentItem : IEquipmentItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nStatus: {Status}\nQuantity: {Quantity}";
        }
    }
}
