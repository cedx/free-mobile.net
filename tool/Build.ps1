Write-Host "Building the project..."
$configuration = $release ? "Release" : "Debug"
dotnet build FreeMobile.slnx --configuration=$configuration
