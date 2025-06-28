namespace GEM_Desktop
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblGEM = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtbxUsername = new TextBox();
            txtbxPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblGEM
            // 
            lblGEM.AutoSize = true;
            lblGEM.Font = new Font("Stencil", 27F, FontStyle.Bold);
            lblGEM.Location = new Point(29, 86);
            lblGEM.Name = "lblGEM";
            lblGEM.Size = new Size(564, 43);
            lblGEM.TabIndex = 0;
            lblGEM.Text = "Gym Equipment Management";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(109, 165);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(102, 23);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(109, 238);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(97, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            lblPassword.Click += label2_Click;
            // 
            // txtbxUsername
            // 
            txtbxUsername.Location = new Point(176, 200);
            txtbxUsername.Name = "txtbxUsername";
            txtbxUsername.Size = new Size(293, 23);
            txtbxUsername.TabIndex = 3;
            // 
            // txtbxPassword
            // 
            txtbxPassword.Location = new Point(176, 274);
            txtbxPassword.Name = "txtbxPassword";
            txtbxPassword.Size = new Size(293, 23);
            txtbxPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LimeGreen;
            btnLogin.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(261, 331);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(92, 35);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(623, 445);
            Controls.Add(btnLogin);
            Controls.Add(txtbxPassword);
            Controls.Add(txtbxUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblGEM);
            MaximizeBox = false;
            Name = "Login";
            Text = "Gym Equipment Management";
            TransparencyKey = Color.CornflowerBlue;
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGEM;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtbxUsername;
        private TextBox txtbxPassword;
        private Button btnLogin;
    }
}
