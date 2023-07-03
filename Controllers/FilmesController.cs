using dotnet_dapper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_dapper.Controllers;
[ApiController]
[Route("api/[controller]")]

public class FilmesController : ControllerBase
{
    private readonly IFilmeRepository _repository;

    public FilmesController(IFilmeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var filmes = await _repository.BuscaFilmesAsync();

        return filmes.Any() ? Ok(filmes) : NoContent();
    }

}
