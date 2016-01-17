using Core.Controllers;
using Core.Dto;
using Core.Entities;

namespace Core.Player
{
    public interface IPlayerConnection
    {
        int Id { get; set; }

        string Name { get; set; }

        PlayerMainAction DoMainAction(GameDto getGameDto);
        Customer TakeCustomer(GameData gameData);
    }
}