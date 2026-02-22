using UnityEngine;

public class EnemyShooterMovement : MonoBehaviour
{
    EntittyAtributes enemyAtributes;
    GameObject player;
    Rigidbody2D rb;
    void Start()
    {
        enemyAtributes = GetComponent<EntittyAtributes>();
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");


    }

    void FixedUpdate()
    {
        MovementShooter();
    }

    void MovementShooter()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 playerDistance = (playerPosition - transform.position).normalized;
        rb.linearVelocity = playerDistance * enemyAtributes.enemyShooterMooveSpeed;
    }
}

