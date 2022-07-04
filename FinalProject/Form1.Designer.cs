namespace FinalProject
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
            this.button1 = new System.Windows.Forms.Button();
            this.drugOrDiseaseCombo = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.DrugStorePanel = new System.Windows.Forms.ListBox();
            this.checkAlergyButton = new System.Windows.Forms.Button();
            this.checkAlergyInput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addDiseaseButton = new System.Windows.Forms.Button();
            this.addDiseaseInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addDrugButton = new System.Windows.Forms.Button();
            this.addDrugInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.priceIncreaseButton = new System.Windows.Forms.Button();
            this.priceIncreaseInput = new System.Windows.Forms.TextBox();
            this.positiveDrugsInput = new System.Windows.Forms.Button();
            this.writeFilesButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(795, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "شروع به خواندن فایل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // drugOrDiseaseCombo
            // 
            this.drugOrDiseaseCombo.FormattingEnabled = true;
            this.drugOrDiseaseCombo.Items.AddRange(new object[] {
            "Diseases",
            "Drugs"});
            this.drugOrDiseaseCombo.Location = new System.Drawing.Point(25, 21);
            this.drugOrDiseaseCombo.Name = "drugOrDiseaseCombo";
            this.drugOrDiseaseCombo.Size = new System.Drawing.Size(151, 28);
            this.drugOrDiseaseCombo.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(216, 21);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(223, 27);
            this.searchBox.TabIndex = 2;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // DrugStorePanel
            // 
            this.DrugStorePanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DrugStorePanel.ForeColor = System.Drawing.Color.Navy;
            this.DrugStorePanel.FormattingEnabled = true;
            this.DrugStorePanel.HorizontalScrollbar = true;
            this.DrugStorePanel.ItemHeight = 20;
            this.DrugStorePanel.Location = new System.Drawing.Point(25, 57);
            this.DrugStorePanel.Name = "DrugStorePanel";
            this.DrugStorePanel.Size = new System.Drawing.Size(414, 544);
            this.DrugStorePanel.TabIndex = 3;
            this.DrugStorePanel.SelectedIndexChanged += new System.EventHandler(this.DrugStorePanel_SelectedIndexChanged);
            // 
            // checkAlergyButton
            // 
            this.checkAlergyButton.Location = new System.Drawing.Point(436, 57);
            this.checkAlergyButton.Name = "checkAlergyButton";
            this.checkAlergyButton.Size = new System.Drawing.Size(244, 73);
            this.checkAlergyButton.TabIndex = 4;
            this.checkAlergyButton.Text = "حساسیت دارو با بیماری، داروی خود را سرچ کنید\r\nو این دکمه را بزنید\r\n";
            this.checkAlergyButton.UseVisualStyleBackColor = true;
            this.checkAlergyButton.Click += new System.EventHandler(this.checkAlergyButton_Click);
            // 
            // checkAlergyInput
            // 
            this.checkAlergyInput.Location = new System.Drawing.Point(436, 127);
            this.checkAlergyInput.Name = "checkAlergyInput";
            this.checkAlergyInput.Size = new System.Drawing.Size(244, 27);
            this.checkAlergyInput.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addDiseaseButton);
            this.panel1.Controls.Add(this.addDiseaseInput);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.addDrugButton);
            this.panel1.Controls.Add(this.addDrugInput);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(681, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 544);
            this.panel1.TabIndex = 6;
            // 
            // addDiseaseButton
            // 
            this.addDiseaseButton.Location = new System.Drawing.Point(69, 377);
            this.addDiseaseButton.Name = "addDiseaseButton";
            this.addDiseaseButton.Size = new System.Drawing.Size(112, 29);
            this.addDiseaseButton.TabIndex = 7;
            this.addDiseaseButton.Text = "Add disease\r\n\r\n";
            this.addDiseaseButton.UseVisualStyleBackColor = true;
            this.addDiseaseButton.Click += new System.EventHandler(this.addDiseaseButton_Click);
            // 
            // addDiseaseInput
            // 
            this.addDiseaseInput.Location = new System.Drawing.Point(37, 344);
            this.addDiseaseInput.Name = "addDiseaseInput";
            this.addDiseaseInput.Size = new System.Drawing.Size(169, 27);
            this.addDiseaseInput.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "<name>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "اضافه کردن به بیماری به فرم \r\n";
            // 
            // addDrugButton
            // 
            this.addDrugButton.Location = new System.Drawing.Point(69, 113);
            this.addDrugButton.Name = "addDrugButton";
            this.addDrugButton.Size = new System.Drawing.Size(94, 29);
            this.addDrugButton.TabIndex = 3;
            this.addDrugButton.Text = "Add drug";
            this.addDrugButton.UseVisualStyleBackColor = true;
            this.addDrugButton.Click += new System.EventHandler(this.addDrugButton_Click);
            // 
            // addDrugInput
            // 
            this.addDrugInput.Location = new System.Drawing.Point(37, 80);
            this.addDrugInput.Name = "addDrugInput";
            this.addDrugInput.Size = new System.Drawing.Size(169, 27);
            this.addDrugInput.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "<name> : <price>\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "اضافه کردن دارو به فرم\r\n\r\n";
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.Location = new System.Drawing.Point(436, 222);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(94, 29);
            this.deleteItemButton.TabIndex = 7;
            this.deleteItemButton.Text = "حذف مورد";
            this.deleteItemButton.UseVisualStyleBackColor = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // priceIncreaseButton
            // 
            this.priceIncreaseButton.Location = new System.Drawing.Point(436, 308);
            this.priceIncreaseButton.Name = "priceIncreaseButton";
            this.priceIncreaseButton.Size = new System.Drawing.Size(165, 82);
            this.priceIncreaseButton.TabIndex = 8;
            this.priceIncreaseButton.Text = "افزایش قیمت داروها با درصد تورم\r\nدرصد تورم را وارد کنید\r\n";
            this.priceIncreaseButton.UseVisualStyleBackColor = true;
            this.priceIncreaseButton.Click += new System.EventHandler(this.priceIncreaseButton_Click);
            // 
            // priceIncreaseInput
            // 
            this.priceIncreaseInput.Location = new System.Drawing.Point(436, 387);
            this.priceIncreaseInput.Name = "priceIncreaseInput";
            this.priceIncreaseInput.Size = new System.Drawing.Size(165, 27);
            this.priceIncreaseInput.TabIndex = 9;
            // 
            // positiveDrugsInput
            // 
            this.positiveDrugsInput.Location = new System.Drawing.Point(436, 460);
            this.positiveDrugsInput.Name = "positiveDrugsInput";
            this.positiveDrugsInput.Size = new System.Drawing.Size(192, 111);
            this.positiveDrugsInput.TabIndex = 10;
            this.positiveDrugsInput.Text = "با کلیک بر این دکمه لیست داروهایی را\r\nکه بر بیماری انتخاب شده تاثیر مثبت\r\nدارند ر" +
    "ا دریافت کنید\r\n";
            this.positiveDrugsInput.UseVisualStyleBackColor = true;
            this.positiveDrugsInput.Click += new System.EventHandler(this.positiveDrugsInput_Click);
            // 
            // writeFilesButton
            // 
            this.writeFilesButton.Location = new System.Drawing.Point(681, 8);
            this.writeFilesButton.Name = "writeFilesButton";
            this.writeFilesButton.Size = new System.Drawing.Size(108, 48);
            this.writeFilesButton.TabIndex = 11;
            this.writeFilesButton.Text = "ذخیره تغییرات\r\n\r\n";
            this.writeFilesButton.UseVisualStyleBackColor = true;
            this.writeFilesButton.Click += new System.EventHandler(this.writeFilesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::FinalProject.Properties.Resources.dark;
            this.ClientSize = new System.Drawing.Size(927, 612);
            this.Controls.Add(this.writeFilesButton);
            this.Controls.Add(this.positiveDrugsInput);
            this.Controls.Add(this.priceIncreaseInput);
            this.Controls.Add(this.priceIncreaseButton);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkAlergyInput);
            this.Controls.Add(this.checkAlergyButton);
            this.Controls.Add(this.DrugStorePanel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.drugOrDiseaseCombo);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private ComboBox drugOrDiseaseCombo;
        private TextBox searchBox;
        private ListBox DrugStorePanel;
        private Button checkAlergyButton;
        private TextBox checkAlergyInput;
        private Panel panel1;
        private Button addDrugButton;
        private TextBox addDrugInput;
        private Label label2;
        private Label label1;
        private Button addDiseaseButton;
        private TextBox addDiseaseInput;
        private Label label4;
        private Label label3;
        private Button deleteItemButton;
        private Button priceIncreaseButton;
        private TextBox priceIncreaseInput;
        private Button positiveDrugsInput;
        private Button writeFilesButton;
    }
}