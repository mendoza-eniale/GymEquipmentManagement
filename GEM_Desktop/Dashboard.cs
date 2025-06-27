using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace GEM_Desktop
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadEquipmentData();
        }

        public class EquipmentItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public int Quantity { get; set; }
        }


        private List<EquipmentItem> equipmentList = new List<EquipmentItem>
        {
            new EquipmentItem { Id = 1, Name = "Treadmill", Status = "Working", Quantity = 3 },
            new EquipmentItem { Id = 2, Name = "Dumbbell", Status = "Needs Repair", Quantity = 10 }
        };

        public List<Dashboard.EquipmentItem> GetEquipmentList()
        {
            return equipmentList;
        }



        //datagridcolumns
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridView dgv = sender as DataGridView;

            if (dgv == null)
                return;

            object cellValue = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            MessageBox.Show(cellValue != null ? cellValue.ToString() : "No value", "Cell Content");
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            using (var addForm = new addEquipment())
            {
                if (addForm.ShowDialog() == DialogResult.OK && addForm.NewEquipment != null)
                {
                    // Assign a new Id
                    int newId = equipmentList.Any() ? equipmentList.Max(eq => eq.Id) + 1 : 1;
                    addForm.NewEquipment.Id = newId;

                    equipmentList.Add(addForm.NewEquipment);
                    LoadEquipmentData();
                }
            }
        }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            using (var updateForm = new updateEquipment())
            {
                updateForm.ShowDialog();
            }
        }

        //delete
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Delete Equipment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete the selected equipment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            // Remove the selected row from the DataGridView
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

            MessageBox.Show("Equipment removed from the list.", "Delete Equipment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //history
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var historyForm = new history())
            {

                historyForm.ShowDialog();
            }
        }
        //logout
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        public void LoadEquipmentData()
        {
            dataGridView1.DataSource = GetEquipmentList();
        }


        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
