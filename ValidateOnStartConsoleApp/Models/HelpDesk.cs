
#nullable disable
namespace ValidateOnStartConsoleApp.Models;
/// <summary>
/// Represents a help desk entity containing contact information such as phone and email.
/// </summary>
public class HelpDesk
{
    /// <summary>
    /// Gets or sets the phone number associated with the help desk.
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Gets or sets the email address associated with the help desk.
    /// </summary>
    public string Email { get; set; }
}
