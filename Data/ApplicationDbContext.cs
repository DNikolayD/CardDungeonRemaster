using Data.Entities;
using Data.Entities.Common;
using Data.Entities.Forum;
using Data.Entities.User;
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

        public DbSet<CardsDataEntity> Cards { get; init; }

        public DbSet<CardTypesDataEntity> CardTypes { get; init; }

        public DbSet<DecksDataEntity> Decks { get; init; }

        public DbSet<DeckTypesDataEntity> DeckTypes { get;  init; }

        public DbSet<EffectsDataEntity> Effects { get; init; }

        public DbSet<EffectTypesDataEntity> EffectTypes { get; init; }

        public DbSet<CategoriesDataEntity> Categories { get; init; }

        public DbSet<PostsDataEntity> Posts { get; init; }

        public DbSet<CommentsDataEntity> Comments { get; init; }

        public DbSet<ImagesDataEntity> Images { get; init; }

        public DbSet<ApplicationRole> Roles { get; init; }

        public DbSet<ApplicationUser> Users { get; init; }

    }
}
