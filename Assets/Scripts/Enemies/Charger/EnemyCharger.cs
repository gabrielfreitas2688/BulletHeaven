using System.Collections;
using UnityEngine;

public class EnemyCharger : MonoBehaviour
{
    public SpriteRenderer spriteEnemy;
    Animator animatorEnemy;
    EntittyAtributes enemyAtributes;
    GameObject player;
    Rigidbody2D rb;

    bool canRun = true;
    bool canAttack = true;

    void Start()
    {
        enemyAtributes = GetComponent<EntittyAtributes>();
        animatorEnemy = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");


    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        Movement();

        if (canAttack && distance <= 8)
        {
            StartCoroutine(PrepareDash());
        }

    }

    void Movement()
    {
        if(canRun)
        {
            animatorEnemy.SetBool("isIdle", false);
            Vector3 playerDistance = (player.transform.position - transform.position).normalized;
            rb.linearVelocity = playerDistance * enemyAtributes.enemyChargerVelocity;
            Flip();
        }
        
    }

    IEnumerator PrepareDash()
    {
        Flip();
        canAttack = false;
        canRun = false;

        animatorEnemy.SetBool("isIdle", true);

        
        rb.linearVelocity = Vector2.zero;
        spriteEnemy.color = Color.red;

        yield return new WaitForSeconds(0.8f);

        
        Vector3 playerDistance = (player.transform.position - transform.position).normalized;
        rb.AddForce(playerDistance * enemyAtributes.enemyChargerDSForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);
        spriteEnemy.color = Color.white;
        canRun = true;

        yield return new WaitForSeconds(4f);

        canAttack = true;
    }

    void Flip()
    {
        if(transform.position.x > player.transform.position.x )  
        {
            spriteEnemy.flipX = false;
        }
        else if(transform.position.x < player.transform.position.x)
        {
            spriteEnemy.flipX = true;
        }
    }
}

