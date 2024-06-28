namespace HeavyTruckApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label6 = new Label();
            textBox5 = new TextBox();
            label7 = new Label();
            textBox6 = new TextBox();
            button6 = new Button();
            button7 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox2 = new TextBox();
            textBox7 = new TextBox();
            label8 = new Label();
            button3 = new Button();
            comboBox3 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(522, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(943, 744);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(33, 77);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(180, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 23);
            textBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(429, 77);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Upload";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(202, 30);
            label1.Name = "label1";
            label1.Size = new Size(159, 21);
            label1.TabIndex = 4;
            label1.Text = "Newest EDI to upload";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(180, 165);
            label2.Name = "label2";
            label2.Size = new Size(212, 21);
            label2.TabIndex = 8;
            label2.Text = "Insert Planned jobs to Master";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(180, 312);
            label6.Name = "label6";
            label6.Size = new Size(187, 21);
            label6.TabIndex = 15;
            label6.Text = "Change status to Shipped";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(145, 345);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(107, 23);
            textBox5.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(263, 352);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 17;
            label7.Text = "thru";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(298, 344);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(107, 23);
            textBox6.TabIndex = 18;
            // 
            // button6
            // 
            button6.BackColor = Color.SteelBlue;
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(405, 457);
            button6.Name = "button6";
            button6.Size = new Size(99, 23);
            button6.TabIndex = 19;
            button6.Text = "GO";
            button6.UseVisualStyleBackColor = false;
            button6.Click += Button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.LawnGreen;
            button7.Location = new Point(429, 344);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 21;
            button7.Text = "Shipped";
            button7.UseVisualStyleBackColor = false;
            button7.Click += Button7_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(383, 428);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 22;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 217);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 23;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(145, 217);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(107, 23);
            textBox2.TabIndex = 24;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(298, 217);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(107, 23);
            textBox7.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(263, 224);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 26;
            label8.Text = "thru";
            // 
            // button3
            // 
            button3.BackColor = Color.Yellow;
            button3.Location = new Point(429, 216);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 27;
            button3.Text = "Planned";
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(12, 344);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 28;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1491, 765);
            Controls.Add(comboBox3);
            Controls.Add(button3);
            Controls.Add(label8);
            Controls.Add(textBox7);
            Controls.Add(textBox2);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(textBox6);
            Controls.Add(label7);
            Controls.Add(textBox5);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label6;
        private TextBox textBox5;
        private Label label7;
        private TextBox textBox6;
        private Button button6;
        private Button button7;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox textBox2;
        private TextBox textBox7;
        private Label label8;
        private Button button3;
        private ComboBox comboBox3;
    }
}
