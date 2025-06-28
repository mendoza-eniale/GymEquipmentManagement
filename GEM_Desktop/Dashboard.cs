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
        private int nextEquipmentId = 3;
        public Dashboard()
        {
            InitializeComponent(); 
            if (equipmentList.Any())
                nextEquipmentId = equipmentList.Max(eq => eq.Id) + 1;
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
            if (dataGridView1 == null)
                return;

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var selectedItem = dataGridView1.Rows[e.RowIndex].DataBoundItem as Dashboard.EquipmentItem;
            if (selectedItem != null)
            {
                MessageBox.Show(
                    $"ID: {selectedItem.Id}\nName: {selectedItem.Name}\nStatus: {selectedItem.Status}\nQuantity: {selectedItem.Quantity}",
                    "Equipment Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None
                );
            }
            else
            {
                MessageBox.Show("No equipment data found for this row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            using (var addForm = new addEquipment())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // next autoincremented Id
                    addForm.NewEquipment.Id = nextEquipmentId++;
                    equipmentList.Add(addForm.NewEquipment);
                    LoadEquipmentData();
                }
            }
        }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Edit Equipment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var itemToEdit = equipmentList.FirstOrDefault(eq => eq.Id == selectedId);

            if (itemToEdit != null)
            {
                using (var updateForm = new updateEquipment(itemToEdit, this))
                {
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadEquipmentData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Equipment not found.", "Edit Equipment", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            int selectedRow = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            db.delete(selectedRow);

            var history = new desktopDB.historyRecord
            {
                Action = "Added",
                Timestamp = DateTime.Now
            };
            db.GetHistory().Add(history);

            var itemToRemove = equipmentList.FirstOrDefault(eq => eq.Id == selectedRow);
            if (itemToRemove != null)
            {
                equipmentList.Remove(itemToRemove);
                LoadEquipmentData();
                MessageBox.Show("Equipment removed from the list.", "Delete Equipment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Equipment not found in the list.", "Delete Equipment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private desktopDB db = new desktopDB();
        public void LoadEquipmentData()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = null;
                //dataGridView1.DataSource = equipmentList;
            dataGridView1.DataSource = db.GetAll();
            }
        }


        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
