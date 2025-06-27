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

            if (string.IsNullOrWhiteSpace(txtbxAddName.Text))
            {
                MessageBox.Show("Equipment name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbxAddName.Focus();
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
            NewEquipment = new Dashboard.EquipmentItem
            {
                Id = 0,
                Name = txtbxAddName.Text.Trim(),
                Status = cmbStatus.Text,
                Quantity = (int)numQuantity.Value
            };

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
