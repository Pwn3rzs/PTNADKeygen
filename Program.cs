using System.Security.Cryptography;
using Jose;

namespace PTADKeygen;

public class LicenseFeatures
{
    [JsonProperty("number")] public int Number { get; set; }

    [JsonProperty("generation")] public int Generation { get; set; }

    [JsonProperty("client")] public string Client { get; set; }

    [JsonProperty("product")] public string Product { get; set; }

    [JsonProperty("expired")] public int Expired { get; set; }

    [JsonProperty("comment")] public string Comment { get; set; }

    [JsonProperty("secret")] public string Secret { get; set; }

    [JsonProperty("token")] public string Token { get; set; }

    [JsonProperty("serial")] public string Serial { get; set; }

    [JsonProperty("vendors")] public List<object> Vendors { get; set; }

    [JsonProperty("parameters")] public Parameters Parameters { get; set; }

    [JsonProperty("unlimited")] public bool Unlimited { get; set; }
}

public class Parameters
{
    [JsonProperty("Type")] public string Type { get; set; }

    [JsonProperty("product")] public string Product { get; set; }

    [JsonProperty("throughput")] public int Throughput { get; set; }

    [JsonProperty("pcap_storage")] public bool pcap_storage { get; set; }
}

public class RootLicense
{
    [JsonProperty("LicenseFeatures")] public LicenseFeatures license_features { get; set; }

    [JsonProperty("instance_access_token_jwt")]
    public string instance_access_token_jwt { get; set; }

    [JsonProperty("prod_data")] public string prod_data { get; set; }
}

public class JsonPropertyAttribute : Attribute
{
    public JsonPropertyAttribute(string unlimited)
    {
        throw new NotImplementedException();
    }
}

internal class Program
{
    public static string RSA_PUBLIC_KEY =
        "-----BEGIN PUBLIC KEY-----MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAv7notQ4zg8LTC2n/YOGQ4UJKrue6oL9Z4RV0HoQxDjwdtAj5ySJm9RfKVc1WvsB3skuAwrW1vQzINZ8avCrPXJzyt7Uee+2xTImeTFuybi6nTzYaYanUwp0BcV4swJSbkzB5OOxJOQX1TiODx3+i1E1SfqLLrjkNu6vEwOJrG9PB6FDZVRekzFkzG98nGqnoEMkJaPITK9S5q0IMxurRQtZjG0vEutbN0XeQHWuWEEsgar1SNmfk6Bfl+e2Sb/yoK8dFGpC+tCNthvasN6oqgnBz7PjAKKJmapp8G8j6xMkm56qy6MGtlXGnmgTSigOVG62H9Fu6yurXxtCmQCTsWwIDAQAB-----END PUBLIC KEY-----";

    public static string RSA_PRIVATE_KEY =
        "-----BEGIN RSA PRIVATE KEY-----MIIEpQIBAAKCAQEAv7notQ4zg8LTC2n/YOGQ4UJKrue6oL9Z4RV0HoQxDjwdtAj5ySJm9RfKVc1WvsB3skuAwrW1vQzINZ8avCrPXJzyt7Uee+2xTImeTFuybi6nTzYaYanUwp0BcV4swJSbkzB5OOxJOQX1TiODx3+i1E1SfqLLrjkNu6vEwOJrG9PB6FDZVRekzFkzG98nGqnoEMkJaPITK9S5q0IMxurRQtZjG0vEutbN0XeQHWuWEEsgar1SNmfk6Bfl+e2Sb/yoK8dFGpC+tCNthvasN6oqgnBz7PjAKKJmapp8G8j6xMkm56qy6MGtlXGnmgTSigOVG62H9Fu6yurXxtCmQCTsWwIDAQABAoIBABDAT4KyMPIMLaBLrJJsYtorjpbljDrLPTEbTL/10MtrmTTHq/tU1CYJ5BXHERMtgcfELQXWFoDkAwIcWpuiKefvlo1Sd81gISOMypXlVRunW9rh4UAzNHGkgiHDlqlk0orzq0O78VHYIWyoUbU2g6WE8/Y4hw870OVaxqALqEwP93paYaiAKsHY5QSlhlueAUBBDuGv5SvWc78pRM21qGq7kUyha5ondmLJDKUS+y2VpIKSvJIB8BtILk+1G/DCvjGDGwgNoH2OMe6KmIjIz/hQVGBlTHAnNLohLAM0OoD4+iYe39NHFVRw11EO3Ar84Ji2Go55im6gCTkKgh1++SECgYEA8vQDn+YStNPknsoYbj2Rg7y9ZSGu43TJnDAzN4UERrlyhv9qSBUCJT2CaxILlXtaPnwcnWRFX/wycy490qnhI8YBcqzXlo0rG5nq3lZjB45RGmPRx4Dr72eMHyAbKENbTDajxDjDlxXQj2G3jrp2ouXVsl09DfZVuy5fhVxkk/kCgYEAygWnn8a+sGUF18KYiceHlmPbwMTbsWGT8Pfte3B3TRcG3XD5LANQHmsHre+VSIl1e7geBHU1SqgbBvbPr8YqlgBQ7hiRsyRviRApzNWu04BQf4FjM20pJawlyLajdogRtHYlKFq84D5v1jwjjCfaZkqlWL0eGRtKRtdnPa5/7/MCgYEAsqv7wmtMVIoEdza/Msu6qTxzuN1FpedsoZ3c/LapR234qQlL20j/8+1BbYau2DcITi2uSZ3FW2q4m3ZlZvkiJtHmnLQ6NHELQ9g1H2A+of7q7FJ+o47PdJgdN4LAFiM7EFiapaLtTL5xTBEcEi5VM0V9nBfv38XKlMbs3sHtAdkCgYEAvXa2MSN8fQQRibtHwZeucn2uf8hf3aiMzaZHQ8hDKrpYxt8H4J4uyohISHj0AXZhBymyhS3DUAP+bPaV6tyn3cvoGpRSOLcIH3xYJ3GTp2mklSAsf/N1bo5XVTjsbuLH7/4JdSI8FvaXfk0ibXSG3/5LucCLdLJiY7PqcC+ybr8CgYEAu98QetLXaPkYZO3Tf1Fzou5AYRDw52oyjQf4pWkcjTy6tEaPVN+FuDjMDvb8KxTlLjt+e65pS4WaHNzZU4wlRflrHdga43+6nfP6xOW012GycCLl4W8Flz4G05HWyqCr8OlZw1meYTiWroCB6bPx3F6B1mh/GmdxN6dPAxZeP4c=-----END RSA PRIVATE KEY-----";

