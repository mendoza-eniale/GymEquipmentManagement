using System;
using System.Windows.Forms;
using static GEM_Desktop.Dashboard;



namespace GEM_Desktop
{
    public partial class updateEquipment : Form
    {
        public EquipmentItem UpdatedEquipment { get; private set; }
        private EquipmentItem originalItem;

        public updateEquipment(EquipmentItem itemToEdit)
        {
            InitializeComponent();

            originalItem = itemToEdit;
            txtbxUpName.Text = itemToEdit.Name;
            cmboStats.Text = itemToEdit.Status;
            numEditQuantity.Value = itemToEdit.Quantity;
        }

        public updateEquipment()
        {
            InitializeComponent();
        }

        private void btnUpdateAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbxUpName.Text))
            {
                MessageBox.Show("Equipment name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbxUpName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cmboStats.Text))
            {
                MessageBox.Show("Status cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmboStats.Focus();
                return;
            }
            if (numEditQuantity.Value < 1)
            {
                MessageBox.Show("Quantity must be at least 1.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numEditQuantity.Focus();
                return;
            }

            UpdatedEquipment = new EquipmentItem
            {
                Id = originalItem.Id,
                Name = txtbxUpName.Text.Trim(),
                Status = cmboStats.Text,
                Quantity = (int)numEditQuantity.Value
            };

            this.DialogResult = DialogResult.OK;
            var dashbordForm = new Dashboard();
            dashbordForm.Show();
            this.Close();
        }

        private void updateEquipment_Load(object sender, EventArgs e)
        {
            if (cmboStats.Items.Count == 0)
            {
                cmboStats.Items.AddRange(new string[] { "Working", "Needs Repair" });
            }
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchID.Text.Trim(), out int searchId))
            {
                var dashboard = this.Owner as Dashboard;
                if (dashboard == null)
                    return;

                var item = dashboard.GetEquipmentList().FirstOrDefault(eq => eq.Id == searchId);

                if (item != null)
                {
                    using (var updateForm = new updateEquipment(item))
                    {
                        if (updateForm.ShowDialog() == DialogResult.OK && updateForm.UpdatedEquipment != null)
                        {
                            // update item
                            item.Name = updateForm.UpdatedEquipment.Name;
                            item.Status = updateForm.UpdatedEquipment.Status;
                            item.Quantity = updateForm.UpdatedEquipment.Quantity;
                            dashboard.LoadEquipmentData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No equipment found with that ID.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

    }
}
