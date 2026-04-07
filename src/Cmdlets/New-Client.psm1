using namespace Belin.FreeMobile
using namespace System.Diagnostics.CodeAnalysis
using namespace System.Net

<#
.SYNOPSIS
	Creates a new Free Mobile client.
.INPUTS
	The Free Mobile user name and password.
.OUTPUTS
	The newly created client.
#>
function New-Client {
	[CmdletBinding()]
	[OutputType([Belin.FreeMobile.Client])]
	[SuppressMessage("PSUseShouldProcessForStateChangingFunctions", "")]
	param (
		# The Free Mobile user name and password.
		[Parameter(Mandatory, Position = 0, ValueFromPipeline)]
		[Credential()]
		[pscredential] $Credential,

		# The base URL of the remote API endpoint.
		[uri] $Uri
	)

	process {
		[Client]::new([NetworkCredential] $Credential, $Uri)
	}
}
