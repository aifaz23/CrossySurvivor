using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    public RowUI rowUI;
    public ScoreManager scoreManager;

    void Start()
    {
        // scoreManager.AddScore(new Score("abc", 1));

        var scores = scoreManager.GetHighScore().ToArray();
        for (int i = 0; i < 6; i++) {
            if (i < scores.Length) {
                var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
                row.rank.text = (i + 1).ToString();
                row.playerName.text = scores[i].playerName;
                row.score.text = scores[i].score.ToString();
                if (i % 2 == 0){
                    row.GetComponent<Image>().color = new Color32(21,79,66,255);
                }
                else {
                    row.GetComponent<Image>().color = new Color32(19,99,80,255);
                }
            }
            else {
                
            }
        }
    }
}
