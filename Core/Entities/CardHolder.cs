using System;
using System.Collections.Generic;
using System.Linq;
using Core.Dto;

namespace Core.Entities
{
    public class CardHolder
    {
        public CardHolder(CardHolderDto dto)
        {
            ActiveCards = new ActiveCardRepository(dto.ActiveCards);
            InactiveCards = new InactiveCardRepository(dto.InactiveCards);
        }

        public CardHolder()
        {
            ActiveCards = new ActiveCardRepository();
            InactiveCards = new InactiveCardRepository();
        }

        public CardHolder(ActiveCardRepository activeCards, InactiveCardRepository inactiveCards)
        {
            ActiveCards = activeCards;
            InactiveCards = inactiveCards;
        }

        public ActiveCardRepository ActiveCards { get; }

        public InactiveCardRepository InactiveCards { get; }

        public void BookCard(int id, PlayerData playerData)
        {
            TransferCardTo(id, playerData.BookedCards);
        }

        public void BuyCard(int id, PlayerData playerData)
        {
            TransferCardTo(id, playerData.BoughtCards);
        }

        private void TransferCardTo(int id, List<Card> destination)
        {
            var card = ActiveCards.AllCards.FirstOrDefault(x => x.Id == id);
            if (card == null)
            {
                throw new ArgumentException($"Card with unknown id [{id}]");
            }

            switch (card.Id)
            {
                case 1:
                    TransferFromLevel(card, ActiveCards.Cards1Level, destination, InactiveCards.Cards1Level);
                    break;
                case 2:
                    TransferFromLevel(card, ActiveCards.Cards2Level, destination, InactiveCards.Cards2Level);
                    break;
                case 3:
                    TransferFromLevel(card, ActiveCards.Cards3Level, destination, InactiveCards.Cards3Level);
                    break;
            }
        }

        private void TransferFromLevel(Card card, List<Card> level, List<Card> destination, Queue<Card> inactiveLevel)
        {
            level.Remove(card);
            destination.Add(card);
            level.Add(inactiveLevel.Dequeue());
        }
    }
}