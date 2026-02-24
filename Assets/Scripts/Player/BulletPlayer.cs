using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    float playerDamage;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        EntittyAtributes player = GameObject.FindGameObjectWithTag("Player").GetComponent<EntittyAtributes>();
        playerDamage = player.damage;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Vector3 direcao, float velocity)
    {
        rb.linearVelocity = direcao * velocity;
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Enemy")
        {
            EntittyAtributes atributes = collision.GetComponent<EntittyAtributes>();
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            if (atributes != null)
            {
                atributes.enemyHP -= playerDamage;
                Destroy(this.gameObject);
            }
            
        }
    }
}
