using Data.Entities;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
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
                Effects = cardDto.Effects.Select(e => e.GetEffectsDataEntity()),
                IsDeleted = cardDto.IsDeleted,
                IsEdited = cardDto.IsEdited,
                Type = cardDto.CardType.GetCardTypesDataEntity(),

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
                EffectType = effectDto.EffectType.GetEffectTypesDataEntity(),
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
                Cards = deckDto.Cards.Select(c => c.GetCardsDataEntity()),
                CreatedOn = deckDto.CreatedOn,
                DeckType = deckDto.DeckType.GetDeckTypesDataEntity(),
                DeletedOn = deckDto.DeletedOn,
                Description = deckDto.Description,
                EditedOn = deckDto.EditedOn,
                Id = deckDto.Id,
                IsDeleted = deckDto.IsDeleted,
                IsEdited = deckDto.IsEdited,
                Name = deckDto.Name,
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
                CardType = cardsDataEntity.Type.GetCardTypesDto(),
                CreatedOn = cardsDataEntity.CreatedOn,
                DeletedOn = cardsDataEntity.DeletedOn,
                Description = cardsDataEntity.Description,
                EditedOn = cardsDataEntity.EditedOn,
                Effects = cardsDataEntity.Effects.Select(e => e.GetEffectsDto()),
                IsDeleted = cardsDataEntity.IsDeleted,
                IsEdited = cardsDataEntity.IsEdited,
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
                EffectType = effectsDataEntity.EffectType.GetEffectTypesDto(),
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
                Cards = decksDataEntity.Cards.Select(c => c.GetCardsDto()),
                CreatedOn = decksDataEntity.CreatedOn,
                DeckType = decksDataEntity.DeckType.GetDeckTypes(),
                DeletedOn = decksDataEntity.DeletedOn,
                Description = decksDataEntity.Description,
                EditedOn = decksDataEntity.EditedOn,
                Id = decksDataEntity.Id,
                IsDeleted = decksDataEntity.IsDeleted,
                IsEdited = decksDataEntity.IsEdited,
                Name = decksDataEntity.Name,
            };
        }

        public static DeckTypesDto GetDeckTypes (this DeckTypesDataEntity deckTypesDataEntity)
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
    }
}
