namespace Apical.SendGridMailer.MediatR.Interfaces;
/// <summary>
/// Defines a contract for dispatching email messages asynchronously.
/// </summary>
public interface IEmailDispatcher
{
    /// <summary>
    /// Sends an email message asynchronously.
    /// </summary>
    /// <param name="toEmail">The recipient's email address.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="textBody">The plain text body content of the email.</param>
    /// <param name="htmlBody">The HTML body content of the email.</param>
    /// <param name="attachments">
    /// Optional. A list of attachments, where each attachment is a tuple containing the file name, content as a byte array, and MIME type.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains <c>true</c> if the email was sent successfully; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> SendEmailAsync(
        string toEmail,
        string subject,
        string? textBody = null,
        string? htmlBody=null,
        List<(string FileName, byte[] Content, string MimeType)>? attachments = null);
}
