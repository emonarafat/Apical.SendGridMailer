# 📧 SendGrid Email Service for ASP.NET Core

![NuGet](https://img.shields.io/nuget/v/Apical.SendGridMailer.MediatR.svg)
![Build](https://img.shields.io/github/actions/workflow/status/emonarafat/Apical.SendGridMailer/dotnet.yml?branch=main)
![License](https://img.shields.io/github/license/emonarafat/Apical.SendGridMailer.svg)
![.NET](https://img.shields.io/badge/dotnet-9.0-blue.svg)

A modular, plug-and-play email service for .NET 9+ projects, featuring:
- ✅ SendGrid integration  
- ✅ MediatR command handling  
- ✅ Typed configuration via `IOptions<EmailSettings>`  
- ✅ Built-in controller with support for text/HTML emails and attachments  
- ✅ Clean architecture — ideal for use as a NuGet package or shared module  

---

## 🚀 Features

- Send email with both **HTML and plain text bodies**
- Attach multiple files via `multipart/form-data`
- Uses **MediatR** for decoupled command handling
- Configuration via `appsettings.json`
- Ready-to-use **`EmailController`** built into the library
- Designed for **separation of concerns** (can be plugged into any ASP.NET Core API)

---

## 📦 Installation

### Option 1: Install from NuGet

```bash
dotnet add package Apical.SendGridMailer.MediatR
````

### Option 2: Local Project Reference

```xml
<ProjectReference Include="..\Apical.SendGridMailer\Apical.SendGridMailer.MediatR.csproj" />
```

---

## 🛠 Configuration

### `appsettings.json` in your API project

```json
"EmailSettings": {
  "ApiKey": "YOUR_SENDGRID_API_KEY",
  "FromEmail": "you@example.com",
  "FromName": "Your Name"
}
```

---

## 🧩 Integration Steps

### 1. Register Services in `Program.cs`

```csharp

builder.Services.AddEmailServices(builder.Configuration); // Extension method from package
```

### 2. Use the Built-in API Endpoint

```
POST /api/email/send
Content-Type: multipart/form-data

Form Fields:
- toEmail
- subject
- htmlBody
- textBody
- attachments[] (optional files)
```

---

## 📁 Folder Structure

```
Apical.SendGridMailer.MediatR/
├── Features/              // MediatR command + handler
├── Interfaces/            // IEmailDispatcher
├── Services/              // SendGridEmailSender (implements IEmailDispatcher)
├── Models/                // EmailSettings (for IOptions)
├── Extensions/            // AddEmailServices() for DI setup
```

---

## 🔒 Security

This library depends on SendGrid — keep your API key safe. Use [Azure Key Vault](https://learn.microsoft.com/en-us/azure/key-vault/) or environment secrets in production.

---

## 📄 License

MIT — free for personal and commercial use.

---

## 🧑‍💻 Author

**Yaseer Arafat**
🔗 [LinkedIn](https://www.linkedin.com/in/yaseerarafat)
🛠 Founder at [Apical Automate](https://github.com/apicalautomate)

---