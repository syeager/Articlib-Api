Write-Output "Set environment variables"
Invoke-Expression -Command ".\\set-environment-variables.ps1"

Write-Output "Install HTTPS certs"
Invoke-Expression -Command ".\\https-certs-install.ps1"