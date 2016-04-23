﻿namespace VPProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbSignOut = new System.Windows.Forms.LinkLabel();
            this.lblUsername = new System.Windows.Forms.LinkLabel();
            this.panelUser = new System.Windows.Forms.Panel();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lbMovies = new System.Windows.Forms.ListBox();
            this.lblBorder = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadMore = new System.Windows.Forms.Button();
            this.panelMovie = new System.Windows.Forms.TableLayoutPanel();
            this.btnWatchTrailer = new System.Windows.Forms.Button();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMovieTitle = new System.Windows.Forms.Label();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.btnDodadiKosnicka = new System.Windows.Forms.Button();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMovie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSignOut
            // 
            this.lbSignOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSignOut.AutoSize = true;
            this.lbSignOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSignOut.Location = new System.Drawing.Point(184, 17);
            this.lbSignOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSignOut.Name = "lbSignOut";
            this.lbSignOut.Size = new System.Drawing.Size(64, 20);
            this.lbSignOut.TabIndex = 1;
            this.lbSignOut.TabStop = true;
            this.lbSignOut.Text = "Sign out";
            this.lbSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbSignOut_LinkClicked);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(91, 17);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 20);
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
            this.panelUser.Location = new System.Drawing.Point(1071, 5);
            this.panelUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(323, 52);
            this.panelUser.TabIndex = 12;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.Location = new System.Drawing.Point(1103, 15);
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
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(1251, 15);
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
            this.lbMovies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMovies.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMovies.FormattingEnabled = true;
            this.lbMovies.ItemHeight = 20;
            this.lbMovies.Location = new System.Drawing.Point(21, 171);
            this.lbMovies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbMovies.Name = "lbMovies";
            this.lbMovies.Size = new System.Drawing.Size(391, 364);
            this.lbMovies.TabIndex = 1;
            this.lbMovies.SelectedIndexChanged += new System.EventHandler(this.lbMovies_SelectedIndexChanged);
            // 
            // lblBorder
            // 
            this.lblBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBorder.Location = new System.Drawing.Point(0, 73);
            this.lblBorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(1407, 2);
            this.lblBorder.TabIndex = 4;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbSearch.Location = new System.Drawing.Point(21, 94);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(308, 27);
            this.tbSearch.TabIndex = 14;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(339, 94);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 62);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Go";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadMore
            // 
            this.btnLoadMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadMore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMore.Location = new System.Drawing.Point(20, 553);
            this.btnLoadMore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadMore.Name = "btnLoadMore";
            this.btnLoadMore.Size = new System.Drawing.Size(392, 39);
            this.btnLoadMore.TabIndex = 17;
            this.btnLoadMore.Text = "Load More";
            this.btnLoadMore.UseVisualStyleBackColor = true;
            this.btnLoadMore.Click += new System.EventHandler(this.btnLoadMore_Click);
            // 
            // panelMovie
            // 
            this.panelMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMovie.AutoScroll = true;
            this.panelMovie.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMovie.ColumnCount = 2;
            this.panelMovie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.panelMovie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMovie.Controls.Add(this.btnWatchTrailer, 0, 2);
            this.panelMovie.Controls.Add(this.pbPoster, 0, 1);
            this.panelMovie.Controls.Add(this.lblDescription, 1, 1);
            this.panelMovie.Controls.Add(this.lblMovieTitle, 0, 0);
            this.panelMovie.Location = new System.Drawing.Point(440, 92);
            this.panelMovie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMovie.MinimumSize = new System.Drawing.Size(667, 474);
            this.panelMovie.Name = "panelMovie";
            this.panelMovie.RowCount = 3;
            this.panelMovie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelMovie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMovie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.panelMovie.Size = new System.Drawing.Size(951, 607);
            this.panelMovie.TabIndex = 5;
            // 
            // btnWatchTrailer
            // 
            this.btnWatchTrailer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWatchTrailer.Location = new System.Drawing.Point(4, 554);
            this.btnWatchTrailer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWatchTrailer.Name = "btnWatchTrailer";
            this.btnWatchTrailer.Size = new System.Drawing.Size(171, 46);
            this.btnWatchTrailer.TabIndex = 5;
            this.btnWatchTrailer.Text = "Watch Trailer >";
            this.btnWatchTrailer.UseVisualStyleBackColor = true;
            this.btnWatchTrailer.Click += new System.EventHandler(this.btnWatchTrailer_Click);
            // 
            // pbPoster
            // 
            this.pbPoster.Location = new System.Drawing.Point(4, 41);
            this.pbPoster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(259, 372);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 4;
            this.pbPoster.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(271, 37);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(85, 20);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            // 
            // lblMovieTitle
            // 
            this.lblMovieTitle.AutoSize = true;
            this.panelMovie.SetColumnSpan(this.lblMovieTitle, 2);
            this.lblMovieTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieTitle.Location = new System.Drawing.Point(4, 0);
            this.lblMovieTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMovieTitle.Name = "lblMovieTitle";
            this.lblMovieTitle.Size = new System.Drawing.Size(49, 28);
            this.lblMovieTitle.TabIndex = 0;
            this.lblMovieTitle.Text = "Title";
            // 
            // cbGenre
            // 
            this.cbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Items.AddRange(new object[] {
            "All"});
            this.cbGenre.Location = new System.Drawing.Point(21, 129);
            this.cbGenre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbGenre.MaxDropDownItems = 100;
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(308, 24);
            this.cbGenre.TabIndex = 18;
            this.cbGenre.SelectedIndexChanged += new System.EventHandler(this.cbGenre_SelectedIndexChanged);
            // 
            // btnDodadiKosnicka
            // 
            this.btnDodadiKosnicka.Location = new System.Drawing.Point(21, 617);
            this.btnDodadiKosnicka.Name = "btnDodadiKosnicka";
            this.btnDodadiKosnicka.Size = new System.Drawing.Size(391, 44);
            this.btnDodadiKosnicka.TabIndex = 19;
            this.btnDodadiKosnicka.Text = "Shopping cart";
            this.btnDodadiKosnicka.UseVisualStyleBackColor = true;
            this.btnDodadiKosnicka.Click += new System.EventHandler(this.btnDodadiKosnicka_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 714);
            this.Controls.Add(this.btnDodadiKosnicka);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.panelMovie);
            this.Controls.Add(this.btnLoadMore);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.lbMovies);
            this.Controls.Add(this.panelUser);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Видеотека";
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMovie.ResumeLayout(false);
            this.panelMovie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
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
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoadMore;
        private System.Windows.Forms.TableLayoutPanel panelMovie;
        private System.Windows.Forms.Button btnWatchTrailer;
        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblMovieTitle;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.Button btnDodadiKosnicka;
    }
}

