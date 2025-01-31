namespace bik
{
    partial class BikeStoreApp
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
            comboBox1 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            sales = new Button();
            button3 = new Button();
            comboBox4 = new ComboBox();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(209, 63);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(184, 49);
            comboBox1.TabIndex = 0;
            // 
            // comboBox3
            // 
            comboBox3.AllowDrop = true;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(635, 63);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(212, 49);
            comboBox3.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(421, 63);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(184, 49);
            comboBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(421, 147);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(194, 47);
            textBox1.TabIndex = 4;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(804, 228);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(231, 47);
            textBox2.TabIndex = 5;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(800, 144);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(235, 47);
            textBox3.TabIndex = 6;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(421, 231);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(194, 47);
            textBox4.TabIndex = 7;
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(1176, 231);
            button1.Name = "button1";
            button1.Size = new Size(188, 47);
            button1.TabIndex = 8;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(182, 41);
            label1.TabIndex = 9;
            label1.Text = "Choose Bike";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 153);
            label2.Name = "label2";
            label2.Size = new Size(207, 41);
            label2.TabIndex = 10;
            label2.Text = "Customer Info";
            // 
            // sales
            // 
            sales.Location = new Point(1176, 366);
            sales.Name = "sales";
            sales.Size = new Size(188, 97);
            sales.TabIndex = 11;
            sales.Text = "Customer History";
            sales.UseVisualStyleBackColor = true;
            sales.Click += sales_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1176, 507);
            button3.Name = "button3";
            button3.Size = new Size(188, 94);
            button3.TabIndex = 12;
            button3.Text = "Today's Sales";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(932, 657);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(228, 49);
            comboBox4.TabIndex = 13;
            comboBox4.Text = "Choose Year";
            // 
            // button2
            // 
            button2.Location = new Point(1176, 656);
            button2.Name = "button2";
            button2.Size = new Size(188, 49);
            button2.TabIndex = 14;
            button2.Text = "Submit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 331);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 102;
            dataGridView1.Size = new Size(881, 375);
            dataGridView1.TabIndex = 15;
            // 
            // button4
            // 
            button4.Location = new Point(22, 757);
            button4.Name = "button4";
            button4.Size = new Size(188, 58);
            button4.TabIndex = 16;
            button4.Text = "Inventory";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 150);
            label3.Name = "label3";
            label3.Size = new Size(97, 41);
            label3.TabIndex = 17;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(236, 231);
            label4.Name = "label4";
            label4.Size = new Size(157, 41);
            label4.TabIndex = 18;
            label4.Text = "Last Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(673, 150);
            label5.Name = "label5";
            label5.Size = new Size(103, 41);
            label5.TabIndex = 19;
            label5.Text = "Phone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(673, 231);
            label6.Name = "label6";
            label6.Size = new Size(125, 41);
            label6.TabIndex = 20;
            label6.Text = "Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(209, 9);
            label7.Name = "label7";
            label7.Size = new Size(144, 41);
            label7.TabIndex = 21;
            label7.Text = "Bike Type";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(421, 9);
            label8.Name = "label8";
            label8.Size = new Size(134, 41);
            label8.TabIndex = 22;
            label8.Text = "Bike Size";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(635, 9);
            label9.Name = "label9";
            label9.Size = new Size(153, 41);
            label9.TabIndex = 23;
            label9.Text = "Bike Color";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(897, 9);
            label10.Name = "label10";
            label10.Size = new Size(125, 41);
            label10.TabIndex = 24;
            label10.Text = "Amount";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(897, 63);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(151, 47);
            textBox5.TabIndex = 25;
            // 
            // BikeStoreApp
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuBar;
            ClientSize = new Size(1443, 947);
            Controls.Add(textBox5);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(comboBox4);
            Controls.Add(button3);
            Controls.Add(sales);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox3);
            Controls.Add(comboBox1);
            Name = "BikeStoreApp";
            Text = "Bike Store App";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Label label1;
        private Label label2;
        private Button sales;
        private Button button3;
        private ComboBox comboBox4;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button4;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox5;
    }
}
