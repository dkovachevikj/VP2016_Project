namespace VPProject
{
    partial class SignUp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.lblName = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSurname = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lblRepeatPassword = new System.Windows.Forms.Label();
            this.tbRepeatPassword = new System.Windows.Forms.TextBox();
            this.lblRegister = new System.Windows.Forms.Label();
            this.lblMandatory = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblName.Location = new System.Drawing.Point(31, 131);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 17);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Име:";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(184, 240);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(182, 25);
            this.tbUsername.TabIndex = 2;
            this.tbUsername.Enter += new System.EventHandler(this.tbUsername_Enter);
            this.tbUsername.Leave += new System.EventHandler(this.tbUsername_Leave);
            this.tbUsername.Validating += new System.ComponentModel.CancelEventHandler(this.tbUsername_Validating);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPassword.Location = new System.Drawing.Point(31, 351);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 17);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Лозинка:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(184, 351);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(182, 25);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.Enter += new System.EventHandler(this.tbPassword_Enter);
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.BackColor = System.Drawing.Color.Transparent;
            this.lblSurname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSurname.Location = new System.Drawing.Point(31, 174);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(64, 17);
            this.lblSurname.TabIndex = 12;
            this.lblSurname.Text = "Презиме:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(184, 131);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(182, 25);
            this.tbName.TabIndex = 0;
            this.tbName.Enter += new System.EventHandler(this.tbName_Enter);
            this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
            this.tbName.Validating += new System.ComponentModel.CancelEventHandler(this.tbName_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblEmail.Location = new System.Drawing.Point(31, 283);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 17);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Е-Пошта:";
            // 
            // tbSurname
            // 
            this.tbSurname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSurname.Location = new System.Drawing.Point(184, 174);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(182, 25);
            this.tbSurname.TabIndex = 1;
            this.tbSurname.Enter += new System.EventHandler(this.tbSurname_Enter);
            this.tbSurname.Leave += new System.EventHandler(this.tbSurname_Leave);
            this.tbSurname.Validating += new System.ComponentModel.CancelEventHandler(this.tbSurname_Validating);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUsername.Location = new System.Drawing.Point(31, 240);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(110, 17);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Корисничко име:";
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbEmail.Location = new System.Drawing.Point(184, 283);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(182, 25);
            this.tbEmail.TabIndex = 3;
            this.tbEmail.Text = "user@example.com";
            this.tbEmail.Enter += new System.EventHandler(this.tbEmail_Enter);
            this.tbEmail.Leave += new System.EventHandler(this.tbEmail_Leave);
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tbEmail_Validating);
            // 
            // lblRepeatPassword
            // 
            this.lblRepeatPassword.AutoSize = true;
            this.lblRepeatPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblRepeatPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRepeatPassword.Location = new System.Drawing.Point(31, 394);
            this.lblRepeatPassword.Name = "lblRepeatPassword";
            this.lblRepeatPassword.Size = new System.Drawing.Size(115, 17);
            this.lblRepeatPassword.TabIndex = 8;
            this.lblRepeatPassword.Text = "Повтори лозинка:";
            // 
            // tbRepeatPassword
            // 
            this.tbRepeatPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRepeatPassword.Location = new System.Drawing.Point(184, 394);
            this.tbRepeatPassword.Name = "tbRepeatPassword";
            this.tbRepeatPassword.Size = new System.Drawing.Size(182, 25);
            this.tbRepeatPassword.TabIndex = 5;
            this.tbRepeatPassword.Enter += new System.EventHandler(this.tbRepeatPassword_Enter);
            this.tbRepeatPassword.Leave += new System.EventHandler(this.tbRepeatPassword_Leave);
            this.tbRepeatPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbRepeatPassword_Validating);
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.BackColor = System.Drawing.Color.Transparent;
            this.lblRegister.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegister.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblRegister.Location = new System.Drawing.Point(119, 36);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(146, 30);
            this.lblRegister.TabIndex = 15;
            this.lblRegister.Text = "Регистрација";
            // 
            // lblMandatory
            // 
            this.lblMandatory.AutoSize = true;
            this.lblMandatory.BackColor = System.Drawing.Color.Transparent;
            this.lblMandatory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMandatory.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblMandatory.Location = new System.Drawing.Point(96, 76);
            this.lblMandatory.Name = "lblMandatory";
            this.lblMandatory.Size = new System.Drawing.Size(195, 17);
            this.lblMandatory.TabIndex = 14;
            this.lblMandatory.Text = "Сите полиња се задолжителни!";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(35, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Откажи";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(223, 450);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(143, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Регистрирај се";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(408, 509);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 2);
            this.label1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 2);
            this.label2.TabIndex = 20;
            // 
            // SignUp
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(408, 509);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMandatory);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.tbRepeatPassword);
            this.Controls.Add(this.lblRepeatPassword);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрирај се";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox tbRepeatPassword;
        private System.Windows.Forms.Label lblRepeatPassword;
        private System.Windows.Forms.Label lblMandatory;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}