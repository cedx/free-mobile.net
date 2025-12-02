namespace Belin.FreeMobile.Cmdlets;

using System.Net;

/// <summary>
/// Creates a new Free Mobile client.
/// </summary>
[Cmdlet(VerbsCommon.New, "Client")]
[OutputType(typeof(Client))]
public class NewClientCommand: PSCmdlet {

	/// <summary>
	/// The Free Mobile user name and password.
	/// </summary>
	[Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true), Credential]
	public required PSCredential Credential { get; set; }

	/// <summary>
	/// The base URL of the remote API endpoint.
	/// </summary>
	[Parameter]
	public Uri? Uri { get; set; }

	/// <summary>
	/// Performs execution of this command.
	/// </summary>
	protected override void ProcessRecord() =>
		WriteObject(new Client((NetworkCredential) Credential, Uri));
}
