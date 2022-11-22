using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;

    Camera cam;
    [SerializeField] public Vector3 viewPos;

    public Vector3 offset;

    void Start()
    {
        cam = GetComponent<Camera>();
        offset = new Vector3(0, 10, 0);
        moveSpeed = 2.0f;
    }

    void Update()
    {
        // TODO work on camera keep up
        // viewPos = cam.WorldToViewportPoint(target.position);
        // print(viewPos.y);
        // if (viewPos.y > 0.5f)
        // {
        //     print("Ahead");
        //     moveSpeed = 7.0f;
        //     transform.position = Vector3.Lerp(transform.position, target.position + offset, moveSpeed * Time.deltaTime);
        // }
        // else if (viewPos.y <= 50)
        // {
        //     // print("Behind");
        //     moveSpeed = 2.5f;
        //     transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, target);
        // }

        //Only move camera forward when in normal phase(not boss phase)
        if(!GameManager.getIsBossPhase()){
            viewPos = transform.position;
            Movement();
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, target);
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in gos)
        {
            float z = go.GetComponent<Player>().transform.position.z;
            if(viewPos.z>z+16.0f){
            go.GetComponent<Player>().kill();
            }
            else if(viewPos.z<(z-16.0f)){
            go.GetComponent<Player>().kill();
            }
            // go.GetComponent<Gun>().damages += increasedamage;
        }
        
        
    }
}
