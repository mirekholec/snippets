// nastavení e-mailu pro doménu
az communication email domain sender-username create --email-service-name "CommunicationEmailSvcs" --resource-group "MiroslavHolec" --domain-name "dotnetnews.cz" --sender-username "mirek" --username "mirek"

// aktualizace e-mailu (název účtu)
az communication email update --ids  --email-service-name "CommunicationEmailSvcs" --resource-group "MiroslavHolec" --set name="Dotnet News" 

// odstranění e-mailu
az communication email domain sender-username delete --email-service-name "CommunicationEmailSvcs" --resource-group "MiroslavHolec" --domain-name "dotnetnews.cz" --name "DoNotReply"