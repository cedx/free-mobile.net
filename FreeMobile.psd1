@{
	DefaultCommandPrefix = "FreeMobile"
	ModuleVersion = "3.3.0"
	PowerShellVersion = "7.5"
	RootModule = "bin/Belin.FreeMobile.Cmdlets.dll"

	Author = "Cédric Belin <cedx@outlook.com>"
	CompanyName = "Cedric-Belin.fr"
	Copyright = "© Cédric Belin"
	Description = "Send SMS messages to your Free Mobile device."
	GUID = "8a16d600-a064-4037-9147-d13059c6abf7"

	AliasesToExport = @()
	FunctionsToExport = @()
	VariablesToExport = @()

	CmdletsToExport = @(
		"New-Client"
		"Send-Message"
	)

	RequiredAssemblies = @(
		"bin/Belin.FreeMobile.dll"
	)

	PrivateData = @{
		PSData = @{
			LicenseUri = "https://github.com/cedx/free-mobile.net/blob/main/License.md"
			ProjectUri = "https://github.com/cedx/free-mobile.net"
			ReleaseNotes = "https://github.com/cedx/free-mobile.net/releases"
			Tags = "api", "client", "free", "mobile", "sms"
		}
	}
}
