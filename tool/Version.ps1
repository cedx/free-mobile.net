Write-Host "Updating the version number in the sources..."
$version = [xml] (Get-Content "etc/Package.xml") | Select-Xml "//Version"
foreach ($item in Get-ChildItem "*/*.csproj") { (Get-Content $item) -replace "<Version>\d+(\.\d+){2}</Version>", "<Version>$version</Version>" | Out-File $item }
