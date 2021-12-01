$DEV_PASSWORD = "dev-pass"
$CORE_CSPROJ_PATH = "..\..\Articlib\Core\Source\Articlib.Core.Api\Articlib.Core.Api.csproj"
$NOTIFICATIONS_CSPROJ_PATH = "..\..\Articlib\Notifications\Source\Articlib.Notifications.Api\Articlib.Notifications.Api.csproj"

Invoke-Expression -Command "dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Articlib.Core.Api.pfx -p $DEV_PASSWORD"
Invoke-Expression -Command "dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Articlib.Notifications.Api.pfx -p $DEV_PASSWORD"
Invoke-Expression -Command "dotnet dev-certs https -t"

Invoke-Expression -Command "dotnet user-secrets -p $CORE_CSPROJ_PATH set Kestrel:Certificates:Development:Password $DEV_PASSWORD"
Invoke-Expression -Command "dotnet user-secrets -p $NOTIFICATIONS_CSPROJ_PATH set Kestrel:Certificates:Development:Password $DEV_PASSWORD"
