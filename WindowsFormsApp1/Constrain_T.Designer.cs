namespace WindowsFormsApp1
{
    partial class Constrain_T
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Constrain_T));
            this.panel2 = new System.Windows.Forms.Panel();
            this.Add_Const = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_value = new System.Windows.Forms.TextBox();
            this.Combo_const = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_col_Create = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Add_Const);
            this.panel2.Location = new System.Drawing.Point(457, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 55);
            this.panel2.TabIndex = 22;
            // 
            // Add_Const
            // 
            this.Add_Const.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Add_Const.FlatAppearance.BorderSize = 0;
            this.Add_Const.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_Const.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Const.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Add_Const.Image = ((System.Drawing.Image)(resources.GetObject("Add_Const.Image")));
            this.Add_Const.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Add_Const.Location = new System.Drawing.Point(0, 0);
            this.Add_Const.Name = "Add_Const";
            this.Add_Const.Size = new System.Drawing.Size(90, 29);
            this.Add_Const.TabIndex = 16;
            this.Add_Const.Text = "Add More";
            this.Add_Const.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add_Const.UseVisualStyleBackColor = false;
            this.Add_Const.Click += new System.EventHandler(this.Add_Const_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(162, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Value :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Constrain :";
            // 
            // textBox_value
            // 
            this.textBox_value.Location = new System.Drawing.Point(246, 142);
            this.textBox_value.Name = "textBox_value";
            this.textBox_value.Size = new System.Drawing.Size(100, 20);
            this.textBox_value.TabIndex = 19;
            // 
            // Combo_const
            // 
            this.Combo_const.FormattingEnabled = true;
            this.Combo_const.Items.AddRange(new object[] {
            "<",
            ">",
            "=",
            "!=",
            ">=",
            "<=",
            "uni",
            "Auto"});
            this.Combo_const.Location = new System.Drawing.Point(246, 98);
            this.Combo_const.Name = "Combo_const";
            this.Combo_const.Size = new System.Drawing.Size(121, 21);
            this.Combo_const.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Select Column :";
            // 
            // comboBox_col_Create
            // 
            this.comboBox_col_Create.FormattingEnabled = true;
            this.comboBox_col_Create.Location = new System.Drawing.Point(246, 48);
            this.comboBox_col_Create.Name = "comboBox_col_Create";
            this.comboBox_col_Create.Size = new System.Drawing.Size(121, 21);
            this.comboBox_col_Create.TabIndex = 23;
            this.comboBox_col_Create.SelectedIndexChanged += new System.EventHandler(this.comboBox_col_Create_SelectedIndexChanged);
            // 
            // Constrain_T
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_col_Create);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_value);
            this.Controls.Add(this.Combo_const);
            this.Name = "Constrain_T";
            this.Size = new System.Drawing.Size(612, 285);
            this.Load += new System.EventHandler(this.Constrain_T_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Add_Const;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_value;
        private System.Windows.Forms.ComboBox Combo_const;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_col_Create;
    }
}
