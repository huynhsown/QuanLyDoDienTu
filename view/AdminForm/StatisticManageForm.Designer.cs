namespace QuanLyDoDienTu.view.AdminForm
{
    partial class StatisticManageForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            FastReport.DataVisualization.Charting.Series series1 = new FastReport.DataVisualization.Charting.Series();
            dtp_Date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            chartRevenue = new FastReport.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            SuspendLayout();
            // 
            // dtp_Date
            // 
            dtp_Date.Checked = true;
            dtp_Date.CustomizableEdges = customizableEdges1;
            dtp_Date.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_Date.Format = DateTimePickerFormat.Short;
            dtp_Date.Location = new Point(62, 88);
            dtp_Date.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtp_Date.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtp_Date.Name = "dtp_Date";
            dtp_Date.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtp_Date.Size = new Size(248, 35);
            dtp_Date.TabIndex = 84;
            dtp_Date.Value = new DateTime(2024, 10, 22, 21, 32, 36, 24);
            // 
            // guna2DateTimePicker1
            // 
            guna2DateTimePicker1.Checked = true;
            guna2DateTimePicker1.CustomizableEdges = customizableEdges3;
            guna2DateTimePicker1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DateTimePicker1.Format = DateTimePickerFormat.Short;
            guna2DateTimePicker1.Location = new Point(558, 88);
            guna2DateTimePicker1.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            guna2DateTimePicker1.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            guna2DateTimePicker1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2DateTimePicker1.Size = new Size(248, 35);
            guna2DateTimePicker1.TabIndex = 85;
            guna2DateTimePicker1.Value = new DateTime(2024, 10, 22, 21, 32, 36, 24);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 65);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 86;
            label1.Text = "Thời gian bắt đầu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(558, 65);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 87;
            label2.Text = "Thời gian kết thúc";
            // 
            // chartRevenue
            // 
            chartRevenue.Location = new Point(191, 184);
            chartRevenue.Name = "chartRevenue";
            series1.Name = "Series1";
            chartRevenue.Series.Add(series1);
            chartRevenue.Size = new Size(494, 399);
            chartRevenue.TabIndex = 88;
            chartRevenue.Text = "chart1";
            // 
            // StatisticManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 678);
            Controls.Add(chartRevenue);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2DateTimePicker1);
            Controls.Add(dtp_Date);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StatisticManageForm";
            Text = "StatisticManageForm";
            Load += StatisticManageForm_Load;
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_Date;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Label label1;
        private Label label2;
        private FastReport.DataVisualization.Charting.Chart chartRevenue;
    }
}