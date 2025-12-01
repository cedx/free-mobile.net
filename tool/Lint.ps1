"Performing the static analysis of source code..."
Import-Module PSScriptAnalyzer
Invoke-ScriptAnalyzer $PSScriptRoot -Recurse
Invoke-ScriptAnalyzer test -Recurse
Test-ModuleManifest FreeMobile.psd1 | Out-Null
