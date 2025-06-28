namespace GEM_Desktop
{
    partial class addEquipment
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtbxAddName = new TextBox();
            cmbStatus = new ComboBox();
            numQuantity = new NumericUpDown();
            btnCanceladd = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            label1.Location = new Point(52, 41);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            label2.Location = new Point(52, 112);
            label2.Name = "label2";
            label2.Size = new Size(52, 17);
            label2.TabIndex = 1;
            label2.Text = "Status:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            label3.Location = new Point(52, 191);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 2;
            label3.Text = "Quantity:";
            // 
            // txtbxAddName
            // 
            txtbxAddName.AccessibleDescription = "Enter equipment name";
            txtbxAddName.Location = new Point(53, 69);
            txtbxAddName.Name = "txtbxAddName";
            txtbxAddName.Size = new Size(254, 23);
            txtbxAddName.TabIndex = 3;
            txtbxAddName.TextChanged += textBox1_TextChanged;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Working", "Needs Repair", "Broken" });
            cmbStatus.Location = new Point(53, 145);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(254, 23);
            cmbStatus.TabIndex = 4;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(53, 222);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(254, 23);
            numQuantity.TabIndex = 5;
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // btnCanceladd
            // 
            btnCanceladd.BackColor = SystemColors.ButtonHighlight;
            btnCanceladd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCanceladd.Location = new Point(143, 271);
            btnCanceladd.Name = "btnCanceladd";
            btnCanceladd.Size = new Size(73, 34);
            btnCanceladd.TabIndex = 7;
            btnCanceladd.Text = "Cancel";
            btnCanceladd.UseVisualStyleBackColor = false;
            btnCanceladd.Click += btnCanceladd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LimeGreen;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(234, 271);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(73, 34);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Add";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnNewAdd_Click;
            // 
            // addEquipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 317);
            Controls.Add(btnUpdate);
            Controls.Add(btnCanceladd);
            Controls.Add(numQuantity);
            Controls.Add(cmbStatus);
            Controls.Add(txtbxAddName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "addEquipment";
            Text = "Add New Equipment";
            Load += addEquipment_Load;
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtbxAddName;
        private ComboBox cmbStatus;
        private NumericUpDown numQuantity;
        private Button btnCanceladd;
        private Button btnUpdate;
    }
}