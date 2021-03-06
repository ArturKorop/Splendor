using Core.Dto;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPlayerConnection
    {
        int Id { get; set; }

        string Name { get; set; }

        PlayerMainAction DoMainAction(GameDto getGameDto);
        Customer TakeCustomer(GameData gameData);
    }
}