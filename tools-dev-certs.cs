// Likvidace nefunkčních certifikátů
used certmgr to remove all localhost certs
dotnet dev-certs https --clean

// Nastavení nových cert
dotnet dev-certs https --trust

// Kontrola nastavení
dotnet dev-certs https --check