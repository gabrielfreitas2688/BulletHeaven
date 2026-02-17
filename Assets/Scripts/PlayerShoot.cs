using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    EntittyAtributes playerAtributes;
    GameObject[] enemies;
    GameObject targetEnemy = null;
    public GameObject bullet;
    float playerAttackSpeedCoolDown;
    float timerCoolDown;


    void Start()
    {
        playerAtributes = GetComponent<EntittyAtributes>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        timerCoolDown = playerAttackSpeedCoolDown;
    }


    void Update()
    {

        coolDown();

    }
    void Attack()
    {
        //pega uma distancia mt grande para ter como parâmetro inicial
        float shortesDistance = Mathf.Infinity;


        foreach (GameObject atualEnemy in enemies)
        {   
            //calcular a distancia entre o inimigo e o player 
            float distance = Vector3.Distance(transform.position, atualEnemy.transform.position);
            
            //verifica se a distancia atual é menor que a distancia inicial, se sim, distancia inicial = atual, assim seleciona o mais perto
            if(distance < shortesDistance)
            {
                shortesDistance = distance;
                targetEnemy = atualEnemy;
            }

        }

        Vector3 enemyPosition = (targetEnemy.transform.position - transform.position).normalized;

        GameObject instantiateBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        instantiateBullet.GetComponent<BulletPlayer>().Shoot(enemyPosition, playerAtributes.attackVelocity);
    }

    void coolDown()
    {
        playerAttackSpeedCoolDown = 3 / playerAtributes.attackSpeed;


        if (timerCoolDown < playerAttackSpeedCoolDown)
        {
            timerCoolDown += Time.deltaTime;
        }
        else
        {
            Attack();
            timerCoolDown = 0;
        }

        
    }
}
