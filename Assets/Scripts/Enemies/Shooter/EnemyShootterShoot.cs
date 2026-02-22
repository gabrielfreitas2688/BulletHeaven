using UnityEngine;

public class EnemyShootterShoot : MonoBehaviour
{
    public float coolDown;
    float timercoolDown;
    public GameObject bullet;
    GameObject player;
    EntittyAtributes enemyAtributes;
    SpriteRenderer spriteEnemy;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAtributes = GetComponent<EntittyAtributes>();
        spriteEnemy = GetComponent<SpriteRenderer>();
        timercoolDown = coolDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();
        Flip();
    }

    void Shoot()
    {
       if(timercoolDown >= coolDown)
        {
            Vector3 playerPosition = player.transform.position;

            Vector3 direcao = Vector3.MoveTowards(transform.position, playerPosition, 1);

            Vector3 direcaoFinal = (direcao - transform.position).normalized;

            GameObject instanciateBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            instanciateBullet.GetComponent<BulletEnemy>().enemyDamage = enemyAtributes.enemyShooterDamage;
            instanciateBullet.GetComponent<BulletEnemy>().Shoot(direcaoFinal, 8f);

            timercoolDown = 0;
        }
        else { timercoolDown += Time.deltaTime; }
        

    }

    void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            spriteEnemy.flipX = true;
        }
        else if (transform.position.x < player.transform.position.x)
        {
            spriteEnemy.flipX = false;
        }
    }
}
