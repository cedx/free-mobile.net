Write-Host "Updating the version number in the sources..."
$version = (Select-Xml "//Version" Package.xml).Node.InnerText
foreach ($item in Get-ChildItem "*/*.csproj") {
	(Get-Content $item) -replace "<Version>\d+(\.\d+){2}</Version>", "<Version>$version</Version>" | Out-File $item
}
