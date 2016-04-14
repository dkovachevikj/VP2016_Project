namespace VPProject
{
    partial class Form1
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
            this.lbSignOut = new System.Windows.Forms.LinkLabel();
            this.lblUsername = new System.Windows.Forms.LinkLabel();
            this.panelUser = new System.Windows.Forms.Panel();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lbMovies = new System.Windows.Forms.ListBox();
            this.lblBorder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.btnDeleteMovie = new System.Windows.Forms.Button();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMovieTitle = new System.Windows.Forms.Label();
            this.lblMovieDesc = new System.Windows.Forms.Label();
            this.lblMovieYear = new System.Windows.Forms.Label();
            this.panelMovie = new System.Windows.Forms.Panel();
            this.panelUser.SuspendLayout();
            this.panelMovie.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSignOut
            // 
            this.lbSignOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSignOut.AutoSize = true;
            this.lbSignOut.Location = new System.Drawing.Point(261, 17);
            this.lbSignOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSignOut.Name = "lbSignOut";
            this.lbSignOut.Size = new System.Drawing.Size(60, 17);
            this.lbSignOut.TabIndex = 1;
            this.lbSignOut.TabStop = true;
            this.lbSignOut.Text = "Sign out";
            this.lbSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbSignOut_LinkClicked);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(168, 17);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(71, 17);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.TabStop = true;
            this.lblUsername.Text = "username";
            this.lblUsername.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUsername_LinkClicked);
            // 
            // panelUser
            // 
            this.panelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUser.Controls.Add(this.lblUsername);
            this.panelUser.Controls.Add(this.lbSignOut);
            this.panelUser.Location = new System.Drawing.Point(544, 5);
            this.panelUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(400, 42);
            this.panelUser.TabIndex = 12;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignUp.Location = new System.Drawing.Point(640, 15);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(140, 28);
            this.btnSignUp.TabIndex = 10;
            this.btnSignUp.Text = "Регистрирај се";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignIn.Location = new System.Drawing.Point(788, 15);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(140, 28);
            this.btnSignIn.TabIndex = 11;
            this.btnSignIn.Text = "Најави се";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lbMovies
            // 
            this.lbMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMovies.FormattingEnabled = true;
            this.lbMovies.ItemHeight = 16;
            this.lbMovies.Location = new System.Drawing.Point(21, 92);
            this.lbMovies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbMovies.Name = "lbMovies";
            this.lbMovies.Size = new System.Drawing.Size(269, 420);
            this.lbMovies.TabIndex = 1;
            this.lbMovies.SelectedIndexChanged += new System.EventHandler(this.lbMovies_SelectedIndexChanged);
            // 
            // lblBorder
            // 
            this.lblBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBorder.Location = new System.Drawing.Point(16, 50);
            this.lblBorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(1191, 2);
            this.lblBorder.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Сортитај по:";
            // 
            // cbSort
            // 
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            "Година",
            "Име"});
            this.cbSort.Location = new System.Drawing.Point(116, 18);
            this.cbSort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(175, 24);
            this.cbSort.TabIndex = 8;
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
            // 
            // btnDeleteMovie
            // 
            this.btnDeleteMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteMovie.Location = new System.Drawing.Point(21, 588);
            this.btnDeleteMovie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteMovie.Name = "btnDeleteMovie";
            this.btnDeleteMovie.Size = new System.Drawing.Size(271, 28);
            this.btnDeleteMovie.TabIndex = 3;
            this.btnDeleteMovie.Text = "Избриши филм";
            this.btnDeleteMovie.UseVisualStyleBackColor = true;
            this.btnDeleteMovie.Click += new System.EventHandler(this.btnDeleteMovie_Click);
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddMovie.Location = new System.Drawing.Point(21, 553);
            this.btnAddMovie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(271, 28);
            this.btnAddMovie.TabIndex = 2;
            this.btnAddMovie.Text = "Додади филм";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Филмови";
            // 
            // lblMovieTitle
            // 
            this.lblMovieTitle.AutoSize = true;
            this.lblMovieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieTitle.Location = new System.Drawing.Point(23, 22);
            this.lblMovieTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMovieTitle.Name = "lblMovieTitle";
            this.lblMovieTitle.Size = new System.Drawing.Size(54, 25);
            this.lblMovieTitle.TabIndex = 0;
            this.lblMovieTitle.Text = "Title";
            // 
            // lblMovieDesc
            // 
            this.lblMovieDesc.AutoSize = true;
            this.lblMovieDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieDesc.Location = new System.Drawing.Point(23, 160);
            this.lblMovieDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMovieDesc.Name = "lblMovieDesc";
            this.lblMovieDesc.Size = new System.Drawing.Size(109, 25);
            this.lblMovieDesc.TabIndex = 1;
            this.lblMovieDesc.Text = "Description";
            // 
            // lblMovieYear
            // 
            this.lblMovieYear.AutoSize = true;
            this.lblMovieYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieYear.Location = new System.Drawing.Point(23, 91);
            this.lblMovieYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMovieYear.Name = "lblMovieYear";
            this.lblMovieYear.Size = new System.Drawing.Size(53, 25);
            this.lblMovieYear.TabIndex = 2;
            this.lblMovieYear.Text = "Year";
            // 
            // panelMovie
            // 
            this.panelMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMovie.Controls.Add(this.lblMovieYear);
            this.panelMovie.Controls.Add(this.lblMovieDesc);
            this.panelMovie.Controls.Add(this.lblMovieTitle);
            this.panelMovie.Location = new System.Drawing.Point(313, 92);
            this.panelMovie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMovie.Name = "panelMovie";
            this.panelMovie.Size = new System.Drawing.Size(615, 524);
            this.panelMovie.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 631);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.panelMovie);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.btnDeleteMovie);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.lbMovies);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Видеотека";
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.panelMovie.ResumeLayout(false);
            this.panelMovie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lbSignOut;
        private System.Windows.Forms.LinkLabel lblUsername;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.ListBox lbMovies;
        private System.Windows.Forms.Label lblBorder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Button btnDeleteMovie;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMovieTitle;
        private System.Windows.Forms.Label lblMovieDesc;
        private System.Windows.Forms.Label lblMovieYear;
        private System.Windows.Forms.Panel panelMovie;
    }
}

