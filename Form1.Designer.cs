namespace PgpTool;

partial class MainForm
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
        // Groups
        GroupBox grpKeys = new GroupBox();
        GroupBox grpFile = new GroupBox();
        GroupBox grpOutput = new GroupBox();
        GroupBox grpActions = new GroupBox();

        // Key Management Controls
        Label lblPublicKey = new Label();
        TextBox txtPublicKey = new TextBox();
        Button btnSelectPublicKey = new Button();

        Label lblPrivateKey = new Label();
        TextBox txtPrivateKey = new TextBox();
        Button btnSelectPrivateKey = new Button();

        Label lblPassword = new Label();
        TextBox txtPassword = new TextBox();

        // File Selection Controls
        Label lblFilePath = new Label();
        TextBox txtFilePath = new TextBox();
        Button btnSelectFile = new Button();

        // Output Configuration Controls
        Label lblOutputDirectory = new Label();
        TextBox txtOutputDirectory = new TextBox();
        Button btnSelectOutputDirectory = new Button();

        Label lblCustomFileName = new Label();
        TextBox txtCustomFileName = new TextBox();

        // Action Controls
        Button btnEncrypt = new Button();
        Button btnDecrypt = new Button();

        // Status Controls
        Label lblStatus = new Label();
        ProgressBar progressBar = new ProgressBar();

        this.SuspendLayout();

        // Form properties
        this.Text = "PGP Encryption/Decryption Tool";
        this.Size = new Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        // Keys Group
        grpKeys.Text = "Key Management";
        grpKeys.Location = new Point(12, 12);
        grpKeys.Size = new Size(760, 140);

        lblPublicKey.Text = "Public Key:";
        lblPublicKey.Location = new Point(15, 25);
        lblPublicKey.Size = new Size(80, 23);

        txtPublicKey.Location = new Point(100, 22);
        txtPublicKey.Size = new Size(500, 23);
        txtPublicKey.ReadOnly = true;

        btnSelectPublicKey.Text = "Browse...";
        btnSelectPublicKey.Location = new Point(610, 21);
        btnSelectPublicKey.Size = new Size(75, 25);
        btnSelectPublicKey.UseVisualStyleBackColor = true;
        btnSelectPublicKey.Click += btnSelectPublicKey_Click;

        lblPrivateKey.Text = "Private Key:";
        lblPrivateKey.Location = new Point(15, 55);
        lblPrivateKey.Size = new Size(80, 23);

        txtPrivateKey.Location = new Point(100, 52);
        txtPrivateKey.Size = new Size(500, 23);
        txtPrivateKey.ReadOnly = true;

        btnSelectPrivateKey.Text = "Browse...";
        btnSelectPrivateKey.Location = new Point(610, 51);
        btnSelectPrivateKey.Size = new Size(75, 25);
        btnSelectPrivateKey.UseVisualStyleBackColor = true;
        btnSelectPrivateKey.Click += btnSelectPrivateKey_Click;

        lblPassword.Text = "Password:";
        lblPassword.Location = new Point(15, 85);
        lblPassword.Size = new Size(80, 23);

        txtPassword.Location = new Point(100, 82);
        txtPassword.Size = new Size(300, 23);
        txtPassword.UseSystemPasswordChar = true;
        txtPassword.TextChanged += txtPassword_TextChanged;

        grpKeys.Controls.AddRange(new Control[] {
            lblPublicKey, txtPublicKey, btnSelectPublicKey,
            lblPrivateKey, txtPrivateKey, btnSelectPrivateKey,
            lblPassword, txtPassword
        });

        // File Group
        grpFile.Text = "File Selection";
        grpFile.Location = new Point(12, 160);
        grpFile.Size = new Size(760, 80);

        lblFilePath.Text = "Target File:";
        lblFilePath.Location = new Point(15, 25);
        lblFilePath.Size = new Size(80, 23);

        txtFilePath.Location = new Point(100, 22);
        txtFilePath.Size = new Size(500, 23);
        txtFilePath.ReadOnly = true;

        btnSelectFile.Text = "Browse...";
        btnSelectFile.Location = new Point(610, 21);
        btnSelectFile.Size = new Size(75, 25);
        btnSelectFile.UseVisualStyleBackColor = true;
        btnSelectFile.Click += btnSelectFile_Click;

        grpFile.Controls.AddRange(new Control[] {
            lblFilePath, txtFilePath, btnSelectFile
        });

        // Output Group
        grpOutput.Text = "Output Configuration";
        grpOutput.Location = new Point(12, 250);
        grpOutput.Size = new Size(760, 100);

        lblOutputDirectory.Text = "Output Directory:";
        lblOutputDirectory.Location = new Point(15, 25);
        lblOutputDirectory.Size = new Size(100, 23);

        txtOutputDirectory.Location = new Point(120, 22);
        txtOutputDirectory.Size = new Size(480, 23);
        txtOutputDirectory.ReadOnly = true;

        btnSelectOutputDirectory.Text = "Browse...";
        btnSelectOutputDirectory.Location = new Point(610, 21);
        btnSelectOutputDirectory.Size = new Size(75, 25);
        btnSelectOutputDirectory.UseVisualStyleBackColor = true;
        btnSelectOutputDirectory.Click += btnSelectOutputDirectory_Click;

        lblCustomFileName.Text = "Custom Filename:";
        lblCustomFileName.Location = new Point(15, 55);
        lblCustomFileName.Size = new Size(100, 23);

        txtCustomFileName.Location = new Point(120, 52);
        txtCustomFileName.Size = new Size(300, 23);
        txtCustomFileName.PlaceholderText = "Leave empty to use original filename";

        grpOutput.Controls.AddRange(new Control[] {
            lblOutputDirectory, txtOutputDirectory, btnSelectOutputDirectory,
            lblCustomFileName, txtCustomFileName
        });

        // Actions Group
        grpActions.Text = "Operations";
        grpActions.Location = new Point(12, 360);
        grpActions.Size = new Size(760, 80);

        btnEncrypt.Text = "Encrypt File";
        btnEncrypt.Location = new Point(200, 30);
        btnEncrypt.Size = new Size(120, 35);
        btnEncrypt.UseVisualStyleBackColor = true;
        btnEncrypt.Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold);
        btnEncrypt.BackColor = Color.LightGreen;
        btnEncrypt.Click += btnEncrypt_Click;

        btnDecrypt.Text = "Decrypt File";
        btnDecrypt.Location = new Point(440, 30);
        btnDecrypt.Size = new Size(120, 35);
        btnDecrypt.UseVisualStyleBackColor = true;
        btnDecrypt.Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold);
        btnDecrypt.BackColor = Color.LightBlue;
        btnDecrypt.Click += btnDecrypt_Click;

        grpActions.Controls.AddRange(new Control[] {
            btnEncrypt, btnDecrypt
        });

        // Status Controls
        lblStatus.Text = "Ready";
        lblStatus.Location = new Point(12, 460);
        lblStatus.Size = new Size(600, 23);
        lblStatus.Font = new Font("Microsoft YaHei", 9F);
        lblStatus.ForeColor = Color.Blue;

        progressBar.Location = new Point(12, 490);
        progressBar.Size = new Size(760, 23);
        progressBar.Style = ProgressBarStyle.Blocks;
        progressBar.Visible = false;

        // Add all controls to form
        this.Controls.AddRange(new Control[] {
            grpKeys, grpFile, grpOutput, grpActions, lblStatus, progressBar
        });

        // Store references to controls that need to be accessed
        this.txtPublicKey = txtPublicKey;
        this.txtPrivateKey = txtPrivateKey;
        this.txtPassword = txtPassword;
        this.txtFilePath = txtFilePath;
        this.txtOutputDirectory = txtOutputDirectory;
        this.txtCustomFileName = txtCustomFileName;
        this.btnEncrypt = btnEncrypt;
        this.btnDecrypt = btnDecrypt;
        this.lblStatus = lblStatus;
        this.progressBar = progressBar;

        this.ResumeLayout(false);
    }

    #endregion

    // Control declarations
    private TextBox txtPublicKey;
    private TextBox txtPrivateKey;
    private TextBox txtPassword;
    private TextBox txtFilePath;
    private TextBox txtOutputDirectory;
    private TextBox txtCustomFileName;
    private Button btnEncrypt;
    private Button btnDecrypt;
    private Label lblStatus;
    private ProgressBar progressBar;
}
