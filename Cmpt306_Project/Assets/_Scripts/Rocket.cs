using UnityEngine;
using UnityEngine.AI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float damage = 60.0f;
    [SerializeField] private float moveSpeed = 3.0f; 

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.player){
            transform.LookAt(GameManager.instance.player.transform.position);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
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
