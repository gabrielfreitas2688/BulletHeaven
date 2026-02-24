using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float enemyDamage;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 direcao, float velocity)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.linearVelocity = direcao * velocity;

        Destroy(this.gameObject, 4.5f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerManagement player = collision.GetComponent<PlayerManagement>();

            if(player != null)
            {
                player.TakeDamage(enemyDamage);
            }

            Destroy(this.gameObject);
        }
    }


}
