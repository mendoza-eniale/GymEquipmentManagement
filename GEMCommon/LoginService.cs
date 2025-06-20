namespace GEMCommon
{
    public class LoginService
    {
        private string Username { get; } = "admin"; // Use properties for encapsulation
        private string Password { get; } = "123456"; // Use properties for encapsulation
        public bool LogIn(string inputUsername, string inputPassword)
        {
            return inputUsername == Username && inputPassword == Password;
        }
    }
    public class EquipmentItem
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
    }
}
