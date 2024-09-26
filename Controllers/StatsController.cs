﻿using Amazon.S3;
using BeatLeader_Server.Enums;
using BeatLeader_Server.Extensions;
using BeatLeader_Server.Models;
using BeatLeader_Server.Utils;
using Lib.ServerTiming;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeatLeader_Server.Controllers
{
    public class StatsController : Controller
    {
        private readonly AppContext _context;
        private readonly StorageContext _storageContext;

        private readonly IServerTiming _serverTiming;
        private readonly IConfiguration _configuration;
        private readonly IAmazonS3 _s3Client;

        public StatsController(
            AppContext context,
            StorageContext storageContext,
            IWebHostEnvironment env,
            IServerTiming serverTiming,
            IConfiguration configuration)
        {
            _context = context;
            _storageContext = storageContext;

            _serverTiming = serverTiming;
            _configuration = configuration;
            _s3Client = configuration.GetS3Client();
        }

        [HttpGet("~/player/{id}/scoresstats")]
        public async Task<ActionResult<ResponseWithMetadata<PlayerLeaderboardStats>>> GetScoresStats(
            string id,
            [FromQuery] string sortBy = "date",
            [FromQuery] Order order = Order.Desc,
            [FromQuery] int page = 1,
            [FromQuery] int count = 8,
            [FromQuery] string? search = null,
            [FromQuery] string? diff = null,
            [FromQuery] EndType? type = null,
            [FromQuery] float? stars_from = null,
            [FromQuery] float? stars_to = null,
            [FromQuery] int? eventId = null)
        {
            string? currentID = HttpContext.CurrentUserID(_context);
            bool admin = currentID != null ? ((await _context
                .Players
                .Where(p => p.Id == currentID)
                .Select(p => p.Role)
                .FirstOrDefaultAsync())
                ?.Contains("admin") ?? false) : false;

            id = await _context.PlayerIdToMain(id);

            var features = await _context
                .Players
                .Where(p => p.Id == id)
                .Select(p => p.ProfileSettings)
                .FirstOrDefaultAsync();

            if (!(currentID == id || admin || (features != null && features.ShowStatsPublic))) {
                return Unauthorized();
            }

            IQueryable<PlayerLeaderboardStats> sequence;

            using (_serverTiming.TimeAction("sequence"))
            {
                sequence = _storageContext
                    .PlayerLeaderboardStats
                    //.Include(pl => pl.Leaderboard)
                    .Where(t => t.PlayerId == id);
                switch (sortBy)
                {
                    case "date":
                        sequence = sequence.Order(order, t => t.Timeset);
                        break;
                    //case "pp":
                    //    sequence = sequence.Order(order, t => t.Pp);
                    //    break;
                    //case "acc":
                    //    sequence = sequence.Order(order, t => t.Accuracy);
                    //    break;
                    //case "pauses":
                    //    sequence = sequence.Order(order, t => t.Pauses);
                    //    break;
                    //case "rank":
                    //    sequence = sequence.Order(order, t => t.Rank);
                    //    break;
                    //case "stars":
                    //    sequence = sequence
                    //                .Include(lb => lb.Leaderboard)
                    //                .ThenInclude(lb => lb.Difficulty)
                    //                .Order(order, s => s.Leaderboard.Difficulty.Stars)
                    //                .Where(s => s.Leaderboard.Difficulty.Status == DifficultyStatus.ranked);
                        break;
                    default:
                        break;
                }
                //if (search != null)
                //{
                //    string lowSearch = search.ToLower();
                //    sequence = sequence
                //        .Include(lb => lb.Leaderboard)
                //        .ThenInclude(lb => lb.Song)
                //        .Where(p => p.Leaderboard.Song.Author.ToLower().Contains(lowSearch) ||
                //                    p.Leaderboard.Song.Mapper.ToLower().Contains(lowSearch) ||
                //                    p.Leaderboard.Song.Name.ToLower().Contains(lowSearch));
                //}
                //if (eventId != null)
                //{
                //    var leaderboardIds = _context.EventRankings.Where(e => e.Id == eventId).Include(e => e.Leaderboards).Select(e => e.Leaderboards.Select(lb => lb.Id)).FirstOrDefaultAsync();
                //    if (leaderboardIds?.CountAsync() != 0)
                //    {
                //        sequence = sequence.Where(s => leaderboardIds.Contains(s.LeaderboardId));
                //    }
                //}
                //if (diff != null)
                //{
                //    sequence = sequence.Include(lb => lb.Leaderboard).ThenInclude(lb => lb.Difficulty).Where(p => p.Leaderboard.Difficulty.DifficultyName.ToLower().Contains(diff.ToLower()));
                //}
                if (type != null)
                {
                    sequence = sequence.Where(p => type == p.Type);
                }
                //if (stars_from != null)
                //{
                //    sequence = sequence.Include(lb => lb.Leaderboard).ThenInclude(lb => lb.Difficulty).Where(p => p.Leaderboard.Difficulty.Stars >= stars_from);
                //}
                //if (stars_to != null)
                //{
                //    sequence = sequence.Include(lb => lb.Leaderboard).ThenInclude(lb => lb.Difficulty).Where(p => p.Leaderboard.Difficulty.Stars <= stars_to);
                //}
            }

            ResponseWithMetadata<PlayerLeaderboardStats> result;
            using (_serverTiming.TimeAction("db"))
            {
                result = new ResponseWithMetadata<PlayerLeaderboardStats>()
                {
                    Metadata = new Metadata()
                    {
                        Page = page,
                        ItemsPerPage = count,
                        Total = await sequence.CountAsync()
                    },
                    Data = await sequence
                            .Skip((page - 1) * count)
                            .Take(count)
                            //.Include(lb => lb.Leaderboard)
                            //    .ThenInclude(lb => lb.Song)
                            //    .ThenInclude(lb => lb.Difficulties)
                            //.Include(lb => lb.Leaderboard)
                            //    .ThenInclude(lb => lb.Difficulty)
                            //    .ThenInclude(d => d.ModifierValues)
                            //.Include(sc => sc.ScoreImprovement)
                            //.Select(ScoreWithMyScore)
                            .ToListAsync()
                };
            }

            //string? currentID = HttpContext.CurrentUserID(_readContext);
            //if (currentID != null && currentID != id)
            //{
            //    var leaderboards = result.Data.Select(s => s.LeaderboardId).ToListAsync();

            //    var myScores = _readContext.Scores.Where(s => s.PlayerId == currentID && leaderboards.Contains(s.LeaderboardId)).Select(RemoveLeaderboard).ToListAsync();
            //    foreach (var score in result.Data)
            //    {
            //        score.MyScore = myScores.FirstOrDefaultAsync(s => s.LeaderboardId == score.LeaderboardId);
            //    }
            //}

            return result;
        }

        [HttpGet("~/map/scorestats")]
        public async Task<ActionResult> GetScorestatsOnMap([FromQuery] string playerId, [FromQuery] string leaderboardId) {
            string? currentID = HttpContext.CurrentUserID(_context);
            bool admin = currentID != null ? ((await _context
                .Players
                .Where(p => p.Id == currentID)
                .Select(p => p.Role)
                .FirstOrDefaultAsync())
                ?.Contains("admin") ?? false) : false;

            playerId = await _context.PlayerIdToMain(playerId);

            var features = await _context
                .Players
                .Where(p => p.Id == playerId)
                .Select(p => p.ProfileSettings)
                .FirstOrDefaultAsync();

            if (!(currentID == playerId || admin || (features != null && features.ShowStatsPublic))) {
                return Unauthorized();
            }

            return Ok(
                await _storageContext
                .PlayerLeaderboardStats
                .Where(s => s.PlayerId == playerId && s.LeaderboardId == leaderboardId)
                .ToListAsync());
        }

        [HttpGet("~/otherreplays/{name}")]
        public async Task<ActionResult<string>> GetOtherReplay(string name) {
            var stat = await _storageContext
                .PlayerLeaderboardStats
                .Where(s => s.Replay == $"https://api.beatleader.xyz/otherreplays/{name}")
                .Select(s => s.PlayerId)
                .FirstOrDefaultAsync();
            if (stat == null) {
                return NotFound();
            }

            string? currentID = HttpContext.CurrentUserID(_context);
            bool admin = currentID != null ? ((await _context
                .Players
                .Where(p => p.Id == currentID)
                .Select(p => p.Role)
                .FirstOrDefaultAsync())
                ?.Contains("admin") ?? false) : false;

            var playerId = await _context.PlayerIdToMain(stat);

            var features = await _context
                .Players
                .Where(p => p.Id == playerId)
                .Select(p => p.ProfileSettings)
                .FirstOrDefaultAsync();

            if (!(currentID == playerId || admin || (features != null && features.ShowStatsPublic))) {
                return Unauthorized();
            }

            return await _s3Client.GetPresignedUrlUnsafe(name, S3Container.otherreplays);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("~/watched/{scoreId}/")]
        public async Task<ActionResult> Played(
            int scoreId)
        {
            var ip = HttpContext.GetIpAddress();

            if (ip == null) return BadRequest();

            string ipString = ip;
            string? currentID = HttpContext.CurrentUserID(_context);
            if (currentID != null) {
                if ((await _context.WatchingSessions.FirstOrDefaultAsync(ws => ws.ScoreId == scoreId && ws.Player == currentID)) != null) return Ok();
            } else {
                if ((await _context.WatchingSessions.FirstOrDefaultAsync(ws => ws.ScoreId == scoreId && ws.IP == ipString)) != null) return Ok();
            }

            Score? score = await _context.Scores.FindAsync(scoreId);
            if (score == null) return NotFound();
            if (score.PlayerId == currentID) return Ok();

            Player? scoreMaker = await _context.Players.Where(p => p.Id == score.PlayerId).Include(p => p.ScoreStats).FirstOrDefaultAsync();
            if (scoreMaker == null) return NotFound();
            if (scoreMaker.ScoreStats == null) {
                scoreMaker.ScoreStats = new PlayerScoreStats();
            }

            if (currentID != null)
            {
                score.AuthorizedReplayWatched++;
                scoreMaker.ScoreStats.AuthorizedReplayWatched++;
                var player = await _context.Players.Where(p => p.Id == currentID).Include(p => p.ScoreStats).FirstOrDefaultAsync();
                if (player != null && player.ScoreStats != null) {
                    player.ScoreStats.WatchedReplays++;
                }
            } else {
                score.AnonimusReplayWatched++;
                scoreMaker.ScoreStats.AnonimusReplayWatched++;
            }

            _context.WatchingSessions.Add(new ReplayWatchingSession {
                ScoreId = scoreId,
                IP = currentID == null ? ipString : null,
                Player = currentID
            });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
