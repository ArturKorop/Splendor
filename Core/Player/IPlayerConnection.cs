using Core.Controllers;
using Core.Dto;

namespace Core.Player
{
    public interface IPlayerConnection
    {
        int Id { get; set; }

        string Name { get; set; }

        PlayerChoice DoTurn(GameDto getGameDto);
    }
}