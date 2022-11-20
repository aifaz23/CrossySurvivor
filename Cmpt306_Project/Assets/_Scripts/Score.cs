using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Score
{
    public string playerName;
    public float score;

    public Score(string playerName, float score) {
        this.playerName = playerName;
        this.score = score;
    }
}
