<#
.SYNOPSIS
	Tests the features of the `Send-Message` cmdlet.
#>
Describe "Send-Message" {
	BeforeAll {
		Import-Module "$PSScriptRoot/../../FreeMobile.psd1"
	}

	It "should throw an exception if a network error occurred" {
		$credential = [pscredential]::new("anonymous", (ConvertTo-SecureString "secret" -AsPlainText))
		{ "Hello World!" | Send-FreeMobileMessage -Credential $credential -Uri "http://localhost:666" } | Should -Throw
	}

	It "should throw an exception if the credentials are invalid" {
		$credential = [pscredential]::new("anonymous", (ConvertTo-SecureString "secret" -AsPlainText))
		{ "Hello World!" | Send-FreeMobileMessage -Credential $credential } | Should -Throw
	}

	It "should send SMS messages if the credentials are valid" {
		$credential = [pscredential]::new($Env:FREEMOBILE_ACCOUNT, (ConvertTo-SecureString $Env:FREEMOBILE_API_KEY -AsPlainText))
		{ "Hello Cédric, from PowerShell!" | Send-FreeMobileMessage -Credential $credential } | Should -Not -Throw
	}
}
