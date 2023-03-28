param(
  [Parameter(Mandatory)] [string] $Configuration,
  [Parameter(Mandatory)] [string] $SimhubInstallationDirectory,
  [string] $ShortcutDestinationPath = ".")

$ConfigurationPath = ".\SimHubToF12020UDP\bin\$Configuration"

$configuration_path_exists = Test-Path $ConfigurationPath

$simhub_installation_path_exists = Test-Path $SimhubInstallationDirectory

Write-Output "Configuration path is:             $ConfigurationPath" 
Write-Output "Simhub installation path is:       $SimhubInstallationDirectory"

Write-Output "Configuration path is valid:       $configuration_path_exists"
Write-Output "Simhub installation path is valid: $simhub_installation_path_exists"

$pluginFileName = "SimHubToF12020UDP.dll"

$source_SimHubToF12020_plugin_filePath = "$ConfigurationPath\$pluginFileName"
$destination_SimHubInstallation_filePath = "$SimhubInstallationDirectory\$pluginFileName"

Write-Output "Source plugin path:                $source_SimHubToF12020_plugin_filePath"
Write-Output "Destination plugin path:           $destination_SimHubInstallation_filePath"

Copy-Item $source_SimHubToF12020_plugin_filePath $destination_SimHubInstallation_filePath -Verbose

