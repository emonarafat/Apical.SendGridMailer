using MediatR;

using Microsoft.AspNetCore.Http;

namespace Apical.SendGridMailer.MediatR.Features.SendEmail;
/// <summary>
/// Command to send an email with optional attachments.
/// </summary>
public class SendEmailCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets the recipient's email address.
    /// </summary>
    public string ToEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the subject of the email.
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the HTML body of the email.
    /// </summary>
    public string HtmlBody { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the plain text body of the email.
    /// </summary>
    public string TextBody { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of attachments for the email.
    /// </summary>
    public List<IFormFile>? Attachments { get; set; }
}

