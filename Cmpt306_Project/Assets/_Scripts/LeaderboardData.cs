using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LeaderboardData
{
   public List<Leaderboard> leaderboard;

    public LeaderboardData() {
        leaderboard = new List<Leaderboard>();
    }    
}
