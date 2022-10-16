// Projekt.csproj
<PackageReference Include="Inferno" Version="1.6.4" />

// random number
Random.Shared.Next(11111111, 99999999)
CryptoRandom.Shared.Next(11111111, 99999999)

// RandomNumberGenerator
private static int GetRandomNumber(RandomNumberGenerator generator, int min, int max)
{
    max = max - 1;

    var bytes = new byte[sizeof(int)];
    generator.GetNonZeroBytes(bytes);
    int val = BitConverter.ToInt32(bytes);
    
    var result = ((val - min) % (max - min + 1) + (max - min + 1)) % (max - min + 1) + min;
    return result;
}

// SHA
var sha256 = SecurityDriven.Inferno.Hash.HashFactories.SHA256;
using (var hasher = sha256())
{
    var hash = await hasher.ComputeHashAsync(Form.File.OpenReadStream(), ctn);
    var hashString = string.Concat(hash.Select(x => x.ToString("x2")));
}

// HMACSHA
var hmac = SecurityDriven.Inferno.Mac.HMACFactories.HMACSHA256;
using var hasher = hmac();
hasher.Key = Encoding.ASCII.GetBytes(salt);
var byteHash = hasher.ComputeHash(Encoding.ASCII.GetBytes(str));
var hashString string.Concat(byteHash.Select(x => x.ToString("x2")));