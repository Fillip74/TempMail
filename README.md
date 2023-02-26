# TempMail
Simple .NET API Wrapper for [temp-mail.io](https://temp-mail.io/). This is a unofficial wrapper. 
## Getting started:
Choosing a username and domain
```C#
MailClient client = new MailClient();
DomainInfo domain = await client.GetDomain();
await client.CreateAccount("example", domain.Name);
Message[] messages = await client.GetMessages();
```
Using a random username and domain
```C#
MailClient client = new MailClient();
await client.CreateAccount();
Message[] messages = await client.GetMessages();
```
Using an existing email
```C#
MailClient client = new MailClient();
client.Login("example@example.com");
Message[] messages = await client.GetMessages();
```