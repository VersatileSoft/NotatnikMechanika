using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace NotatnikMechanika.IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                //new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource> {
                new ApiResource("Api"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client {
                    ClientId = "blazor",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost:4200" },
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "Api",
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                },

                new Client {
                    ClientId = "wpf",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost/sample-wpf-app" },
                    AllowedCorsOrigins = { "http://localhost" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "Api",
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                },
                new Client {
                    ClientId = "xamarin",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "xamarinformsclients://callback" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "Api",
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                },

            };
        }
    }
}
