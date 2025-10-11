Write-Output "Updating the version number in the sources..."
$version = (Import-PowerShellDataFile "Package.psd1").Version
foreach ($item in Get-ChildItem "*/*.csproj") {
	(Get-Content $item) -replace "<Version>\d+(\.\d+){2}</Version>", "<Version>$version</Version>" | Out-File $item
}
