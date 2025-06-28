namespace GEM_Desktop
{
    partial class updateEquipment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUpdateAdd = new Button();
            btnCancelUpdate = new Button();
            numEditQuantity = new NumericUpDown();
            cmboStats = new ComboBox();
            txtbxUpName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            txtSearchID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numEditQuantity).BeginInit();
            SuspendLayout();
            // 
            // btnUpdateAdd
            // 
            btnUpdateAdd.BackColor = Color.LimeGreen;
            btnUpdateAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateAdd.Location = new Point(235, 271);
            btnUpdateAdd.Name = "btnUpdateAdd";
            btnUpdateAdd.Size = new Size(73, 34);
            btnUpdateAdd.TabIndex = 16;
            btnUpdateAdd.Text = "Update";
            btnUpdateAdd.UseVisualStyleBackColor = false;
            btnUpdateAdd.Click += btnUpdateAdd_Click;
            // 
            // btnCancelUpdate
            // 
            btnCancelUpdate.BackColor = SystemColors.ButtonHighlight;
            btnCancelUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelUpdate.Location = new Point(144, 271);
            btnCancelUpdate.Name = "btnCancelUpdate";
            btnCancelUpdate.Size = new Size(73, 34);
            btnCancelUpdate.TabIndex = 15;
            btnCancelUpdate.Text = "Cancel";
            btnCancelUpdate.UseVisualStyleBackColor = false;
            btnCancelUpdate.Click += btnCancelUpdate_Click;
            // 
            // numEditQuantity
            // 
            numEditQuantity.Location = new Point(54, 238);
            numEditQuantity.Name = "numEditQuantity";
            numEditQuantity.Size = new Size(254, 23);
            numEditQuantity.TabIndex = 14;
            numEditQuantity.ValueChanged += numEditQuantity_ValueChanged;
            // 
            // cmboStats
            // 
            cmboStats.FormattingEnabled = true;
            cmboStats.Items.AddRange(new object[] { "Working", "Needs Repair", "Broken" });
            cmboStats.Location = new Point(54, 161);
            cmboStats.Name = "cmboStats";
            cmboStats.Size = new Size(254, 23);
            cmboStats.TabIndex = 13;
            cmboStats.SelectedIndexChanged += cmboStats_SelectedIndexChanged;
            // 
            // txtbxUpName
            // 
            txtbxUpName.AccessibleDescription = "Enter equipment name";
            txtbxUpName.Location = new Point(54, 85);
            txtbxUpName.Name = "txtbxUpName";
            txtbxUpName.Size = new Size(254, 23);
            txtbxUpName.TabIndex = 12;
            txtbxUpName.TextChanged += txtbxUpName_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            label3.Location = new Point(53, 207);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 11;
            label3.Text = "Quantity:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            label2.Location = new Point(53, 128);
            label2.Name = "label2";
            label2.Size = new Size(52, 17);
            label2.TabIndex = 10;
            label2.Text = "Status:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            label1.Location = new Point(53, 57);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 9;
            label1.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            label4.Location = new Point(24, 24);
            label4.Name = "label4";
            label4.Size = new Size(29, 17);
            label4.TabIndex = 17;
            label4.Text = "ID:";
            // 
            // txtSearchID
            // 
            txtSearchID.AccessibleDescription = "";
            txtSearchID.Location = new Point(54, 21);
            txtSearchID.Name = "txtSearchID";
            txtSearchID.Size = new Size(80, 23);
            txtSearchID.TabIndex = 18;
            txtSearchID.TextChanged += txtSearchID_TextChanged;
            // 
            // updateEquipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 317);
            Controls.Add(txtSearchID);
            Controls.Add(label4);
            Controls.Add(btnUpdateAdd);
            Controls.Add(btnCancelUpdate);
            Controls.Add(numEditQuantity);
            Controls.Add(cmboStats);
            Controls.Add(txtbxUpName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "updateEquipment";
            Text = "Update Equipment";
            Load += updateEquipment_Load;
            ((System.ComponentModel.ISupportInitialize)numEditQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdateAdd;
        private Button btnCancelUpdate;
        private NumericUpDown numEditQuantity;
        private ComboBox cmboStats;
        private TextBox txtbxUpName;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private TextBox txtSearchID;
    }
}