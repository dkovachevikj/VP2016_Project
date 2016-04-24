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
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panelTitleInfo = new System.Windows.Forms.Panel();
            this.lblVotes = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblMovieTitle = new System.Windows.Forms.Label();
            this.btnWatchTrailer = new System.Windows.Forms.Button();
            this.lblCast = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toopStripLblSearchResults = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMovie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            this.panelTitleInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSignOut
            // 
            this.lbSignOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSignOut.AutoSize = true;
            this.lbSignOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSignOut.Location = new System.Drawing.Point(157, 6);
            this.lbSignOut.Name = "lbSignOut";
            this.lbSignOut.Size = new System.Drawing.Size(56, 17);
            this.lbSignOut.TabIndex = 1;
            this.lbSignOut.TabStop = true;
            this.lbSignOut.Text = "Sign out";
            this.lbSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbSignOut_LinkClicked);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(77, 6);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(65, 17);
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
            this.panelUser.Location = new System.Drawing.Point(881, 12);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(242, 42);
            this.panelUser.TabIndex = 12;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignUp.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.Location = new System.Drawing.Point(895, 12);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(105, 31);
            this.btnSignUp.TabIndex = 10;
            this.btnSignUp.Text = "Register";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignIn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(1018, 12);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(105, 31);
            this.btnSignIn.TabIndex = 11;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lbMovies
            // 
            this.lbMovies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMovies.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lbMovies.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMovies.ForeColor = System.Drawing.Color.White;
            this.lbMovies.FormattingEnabled = true;
            this.lbMovies.ItemHeight = 17;
            this.lbMovies.Location = new System.Drawing.Point(16, 139);
            this.lbMovies.Name = "lbMovies";
            this.lbMovies.Size = new System.Drawing.Size(294, 412);
            this.lbMovies.TabIndex = 1;
            this.lbMovies.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbMovies_DrawItem);
            this.lbMovies.SelectedIndexChanged += new System.EventHandler(this.lbMovies_SelectedIndexChanged);
            // 
            // lblBorder
            // 
            this.lblBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBorder.Location = new System.Drawing.Point(0, 59);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(1135, 2);
            this.lblBorder.TabIndex = 4;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbSearch.Location = new System.Drawing.Point(16, 80);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(232, 23);
            this.tbSearch.TabIndex = 14;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(254, 81);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 52);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Go";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadMore
            // 
            this.btnLoadMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadMore.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnLoadMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadMore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMore.Location = new System.Drawing.Point(16, 557);
            this.btnLoadMore.Name = "btnLoadMore";
            this.btnLoadMore.Size = new System.Drawing.Size(294, 36);
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
            this.panelMovie.BackColor = System.Drawing.Color.Transparent;
            this.panelMovie.ColumnCount = 2;
            this.panelMovie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.panelMovie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMovie.Controls.Add(this.pbPoster, 0, 1);
            this.panelMovie.Controls.Add(this.lblDescription, 1, 1);
            this.panelMovie.Controls.Add(this.panelTitleInfo, 0, 0);
            this.panelMovie.Controls.Add(this.btnWatchTrailer, 0, 3);
            this.panelMovie.Controls.Add(this.lblCast, 0, 2);
            this.panelMovie.Controls.Add(this.btnRent, 1, 3);
            this.panelMovie.Location = new System.Drawing.Point(330, 80);
            this.panelMovie.MinimumSize = new System.Drawing.Size(500, 443);
            this.panelMovie.Name = "panelMovie";
            this.panelMovie.RowCount = 4;
            this.panelMovie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.panelMovie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 308F));
            this.panelMovie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMovie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.panelMovie.Size = new System.Drawing.Size(793, 516);
            this.panelMovie.TabIndex = 5;
            // 
            // pbPoster
            // 
            this.pbPoster.Location = new System.Drawing.Point(3, 66);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(194, 294);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 4;
            this.pbPoster.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(203, 63);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 17);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            // 
            // panelTitleInfo
            // 
            this.panelMovie.SetColumnSpan(this.panelTitleInfo, 2);
            this.panelTitleInfo.Controls.Add(this.lblVotes);
            this.panelTitleInfo.Controls.Add(this.lblRating);
            this.panelTitleInfo.Controls.Add(this.pictureBox2);
            this.panelTitleInfo.Controls.Add(this.lblInfo);
            this.panelTitleInfo.Controls.Add(this.lblMovieTitle);
            this.panelTitleInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.panelTitleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitleInfo.Location = new System.Drawing.Point(3, 3);
            this.panelTitleInfo.Name = "panelTitleInfo";
            this.panelTitleInfo.Size = new System.Drawing.Size(787, 57);
            this.panelTitleInfo.TabIndex = 6;
            // 
            // lblVotes
            // 
            this.lblVotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVotes.AutoSize = true;
            this.lblVotes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVotes.Location = new System.Drawing.Point(726, 27);
            this.lblVotes.Name = "lblVotes";
            this.lblVotes.Size = new System.Drawing.Size(32, 13);
            this.lblVotes.TabIndex = 4;
            this.lblVotes.Text = "Total";
            // 
            // lblRating
            // 
            this.lblRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(724, -3);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(37, 30);
            this.lblRating.TabIndex = 3;
            this.lblRating.Text = "10";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(678, -3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(3, 30);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(28, 15);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Info";
            // 
            // lblMovieTitle
            // 
            this.lblMovieTitle.AutoSize = true;
            this.lblMovieTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieTitle.Location = new System.Drawing.Point(1, -9);
            this.lblMovieTitle.Name = "lblMovieTitle";
            this.lblMovieTitle.Size = new System.Drawing.Size(56, 30);
            this.lblMovieTitle.TabIndex = 0;
            this.lblMovieTitle.Text = "Title";
            // 
            // btnWatchTrailer
            // 
            this.btnWatchTrailer.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnWatchTrailer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWatchTrailer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWatchTrailer.Location = new System.Drawing.Point(3, 477);
            this.btnWatchTrailer.Name = "btnWatchTrailer";
            this.btnWatchTrailer.Size = new System.Drawing.Size(128, 36);
            this.btnWatchTrailer.TabIndex = 5;
            this.btnWatchTrailer.Text = "Watch Trailer >";
            this.btnWatchTrailer.UseVisualStyleBackColor = true;
            this.btnWatchTrailer.Click += new System.EventHandler(this.btnWatchTrailer_Click);
            // 
            // lblCast
            // 
            this.lblCast.AutoSize = true;
            this.panelMovie.SetColumnSpan(this.lblCast, 2);
            this.lblCast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCast.Location = new System.Drawing.Point(3, 371);
            this.lblCast.Name = "lblCast";
            this.lblCast.Size = new System.Drawing.Size(30, 15);
            this.lblCast.TabIndex = 7;
            this.lblCast.Text = "Cast";
            // 
            // btnRent
            // 
            this.btnRent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRent.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRent.Image = ((System.Drawing.Image)(resources.GetObject("btnRent.Image")));
            this.btnRent.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRent.Location = new System.Drawing.Point(681, 477);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(109, 36);
            this.btnRent.TabIndex = 8;
            this.btnRent.Text = "Rent Movie";
            this.btnRent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // cbGenre
            // 
            this.cbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Items.AddRange(new object[] {
            "All"});
            this.cbGenre.Location = new System.Drawing.Point(16, 110);
            this.cbGenre.MaxDropDownItems = 100;
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(232, 23);
            this.cbGenre.TabIndex = 18;
            this.cbGenre.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbGenre_DrawItem);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toopStripLblSearchResults});
            this.statusStrip1.Location = new System.Drawing.Point(0, 599);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1135, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toopStripLblSearchResults
            // 
            this.toopStripLblSearchResults.Name = "toopStripLblSearchResults";
            this.toopStripLblSearchResults.Size = new System.Drawing.Size(82, 17);
            this.toopStripLblSearchResults.Text = "Search Results";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 621);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.panelMovie);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnLoadMore);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.lbMovies);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Видеотека";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMovie.ResumeLayout(false);
            this.panelMovie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            this.panelTitleInfo.ResumeLayout(false);
            this.panelTitleInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Panel panelTitleInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblCast;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblVotes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toopStripLblSearchResults;
    }
}

