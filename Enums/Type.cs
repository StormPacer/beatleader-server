﻿namespace BeatLeader_Server.Enums;

public enum Type
{
    All,
    Ranked,
    Ranking,
    Nominated,
    Qualified,
    Staff,
    Reweighting,
    Reweighted,
    Unranked,
    Ost
}

public enum MapsType {
    Ranked,
    Unranked,
    All
}

public enum FollowerType {
    Following,
    Followers
}

public enum RandomScoreSource {
    General,
    Friends
}

public enum DateRangeType {
    Upload,
    Ranked,
    Score
}