$DEV_PASSWORD = "dev-pass"
$ARTICLES_CSPROJ_PATH = "..\..\Articlib\Articles\Source\Articlib.Articles.Api\Articlib.Articles.Api.csproj"
$IDENTITY_CSPROJ_PATH = "..\..\Articlib\Identity\Source\Articlib.Identity.Api\Articlib.Identity.Api.csproj"

Invoke-Expression -Command "dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Articlib.Articles.Api.pfx -p $DEV_PASSWORD"
Invoke-Expression -Command "dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\Articlib.Identity.Api.pfx -p $DEV_PASSWORD"
Invoke-Expression -Command "dotnet dev-certs https -t"

Invoke-Expression -Command "dotnet user-secrets -p $ARTICLES_CSPROJ_PATH set Kestrel:Certificates:Development:Password $DEV_PASSWORD"
Invoke-Expression -Command "dotnet user-secrets -p $IDENTITY_CSPROJ_PATH set Kestrel:Certificates:Development:Password $DEV_PASSWORD"
