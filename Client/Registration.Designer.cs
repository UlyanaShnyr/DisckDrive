namespace Client
{
    partial class Registration
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
            this.labelLogIn = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.ButtonRegistration = new System.Windows.Forms.Button();
            this.linkLabelGoToTheLoginForm = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelLogIn
            // 
            this.labelLogIn.AutoSize = true;
            this.labelLogIn.Location = new System.Drawing.Point(12, 23);
            this.labelLogIn.Name = "labelLogIn";
            this.labelLogIn.Size = new System.Drawing.Size(34, 13);
            this.labelLogIn.TabIndex = 2;
            this.labelLogIn.Text = "LogIn";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(85, 23);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(187, 20);
            this.textBoxLogin.TabIndex = 3;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 55);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(85, 55);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(187, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // ButtonRegistration
            // 
            this.ButtonRegistration.Location = new System.Drawing.Point(11, 90);
            this.ButtonRegistration.Name = "ButtonRegistration";
            this.ButtonRegistration.Size = new System.Drawing.Size(261, 23);
            this.ButtonRegistration.TabIndex = 6;
            this.ButtonRegistration.Text = "Registration";
            this.ButtonRegistration.UseVisualStyleBackColor = true;
            // 
            // linkLabelGoToTheLoginForm
            // 
            this.linkLabelGoToTheLoginForm.AutoSize = true;
            this.linkLabelGoToTheLoginForm.Location = new System.Drawing.Point(12, 127);
            this.linkLabelGoToTheLoginForm.Name = "linkLabelGoToTheLoginForm";
            this.linkLabelGoToTheLoginForm.Size = new System.Drawing.Size(106, 13);
            this.linkLabelGoToTheLoginForm.TabIndex = 7;
            this.linkLabelGoToTheLoginForm.TabStop = true;
            this.linkLabelGoToTheLoginForm.Text = "Go to the Login Form";
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 171);
            this.Controls.Add(this.linkLabelGoToTheLoginForm);
            this.Controls.Add(this.ButtonRegistration);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelLogIn);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogIn;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button ButtonRegistration;
        private System.Windows.Forms.LinkLabel linkLabelGoToTheLoginForm;
    }
}