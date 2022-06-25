
namespace TemperatureMonitoring.WindowsForms
{
    partial class MainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loadFile = new System.Windows.Forms.OpenFileDialog();
            this.tb_FishType = new System.Windows.Forms.TextBox();
            this.tb_MaxTemp = new System.Windows.Forms.TextBox();
            this.tb_MaxTempDuration = new System.Windows.Forms.TextBox();
            this.tb_MinTemp = new System.Windows.Forms.TextBox();
            this.tb_MinTempDuration = new System.Windows.Forms.TextBox();
            this.tb_Temperature = new System.Windows.Forms.TextBox();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.lw_Content = new System.Windows.Forms.ListBox();
            this.VerdictText = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вид рыбы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Температура";
            // 
            // loadFile
            // 
            this.loadFile.FileName = "openFileDialog1";
            // 
            // tb_FishType
            // 
            this.tb_FishType.Location = new System.Drawing.Point(109, 34);
            this.tb_FishType.Name = "tb_FishType";
            this.tb_FishType.Size = new System.Drawing.Size(100, 23);
            this.tb_FishType.TabIndex = 5;
            // 
            // tb_MaxTemp
            // 
            this.tb_MaxTemp.Location = new System.Drawing.Point(109, 75);
            this.tb_MaxTemp.Name = "tb_MaxTemp";
            this.tb_MaxTemp.Size = new System.Drawing.Size(100, 23);
            this.tb_MaxTemp.TabIndex = 6;
            // 
            // tb_MaxTempDuration
            // 
            this.tb_MaxTempDuration.Location = new System.Drawing.Point(232, 77);
            this.tb_MaxTempDuration.Name = "tb_MaxTempDuration";
            this.tb_MaxTempDuration.Size = new System.Drawing.Size(100, 23);
            this.tb_MaxTempDuration.TabIndex = 7;
            // 
            // tb_MinTemp
            // 
            this.tb_MinTemp.Location = new System.Drawing.Point(109, 107);
            this.tb_MinTemp.Name = "tb_MinTemp";
            this.tb_MinTemp.Size = new System.Drawing.Size(100, 23);
            this.tb_MinTemp.TabIndex = 8;
            // 
            // tb_MinTempDuration
            // 
            this.tb_MinTempDuration.Location = new System.Drawing.Point(232, 106);
            this.tb_MinTempDuration.Name = "tb_MinTempDuration";
            this.tb_MinTempDuration.Size = new System.Drawing.Size(100, 23);
            this.tb_MinTempDuration.TabIndex = 9;
            // 
            // tb_Temperature
            // 
            this.tb_Temperature.Location = new System.Drawing.Point(109, 181);
            this.tb_Temperature.Name = "tb_Temperature";
            this.tb_Temperature.Size = new System.Drawing.Size(304, 23);
            this.tb_Temperature.TabIndex = 11;
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(27, 272);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(182, 23);
            this.btn_Load.TabIndex = 12;
            this.btn_Load.Text = "Загрузить из файла";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(27, 311);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(182, 23);
            this.btn_Submit.TabIndex = 14;
            this.btn_Submit.Text = "По данным";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // lw_Content
            // 
            this.lw_Content.FormattingEnabled = true;
            this.lw_Content.ItemHeight = 15;
            this.lw_Content.Location = new System.Drawing.Point(479, 36);
            this.lw_Content.Name = "lw_Content";
            this.lw_Content.Size = new System.Drawing.Size(309, 364);
            this.lw_Content.TabIndex = 18;
            // 
            // VerdictText
            // 
            this.VerdictText.AutoSize = true;
            this.VerdictText.Location = new System.Drawing.Point(27, 230);
            this.VerdictText.Name = "VerdictText";
            this.VerdictText.Size = new System.Drawing.Size(0, 15);
            this.VerdictText.TabIndex = 19;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(109, 144);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(223, 23);
            this.dateTimePicker.TabIndex = 20;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(27, 353);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(182, 23);
            this.btn_Save.TabIndex = 21;
            this.btn_Save.Text = "Сохранить отчет";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.VerdictText);
            this.Controls.Add(this.lw_Content);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.tb_Temperature);
            this.Controls.Add(this.tb_MinTempDuration);
            this.Controls.Add(this.tb_MinTemp);
            this.Controls.Add(this.tb_MaxTempDuration);
            this.Controls.Add(this.tb_MaxTemp);
            this.Controls.Add(this.tb_FishType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog loadFile;
        private System.Windows.Forms.TextBox tb_FishType;
        private System.Windows.Forms.TextBox tb_MaxTemp;
        private System.Windows.Forms.TextBox tb_MaxTempDuration;
        private System.Windows.Forms.TextBox tb_MinTemp;
        private System.Windows.Forms.TextBox tb_MinTempDuration;
        private System.Windows.Forms.TextBox tb_Temperature;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.ListBox lw_Content;
        private System.Windows.Forms.Label VerdictText;
        private System.Windows.Forms.TextBox dateTimePicker;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}