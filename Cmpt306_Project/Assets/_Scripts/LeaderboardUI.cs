using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{

    public TableUI tableUI;
    public LeaderboardManager leaderboardManager;

    void Start()
    {
        var lead = leaderboardManager.GetHighScore().ToArray();
        for (int x = 1; x < 7; x++) {
            
            if (x < (lead.Length+1)) {
                var entry = Instantiate(tableUI, transform).GetComponent<TableUI>();
                if (x % 2 == 0){
                    entry.GetComponent<Image>().color = new Color32(21,79,66,255);
                }
                else {
                    entry.GetComponent<Image>().color = new Color32(19,99,80,255);
                }
                entry.rank.text = x.ToString();
                entry.playerName.text = lead[x-1].playerName;
                entry.score.text = lead[x-1].score.ToString();
            }
            else {
                
            }
        }
    }
}
