using System.Collections.Generic;
using Core.Common;
using Core.Controllers;
using Core.Entities;
using Core.Player;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameData = new GameData(new List<IPlayerConnection> {new DummyPlayerConnection(), new DummyPlayerConnection(), new RealPlayerConnection()});
            var game = new GameController(gameData);

            game.Start();
        }
    }
}
