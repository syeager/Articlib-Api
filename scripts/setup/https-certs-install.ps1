$DEV_PASSWORD = "dev-pass"

$services = "Core", "Notifications"

foreach ($service in $services) {
    Invoke-Expression -Command "dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Articlib.$service.Api.pfx -p $DEV_PASSWORD"

    $CSPROJ_PATH = "..\..\Articlib\$service\Source\Articlib.$service.Api\Articlib.$service.Api.csproj"
    Invoke-Expression -Command "dotnet user-secrets init -p $CSPROJ_PATH"
    Invoke-Expression -Command "dotnet user-secrets -p $CSPROJ_PATH set Kestrel:Certificates:Development:Password $DEV_PASSWORD"
}

Invoke-Expression -Command "dotnet dev-certs https -t"
