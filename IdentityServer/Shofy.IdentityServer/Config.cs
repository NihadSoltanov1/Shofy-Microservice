using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Shofy.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
          new ApiResource ("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission", "CatalogWritePermission","CatalogUpdatePermission","CatalogRemovePermission"}},

          new ApiResource ("ResourceDiscount"){Scopes={"DiscountFullPermission","DiscountReadPermission", "DiscountWritePermission","DiscountUpdatePermission","DiscountRemovePermission"}},

          new ApiResource ("ResourceOrder"){Scopes={"OrderFullPermission","OrderReadPermission", "OrderWritePermission","OrderUpdatePermission","OrderRemovePermission"}},
           new ApiResource ("ResourceCargo"){Scopes={"CargoFullPermission","CargoReadPermission"}},
          new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
       {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile(),
          new IdentityResources.Email()
       };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("CatalogWritePermission","Writing authority for catalog operations"),
            new ApiScope("CatalogUpdatePermission","Updating authority for catalog operations"),
            new ApiScope("CatalogRemovePermission","Removing authority for catalog operations"),

            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("DiscountReadPermission","Reading authority for discount operations"),
            new ApiScope("DiscountWritePermission","Writing authority for discount operations"),
            new ApiScope("DiscountUpdatePermission","Updating authority for discount operations"),
            new ApiScope("DiscountRemovePermission","Removing authority for discount operations"),

            new ApiScope("OrderFullPermission","Full authority for discount operations"),
            new ApiScope("OrderReadPermission","Reading authority for discount operations"),
            new ApiScope("OrderWritePermission","Writing authority for discount operations"),
            new ApiScope("OrderUpdatePermission","Updating authority for discount operations"),
            new ApiScope("OrderRemovePermission","Removing authority for discount operations"),

                        new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("CargoReadPermission","Reading authority for cargo operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="ShofyUserId",
                ClientName="Shofy User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("shofysecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission" }
            },

            new Client
            {
                 ClientId="ShofyManagerId",
                ClientName="Shofy User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("shofysecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "BasketFullPermission","DiscountFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile }
            },

             new Client
            {
                ClientId="ShofyAdminId",
                ClientName="Shofy Admin",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("shofysecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "BasketFullPermission","DiscountFullPermission","CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
             }
        };


    }
}