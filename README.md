# SMIP C# SDK

## Usage

Refer to the [test project](./smip.sdk.test/Program.cs) for a short console application demonstrating the usage of the SDK.

### Authenticator Class and Configuration

We can use either an appsettings.json or a user secrets json file to store the required authenticator information, including:

- graphQlEndpoint
- clientId
- clientSecret
- role
- userName

``` C#
SmipAuthenticator authenticator = config.GetRequiredSection("SMIP").Get<SmipAuthenticator>();
```

### Create new instance of SMIP GraphQL client

A new instance is created with the authenticator object. The client automatically pulls a token if none is present or renews the token when an existing token is about to expire. Alternatively, we can explicitely pull a token:

``` C#
SmipEntry aEntry = new SmipEntry(authenticator);
await aEntry.AuthorizeGraphQLClient();
Console.WriteLine(aEntry.tokenString);
```

### GraphQL Requests

We have two methods to make requests: either get a JObject with the complete response or specify the node and have the response explicitely cast as a SMIP SDK object.

The following object types are included. The list can easily be extended as needed:

- Attribute
- Equipment
- MeasurementUnit
- Quantity
- Thing (the base class for most object types in the smip)
- TimeSeries (a time series record with timestamp, intvalue, and an example of timezone conversion using NodaTime)

``` C#
// get quantities
var aResult = await aEntry.GetGraphQLDataAsync("query q1{quantities{id displayName}}");
Console.WriteLine(JsonConvert.SerializeObject(aResult, Formatting.Indented));
```

``` C#
// get quanities as object
// here we return a List<SmipQuantity>
// note that each quantity can include units if they are included in the query
var allQuantities = await aEntry.GetGraphQLDataAsync<List<SmipQuantity>>(
  "query q1{quantities{id displayName measurementUnits{displayName}}}", 
  "quantities"
);
```
