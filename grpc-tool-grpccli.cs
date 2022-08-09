// Install
dotnet tool install -g dotnet-grpc-cli

// Základní příkazy
dotnet grpc-cli ls http://localhost:5000
dotnet grpc-cli ls http://localhost:5000 greet.Greeter
dotnet grpc-cli dump http://localhost:5000 greet.Greeter
dotnet grpc-cli dump http://localhost:5000 greet.Greeter -o ./protos