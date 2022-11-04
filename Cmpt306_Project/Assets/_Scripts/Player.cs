using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private int distanceTravelled;

    void Start()
    {
        moveSpeed = 5.0f;
        distanceTravelled = 0;
    }

    void Update()
    {
        Movement();
    }

    public int getDistanceTravelled()
    {
        return distanceTravelled;
    }
    void Movement()
    {
        // forward and backward movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            distanceTravelled = (int)transform.position.z;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // left and right movement
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x <= 10)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= -10)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }
}
