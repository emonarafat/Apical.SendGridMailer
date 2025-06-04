using Apical.SendGridMailer.MediatR.Interfaces;
using Apical.SendGridMailer.MediatR.Models;

using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace Apical.SendGridMailer.MediatR.Services;

/// <summary>
/// A service for sending emails using SendGrid.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SendGridEmailSender"/> class.
/// </remarks>
/// <param name="options">The email settings options.</param>
public class SendGridEmailSender(IOptions<EmailSettings> options) : IEmailDispatcher
{
    private readonly EmailSettings _settings = options.Value;

    /// <summary>
    /// Sends an email asynchronously using SendGrid.
    /// </summary>
    /// <param name="toEmail">The recipient's email address.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="textBody">The plain text content of the email.</param>
    /// <param name="htmlBody">The HTML content of the email.</param>
    /// <param name="attachments">Optional list of attachments to include in the email.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SendEmailAsync(string toEmail, string subject, string? textBody = null, string? htmlBody = null, List<(string FileName, byte[] Content, string MimeType)>? attachments = null)
    {
        var client = new SendGridClient(_settings.ApiKey);
        var from = new EmailAddress(_settings.FromEmail, _settings.FromName);
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, textBody, htmlBody);

        if (attachments != null)
        {
            foreach (var (fileName, content, mimeType) in attachments)
            {
                var base64 = Convert.ToBase64String(content);
                msg.AddAttachment(fileName, base64, mimeType);
            }
        }

        var response = await client.SendEmailAsync(msg);
        return response.IsSuccessStatusCode;
    }
}
