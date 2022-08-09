// Install
https://github.com/fullstorydev/grpcurl#installation (windows - release page)
brew install grpcurl

// Základní příkazy
grpcurl localhost:443 list                  // seznam endpointů
grpcurl -plaintext localhost:5000 list      // seznam endpointů, bez TLS
grpcurl -import-path ../protos -proto my-stuff.proto list

grpcurl localhost:8787 describe my.custom.server.Service.MethodOne

grpcurl grpc.server.com:443 my.custom.server.Service/Method
grpcurl -plaintext grpc.server.com:80 my.custom.server.Service/Method