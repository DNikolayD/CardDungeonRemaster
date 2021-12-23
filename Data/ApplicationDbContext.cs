using Data.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<CardsDataEntity> Cards { get; set; }

        public DbSet<CardTypesDataEntity> CardTypes { get; set; }

        public DbSet<DecksDataEntity> Decks { get; set; }

        public DbSet<DeckTypesDataEntity> DeckTypes { get; set; }

        public DbSet<EffectsDataEntity> Effects { get; set; }

        public DbSet<EffectTypesDataEntity> EffectTypes { get; set; }
    }
}
