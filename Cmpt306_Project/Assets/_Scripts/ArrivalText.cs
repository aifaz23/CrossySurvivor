using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class ArrivalText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject bossCanvas;

    IEnumerator blinking() {
        while (true)
        { 
            text.enabled = true;
            yield return new WaitForSeconds(0.45f);
            text.enabled = false;
            yield return new WaitForSeconds(0.45f);
        }
    }

    IEnumerator done() {
        yield return new WaitForSeconds(2.25f);
        bossCanvas.SetActive(false);
    }

    public void blink() {
        StartCoroutine(blinking());
        StartCoroutine(done());
    }
}