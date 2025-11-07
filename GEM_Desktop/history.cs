using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEM_Desktop;

namespace GEM_Desktop
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            var db = new desktopDB();
            var historyRecords = db.GetHistory();

            if (historyRecords != null && historyRecords.Any())
            {
                var sb = new StringBuilder();
                foreach (var record in historyRecords)
                {
                    sb.AppendLine($"{record.Timestamp}: [{record.Action}] ID: {record.EquipmentId}, Name: {record.Name}, Status: {record.Status}, Quantity: {record.Quantity}");
                }
                richTextBox1.Text = sb.ToString();
            }
            else
            {
                var equipmentList = db.GetAll();
                if (equipmentList != null && equipmentList.Any())
                {
                    var sb = new StringBuilder();
                    foreach (var item in equipmentList)
                    {
                        sb.AppendLine($"[Added] ID: {item.Id}, Name: {item.Name}, Status: {item.Status}, Quantity: {item.Quantity}");
                        sb.AppendLine($"[Added] ID: {item.Id}, Name: {item.Name}, Status: {item.Status}, Quantity: {item.Quantity}");
                    }
                    richTextBox1.Text = sb.ToString();
                }
                else
                {
                    richTextBox1.Text = "No equipment data available.";
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
