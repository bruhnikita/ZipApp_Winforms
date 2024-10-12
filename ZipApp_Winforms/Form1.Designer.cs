namespace ZipApp_Winforms
{
    partial class MainForm : Form
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
            btnDecompress = new Button();
            btnCompress = new Button();
            txtZipFileName = new TextBox();
            txtFilesToCompress = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            btnSelectFiles = new Button();
            txtExtractPath = new TextBox();
            SuspendLayout();
            // 
            // btnDecompress
            // 
            btnDecompress.Dock = DockStyle.Bottom;
            btnDecompress.Location = new Point(0, 403);
            btnDecompress.Name = "btnDecompress";
            btnDecompress.Size = new Size(342, 47);
            btnDecompress.TabIndex = 0;
            btnDecompress.Text = "Разархивировать";
            btnDecompress.UseVisualStyleBackColor = true;
            btnDecompress.Click += btnDecompress_Click;
            // 
            // btnCompress
            // 
            btnCompress.Dock = DockStyle.Bottom;
            btnCompress.Location = new Point(0, 356);
            btnCompress.Name = "btnCompress";
            btnCompress.Size = new Size(342, 47);
            btnCompress.TabIndex = 1;
            btnCompress.Text = "Архивировать";
            btnCompress.UseVisualStyleBackColor = true;
            btnCompress.Click += btnCompress_Click;
            // 
            // txtZipFileName
            // 
            txtZipFileName.Location = new Point(0, 12);
            txtZipFileName.Name = "txtZipFileName";
            txtZipFileName.PlaceholderText = "Имя архива";
            txtZipFileName.Size = new Size(342, 23);
            txtZipFileName.TabIndex = 2;
            // 
            // txtFilesToCompress
            // 
            txtFilesToCompress.Location = new Point(0, 41);
            txtFilesToCompress.Name = "txtFilesToCompress";
            txtFilesToCompress.PlaceholderText = "Имена файлов для сжатия";
            txtFilesToCompress.Size = new Size(342, 23);
            txtFilesToCompress.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.Dock = DockStyle.Bottom;
            btnSelectFiles.Location = new Point(0, 309);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new Size(342, 47);
            btnSelectFiles.TabIndex = 4;
            btnSelectFiles.Text = "Выбрать файлы для архивации";
            btnSelectFiles.UseVisualStyleBackColor = true;
            btnSelectFiles.Click += btnSelectFiles_Click;
            // 
            // txtExtractPath
            // 
            txtExtractPath.Location = new Point(0, 70);
            txtExtractPath.Name = "txtExtractPath";
            txtExtractPath.PlaceholderText = "Путь для распаковки";
            txtExtractPath.Size = new Size(342, 23);
            txtExtractPath.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 450);
            Controls.Add(txtExtractPath);
            Controls.Add(btnSelectFiles);
            Controls.Add(txtFilesToCompress);
            Controls.Add(txtZipFileName);
            Controls.Add(btnCompress);
            Controls.Add(btnDecompress);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDecompress;
        private Button btnCompress;
        private TextBox txtZipFileName;
        private TextBox txtFilesToCompress;
        private OpenFileDialog openFileDialog1;
        private Button btnSelectFiles;
        private TextBox txtExtractPath;
    }
}
