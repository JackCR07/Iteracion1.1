namespace Vista
{
    partial class Eliminar_Servicio
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
            this.button_Si = new System.Windows.Forms.Button();
            this.button_No = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Si
            // 
            this.button_Si.BackColor = System.Drawing.Color.OliveDrab;
            this.button_Si.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Si.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Si.Location = new System.Drawing.Point(69, 168);
            this.button_Si.Name = "button_Si";
            this.button_Si.Size = new System.Drawing.Size(186, 33);
            this.button_Si.TabIndex = 0;
            this.button_Si.Text = "Si";
            this.button_Si.UseVisualStyleBackColor = false;
            this.button_Si.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_No
            // 
            this.button_No.BackColor = System.Drawing.Color.OliveDrab;
            this.button_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_No.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_No.Location = new System.Drawing.Point(368, 168);
            this.button_No.Name = "button_No";
            this.button_No.Size = new System.Drawing.Size(186, 33);
            this.button_No.TabIndex = 1;
            this.button_No.Text = "No";
            this.button_No.UseVisualStyleBackColor = false;
            this.button_No.Click += new System.EventHandler(this.button_No_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "¿Está seguro que desea eliminar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "este servicio?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.Precaucion2;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(34, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 72);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Eliminar_Servicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(614, 243);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_No);
            this.Controls.Add(this.button_Si);
            this.Name = "Eliminar_Servicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Servicio";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Si;
        private System.Windows.Forms.Button button_No;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}