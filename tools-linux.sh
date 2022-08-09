# publikace aplikace
dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true -p:GenerateRuntimeConfigurationFiles=true -o output


# kongiurace systemd
[Unit]
Description=daemon service
After=network.target

[Service]
ExecStart=/usr/bin/dotnet $(pwd)/bin/daemonsrv.dll 10000
Restart=on-failure

[Install]
WantedBy=multi-user.target
EOF




# kopirovani do system location
sudo cp daemonsrv.service /lib/systemd/system

# reload systemd
sudo systemctl daemon-reload 
sudo systemctl enable daemonsrv

# start
sudo systemctl start daemonsrv

# status
systemctl status daemonsrv