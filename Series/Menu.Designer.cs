namespace Series
{
    partial class Menu
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
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEpisodWatched = new System.Windows.Forms.Button();
            this.btnSeasonWatched = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Season = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Episod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(50, 13);
            this.txtAdd.Multiline = true;
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(302, 30);
            this.txtAdd.TabIndex = 2;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Series.Properties.Resources.btnEdit;
            this.btnEdit.Location = new System.Drawing.Point(358, 183);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 30);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::Series.Properties.Resources.delete_16;
            this.btnDel.Location = new System.Drawing.Point(358, 219);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(30, 30);
            this.btnDel.TabIndex = 5;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEpisodWatched
            // 
            this.btnEpisodWatched.Image = global::Series.Properties.Resources.view;
            this.btnEpisodWatched.Location = new System.Drawing.Point(358, 86);
            this.btnEpisodWatched.Name = "btnEpisodWatched";
            this.btnEpisodWatched.Size = new System.Drawing.Size(30, 30);
            this.btnEpisodWatched.TabIndex = 4;
            this.btnEpisodWatched.UseVisualStyleBackColor = true;
            this.btnEpisodWatched.Click += new System.EventHandler(this.btnEpisodWatched_Click);
            // 
            // btnSeasonWatched
            // 
            this.btnSeasonWatched.Image = global::Series.Properties.Resources.select;
            this.btnSeasonWatched.Location = new System.Drawing.Point(358, 50);
            this.btnSeasonWatched.Name = "btnSeasonWatched";
            this.btnSeasonWatched.Size = new System.Drawing.Size(30, 30);
            this.btnSeasonWatched.TabIndex = 3;
            this.btnSeasonWatched.UseVisualStyleBackColor = true;
            this.btnSeasonWatched.Click += new System.EventHandler(this.btnSeasonWatched_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Series.Properties.Resources.add1;
            this.btnAdd.Location = new System.Drawing.Point(13, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Names,
            this.Season,
            this.Episod});
            this.dgvList.Location = new System.Drawing.Point(13, 49);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(339, 200);
            this.dgvList.TabIndex = 7;
            this.dgvList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Names
            // 
            this.Names.DataPropertyName = "Names";
            this.Names.HeaderText = "Names";
            this.Names.Name = "Names";
            this.Names.ReadOnly = true;
            // 
            // Season
            // 
            this.Season.DataPropertyName = "Season";
            this.Season.HeaderText = "Season";
            this.Season.Name = "Season";
            this.Season.ReadOnly = true;
            // 
            // Episod
            // 
            this.Episod.DataPropertyName = "Episod";
            this.Episod.HeaderText = "Episod";
            this.Episod.Name = "Episod";
            this.Episod.ReadOnly = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(359, 123);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(30, 30);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "[-]";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(396, 261);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEpisodWatched);
            this.Controls.Add(this.btnSeasonWatched);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.Button btnSeasonWatched;
        private System.Windows.Forms.Button btnEpisodWatched;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn Season;
        private System.Windows.Forms.DataGridViewTextBoxColumn Episod;
        private System.Windows.Forms.Button btnReset;        

    }
}

