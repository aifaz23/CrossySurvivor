using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Leaderboard
{
    public string playerName;
    public float score;

    public Leaderboard(string playerName, float score) {
        this.playerName = playerName;
        this.score = score;
    }
}
