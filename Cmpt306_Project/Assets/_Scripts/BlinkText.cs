using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    public TextMeshProUGUI text;

    IEnumerator blinking() {
        while (true)
        {
            text.enabled = true;
            yield return new WaitForSeconds(0.45f);
            text.enabled = false;
            yield return new WaitForSeconds(0.45f);
        }
    }

    public void blink() {
        StartCoroutine(blinking());
    }
}
