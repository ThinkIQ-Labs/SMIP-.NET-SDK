using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using smip.sdk;
using smip.sdk.SmipModel;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>(true)
    .Build();

SmipAuthenticator authenticator = config.GetRequiredSection("SMIP").Get<SmipAuthenticator>();

SmipEntry aEntry = new SmipEntry(authenticator);


// get token
await aEntry.AuthorizeGraphQLClient();
Console.WriteLine(aEntry.tokenString);

// get quantities
var aResult = await aEntry.GetGraphQLDataAsync("query q1{quantities{id displayName}}");
Console.WriteLine(JsonConvert.SerializeObject(aResult, Formatting.Indented));

// get quanities as object
var allQuantities = await aEntry.GetGraphQLDataAsync<List<SmipQuantity>>("query q1{quantities{id displayName measurementUnits{displayName}}}", "quantities");
foreach(var aQuantity in allQuantities)
{
    Console.WriteLine(aQuantity.displayName);
    foreach(var aUom in aQuantity.measurementUnits)
    {
        Console.WriteLine($"\t{aUom.displayName}");
    }
}

