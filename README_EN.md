# PGP Encryption/Decryption Tool

A user-friendly PGP encryption and decryption tool developed with C# WinForms and PgpCore library.

## Features

- **Key Management**: Support for loading and managing PGP public/private keys
- **File Encryption**: Encrypt any file using public key
- **File Decryption**: Decrypt PGP encrypted files using private key and password
- **Flexible Output**: Configurable output directory and custom file naming
- **User-Friendly**: Intuitive graphical interface with file browser support
- **Security**: Secure password handling with integrity check support
- **Settings Memory**: Automatically remembers key paths, passwords, and output directories

## System Requirements

- .NET 8.0 or higher
- Windows Operating System
- PgpCore 6.5.0+ library

## Usage

### Encrypting Files
1. In the "Key Management" section, select a public key file (.asc or .pub)
2. In the "File Selection" section, choose the file to encrypt
3. In the "Output Configuration" section, set output directory (optional custom filename)
4. Click the "Encrypt File" button

### Decrypting Files
1. In the "Key Management" section, select a private key file (.asc or .key)
2. Enter the private key password
3. In the "File Selection" section, choose the PGP file to decrypt
4. In the "Output Configuration" section, set output directory (optional custom filename)
5. Click the "Decrypt File" button

## Project Structure

```
pgp_tool/
├── Program.cs              # Application entry point
├── Form1.cs               # Main form logic (MainForm)
├── Form1.Designer.cs      # Main form designer code
├── PgpTool.csproj         # Project file
├── Properties/            # Application settings
│   ├── Settings.settings  # User settings configuration
│   └── Settings.Designer.cs # Auto-generated settings class
├── .github/
│   └── copilot-instructions.md # Copilot development guidelines
└── README.md              # Project documentation
```

## Build and Run

### Using .NET CLI
```bash
# Restore dependencies
dotnet restore

# Build project
dotnet build

# Run application
dotnet run

# Publish as executable
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true -o ./publish
```

### Using Visual Studio
1. Open `PgpTool.csproj` file
2. Press F5 to start debugging

## Dependencies

- **PgpCore**: Core PGP encryption/decryption library
- **.NET 8.0 Windows Forms**: UI framework
- **System.Configuration.ConfigurationManager**: Settings management

## Distribution

### Framework-Dependent (Recommended)
- **File**: `publish/PgpTool.exe` 
- **Size**: ~7 MB
- **Requirements**: .NET 8 Runtime must be installed on target machine

### Self-Contained
- **File**: `publish-release/PgpTool.exe`
- **Size**: ~153 MB
- **Requirements**: No .NET installation required

## Security Considerations

- Private key passwords are temporarily stored in memory as plaintext and cleared when application closes
- Passwords are Base64 encoded when saved to settings (basic obfuscation)
- Recommended to use this tool in a secure environment
- Keep your private key files and passwords safe

## Settings Storage

User settings are automatically saved to:
```
%USERPROFILE%\AppData\Local\PgpTool\
```

Settings include:
- Public key file path
- Private key file path
- Password (Base64 encoded)
- Output directory preference

## License

This project is for educational and personal use only.

## Contributing

Bug reports and feature requests are welcome.

## Changelog

### v1.0.0 (2025-08-11)
- Basic PGP encryption/decryption functionality
- English graphical user interface
- Key management system
- File operations with drag-and-drop support
- Output configuration options
- Settings persistence
- Asynchronous operations for UI responsiveness
- Comprehensive error handling and validation
