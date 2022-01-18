using Data.Entities;
using Data.Entities.Forum;
using Data.Entities.User;
using Service.DTOs;
using Service.DTOs.Posts;
using Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{

    //more relaiable then auto-mapper?

    public static class ConversionsForService
    {
        public static CardsDataEntity GetCardsDataEntity (this CardsDto cardDto)
        {
            return new()
            {
                Id = cardDto.Id,
                Name = cardDto.Name,
                CreatedOn = cardDto.CreatedOn,
                DeletedOn = cardDto.DeletedOn,
                Description = cardDto.Description,
                EditedOn = cardDto.EditedOn,
                IsDeleted = cardDto.IsDeleted,
                IsEdited = cardDto.IsEdited,
                Cost = cardDto.Cost,
                CreatorId = cardDto.Creator.Id,
                TypeId = cardDto.CardType.Id,
                Effects = cardDto.Effects.Select(e => e.GetEffectsDataEntity()),
            };
        }

        public static CardTypesDataEntity GetCardTypesDataEntity (this CardTypesDto cardTypeDto)
        {
            return new()
            {
                Id = cardTypeDto.Id,
                CreatedOn = cardTypeDto.CreatedOn,
                DeletedOn = cardTypeDto.DeletedOn,
                EditedOn = cardTypeDto.EditedOn,
                IsDeleted = cardTypeDto.IsDeleted,
                IsEdited = cardTypeDto.IsEdited,
                Name = cardTypeDto.Name,
            };
        }

        public static EffectsDataEntity GetEffectsDataEntity (this EffectsDto effectDto)
        {
            return new()
            {
                Id = effectDto.Id,
                ActiveTurns = effectDto.ActiveTurns,
                CreatedOn = effectDto.CreatedOn,
                DeletedOn = effectDto.DeletedOn,
                Description = effectDto.Description,
                EditedOn = effectDto.EditedOn,
                IsDeleted = effectDto.IsDeleted,
                IsEdited = effectDto.IsEdited,
                Name = effectDto.Name,
                Value = effectDto.Value
            };
        }

        public static EffectTypesDataEntity GetEffectTypesDataEntity (this EffectTypesDto effectTypeDto)
        {
            return new()
            {
                Id = effectTypeDto.Id,
                CreatedOn = effectTypeDto.CreatedOn,
                DeletedOn = effectTypeDto.DeletedOn,
                EditedOn = effectTypeDto.EditedOn,
                IsDeleted = effectTypeDto.IsDeleted,
                IsEdited = effectTypeDto.IsEdited,
                Name = effectTypeDto.Name,
            };
        }

        public static DecksDataEntity GetDecksDataEntity (this DecksDto deckDto)
        {
            return new()
            {
                CreatedOn = deckDto.CreatedOn,
                DeletedOn = deckDto.DeletedOn,
                Description = deckDto.Description,
                EditedOn = deckDto.EditedOn,
                Id = deckDto.Id,
                IsDeleted = deckDto.IsDeleted,
                IsEdited = deckDto.IsEdited,
                Name = deckDto.Name,
                CreatorId = deckDto.Creator.Id,
                TypeId = deckDto.DeckType.Id
            };
        }

        public static DeckTypesDataEntity GetDeckTypesDataEntity (this DeckTypesDto deckTypeDto)
        {
            return new()
            {
                Name = deckTypeDto.Name,
                Id = deckTypeDto.Id,
                CreatedOn = deckTypeDto.CreatedOn,
                DeletedOn = deckTypeDto.DeletedOn,
                EditedOn = deckTypeDto.EditedOn,
                IsDeleted = deckTypeDto.IsDeleted,
                IsEdited = deckTypeDto.IsEdited,
            };
        }

        public static CardsDto GetCardsDto (this CardsDataEntity cardsDataEntity)
        {
            return new()
            {
                Id = cardsDataEntity.Id,
                Name = cardsDataEntity.Name,
                CreatedOn = cardsDataEntity.CreatedOn,
                DeletedOn = cardsDataEntity.DeletedOn,
                Description = cardsDataEntity.Description,
                EditedOn = cardsDataEntity.EditedOn,
                IsDeleted = cardsDataEntity.IsDeleted,
                IsEdited = cardsDataEntity.IsEdited,
                Cost = cardsDataEntity.Cost,
                Effects = cardsDataEntity.Effects.Select(e => e.GetEffectsDto()),
            };
        }

        public static CardTypesDto GetCardTypesDto (this CardTypesDataEntity cardTypesDataEntity)
        {
            return new()
            {
                IsEdited = cardTypesDataEntity.IsEdited,
                Id = cardTypesDataEntity.Id,
                CreatedOn = cardTypesDataEntity.CreatedOn,
                DeletedOn = cardTypesDataEntity.DeletedOn,
                EditedOn = cardTypesDataEntity.EditedOn,
                IsDeleted = cardTypesDataEntity.IsDeleted,
                Name = cardTypesDataEntity.Name,
            };
        }

        public static EffectsDto GetEffectsDto (this EffectsDataEntity effectsDataEntity)
        {
            return new()
            {
                ActiveTurns = effectsDataEntity.ActiveTurns,
                CreatedOn = effectsDataEntity.CreatedOn,
                DeletedOn = effectsDataEntity.DeletedOn,
                Description = effectsDataEntity.Description,
                EditedOn = effectsDataEntity.EditedOn,
                Id = effectsDataEntity.Id,
                IsDeleted = effectsDataEntity.IsDeleted,
                IsEdited = effectsDataEntity.IsEdited,
                Name = effectsDataEntity.Name,
                Value = effectsDataEntity.Value,
            };
        }

        public static EffectTypesDto GetEffectTypesDto (this EffectTypesDataEntity effectTypesDataEntity)
        {
            return new()
            {
                CreatedOn = effectTypesDataEntity.CreatedOn,
                DeletedOn = effectTypesDataEntity.DeletedOn,
                EditedOn = effectTypesDataEntity.EditedOn,
                Id = effectTypesDataEntity.Id,
                IsDeleted = effectTypesDataEntity.IsDeleted,
                IsEdited = effectTypesDataEntity.IsEdited,
                Name = effectTypesDataEntity.Name,
            };
        }

        public static DecksDto GetDecksDto (this DecksDataEntity decksDataEntity)
        {
            return new()
            {
                CreatedOn = decksDataEntity.CreatedOn,
                DeletedOn = decksDataEntity.DeletedOn,
                Description = decksDataEntity.Description,
                EditedOn = decksDataEntity.EditedOn,
                Id = decksDataEntity.Id,
                IsDeleted = decksDataEntity.IsDeleted,
                IsEdited = decksDataEntity.IsEdited,
                Name = decksDataEntity.Name,
            };
        }

        public static DeckTypesDto GetDeckTypesDto (this DeckTypesDataEntity deckTypesDataEntity)
        {
            return new()
            {
                Name = deckTypesDataEntity.Name,
                CreatedOn = deckTypesDataEntity.CreatedOn,
                DeletedOn = deckTypesDataEntity.DeletedOn,
                EditedOn = deckTypesDataEntity.EditedOn,
                Id = deckTypesDataEntity.Id,
                IsDeleted = deckTypesDataEntity.IsDeleted,
                IsEdited = deckTypesDataEntity.IsEdited,
            };
        }

        public static CategoriesDto GetCategoriesDto (this CategoriesDataEntity categoriesDataEntity)
        {
            return new()
            {
                Id = categoriesDataEntity.Id,
                Name = categoriesDataEntity.Name,
                CreatedOn = categoriesDataEntity.CreatedOn,
                DeletedOn = categoriesDataEntity.DeletedOn,
                Description = categoriesDataEntity.Description,
                EditedOn = categoriesDataEntity.EditedOn,
                IsDeleted = categoriesDataEntity.IsDeleted,
                IsEdited = categoriesDataEntity.IsEdited,
            };
        }

        public static CategoriesDataEntity GetCategoriesDataEntity (this CategoriesDto categoriesDto)
        {
            return new()
            {
                IsEdited = categoriesDto.IsEdited,
                CreatedOn = categoriesDto.CreatedOn,
                DeletedOn = categoriesDto.DeletedOn,
                Description = categoriesDto.Description,
                EditedOn = categoriesDto.EditedOn,
                Id = categoriesDto.Id,
                IsDeleted = categoriesDto.IsDeleted,
                Name = categoriesDto.Name,
            };
        }

        public static PostsDto GetPostsDto (this PostsDataEntity postsDataEntity)
        {
            return new()
            {
                Content = postsDataEntity.Content,
                CreatedOn = postsDataEntity.CreatedOn,
                DeletedOn = postsDataEntity.DeletedOn,
                IsDeleted = postsDataEntity.IsDeleted,
                Dislikes = postsDataEntity.Dislikes,
                EditedOn = postsDataEntity.EditedOn,
                Id = postsDataEntity.Id,
                IsEdited = postsDataEntity.IsEdited,
                Likes = postsDataEntity.Likes,
                Title = postsDataEntity.Title,
            };
        }

        public static PostsDataEntity GetPostsDataEntity (this PostsDto postsDto)
        {
            return new()
            {
                CreatedOn = postsDto.CreatedOn,
                Title = postsDto.Title,
                Content = postsDto.Content,
                DeletedOn = postsDto.DeletedOn,
                Dislikes = postsDto.Dislikes,
                EditedOn = postsDto.EditedOn,
                Id = postsDto.Id,
                IsDeleted = postsDto.IsDeleted,
                IsEdited = postsDto.IsEdited,
                Likes = postsDto.Likes,
                CreatorId = postsDto.Creator.Id
            };
        }

        public static CommentsDto GetCommentsDto (this CommentsDataEntity commentsDataEntity)
        {
            return new()
            {
                Id = commentsDataEntity.Id,
                CreatedOn = commentsDataEntity.CreatedOn,
                Content = commentsDataEntity.Content,
                DeletedOn = commentsDataEntity.DeletedOn,
                Dislikes = commentsDataEntity.Dislikes,
                EditedOn = commentsDataEntity.EditedOn,
                IsDeleted = commentsDataEntity.IsDeleted,
                Likes = commentsDataEntity.Likes,
                IsEdited = commentsDataEntity.IsEdited,
            };
        }

        public static CommentsDataEntity GetCommentsDataEntity (this CommentsDto commentsDto)
        {
            return new()
            {
                IsEdited = commentsDto.IsEdited,
                Content = commentsDto.Content,
                CreatedOn = commentsDto.CreatedOn,
                DeletedOn = commentsDto.DeletedOn,
                Dislikes = commentsDto.Dislikes,
                EditedOn = commentsDto.EditedOn,
                Id = commentsDto.Id,
                IsDeleted = commentsDto.IsDeleted,
                Likes = commentsDto.Likes,
                CreatorId = commentsDto.Creator.Id,
            };
        }

        public static ApplicationUser GetApplicationUser (this UserDto userDto)
        {
            return new()
            {
                CreatedOn = userDto.CreatedOn,
                DeletedOn = userDto.DeletedOn,
                DisplayName = userDto.DisplayName,
                EditedOn = userDto.EditedOn,
                Id = userDto.Id,
                IsDeleted = userDto.IsDeleted,
                IsEdited = userDto.IsEdited,
                RoleId = userDto.Role.Id,
            };
        }

        public static UserDto GetUserDto (this ApplicationUser applicationUser)
        {
            return new()
            {
                Id = applicationUser.Id,
                CreatedOn = applicationUser.CreatedOn,
                DeletedOn = applicationUser.DeletedOn,
                DisplayName = applicationUser.DisplayName,
                EditedOn = applicationUser.EditedOn,
                IsDeleted = applicationUser.IsDeleted,
                IsEdited = applicationUser.IsEdited,
            };
        }

        public static ApplicationRole GetApplicationRole (this RoleDto roleDto)
        {
            return new(roleDto.Name)
            {
                Id = roleDto.Id,
                Name = roleDto.Name,
                CreatedOn = roleDto.CreatedOn,
                DeletedOn = roleDto.DeletedOn,
                EditedOn = roleDto.EditedOn,
                IsDeleted = roleDto.IsDeleted,
                IsEdited = roleDto.IsEdited,
            };
        }

        public static RoleDto GetRoleDto (this ApplicationRole applicationRole)
        {
            return new()
            {
                IsEdited = applicationRole.IsEdited,
                CreatedOn = applicationRole.CreatedOn,
                DeletedOn = applicationRole.DeletedOn,
                EditedOn = applicationRole.EditedOn,
                Id = applicationRole.Id,
                IsDeleted = applicationRole.IsDeleted,
                Name = applicationRole.Name,
            };
        }

    }
}
