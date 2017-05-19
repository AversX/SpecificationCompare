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
            this.SuspendLayout();
            // 
            // oldVerLabel
            // 
            this.oldVerLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.oldVerLabel.AutoSize = true;
            this.oldVerLabel.Location = new System.Drawing.Point(4, 83);
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
            this.SrchSpecOldBtn.Location = new System.Drawing.Point(333, 148);
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
            this.oldVerTxt.Location = new System.Drawing.Point(4, 119);
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
            this.newVerTxt.Location = new System.Drawing.Point(4, 191);
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
            this.SrchSpecNewBtn.Location = new System.Drawing.Point(333, 220);
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
            this.compareBtn.Location = new System.Drawing.Point(4, 266);
            this.compareBtn.Name = "compareBtn";
            this.compareBtn.Size = new System.Drawing.Size(388, 55);
            this.compareBtn.TabIndex = 6;
            this.compareBtn.Text = "Сравнить";
            this.compareBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.compareBtn.Click += new System.EventHandler(this.CompareBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 329);
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
    }
}

