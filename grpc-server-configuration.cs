// WebApplicationBuilder (builder.Services)
Services.AddGrpc(x =>
{
    x.EnableDetailedErrors = true;               // detailní chyby vrácené na klienta
    x.MaxSendMessageSize = null;                 // maximální velikost zprávy odeslané ze serveru
    x.MaxReceiveMessageSize = 4 * 1024 * 1024;   // maximální velikost přijaté zprávy
}).AddServiceOptions<GreeterService>(x=>         // nastavení pro jednu konkrétní službu
{
    x.MaxReceiveMessageSize = 1 * 1024 * 1024;
});