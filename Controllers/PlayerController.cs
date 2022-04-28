using Microsoft.AspNetCore.Mvc;
using ProjecteBLD.Data;
using ProjecteBLD.Model;

namespace ProjecteBLD.Controllers;

[ApiController]
[Route("player/")]
public class PlayerController : Controller
{
    public static ProjecteCtx context = new ProjecteCtx();

    [HttpGet]
    [Route("get")]
    public ActionResult GetPlayer()
    {
        try
        {
            return Ok(context.Players.ToList());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }

    [HttpPost]
    [Route("login")]
    public ActionResult LoginPlayer([FromBody] Player player)
    {
        try
        {
            var p = context.Players.SingleOrDefault(p => p.username == player.username && p.password == player.password);
            if (p != null) {
                return Ok(p);
            }
            else {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }

    [HttpPost]
    [Route("add")]
    public async Task<ActionResult> AddPlayer([FromBody] Player player)
    {
        try
        {
            Player p = new Player();
            p.username = player.username;
            p.password = player.password;
            p.email = player.email;
            context.Players.Add(p);
            await context.SaveChangesAsync();
            return Ok(p);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }

    [HttpPost]
    [Route("delete")]
    public async Task<ActionResult> deletePlayer([FromBody] Player player)
    {
        try
        {
            var p = context.Players.SingleOrDefault(p => p.username == player.username);
            if (p != null) {
                context.Players.Remove(p);
                await context.SaveChangesAsync();
                return Ok(p);
            } else {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }
}