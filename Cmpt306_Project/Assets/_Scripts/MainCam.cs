using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;

    Camera cam;
    [SerializeField] public Vector3 viewPos;


    void Start()
    {
        cam = GetComponent<Camera>();

        moveSpeed = 2.0f;
    }

    void Update()
    {

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
