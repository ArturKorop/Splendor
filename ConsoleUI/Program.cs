using System.Collections.Generic;
using Core.Common;
using Core.Controllers;
using Core.Entities;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameData(new List<IPlayerConnection> {new DummyPlayerConnection(), new DummyPlayerConnection()});
        }
    }
}
