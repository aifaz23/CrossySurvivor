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
        if (GameManager.instance.player) {//null reference check
            Ray ray = new Ray(GameManager.instance.player.transform.position, GameManager.instance.player.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                agent.SetDestination(hit.point);
            }
        }

        //If boss dies kill this
        if(!GameManager.getIsBossPhase()){
            Destroy(this.gameObject);
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
