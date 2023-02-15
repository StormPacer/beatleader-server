﻿using BeatLeader_Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BeatLeader_Server.Utils
{
    public static class ClanUtils
    {
        public static float RecalculateClanPP(this AppContext context, int clanId)
        {
            Clan clan = context.Clans.Where(c => c.Id == clanId).Include(c => c.Players).FirstOrDefault();
            var ranked = clan.Players.OrderByDescending(s => s.Pp).ToList();
            float resultPP = 0f;
            foreach ((int i, Player p) in ranked.Select((value, i) => (i, value)))
            {
                float weight = MathF.Pow(0.965f, i);
                resultPP += p.Pp * weight;
            }
            return resultPP;
        }

        public static Clan CalculateOwningClan(this AppContext context, string leaderboardId)
        {
            // Calculate owning clan on this leaderboard
            var clanPPDict = new Dictionary<string, (float, float)>();
            try
            {
                // Why can't I put a Where clause of: ".Where(s => s.LeaderboardId == leaderboardId && !s.Banned && s.Player.Clans != null)"
                // I want to ignore all players who aren't in any clans
                var leaderboardClans =
                    context
                        .Scores
                        .Where(s => s.LeaderboardId == leaderboardId && !s.Banned)
                        .OrderByDescending(el => el.Pp)
                        .Select(s => new { Pp = s.Pp, Clans = s.Player.Clans })
                        .ToList();

                // Build up a dictionary of the clans on this leaderboard with pp, weighted by the pp
                foreach (var score in leaderboardClans)
                {
                    foreach (Clan clan in score.Clans)
                    {
                        if (clanPPDict.ContainsKey(clan.Tag))
                        {
                            // Just picked a value of .9f, need to balance value based on how many clan members usually play the same map so as to not give advantage
                            // to clans with lots of members
                            float weight = clanPPDict[clan.Tag].Item2 * 0.9f;
                            float clanPP = clanPPDict[clan.Tag].Item1 + (score.Pp * weight);
                            clanPPDict[clan.Tag] = (clanPP, weight);
                        }
                        else
                        {
                            clanPPDict.Add(clan.Tag, (score.Pp, 1.0f));
                        }
                    }
                }

                // Get the clan with the most weighted pp on the map
                bool unclaimed = true;
                bool contested = false;
                string owningClanTag = "";
                float maxPP = 0;
                foreach (var clanWeightedPP in clanPPDict)
                {
                    if (clanWeightedPP.Value.Item1 > maxPP)
                    {
                        maxPP = clanWeightedPP.Value.Item1;
                        owningClanTag = clanWeightedPP.Key;
                        contested = false;
                        unclaimed = false;
                    }
                    else
                    {
                        // There are multiple clans with the same weighted pp on this leaderboard
                        if (clanWeightedPP.Value.Item1 == maxPP)
                        {
                            contested = true;
                        }
                    }
                }

                if (unclaimed)
                {
                    // Reserve clan name/tag?
                    Clan unclaimedClan = new Clan();
                    unclaimedClan.Name = "Unclaimed";
                    unclaimedClan.Tag = "OOOO";
                    unclaimedClan.Color = "#000000";
                    return unclaimedClan;
                }
                else
                {
                    if (contested)
                    {
                        // If score submitted causes map to become contested, previous clan owner loses owned leaderboard
                        var previousOwner = context
                            .Leaderboards
                            .Where(lb => lb.Id == leaderboardId)
                            .Select(lb => lb.OwningClan)
                            .FirstOrDefault();
                        if (previousOwner != null)
                        {
                            previousOwner.OwnedLeaderboardsCount--;
                        }

                        // Reserve clan name/tag?
                        Clan contestedClan = new Clan();
                        contestedClan.Name = "Contested";
                        contestedClan.Tag = "XXXX";
                        contestedClan.Color = "#ffffff";
                        return contestedClan;
                    }
                    else
                    {
                        // Previous clan owner loses leaderboard, new clan owner captures leaderboard
                        var previousOwner = context
                            .Leaderboards
                            .Where(lb => lb.Id == leaderboardId)
                            .Select(lb => lb.OwningClan)
                            .FirstOrDefault();
                        if (previousOwner != null)
                        {
                            previousOwner.OwnedLeaderboardsCount--;
                        }

                        var newOwner = context
                            .Clans
                            .Where(c => c.Tag == owningClanTag)
                            .FirstOrDefault();
                        if (newOwner != null)
                        {
                            newOwner.OwnedLeaderboardsCount++;
                        }

                        return newOwner;
                    }
                }
            } catch (Exception e)
            {
                throw new Exception(e.StackTrace);
                var myValue = e.StackTrace;
                Console.WriteLine(myValue);
                return null;
            }

            
        }
    }
}
