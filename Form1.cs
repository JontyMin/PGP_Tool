using PgpCore;
using System.Configuration;

namespace PgpTool;

public partial class MainForm : Form
{
    private string publicKeyPath = "";
    private string privateKeyPath = "";
    private string password = "";
    private string outputDirectory = "";

    public MainForm()
    {
        InitializeComponent();
        InitializeForm();
        
        // Subscribe to form closing event to save settings
        this.FormClosing += MainForm_FormClosing;
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // Save settings when the form is closing
        SaveSettings();
    }

    private void InitializeForm()
    {
        this.Text = "PGP Encryption/Decryption Tool";
        this.Size = new System.Drawing.Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        
        // Set default output directory to current directory
        outputDirectory = Environment.CurrentDirectory;
        txtOutputDirectory.Text = outputDirectory;
        
        // Load saved settings
        LoadSettings();
    }

    private void LoadSettings()
    {
        try
        {
            // Load public key path
            string savedPublicKey = Properties.Settings.Default.PublicKeyPath;
            if (!string.IsNullOrEmpty(savedPublicKey) && File.Exists(savedPublicKey))
            {
                publicKeyPath = savedPublicKey;
                txtPublicKey.Text = publicKeyPath;
            }

            // Load private key path
            string savedPrivateKey = Properties.Settings.Default.PrivateKeyPath;
            if (!string.IsNullOrEmpty(savedPrivateKey) && File.Exists(savedPrivateKey))
            {
                privateKeyPath = savedPrivateKey;
                txtPrivateKey.Text = privateKeyPath;
            }

            // Load password (encrypted/base64 encoded for basic security)
            string savedPassword = Properties.Settings.Default.Password;
            if (!string.IsNullOrEmpty(savedPassword))
            {
                // Decode the base64 encoded password
                byte[] passwordBytes = Convert.FromBase64String(savedPassword);
                password = System.Text.Encoding.UTF8.GetString(passwordBytes);
                txtPassword.Text = password;
            }

            // Load output directory
            string savedOutputDir = Properties.Settings.Default.OutputDirectory;
            if (!string.IsNullOrEmpty(savedOutputDir) && Directory.Exists(savedOutputDir))
            {
                outputDirectory = savedOutputDir;
                txtOutputDirectory.Text = outputDirectory;
            }

            lblStatus.Text = "Settings loaded successfully";
            lblStatus.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Failed to load settings: {ex.Message}";
            lblStatus.ForeColor = Color.Orange;
        }
    }

    private void SaveSettings()
    {
        try
        {
            // Save public key path
            Properties.Settings.Default.PublicKeyPath = publicKeyPath;

            // Save private key path
            Properties.Settings.Default.PrivateKeyPath = privateKeyPath;

            // Save password (base64 encoded for basic security)
            if (!string.IsNullOrEmpty(password))
            {
                byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
                Properties.Settings.Default.Password = Convert.ToBase64String(passwordBytes);
            }
            else
            {
                Properties.Settings.Default.Password = "";
            }

            // Save output directory
            Properties.Settings.Default.OutputDirectory = outputDirectory;

            // Save settings to file
            Properties.Settings.Default.Save();
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Failed to save settings: {ex.Message}";
            lblStatus.ForeColor = Color.Orange;
        }
    }

