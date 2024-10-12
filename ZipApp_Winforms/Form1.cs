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
                openFileDialog.Title = "�������� ����� ��� ������";
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
                MessageBox.Show("����������, ������� ��� ZIP �����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show($"���� �� ������: {trimmedFile}", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                MessageBox.Show("����� ������� �����!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("����������, ������� ��� ZIP ����� � ���� ��� ����������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(zipPath))
            {
                MessageBox.Show("ZIP ���� �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                ZipFile.ExtractToDirectory(zipPath, extractPath);
                MessageBox.Show("����� ������� �����������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"������ �����-������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"������������ ���� ��� �������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
