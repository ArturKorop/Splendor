using System.Collections.Generic;
using Core.Common;
using Core.Controllers;
using Core.Entities;
using Core.Players;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameData = new GameData(new List<IPlayerConnection> {new DummyPlayerConnection {Id = 0}, new DummyPlayerConnection {Id = 1}, new RealPlayerConnection {Id = 2} });
            var game = new GameController(gameData);

            game.Start();
        }
    }
}
