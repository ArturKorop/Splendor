using System;
using System.Collections.Generic;
using Core.Common;
using Core.Controllers;
using Core.Dto;
using Core.Entities;
using Core.PlayerChoiceParameters;

namespace Core.Player
{
    public class RealPlayerConnection : IPlayerConnection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerMainAction DoMainAction(GameDto gameDto)
        {
            Print(gameDto);

            var result = Console.ReadKey();

            return new PlayerMainAction
            {
                MainAction = MainAction.Take3DifferentGems,
                Parameters = new Take3DifferentGemsParameters
                {
                    Gems = new[] { Gem.Blue, Gem.Green, Gem.Red }
                }
            };
        }

        public Customer TakeCustomer(GameData gameData)
        {
            return null;
        }

        private void Print(GameDto gameDto)
        {
            Print(gameDto.GemHolder);
            Console.WriteLine("1 Level Cards");
            Print(gameDto.CardHolder.ActiveCards.Cards1Level);
            Console.WriteLine("2 Level Cards");
            Print(gameDto.CardHolder.ActiveCards.Cards2Level);
            Console.WriteLine("3 Level Cards");
            Print(gameDto.CardHolder.ActiveCards.Cards3Level);
        }

        private void Print(GemHolderDto gemHolder)
        {
            foreach (var gem in gemHolder.Repository)
            {
                Console.Write("{0}: {1}; ", gem.Gem, gem.Count);
            }
        }

        private void Print(List<CardDto> cards)
        {
            foreach (var cardDto in cards)
            {
                Console.WriteLine(cardDto);
            }
        }
    }
}