    private void btnSelectPublicKey_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "PGP Public Key files (*.asc;*.pub;*.key)|*.asc;*.pub;*.key|All files (*.*)|*.*";
            openFileDialog.Title = "Select Public Key File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                publicKeyPath = openFileDialog.FileName;
                txtPublicKey.Text = publicKeyPath;
                lblStatus.Text = "Public key selected";
                lblStatus.ForeColor = Color.Green;
                SaveSettings(); // Auto-save settings
            }
        }
    }

    private void btnSelectPrivateKey_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "PGP Private Key files (*.asc;*.key)|*.asc;*.key|All files (*.*)|*.*";
            openFileDialog.Title = "Select Private Key File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                privateKeyPath = openFileDialog.FileName;
                txtPrivateKey.Text = privateKeyPath;
                lblStatus.Text = "Private key selected";
                lblStatus.ForeColor = Color.Green;
                SaveSettings(); // Auto-save settings
            }
        }
    }

    private void btnSelectOutputDirectory_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = "Select Output Directory";
            folderDialog.SelectedPath = outputDirectory;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                outputDirectory = folderDialog.SelectedPath;
                txtOutputDirectory.Text = outputDirectory;
                lblStatus.Text = "Output directory set";
                lblStatus.ForeColor = Color.Green;
                SaveSettings(); // Auto-save settings
            }
        }
    }

    private void btnSelectFile_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Title = "Select File to Encrypt/Decrypt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
                lblStatus.Text = "File selected";
                lblStatus.ForeColor = Color.Blue;
            }
        }
    }

    private async void btnEncrypt_Click(object sender, EventArgs e)
    {
        if (!ValidateEncryptionInputs())
            return;

        try
        {
            btnEncrypt.Enabled = false;
            lblStatus.Text = "Encrypting...";
            lblStatus.ForeColor = Color.Blue;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = true;

            await Task.Run(async () =>
            {
                string inputFile = txtFilePath.Text;
                string fileName = Path.GetFileName(inputFile);
                string outputFile = string.IsNullOrWhiteSpace(txtCustomFileName.Text) 
                    ? Path.Combine(outputDirectory, fileName + ".pgp")
                    : Path.Combine(outputDirectory, txtCustomFileName.Text + ".pgp");

                // Use EncryptionKeys and async encryption
                FileInfo publicKeyFile = new FileInfo(publicKeyPath);
                FileInfo inputFileInfo = new FileInfo(inputFile);
                FileInfo outputFileInfo = new FileInfo(outputFile);

                EncryptionKeys encryptionKeys = new EncryptionKeys(publicKeyFile);
                PGP pgp = new PGP(encryptionKeys);
                
                await pgp.EncryptAsync(inputFileInfo, outputFileInfo);
            });

            lblStatus.Text = "File encrypted successfully!";
            lblStatus.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Encryption failed: {ex.Message}";
            lblStatus.ForeColor = Color.Red;
        }
        finally
        {
            btnEncrypt.Enabled = true;
            progressBar.Visible = false;
            progressBar.Style = ProgressBarStyle.Blocks;
        }
    }

    private async void btnDecrypt_Click(object sender, EventArgs e)
    {
        if (!ValidateDecryptionInputs())
            return;

        try
        {
            btnDecrypt.Enabled = false;
            lblStatus.Text = "Decrypting...";
            lblStatus.ForeColor = Color.Blue;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = true;

            await Task.Run(async () =>
            {
                string inputFile = txtFilePath.Text;
                string fileName = Path.GetFileNameWithoutExtension(inputFile);
                if (fileName.EndsWith(".pgp", StringComparison.OrdinalIgnoreCase))
                {
                    fileName = fileName.Substring(0, fileName.Length - 4);
                }
                
                string outputFile = string.IsNullOrWhiteSpace(txtCustomFileName.Text)
                    ? Path.Combine(outputDirectory, fileName)
                    : Path.Combine(outputDirectory, txtCustomFileName.Text);

                // Use EncryptionKeys and async decryption
                FileInfo publicKeyFile = new FileInfo(publicKeyPath);
                FileInfo privateKeyFile = new FileInfo(privateKeyPath);
                FileInfo inputFileInfo = new FileInfo(inputFile);
                FileInfo outputFileInfo = new FileInfo(outputFile);

                EncryptionKeys encryptionKeys = new EncryptionKeys(publicKeyFile, privateKeyFile, txtPassword.Text);
                PGP pgp = new PGP(encryptionKeys);
                
                await pgp.DecryptAsync(inputFileInfo, outputFileInfo);
            });

            lblStatus.Text = "File decrypted successfully!";
            lblStatus.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Decryption failed: {ex.Message}";
            lblStatus.ForeColor = Color.Red;
        }
        finally
        {
            btnDecrypt.Enabled = true;
            progressBar.Visible = false;
            progressBar.Style = ProgressBarStyle.Blocks;
        }
    }

    private bool ValidateEncryptionInputs()
    {
        if (string.IsNullOrWhiteSpace(publicKeyPath))
        {
            lblStatus.Text = "Please select a public key file";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtFilePath.Text))
        {
            lblStatus.Text = "Please select a file to encrypt";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        if (!File.Exists(publicKeyPath))
        {
            lblStatus.Text = "Public key file does not exist";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        if (!File.Exists(txtFilePath.Text))
        {
            lblStatus.Text = "File to encrypt does not exist";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        return true;
    }

    private bool ValidateDecryptionInputs()
    {
        if (string.IsNullOrWhiteSpace(privateKeyPath))
        {
            lblStatus.Text = "Please select a private key file";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtFilePath.Text))
        {
            lblStatus.Text = "Please select a file to decrypt";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            lblStatus.Text = "Please enter the private key password";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        if (!File.Exists(privateKeyPath))
        {
            lblStatus.Text = "Private key file does not exist";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        if (!File.Exists(txtFilePath.Text))
        {
            lblStatus.Text = "File to decrypt does not exist";
            lblStatus.ForeColor = Color.Red;
            return false;
        }

        return true;
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
        password = txtPassword.Text;
        SaveSettings(); // Auto-save password when changed
    }
}
