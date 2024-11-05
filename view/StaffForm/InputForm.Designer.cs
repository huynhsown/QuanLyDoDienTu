namespace QuanLyDoDienTu.view.StaffForm
{
    partial class InputForm
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
            txtInput = new TextBox();
            btnOK = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInput.ForeColor = SystemColors.MenuText;
            txtInput.Location = new Point(127, 128);
            txtInput.Margin = new Padding(4, 3, 4, 3);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(101, 29);
            txtInput.TabIndex = 0;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.MintCream;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnOK.ForeColor = Color.LightSeaGreen;
            btnOK.Location = new Point(139, 214);
            btnOK.Margin = new Padding(4, 3, 4, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(74, 42);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(106, 75);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 30);
            label1.TabIndex = 8;
            label1.Text = "Nhập mã NSX";
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(359, 341);
            Controls.Add(label1);
            Controls.Add(btnOK);
            Controls.Add(txtInput);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "InputForm";
            Text = "InputForm";
            Load += InputForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
    }
}