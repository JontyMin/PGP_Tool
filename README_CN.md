# PGP 加密解密工具

一个基于 C# WinForms 和 PgpCore 库开发的用户友好的 PGP 加密解密工具。

## 功能特性

- **密钥管理**: 支持加载和管理 PGP 公钥和私钥
- **文件加密**: 使用公钥加密任意文件
- **文件解密**: 使用私钥和密码解密 PGP 加密文件
- **灵活输出**: 可配置输出目录和自定义文件名
- **用户友好**: 直观的图形界面，支持文件浏览选择
- **安全性**: 密码字段安全处理，支持完整性检查
- **设置记忆**: 自动记住密钥路径、密码和输出目录

## 系统要求

- .NET 8.0 或更高版本
- Windows 操作系统
- PgpCore 6.5.0+ 库

## 使用方法

### 加密文件

1. 在"Key Management"区域选择公钥文件 (.asc 或 .pub)
2. 在"File Selection"区域选择要加密的文件
3. 在"Output Configuration"区域设置输出目录（可选择自定义文件名）
4. 点击"Encrypt File"按钮

### 解密文件

1. 在"Key Management"区域选择私钥文件 (.asc 或 .key)
2. 输入私钥密码
3. 在"File Selection"区域选择要解密的 PGP 文件
4. 在"Output Configuration"区域设置输出目录（可选择自定义文件名）
5. 点击"Decrypt File"按钮

## 项目结构

```text
pgp_tool/
├── Program.cs              # 应用程序入口点
├── Form1.cs               # 主窗体逻辑 (MainForm)
├── Form1.Designer.cs      # 主窗体设计器代码
├── PgpTool.csproj         # 项目文件
├── Properties/            # 应用程序设置
│   ├── Settings.settings  # 用户设置配置
│   └── Settings.Designer.cs # 自动生成的设置类
├── .github/
│   └── copilot-instructions.md # Copilot 开发指南
└── README.md              # 项目说明
```

## 构建和运行

### 使用 .NET CLI

```bash
# 还原依赖项
dotnet restore

# 构建项目
dotnet build

# 运行应用程序
dotnet run

# 发布为可执行文件
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true -o ./publish
```

### 使用 Visual Studio

1. 打开 `PgpTool.csproj` 文件
2. 按 F5 开始调试运行

## 依赖项

- **PgpCore**: PGP 加密解密核心库
- **.NET 8.0 Windows Forms**: UI 框架
- **System.Configuration.ConfigurationManager**: 设置管理

## 发布版本

### 框架依赖版本（推荐）

- **文件**: `publish/PgpTool.exe`
- **大小**: ~7 MB
- **要求**: 目标机器需要安装 .NET 8 运行时

### 自包含版本

- **文件**: `publish-release/PgpTool.exe`
- **大小**: ~153 MB
- **要求**: 无需安装 .NET

## 安全注意事项

- 私钥密码在内存中以明文形式暂时存储，应用程序关闭后会被清理
- 保存设置时密码使用 Base64 编码（基本混淆）
- 建议在安全的环境中使用此工具
- 请妥善保管您的私钥文件和密码

## 设置存储

用户设置自动保存到：

```text
%USERPROFILE%\AppData\Local\PgpTool\
```

设置包括：

- 公钥文件路径
- 私钥文件路径
- 密码（Base64编码）
- 输出目录偏好

## 许可证

本项目仅供学习和个人使用。

## 贡献

欢迎提交问题报告和功能请求。

## 更新日志

### v1.0.0 (2025-08-11)

- 基础的 PGP 加密解密功能
- 英文图形用户界面
- 密钥管理系统
- 文件操作支持
- 输出配置选项
- 设置持久化
- 异步操作保持界面响应性
- 全面的错误处理和验证
