namespace Apical.SendGridMailer.MediatR.Models;
/// <summary>
/// Represents the configuration settings required for sending emails using SendGrid.
/// </summary>
public class EmailSettings
{
    /// <summary>
    /// Gets or sets the SendGrid API key used for authentication.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address from which emails will be sent.
    /// </summary>
    public string FromEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the display name of the sender.
    /// </summary>
    public string FromName { get; set; } = string.Empty;
}

