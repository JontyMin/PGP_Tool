# Copilot Instructions for PGP Tool

<!-- Use this file to provide workspace-specific custom instructions to Copilot. For more details, visit https://code.visualstudio.com/docs/copilot/copilot-customization#_use-a-githubcopilotinstructionsmd-file -->

This is a C# WinForms application project for PGP encryption and decryption using the PgpCore library.

## Project Guidelines

- This application provides a user-friendly interface for PGP operations
- Uses PgpCore library for all cryptographic operations
- Implements key management for public/private keys
- Supports file encryption/decryption with configurable output directories
- Follow Windows Forms best practices for UI design
- Implement proper error handling and user feedback
- Use async/await patterns for file operations to keep UI responsive

## Key Features

1. **Key Management**: Load and manage PGP public/private keys
2. **File Operations**: Encrypt/decrypt files with drag-and-drop support
3. **Configuration**: Password input, output directory selection
4. **Security**: Secure password handling and memory management
