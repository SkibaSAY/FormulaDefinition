
namespace TeorVer_MaxSAT
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.KNF_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DetermineAlg_applyBtn = new System.Windows.Forms.Button();
            this.DetermineAlg_maxTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VerAlg_TryCount_K = new System.Windows.Forms.TextBox();
            this.VerAlg_applyBtn = new System.Windows.Forms.Button();
            this.NCountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.VerAlg_False_listBox = new System.Windows.Forms.ListBox();
            this.VerAlg_True_listBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.VerAlg_falseCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VerAlg_trueCountLabel = new System.Windows.Forms.Label();
            this.VerAlg_trueResultLabel = new System.Windows.Forms.Label();
            this.footerTable = new System.Windows.Forms.TableLayoutPanel();
            this.VerAlg_label = new System.Windows.Forms.Label();
            this.DetermineAlg_label = new System.Windows.Forms.Label();
            this.VerAlg_time_group = new System.Windows.Forms.GroupBox();
            this.VerAlg_time = new System.Windows.Forms.Label();
            this.DetermineAlg_time_group = new System.Windows.Forms.GroupBox();
            this.DetermineAlg_time = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DetermineAlg_trueCountLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Determine_Alg_falseCountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DetermineAlg_falseCountLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.VerAlgPodstanovka = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.footerTable.SuspendLayout();
            this.VerAlg_time_group.SuspendLayout();
            this.DetermineAlg_time_group.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // KNF_textBox
            // 
            this.KNF_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KNF_textBox.Location = new System.Drawing.Point(117, 28);
            this.KNF_textBox.MaxLength = 999970000;
            this.KNF_textBox.Name = "KNF_textBox";
            this.KNF_textBox.Size = new System.Drawing.Size(235, 20);
            this.KNF_textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите КНФ";
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(182, 66);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(92, 23);
            this.generateBtn.TabIndex = 3;
            this.generateBtn.Text = "Сгенерировать";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label10);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Controls.Add(this.DetermineAlg_applyBtn);
            this.groupBox.Controls.Add(this.DetermineAlg_maxTime);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.VerAlg_TryCount_K);
            this.groupBox.Controls.Add(this.VerAlg_applyBtn);
            this.groupBox.Controls.Add(this.NCountTextBox);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.generateBtn);
            this.groupBox.Controls.Add(this.KNF_textBox);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(800, 103);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(365, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Детерминированный алг:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(395, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Вероятностный алг:";
            // 
            // DetermineAlg_applyBtn
            // 
            this.DetermineAlg_applyBtn.Location = new System.Drawing.Point(697, 65);
            this.DetermineAlg_applyBtn.Name = "DetermineAlg_applyBtn";
            this.DetermineAlg_applyBtn.Size = new System.Drawing.Size(91, 25);
            this.DetermineAlg_applyBtn.TabIndex = 11;
            this.DetermineAlg_applyBtn.Text = "Применить";
            this.DetermineAlg_applyBtn.UseVisualStyleBackColor = true;
            // 
            // DetermineAlg_maxTime
            // 
            this.DetermineAlg_maxTime.Location = new System.Drawing.Point(635, 68);
            this.DetermineAlg_maxTime.Name = "DetermineAlg_maxTime";
            this.DetermineAlg_maxTime.Size = new System.Drawing.Size(55, 20);
            this.DetermineAlg_maxTime.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Время ожидания (сек)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Количество попыток K";
            // 
            // VerAlg_TryCount_K
            // 
            this.VerAlg_TryCount_K.Location = new System.Drawing.Point(635, 27);
            this.VerAlg_TryCount_K.Name = "VerAlg_TryCount_K";
            this.VerAlg_TryCount_K.Size = new System.Drawing.Size(55, 20);
            this.VerAlg_TryCount_K.TabIndex = 7;
            // 
            // VerAlg_applyBtn
            // 
            this.VerAlg_applyBtn.Location = new System.Drawing.Point(697, 24);
            this.VerAlg_applyBtn.Name = "VerAlg_applyBtn";
            this.VerAlg_applyBtn.Size = new System.Drawing.Size(91, 25);
            this.VerAlg_applyBtn.TabIndex = 6;
            this.VerAlg_applyBtn.Text = "Применить";
            this.VerAlg_applyBtn.UseVisualStyleBackColor = true;
            this.VerAlg_applyBtn.Click += new System.EventHandler(this.VerAlg_applyBtn_Click);
            // 
            // NCountTextBox
            // 
            this.NCountTextBox.Location = new System.Drawing.Point(135, 68);
            this.NCountTextBox.Name = "NCountTextBox";
            this.NCountTextBox.Size = new System.Drawing.Size(41, 20);
            this.NCountTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Число переменных в ()";
            // 
            // VerAlg_False_listBox
            // 
            this.VerAlg_False_listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerAlg_False_listBox.FormattingEnabled = true;
            this.VerAlg_False_listBox.Location = new System.Drawing.Point(3, 186);
            this.VerAlg_False_listBox.Name = "VerAlg_False_listBox";
            this.VerAlg_False_listBox.Size = new System.Drawing.Size(393, 56);
            this.VerAlg_False_listBox.TabIndex = 5;
            // 
            // VerAlg_True_listBox
            // 
            this.VerAlg_True_listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerAlg_True_listBox.FormattingEnabled = true;
            this.VerAlg_True_listBox.Location = new System.Drawing.Point(3, 59);
            this.VerAlg_True_listBox.Name = "VerAlg_True_listBox";
            this.VerAlg_True_listBox.Size = new System.Drawing.Size(393, 79);
            this.VerAlg_True_listBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.VerAlg_falseCountLabel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 37);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "НЕ_Выполненные дизьюнкты";
            // 
            // VerAlg_falseCountLabel
            // 
            this.VerAlg_falseCountLabel.AutoSize = true;
            this.VerAlg_falseCountLabel.Location = new System.Drawing.Point(100, 13);
            this.VerAlg_falseCountLabel.Name = "VerAlg_falseCountLabel";
            this.VerAlg_falseCountLabel.Size = new System.Drawing.Size(13, 13);
            this.VerAlg_falseCountLabel.TabIndex = 2;
            this.VerAlg_falseCountLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Итог:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VerAlg_trueCountLabel);
            this.groupBox1.Controls.Add(this.VerAlg_trueResultLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 36);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выполненные дизьюнкты";
            // 
            // VerAlg_trueCountLabel
            // 
            this.VerAlg_trueCountLabel.AutoSize = true;
            this.VerAlg_trueCountLabel.Location = new System.Drawing.Point(100, 13);
            this.VerAlg_trueCountLabel.Name = "VerAlg_trueCountLabel";
            this.VerAlg_trueCountLabel.Size = new System.Drawing.Size(13, 13);
            this.VerAlg_trueCountLabel.TabIndex = 1;
            this.VerAlg_trueCountLabel.Text = "0";
            // 
            // VerAlg_trueResultLabel
            // 
            this.VerAlg_trueResultLabel.AutoSize = true;
            this.VerAlg_trueResultLabel.Location = new System.Drawing.Point(60, 13);
            this.VerAlg_trueResultLabel.Name = "VerAlg_trueResultLabel";
            this.VerAlg_trueResultLabel.Size = new System.Drawing.Size(34, 13);
            this.VerAlg_trueResultLabel.TabIndex = 0;
            this.VerAlg_trueResultLabel.Text = "Итог:";
            // 
            // footerTable
            // 
            this.footerTable.ColumnCount = 2;
            this.footerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.875F));
            this.footerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.125F));
            this.footerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 276F));
            this.footerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.footerTable.Controls.Add(this.groupBox4, 1, 4);
            this.footerTable.Controls.Add(this.VerAlg_label, 0, 0);
            this.footerTable.Controls.Add(this.VerAlg_True_listBox, 0, 1);
            this.footerTable.Controls.Add(this.DetermineAlg_label, 1, 0);
            this.footerTable.Controls.Add(this.VerAlg_time_group, 0, 6);
            this.footerTable.Controls.Add(this.DetermineAlg_time_group, 1, 6);
            this.footerTable.Controls.Add(this.groupBox1, 0, 2);
            this.footerTable.Controls.Add(this.groupBox3, 1, 2);
            this.footerTable.Controls.Add(this.VerAlg_False_listBox, 0, 3);
            this.footerTable.Controls.Add(this.groupBox2, 0, 4);
            this.footerTable.Controls.Add(this.VerAlgPodstanovka, 0, 5);
            this.footerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerTable.Location = new System.Drawing.Point(0, 103);
            this.footerTable.Name = "footerTable";
            this.footerTable.RowCount = 7;
            this.footerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.62264F));
            this.footerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.37736F));
            this.footerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.footerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.footerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.footerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.footerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.footerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.footerTable.Size = new System.Drawing.Size(800, 347);
            this.footerTable.TabIndex = 7;
            // 
            // VerAlg_label
            // 
            this.VerAlg_label.AutoSize = true;
            this.VerAlg_label.Location = new System.Drawing.Point(3, 0);
            this.VerAlg_label.Name = "VerAlg_label";
            this.VerAlg_label.Size = new System.Drawing.Size(137, 13);
            this.VerAlg_label.TabIndex = 6;
            this.VerAlg_label.Text = "Вероятностный алгоритм";
            // 
            // DetermineAlg_label
            // 
            this.DetermineAlg_label.AutoSize = true;
            this.DetermineAlg_label.Location = new System.Drawing.Point(402, 0);
            this.DetermineAlg_label.Name = "DetermineAlg_label";
            this.DetermineAlg_label.Size = new System.Drawing.Size(145, 13);
            this.DetermineAlg_label.TabIndex = 7;
            this.DetermineAlg_label.Text = "Перебор всех подстановок";
            // 
            // VerAlg_time_group
            // 
            this.VerAlg_time_group.Controls.Add(this.VerAlg_time);
            this.VerAlg_time_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerAlg_time_group.Location = new System.Drawing.Point(3, 317);
            this.VerAlg_time_group.Name = "VerAlg_time_group";
            this.VerAlg_time_group.Size = new System.Drawing.Size(393, 27);
            this.VerAlg_time_group.TabIndex = 8;
            this.VerAlg_time_group.TabStop = false;
            this.VerAlg_time_group.Text = "Время";
            // 
            // VerAlg_time
            // 
            this.VerAlg_time.AutoSize = true;
            this.VerAlg_time.Location = new System.Drawing.Point(6, 16);
            this.VerAlg_time.Name = "VerAlg_time";
            this.VerAlg_time.Size = new System.Drawing.Size(13, 13);
            this.VerAlg_time.TabIndex = 3;
            this.VerAlg_time.Text = "0";
            // 
            // DetermineAlg_time_group
            // 
            this.DetermineAlg_time_group.Controls.Add(this.DetermineAlg_time);
            this.DetermineAlg_time_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetermineAlg_time_group.Location = new System.Drawing.Point(402, 317);
            this.DetermineAlg_time_group.Name = "DetermineAlg_time_group";
            this.DetermineAlg_time_group.Size = new System.Drawing.Size(395, 27);
            this.DetermineAlg_time_group.TabIndex = 9;
            this.DetermineAlg_time_group.TabStop = false;
            this.DetermineAlg_time_group.Text = "Время";
            // 
            // DetermineAlg_time
            // 
            this.DetermineAlg_time.AutoSize = true;
            this.DetermineAlg_time.Location = new System.Drawing.Point(6, 16);
            this.DetermineAlg_time.Name = "DetermineAlg_time";
            this.DetermineAlg_time.Size = new System.Drawing.Size(13, 13);
            this.DetermineAlg_time.TabIndex = 3;
            this.DetermineAlg_time.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DetermineAlg_trueCountLabel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(402, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 36);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Выполненные дизьюнкты";
            // 
            // DetermineAlg_trueCountLabel
            // 
            this.DetermineAlg_trueCountLabel.AutoSize = true;
            this.DetermineAlg_trueCountLabel.Location = new System.Drawing.Point(100, 13);
            this.DetermineAlg_trueCountLabel.Name = "DetermineAlg_trueCountLabel";
            this.DetermineAlg_trueCountLabel.Size = new System.Drawing.Size(13, 13);
            this.DetermineAlg_trueCountLabel.TabIndex = 1;
            this.DetermineAlg_trueCountLabel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Итог:";
            // 
            // Determine_Alg_falseCountLabel
            // 
            this.Determine_Alg_falseCountLabel.AutoSize = true;
            this.Determine_Alg_falseCountLabel.Location = new System.Drawing.Point(100, 13);
            this.Determine_Alg_falseCountLabel.Name = "Determine_Alg_falseCountLabel";
            this.Determine_Alg_falseCountLabel.Size = new System.Drawing.Size(13, 13);
            this.Determine_Alg_falseCountLabel.TabIndex = 2;
            this.Determine_Alg_falseCountLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Итог:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DetermineAlg_falseCountLabel);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(402, 248);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(395, 37);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "НЕ_Выполненные дизьюнкты";
            // 
            // DetermineAlg_falseCountLabel
            // 
            this.DetermineAlg_falseCountLabel.AutoSize = true;
            this.DetermineAlg_falseCountLabel.Location = new System.Drawing.Point(100, 13);
            this.DetermineAlg_falseCountLabel.Name = "DetermineAlg_falseCountLabel";
            this.DetermineAlg_falseCountLabel.Size = new System.Drawing.Size(13, 13);
            this.DetermineAlg_falseCountLabel.TabIndex = 2;
            this.DetermineAlg_falseCountLabel.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Итог:";
            // 
            // VerAlgPodstanovka
            // 
            this.VerAlgPodstanovka.AutoSize = true;
            this.VerAlgPodstanovka.Location = new System.Drawing.Point(3, 288);
            this.VerAlgPodstanovka.Name = "VerAlgPodstanovka";
            this.VerAlgPodstanovka.Size = new System.Drawing.Size(15, 13);
            this.VerAlgPodstanovka.TabIndex = 11;
            this.VerAlgPodstanovka.Text = "{}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.footerTable);
            this.Controls.Add(this.groupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.footerTable.ResumeLayout(false);
            this.footerTable.PerformLayout();
            this.VerAlg_time_group.ResumeLayout(false);
            this.VerAlg_time_group.PerformLayout();
            this.DetermineAlg_time_group.ResumeLayout(false);
            this.DetermineAlg_time_group.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox KNF_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox NCountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button VerAlg_applyBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label VerAlg_falseCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label VerAlg_trueCountLabel;
        private System.Windows.Forms.Label VerAlg_trueResultLabel;
        private System.Windows.Forms.ListBox VerAlg_False_listBox;
        private System.Windows.Forms.ListBox VerAlg_True_listBox;
        private System.Windows.Forms.TableLayoutPanel footerTable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label DetermineAlg_trueCountLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Determine_Alg_falseCountLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox DetermineAlg_time_group;
        private System.Windows.Forms.Label DetermineAlg_time;
        private System.Windows.Forms.Label VerAlg_label;
        private System.Windows.Forms.Label DetermineAlg_label;
        private System.Windows.Forms.GroupBox VerAlg_time_group;
        private System.Windows.Forms.Label VerAlg_time;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button DetermineAlg_applyBtn;
        private System.Windows.Forms.TextBox DetermineAlg_maxTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VerAlg_TryCount_K;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label DetermineAlg_falseCountLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label VerAlgPodstanovka;
    }
}

