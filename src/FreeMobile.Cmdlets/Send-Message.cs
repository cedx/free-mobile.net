namespace Belin.FreeMobile.Cmdlets;

using System.Net;

/// <summary>
/// Sends an SMS message to the specified Free Mobile account.
/// </summary>
[Cmdlet(VerbsCommunications.Send, "Message", DefaultParameterSetName = "Credential")]
[OutputType(typeof(void))]
public class SendMessageCommand: PSCmdlet {

	/// <summary>
	/// The Free Mobile client to use.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = "Client")]
	public required Client Client { get; set; }

	/// <summary>
	/// The Free Mobile user name and password.
	/// </summary>
	[Parameter(Mandatory = true, ParameterSetName = "Credential"), Credential]
	public required PSCredential Credential { get; set; }

	/// <summary>
	/// The message text.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
	public required string Message { get; set; }

	/// <summary>
	/// The base URL of the remote API endpoint.
	/// </summary>
	[Parameter(ParameterSetName = "Credential")]
	public Uri? Uri { get; set; }

	/// <summary>
	/// Performs initialization of command execution.
	/// </summary>
	protected override void BeginProcessing() {
		if (ParameterSetName == "Credential") Client = new Client((NetworkCredential) Credential, Uri);
	}

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() => Client.SendMessage(Message).Wait();
}
