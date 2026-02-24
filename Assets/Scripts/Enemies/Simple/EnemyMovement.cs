using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    SpriteRenderer spriteEnemy;
    EntittyAtributes enemyAtributes;
    GameObject player;
    Rigidbody2D rb;

    void Start()
    {
        enemyAtributes = GetComponent<EntittyAtributes>();
        rb = GetComponent<Rigidbody2D>();
        spriteEnemy = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");


    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 playerDistance = (playerPosition - transform.position).normalized;
        rb.linearVelocity = playerDistance * enemyAtributes.enemyMooveSpeed;
        Flip();

    }

    void Flip()
    {
        if(player.transform.position.x < transform.position.x)
        {
            spriteEnemy.flipX = true;
        }
        else
        {
            spriteEnemy.flipX = false;
        }
    }


}

