namespace Game_engine
{
    partial class Minesweeper
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
            this.mines = new System.Windows.Forms.NumericUpDown();
            this.sizeX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.seed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mineMarksLeft = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeX)).BeginInit();
            this.SuspendLayout();
            // 
            // mines
            // 
            this.mines.Location = new System.Drawing.Point(12, 36);
            this.mines.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.mines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mines.Name = "mines";
            this.mines.Size = new System.Drawing.Size(120, 20);
            this.mines.TabIndex = 0;
            this.mines.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // sizeX
            // 
            this.sizeX.Location = new System.Drawing.Point(138, 36);
            this.sizeX.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sizeX.Name = "sizeX";
            this.sizeX.Size = new System.Drawing.Size(120, 20);
            this.sizeX.TabIndex = 2;
            this.sizeX.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of mines";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(135, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Size (both X and Y)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // seed
            // 
            this.seed.AllowDrop = true;
            this.seed.Location = new System.Drawing.Point(363, 35);
            this.seed.Name = "seed";
            this.seed.Size = new System.Drawing.Size(186, 20);
            this.seed.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(360, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Seed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(572, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mine marks left:";
            // 
            // mineMarksLeft
            // 
            this.mineMarksLeft.AutoSize = true;
            this.mineMarksLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mineMarksLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mineMarksLeft.Location = new System.Drawing.Point(575, 36);
            this.mineMarksLeft.Name = "mineMarksLeft";
            this.mineMarksLeft.Size = new System.Drawing.Size(29, 22);
            this.mineMarksLeft.TabIndex = 10;
            this.mineMarksLeft.Text = "40";
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.mineMarksLeft);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seed);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeX);
            this.Controls.Add(this.mines);
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Minesweeper_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Minesweeper_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.mines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown mines;
        private System.Windows.Forms.NumericUpDown sizeX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox seed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label mineMarksLeft;
    }
}