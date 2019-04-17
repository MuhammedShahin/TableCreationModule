namespace WindowsFormsApp1
{
    partial class Create_T
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create_T));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.C = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.Col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Primary_key = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(462, 268);
            this.dataGridView1.TabIndex = 12;
            // 
            // C
            // 
            this.C.BackColor = System.Drawing.SystemColors.ControlDark;
            this.C.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.C.FlatAppearance.BorderSize = 0;
            this.C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            this.C.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.C.Image = ((System.Drawing.Image)(resources.GetObject("C.Image")));
            this.C.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.C.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.C.Location = new System.Drawing.Point(469, 201);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(128, 67);
            this.C.TabIndex = 13;
            this.C.Text = "Create Table";
            this.C.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.C.UseVisualStyleBackColor = false;
            this.C.Click += new System.EventHandler(this.C_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel.Controls.Add(this.C);
            this.panel.Controls.Add(this.dataGridView1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(612, 285);
            this.panel.TabIndex = 10;
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
            "char",
            "date"});
            this.Data_type.Name = "Data_type";
            this.Data_type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Data_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Primary_key
            // 
            this.Primary_key.HeaderText = "Set_primary";
            this.Primary_key.Name = "Primary_key";
            // 
            // Create_T
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "Create_T";
            this.Size = new System.Drawing.Size(612, 285);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn Data_type;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Primary_key;
    }
}
