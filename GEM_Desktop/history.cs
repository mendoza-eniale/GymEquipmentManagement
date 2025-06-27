using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEMDataAccess;


namespace GEM_Desktop
{
    public partial class history : Form
    {
        public history()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
//            var dataService = new GEMDataAccess.GEMDataService();
//            string historyData = dataService.GetHistoryData();

//// displayhistory  
//            richTextBox1.Text = string.IsNullOrWhiteSpace(historyData)
//                ? "No history available."
//                : historyData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
