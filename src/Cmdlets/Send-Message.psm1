using namespace Belin.FreeMobile
using namespace System.Management.Automation
using namespace System.Net
using module ./New-Client.psm1

<#
.SYNOPSIS
	Sends an SMS message to the specified Free Mobile account.
#>
function Send-Message {
	[CmdletBinding(DefaultParameterSetName = "Credential")]
	[OutputType([void])]
	param (
		# The message text.
		[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
		[string] $Message,

		# The Free Mobile client to use.
		[Parameter(Mandatory, ParameterSetName = "Client")]
		[Client] $Client,

		# The Free Mobile user name and password.
		[Parameter(Mandatory, ParameterSetName = "Credential")]
		[Credential()]
		[pscredential] $Credential,

		# The base URL of the remote API endpoint.
		[Parameter(ParameterSetName = "Credential")]
		[uri] $Uri
	)

	begin {
		if ($PSCmdlet.ParameterSetName -eq "Credential") { $Client = New-Client $Credential -Uri $Uri }
	}

	process {
		$Client.SendMessage($Message)
	}
}
