using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace ZipApp_Winforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файлы для сжатия";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilesToCompress.Text = string.Join(",", openFileDialog.FileNames);
                }
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            string zipPath = txtZipFileName.Text;
            string[] files = txtFilesToCompress.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (string.IsNullOrWhiteSpace(zipPath))
            {
                MessageBox.Show("Пожалуйста, укажите имя ZIP файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    foreach (var file in files)
                    {
                        var trimmedFile = file.Trim();
                        if (File.Exists(trimmedFile))
                        {
                            archive.CreateEntryFromFile(trimmedFile, Path.GetFileName(trimmedFile));
                        }
                        else
                        {
                            MessageBox.Show($"Файл не найден: {trimmedFile}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                MessageBox.Show("Файлы успешно сжаты!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtZipFileName.Text = null;
            txtExtractPath.Text = null;
            txtFilesToCompress.Text = null;
        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            string zipPath = txtZipFileName.Text;
            string extractPath = txtExtractPath.Text;

            if (string.IsNullOrWhiteSpace(zipPath) || string.IsNullOrWhiteSpace(extractPath))
            {
                MessageBox.Show("Пожалуйста, укажите имя ZIP файла и путь для распаковки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(zipPath))
            {
                MessageBox.Show("ZIP файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                ZipFile.ExtractToDirectory(zipPath, extractPath);
                MessageBox.Show("Файлы успешно распакованы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка ввода-вывода: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Недостаточно прав для доступа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
