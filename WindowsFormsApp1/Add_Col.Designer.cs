namespace WindowsFormsApp1
{
    partial class Add_Col
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Col));
            this.panel1 = new System.Windows.Forms.Panel();
            this.D_Col = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_T_Names = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Primary_key = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.D_Col);
            this.panel1.Controls.Add(this.Next);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.combo_T_Names);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 271);
            this.panel1.TabIndex = 0;
            this.panel1.Enter += new System.EventHandler(this.panel1_Enter);
            // 
            // D_Col
            // 
            this.D_Col.BackColor = System.Drawing.Color.Red;
            this.D_Col.FlatAppearance.BorderSize = 0;
            this.D_Col.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.D_Col.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D_Col.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.D_Col.Image = ((System.Drawing.Image)(resources.GetObject("D_Col.Image")));
            this.D_Col.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.D_Col.Location = new System.Drawing.Point(159, 219);
            this.D_Col.Name = "D_Col";
            this.D_Col.Size = new System.Drawing.Size(114, 49);
            this.D_Col.TabIndex = 2;
            this.D_Col.Text = "Delete Column";
            this.D_Col.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.D_Col.UseVisualStyleBackColor = false;
            this.D_Col.Click += new System.EventHandler(this.D_Col_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Next.FlatAppearance.BorderSize = 0;
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Next.Image = ((System.Drawing.Image)(resources.GetObject("Next.Image")));
            this.Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Next.Location = new System.Drawing.Point(499, 220);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 37);
            this.Next.TabIndex = 18;
            this.Next.Text = "Next";
            this.Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Select Table :";
            // 
            // combo_T_Names
            // 
            this.combo_T_Names.FormattingEnabled = true;
            this.combo_T_Names.Location = new System.Drawing.Point(99, 26);
            this.combo_T_Names.Name = "combo_T_Names";
            this.combo_T_Names.Size = new System.Drawing.Size(121, 21);
            this.combo_T_Names.TabIndex = 16;
            this.combo_T_Names.SelectedIndexChanged += new System.EventHandler(this.combo_T_Names_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_name,
            this.Data_type,
            this.Primary_key});
            this.dataGridView1.Location = new System.Drawing.Point(-3, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(482, 210);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Col_name
            // 
            this.Col_name.HeaderText = "Column Name";
            this.Col_name.Name = "Col_name";
            // 
            // Data_type
            // 
            this.Data_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Data_type.HeaderText = "Data Type";
            this.Data_type.Items.AddRange(new object[] {
            "int",
            "double",
            "long",
            "float",
            "string",
            "char"});
            this.Data_type.Name = "Data_type";
            this.Data_type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Data_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Primary_key
            // 
            this.Primary_key.HeaderText = "Set_primary";
            this.Primary_key.Name = "Primary_key";
            // 
            // Add_Col
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Add_Col";
            this.Size = new System.Drawing.Size(590, 271);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_T_Names;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button D_Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn Data_type;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Primary_key;
    }
}
