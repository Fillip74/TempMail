using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TempMail.Helper;
using TempMail.Messages;
using TempMail.Models;

namespace TempMail
{
    public partial class MailClient
    {
        public async Task<DomainInfo[]> GetDomains()
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync(FormatUri(Endpoints.GetDomains)))
            {
                if (response.IsSuccessStatusCode)
                {
                    DomainsData data = await response.Content.ReadFromJsonAsync<DomainsData>();

                    return data.Domains;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<DomainInfo> GetDomain()
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync(FormatUri(Endpoints.GetDomains)))
            {
                if (response.IsSuccessStatusCode)
                {
                    DomainsData data = await response.Content.ReadFromJsonAsync<DomainsData>();

                    return data.Domains.First();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task CreateAccount(int minLength = 10, int maxLength = 10)
        {
            Check.IsValid(minLength, maxLength);

            CreateAccount createBody = new CreateAccount
            {
                MinLength = minLength,
                MaxLength = maxLength,
            };

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            using (HttpResponseMessage response = await _httpClient.PostAsJsonAsync<CreateAccount>(FormatUri(Endpoints.CreateAccount), createBody, options))
            {
                if (response.IsSuccessStatusCode)
                {
                    AccountInfo account = await response.Content.ReadFromJsonAsync<AccountInfo>();
                    Email = account.Email;
                    Token = account.Token;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task CreateAccount(string name, string domain)
        {
            Check.IsValid(name, nameof(name));
            Check.IsValid(domain, nameof(domain));

            CreateAccount randomParam = new CreateAccount
            {
                Name = name,
                Domain = domain,
            };

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            using (HttpResponseMessage response = await _httpClient.PostAsJsonAsync<CreateAccount>(FormatUri(Endpoints.CreateAccount), randomParam, options))
            {
                if (response.IsSuccessStatusCode)
                {
                    AccountInfo account = await response.Content.ReadFromJsonAsync<AccountInfo>();
                    Email = account.Email;
                    Token = account.Token;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public void Login(string fullAddress, string token = null)
        {
            Check.IsValid(fullAddress, nameof(fullAddress));

            Email = fullAddress;
            Token = token;
        }

        public async Task<Message[]> GetMessages()
        {
            Check.IsValid(Email, nameof(Email));

            using (HttpResponseMessage response = await _httpClient.GetAsync(FormatUri(Endpoints.GetMessages, Email)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Message[]>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}