    public static string GenJwt()
    {
        var license = new RootLicense();
        license.license_features = new LicenseFeatures();
        license.license_features.Client = "Pwn3rzs";
        license.license_features.Comment = "by Pwn3rzs / CyberArsenal";
        license.license_features.Parameters = new Parameters()
            { Product = "PTNAD", Throughput = 200000000, pcap_storage = true, Type = "SRV" };
        license.license_features.Generation = 1;
        license.license_features.Product = "PTNAD.KB";
        license.license_features.Expired =
            (int)DateTime.UtcNow.AddYears(40).Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        license.license_features.Number = 12345;
        license.license_features.Serial = "PTNAD-Unlimited-Pwn3rzs";
        license.license_features.Secret = "pwn3rzs";
        license.license_features.Unlimited = true;
        license.license_features.Vendors = new List<object>();
        license.license_features.Token = "";
        license.instance_access_token_jwt =
            "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik9NSFI6T1daRzpVUU5LOllSWE06VTdGQjpDSk1COlZTR0g6Q1NHSDpCV0FHOjRPUzY6NTVHUDpYVjZHIn0.eyJlbnZpcm9ubWVudCI6InByb2R1Y3Rpb24iLCJsaWNlbnNlIjoxMjM0NX0.lj-3ZaDXPSCGqJUHFxiYI0t9aZiF08bXaTQqzAFX9A8ShUsp1i8b_YwH856jAWtxiuFRs0G3DNtO-k6CN2yY-8UgrPcR3gJY0A0tRB_2U47SjY_ENxYj30TF93aw39SRILUihPzL7Ipaci0lEa6V9OmlwpAo1bAe3Nwjzpbh7Bq-mfLrhmqLwfW7g5ifYSqPWUNvl3tOaVTH0UVsLPU9gDUjGdcvmPK9Guwf9FZIrJSWEpRzUCdZORgCAt_anYJZnrELN9j-IV8sFoXCBnGMIfyKRXOqOUyG9LDwVYMhduyh6T79Q0RPXeesGT8aDwFbiSzeJqpOIxqgS1D_I37ejg";
        license.prod_data = "";
        Dictionary<string, object?> payload = license.GetType().GetProperties()
            .ToDictionary(x => x.Name, x => x.GetValue(license));
        var rsaKeys = RSA.Create();
        rsaKeys.ImportFromPem(RSA_PUBLIC_KEY.ToCharArray());
        rsaKeys.ImportFromPem(RSA_PRIVATE_KEY.ToCharArray());
        var licenseEncoded = Jose.JWT.Encode(payload, rsaKeys, JwsAlgorithm.RS256);

        return licenseEncoded;
    }


    public static void Main(string[] args)
    {
        Console.WriteLine("[*] Positive Technolgies Network Attack Discover Keygen by Pwn3rzs / CyberArsenal [*]");
        Console.WriteLine("[*] https://t.me/Pwn3rzs - https://cyberarsenal.org [*]");
        Console.WriteLine("[*] Generating license...");
        try
        {
            Console.WriteLine($"[*] License JWT: \n{GenJwt()}");
            Console.WriteLine("[*] Done, now use your key and enjoy a free world! :)");
        }
        catch (Exception error)
        {
            Console.WriteLine($"[!] Got an error...\n[!] Details: {error.Message}");
        }

    }
}
