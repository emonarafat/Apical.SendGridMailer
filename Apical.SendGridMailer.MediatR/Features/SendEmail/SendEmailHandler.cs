using Apical.SendGridMailer.MediatR.Interfaces;

using MediatR;

namespace Apical.SendGridMailer.MediatR.Features.SendEmail;

/// <summary>
/// Handles the <see cref="SendEmailCommand"/> by dispatching an email using the provided <see cref="IEmailDispatcher"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SendEmailHandler"/> class.
/// </remarks>
/// <param name="emailService">The email dispatcher service used to send emails.</param>
public class SendEmailHandler(IEmailDispatcher emailService) : IRequestHandler<SendEmailCommand, bool>
{

    /// <summary>
    /// Handles the email sending request.
    /// </summary>
    /// <param name="request">The <see cref="SendEmailCommand"/> containing email details and attachments.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation, containing <c>true</c> if the email was sent successfully; otherwise, <c>false</c>.
    /// </returns>
    public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var files = new List<(string FileName, byte[] Content, string MimeType)>();

        if (request.Attachments != null)
        {
            foreach (var file in request.Attachments)
            {
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms, cancellationToken);
                files.Add((file.FileName, ms.ToArray(), file.ContentType));
            }
        }

        // Fix: Explicitly cast 'files' to nullable type using 'as' operator or null-coalescing operator.
        return await emailService.SendEmailAsync(
            request.ToEmail,
            request.Subject,
            request.TextBody,
            request.HtmlBody,
            files.Count > 0 ? files : null
        );
    }
}

