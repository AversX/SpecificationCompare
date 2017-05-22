namespace SpecificationCompare
{
    partial class MainForm
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
            this.oldVerLabel = new MetroFramework.Controls.MetroLabel();
            this.SrchSpecOldBtn = new MetroFramework.Controls.MetroButton();
            this.oldVerTxt = new MetroFramework.Controls.MetroTextBox();
            this.newVerTxt = new MetroFramework.Controls.MetroTextBox();
            this.SrchSpecNewBtn = new MetroFramework.Controls.MetroButton();
            this.compareBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // oldVerLabel
            // 
            this.oldVerLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.oldVerLabel.AutoSize = true;
            this.oldVerLabel.Location = new System.Drawing.Point(5, 81);
            this.oldVerLabel.Name = "oldVerLabel";
            this.oldVerLabel.Size = new System.Drawing.Size(259, 19);
            this.oldVerLabel.TabIndex = 1;
            this.oldVerLabel.Text = "Выберите спецификации для сравнения";
            this.oldVerLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SrchSpecOldBtn
            // 
            this.SrchSpecOldBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SrchSpecOldBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SrchSpecOldBtn.Location = new System.Drawing.Point(334, 146);
            this.SrchSpecOldBtn.Name = "SrchSpecOldBtn";
            this.SrchSpecOldBtn.Size = new System.Drawing.Size(59, 23);
            this.SrchSpecOldBtn.TabIndex = 2;
            this.SrchSpecOldBtn.TabStop = false;
            this.SrchSpecOldBtn.Text = "Обзор";
            this.SrchSpecOldBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SrchSpecOldBtn.Click += new System.EventHandler(this.SrchSpecOldBtn_Click);
            // 
            // oldVerTxt
            // 
            this.oldVerTxt.AllowDrop = true;
            this.oldVerTxt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.oldVerTxt.Location = new System.Drawing.Point(5, 117);
            this.oldVerTxt.Name = "oldVerTxt";
            this.oldVerTxt.PromptText = "Текущая версия";
            this.oldVerTxt.Size = new System.Drawing.Size(388, 23);
            this.oldVerTxt.TabIndex = 3;
            this.oldVerTxt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.oldVerTxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.OldVerTxt_DragDrop);
            this.oldVerTxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.OldVerTxt_DragEnter);
            // 
            // newVerTxt
            // 
            this.newVerTxt.AllowDrop = true;
            this.newVerTxt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.newVerTxt.Location = new System.Drawing.Point(5, 189);
            this.newVerTxt.Name = "newVerTxt";
            this.newVerTxt.PromptText = "Новая версия";
            this.newVerTxt.Size = new System.Drawing.Size(388, 23);
            this.newVerTxt.TabIndex = 5;
            this.newVerTxt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.newVerTxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.NewVerTxt_DragDrop);
            this.newVerTxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.NewVerTxt_DragEnter);
            // 
            // SrchSpecNewBtn
            // 
            this.SrchSpecNewBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SrchSpecNewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SrchSpecNewBtn.Location = new System.Drawing.Point(334, 218);
            this.SrchSpecNewBtn.Name = "SrchSpecNewBtn";
            this.SrchSpecNewBtn.Size = new System.Drawing.Size(59, 23);
            this.SrchSpecNewBtn.TabIndex = 4;
            this.SrchSpecNewBtn.TabStop = false;
            this.SrchSpecNewBtn.Text = "Обзор";
            this.SrchSpecNewBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SrchSpecNewBtn.Click += new System.EventHandler(this.SrchSpecNewBtn_Click);
            // 
            // compareBtn
            // 
            this.compareBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.compareBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compareBtn.Location = new System.Drawing.Point(5, 264);
            this.compareBtn.Name = "compareBtn";
            this.compareBtn.Size = new System.Drawing.Size(388, 55);
            this.compareBtn.TabIndex = 6;
            this.compareBtn.Text = "Сравнить";
            this.compareBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.compareBtn.Click += new System.EventHandler(this.CompareBtn_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(54, 335);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(341, 57);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Несоответствие данных\r\n (за истину приняты данные из новой спецификации,\r\nстарые " +
    "данные см. в примечании к ячейке)";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(5, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 19);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Blue;
            this.panel2.Location = new System.Drawing.Point(5, 396);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(30, 19);
            this.panel2.TabIndex = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(54, 396);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 19);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Повтор строки";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Location = new System.Drawing.Point(5, 430);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(30, 19);
            this.panel3.TabIndex = 12;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(54, 430);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(271, 19);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Строка отсутствует в новой спецификации";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(54, 463);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(274, 19);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Строка отсутствует в старой спецификации";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Green;
            this.panel4.Location = new System.Drawing.Point(5, 463);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(30, 19);
            this.panel4.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 491);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.compareBtn);
            this.Controls.Add(this.newVerTxt);
            this.Controls.Add(this.SrchSpecNewBtn);
            this.Controls.Add(this.oldVerTxt);
            this.Controls.Add(this.SrchSpecOldBtn);
            this.Controls.Add(this.oldVerLabel);
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "SpecificationCompare";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel oldVerLabel;
        private MetroFramework.Controls.MetroButton SrchSpecOldBtn;
        private MetroFramework.Controls.MetroTextBox oldVerTxt;
        private MetroFramework.Controls.MetroTextBox newVerTxt;
        private MetroFramework.Controls.MetroButton SrchSpecNewBtn;
        private MetroFramework.Controls.MetroButton compareBtn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.Panel panel4;
    }
}

