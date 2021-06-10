
namespace GAinTSP
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.ResultButton = new System.Windows.Forms.RadioButton();
            this.PopulationsButton = new System.Windows.Forms.RadioButton();
            this.OKbutton = new System.Windows.Forms.Button();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.NumOfPopsBox = new System.Windows.Forms.TextBox();
            this.NumOfSpeciesBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InputText = new System.Windows.Forms.Label();
            this.OutputText = new System.Windows.Forms.Label();
            this.InputUrl = new System.Windows.Forms.TextBox();
            this.OutputUrl = new System.Windows.Forms.TextBox();
            this.MaxPops = new System.Windows.Forms.TextBox();
            this.PopsMax = new System.Windows.Forms.Label();
            this.MatrixBox = new System.Windows.Forms.RichTextBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.MatrixLabel = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите количество особей в популяции";
            // 
            // ResultButton
            // 
            this.ResultButton.AutoSize = true;
            this.ResultButton.Location = new System.Drawing.Point(474, 129);
            this.ResultButton.Name = "ResultButton";
            this.ResultButton.Size = new System.Drawing.Size(186, 30);
            this.ResultButton.TabIndex = 2;
            this.ResultButton.TabStop = true;
            this.ResultButton.Text = "Значение функции пригодности\r\n(дистанция) не больше\r\n";
            this.ResultButton.UseVisualStyleBackColor = true;
            this.ResultButton.CheckedChanged += new System.EventHandler(this.ResultButton_CheckedChanged);
            // 
            // PopulationsButton
            // 
            this.PopulationsButton.AutoSize = true;
            this.PopulationsButton.Location = new System.Drawing.Point(474, 168);
            this.PopulationsButton.Name = "PopulationsButton";
            this.PopulationsButton.Size = new System.Drawing.Size(169, 17);
            this.PopulationsButton.TabIndex = 3;
            this.PopulationsButton.TabStop = true;
            this.PopulationsButton.Text = "Кол-во поколений эволюции";
            this.PopulationsButton.UseVisualStyleBackColor = true;
            this.PopulationsButton.CheckedChanged += new System.EventHandler(this.PopulationsButton_CheckedChanged);
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(704, 400);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 4;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(703, 129);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(76, 20);
            this.ResultBox.TabIndex = 5;
            this.ResultBox.TextChanged += new System.EventHandler(this.ResultBox_TextChanged);
            // 
            // NumOfPopsBox
            // 
            this.NumOfPopsBox.Location = new System.Drawing.Point(703, 168);
            this.NumOfPopsBox.Name = "NumOfPopsBox";
            this.NumOfPopsBox.Size = new System.Drawing.Size(76, 20);
            this.NumOfPopsBox.TabIndex = 6;
            this.NumOfPopsBox.TextChanged += new System.EventHandler(this.NumOfPopsBox_TextChanged);
            // 
            // NumOfSpeciesBox
            // 
            this.NumOfSpeciesBox.Location = new System.Drawing.Point(588, 46);
            this.NumOfSpeciesBox.Name = "NumOfSpeciesBox";
            this.NumOfSpeciesBox.Size = new System.Drawing.Size(100, 20);
            this.NumOfSpeciesBox.TabIndex = 7;
            this.NumOfSpeciesBox.TextChanged += new System.EventHandler(this.NumOfSpeciesBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выберите критерий остановки алгоритма";
            // 
            // InputText
            // 
            this.InputText.AutoSize = true;
            this.InputText.Location = new System.Drawing.Point(471, 241);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(138, 26);
            this.InputText.TabIndex = 13;
            this.InputText.Text = "Введите название файла \r\nс исходными данными";
            // 
            // OutputText
            // 
            this.OutputText.AutoSize = true;
            this.OutputText.Location = new System.Drawing.Point(471, 289);
            this.OutputText.Name = "OutputText";
            this.OutputText.Size = new System.Drawing.Size(138, 26);
            this.OutputText.TabIndex = 14;
            this.OutputText.Text = "Введите название файла \r\nс выходными данными";
            // 
            // InputUrl
            // 
            this.InputUrl.Location = new System.Drawing.Point(680, 247);
            this.InputUrl.Name = "InputUrl";
            this.InputUrl.Size = new System.Drawing.Size(100, 20);
            this.InputUrl.TabIndex = 15;
            this.InputUrl.TextChanged += new System.EventHandler(this.InputUrl_TextChanged);
            // 
            // OutputUrl
            // 
            this.OutputUrl.Location = new System.Drawing.Point(680, 295);
            this.OutputUrl.Name = "OutputUrl";
            this.OutputUrl.Size = new System.Drawing.Size(100, 20);
            this.OutputUrl.TabIndex = 16;
            this.OutputUrl.TextChanged += new System.EventHandler(this.OutputUrl_TextChanged);
            // 
            // MaxPops
            // 
            this.MaxPops.Location = new System.Drawing.Point(679, 353);
            this.MaxPops.Name = "MaxPops";
            this.MaxPops.Size = new System.Drawing.Size(100, 20);
            this.MaxPops.TabIndex = 17;
            this.MaxPops.TextChanged += new System.EventHandler(this.MaxPops_TextChanged);
            // 
            // PopsMax
            // 
            this.PopsMax.AutoSize = true;
            this.PopsMax.Location = new System.Drawing.Point(471, 347);
            this.PopsMax.Name = "PopsMax";
            this.PopsMax.Size = new System.Drawing.Size(155, 26);
            this.PopsMax.TabIndex = 18;
            this.PopsMax.Text = "Введите пороговое значение\r\nпоколений эволюции";
            // 
            // MatrixBox
            // 
            this.MatrixBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixBox.Location = new System.Drawing.Point(45, 46);
            this.MatrixBox.Name = "MatrixBox";
            this.MatrixBox.Size = new System.Drawing.Size(402, 238);
            this.MatrixBox.TabIndex = 19;
            this.MatrixBox.Text = "";
            // 
            // ResultLabel
            // 
            this.ResultLabel.Location = new System.Drawing.Point(0, 0);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(100, 23);
            this.ResultLabel.TabIndex = 22;
            // 
            // MatrixLabel
            // 
            this.MatrixLabel.AutoSize = true;
            this.MatrixLabel.Location = new System.Drawing.Point(64, 19);
            this.MatrixLabel.Name = "MatrixLabel";
            this.MatrixLabel.Size = new System.Drawing.Size(196, 13);
            this.MatrixLabel.TabIndex = 21;
            this.MatrixLabel.Text = "Исходная матрица смежности графа";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(45, 327);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(402, 111);
            this.ResultTextBox.TabIndex = 23;
            this.ResultTextBox.Text = "";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.MatrixLabel);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.MatrixBox);
            this.Controls.Add(this.PopsMax);
            this.Controls.Add(this.MaxPops);
            this.Controls.Add(this.OutputUrl);
            this.Controls.Add(this.InputUrl);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumOfSpeciesBox);
            this.Controls.Add(this.NumOfPopsBox);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.PopulationsButton);
            this.Controls.Add(this.ResultButton);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton ResultButton;
        private System.Windows.Forms.RadioButton PopulationsButton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.TextBox NumOfPopsBox;
        private System.Windows.Forms.TextBox NumOfSpeciesBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label InputText;
        private System.Windows.Forms.Label OutputText;
        private System.Windows.Forms.TextBox InputUrl;
        private System.Windows.Forms.TextBox OutputUrl;
        private System.Windows.Forms.TextBox MaxPops;
        private System.Windows.Forms.Label PopsMax;
        private System.Windows.Forms.RichTextBox MatrixBox;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label MatrixLabel;
        private System.Windows.Forms.RichTextBox ResultTextBox;
    }
}