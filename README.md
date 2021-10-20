# Rest.CryptoCom.Merchant
This is an unofficial .NET (standard) library for [Crypto.com](https://pay-docs.crypto.com/#overview) REST APIs.

[![.NET](https://github.com/diegostamigni/Rest.CryptoCom.Merchant/actions/workflows/dotnet.yml/badge.svg)](https://github.com/diegostamigni/Rest.CryptoCom.Merchant/actions/workflows/dotnet.yml)

## Description
All APIs are grouped in services:
 * Payments service
 * Refunds service
 * ...

All concrete classes respect a contract (ex. `PaymentsService` -> `IPaymentsService`) making things easier for testing/mocking and people that wants to use dependency injection. All services need at least the `ICryptoComConfig` which exposes the following properties:
 * CryptoComPublicKey
 * CryptoComSecretKey

Because this config is strictly dependant on your project, you are supposed to inherit from it and provide an implementation upon service construction.


### Examples

#### Create payment
```csharp
var config = MyConfig(); // inherits from `ICryptoComConfig`
var paymentsService = new PaymentsService(config);
var result = await paymentsService.CreateAsync(new(1000, "USD"));
...
```

#### Get payment
```csharp
var config = MyConfig(); // inherits from `IGetChangeioConfig`
var paymentsService = new PaymentsService(config);
var result = await paymentsService.GetAsync("payment-id");
...
```

### Supported APIs
* Payments
    - [x] Create a payment
    - [x] List your payments
    - [x] Retrieve a payment by ID
    - [x] Cancel a payment
* Refunds
    - [ ] Request a refund
    - [ ] Retrieve a refund by refund ID
    - [ ] List your refunds by payment ID
* Rebounds
    - [ ] Get rebounds by payment
* Customers
    - [ ] Create a customer
    - [ ] Get customer by ID
    - [ ] Update a customer
    - [ ] List all customers
* Products
    - [ ] Create a product
    - [ ] Get product by ID
    - [ ] List all Products
* Subscriptions
    - [ ] Create a subscription
    - [ ] Get subscription by ID
    - [ ] Cancel a subscription
    - [ ] List all subscriptions

Feel free to contribute! Support for missing APIs and tests are underway.