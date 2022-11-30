using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public void OnPointerEnter( PointerEventData ped ) {
        FindObjectOfType<AudioManager>().Play("ButtonHover");
    }
 
    public void OnPointerDown( PointerEventData ped ) {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    } 
}
