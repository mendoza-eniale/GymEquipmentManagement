using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GEM_Desktop.Dashboard;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GEM_Desktop
{
    public partial class addEquipment : Form
    {
        public EquipmentItem NewEquipment { get; private set; }

        public addEquipment()
        {
            InitializeComponent();
        }

        private void btnNewAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtbxAddName.Text) ||
            string.IsNullOrWhiteSpace(cmbStatus.Text) ||
            numQuantity.Value < 1)
            {
                MessageBox.Show("Please fill all fields correctly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Status cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return;
            }

            if (numQuantity.Value < 1)
            {
                MessageBox.Show("Quantity must be at least 1.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQuantity.Focus();
                return;
            }
            var newItem = new EquipmentItem
            {
                Id = 0,
                Name = txtbxAddName.Text.Trim(),
                Status = cmbStatus.Text,
                Quantity = (int)numQuantity.Value
            };

            var db = new desktopDB();
            db.addEquipment(newItem);

            var history = new desktopDB.historyRecord
            {
                EquipmentId = newItem.Id,
                Action = "Added",
                Name = newItem.Name,
                Status = newItem.Status,
                Quantity = newItem.Quantity,
                Timestamp = DateTime.Now
            };
            db.GetHistory().Add(history);

            // Assign to property so Dashboard can access it
            this.NewEquipment = newItem;

            MessageBox.Show("Equipment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCanceladd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void addEquipment_Load(object sender, EventArgs e)
        {

        }
    }
}
