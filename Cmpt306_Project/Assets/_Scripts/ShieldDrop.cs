using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player") {
            Destroy(this.gameObject); 
            other.GetComponent<Player>().getShieldBuff(); 
        }     
    }
}