using UnityEngine;
using UnityEngine.AI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float damage = 60.0f;

    public NavMeshAgent agent;
    public Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {

        Ray ray = cam.ScreenPointToRay(GameManager.instance.player.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
