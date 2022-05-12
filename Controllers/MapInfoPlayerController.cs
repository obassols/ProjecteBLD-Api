using Microsoft.AspNetCore.Mvc;
using ProjecteBLD.Data;
using ProjecteBLD.Model;

namespace ProjecteBLD.Controllers;

[ApiController]
[Route("mapInfoPlayer/")]
public class MapInfoPlayerController : Controller
{
    public static ProjecteCtx context = new ProjecteCtx();

    [HttpGet]
    [Route("get")]
    public ActionResult GetMapInfoPlayer()
    {
        try
        {
            Console.WriteLine("[SERVER] GetMapInfoPlayer was Succesful");
            return Ok(context.Maps_Info_Player.ToList());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }

    [HttpPost]
    [Route("startMap")]
    public async Task<ActionResult> StartMap([FromBody] Map_Info_Player mapInfoPlayer)
    {
        try
        {
            Map_Info_Player mip = new Map_Info_Player();
            Player? p = context.Players.SingleOrDefault(p => p.username == mapInfoPlayer.player.username);
            Map_Info? m = context.Maps_Info.SingleOrDefault(m => m.id == mapInfoPlayer.mapInfo.id);

            if (p != null && m != null) {
                mip.player = p;
                mip.mapInfo = m;
                mip.completed = false;
                mip.time = -1;
                context.Maps_Info_Player.Add(mip);
                await context.SaveChangesAsync();
                Console.WriteLine("[SERVER] StartMap was Succesful");
                return Ok(mip);
            } else {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }

    [HttpPost]
    [Route("CompleteMap")]
    public async Task<ActionResult> ResetMap([FromBody] Map_Info_Player mapInfoPlayer)
    {
        try
        {
            Player? p = context.Players.SingleOrDefault(p => p.username == mapInfoPlayer.player.username);
            Map_Info? m = context.Maps_Info.SingleOrDefault(m => m.id == mapInfoPlayer.mapInfo.id);
            Map_Info_Player? mip = context.Maps_Info_Player.SingleOrDefault(mip => mip.mapInfo == m && mip.player == p);

            if (mip != null)
            {
                mip.completed = true;
                if (mip.time == -1 || mip.time > mapInfoPlayer.time) {
                    mip.time = mapInfoPlayer.time;
                }
                context.Maps_Info_Player.Add(mip);
                await context.SaveChangesAsync();
                Console.WriteLine("[SERVER] StartMap was Succesful");
                return Ok(mip);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }

    [HttpPost]
    [Route("delete")]
    public async Task<ActionResult> DeleteMapInfoPlayer([FromBody] Map_Info_Player mapInfoPlayer)
    {
        try
        {
            var m = context.Maps_Info_Player.SingleOrDefault(mip => mip.mapInfo == mapInfoPlayer.mapInfo && mip.player == mapInfoPlayer.player);
            if (m != null)
            {
                context.Maps_Info_Player.Remove(m);
                await context.SaveChangesAsync();
                Console.WriteLine("[SERVER] DeleteMapInfoPlayer was Succesful");
                return Ok(m);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }
    }
}