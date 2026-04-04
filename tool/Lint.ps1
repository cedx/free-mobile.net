"Performing the static analysis of source code..."
Import-Module PSScriptAnalyzer
$PSScriptRoot, "test" | Invoke-ScriptAnalyzer -ExcludeRule PSAvoidUsingConvertToSecureStringWithPlainText -Recurse
Test-ModuleManifest FreeMobile.psd1 | Out-Null
