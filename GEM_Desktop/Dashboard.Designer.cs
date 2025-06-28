namespace GEM_Desktop
{
    partial class Dashboard
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
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            menuStrip1 = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            history = new ToolStripMenuItem();
            logout = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = Color.Lavender;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(23, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 286);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Equipment Name";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Quantity";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Status";
            Column4.Name = "Column4";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LimeGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(113, 350);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(64, 31);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += button1_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.LightSkyBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(199, 350);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(64, 31);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += button2_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Tomato;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(284, 350);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(64, 31);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += button3_Click_1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(482, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { history, logout });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "File";
            fileMenu.Click += fileMenu_Click;
            // 
            // history
            // 
            history.Name = "history";
            history.Size = new Size(112, 22);
            history.Text = "History";
            history.Click += historyToolStripMenuItem_Click;
            // 
            // logout
            // 
            logout.Name = "logout";
            logout.Size = new Size(112, 22);
            logout.Text = "Logout";
            logout.Click += logoutToolStripMenuItem_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 402);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem history;
        private ToolStripMenuItem logout;
    }
}