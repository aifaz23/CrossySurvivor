using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float moveSpeed;
    [SerializeField] private GameObject player;

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
        // viewPos = cam.WorldToViewportPoint(player.transform.position);
        // print(viewPos.y);
        // if (viewPos.y > 0.5f)
        // {
        //     print("Ahead");
        //     moveSpeed = 5.0f;
        //     // transform.position = Vector3.Lerp(transform.position, target.position + offset, moveSpeed * Time.deltaTime);
        // }
        // else if (viewPos.y <= 50)
        // {
        //     print("Behind");
        //     moveSpeed = 2.0f;
        //     // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, target);
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
    }
}