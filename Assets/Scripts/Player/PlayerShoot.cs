using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioSource fxShoot;
    public AudioClip Shoot;
    EntittyAtributes playerAtributes;
    GameObject[] enemies;
    GameObject targetEnemy = null;
    public Transform shootPoint;
    public Transform pivotDrone;
    public SpriteRenderer spriteDrone;
    float rotationSpeedDrone = 4; 
    public GameObject bullet;
    float playerAttackSpeedCoolDown;
    float timerCoolDown;



    void Start()
    {
        playerAtributes = GetComponent<EntittyAtributes>();
        timerCoolDown = playerAttackSpeedCoolDown;
    }


    void Update()
    {

        SearchEnemy();
        DroneMovement();
        coolDown();

    }
    void Attack()
    {
        

        if(targetEnemy != null)
        {
          
            Vector3 enemyPosition = (targetEnemy.transform.position - transform.position).normalized;
            GameObject instantiateBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            instantiateBullet.GetComponent<BulletPlayer>().Shoot(enemyPosition, playerAtributes.bulletVelocity);
            fxShoot.PlayOneShot(Shoot);
        }
            
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

    void DroneMovement()
    {
        if (targetEnemy == null) return;
        
        Vector3 enemyPosition = (targetEnemy.transform.position - transform.position).normalized;
        float anguloDrone = Mathf.Atan2(enemyPosition.y, enemyPosition.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, anguloDrone);
        pivotDrone.rotation = Quaternion.Slerp(pivotDrone.rotation, targetRotation, Time.deltaTime * rotationSpeedDrone);

        
        if (pivotDrone.eulerAngles.z > 90 && pivotDrone.eulerAngles.z < 270)
        {
            
            pivotDrone.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            
            pivotDrone.localScale = new Vector3(1, 1, 1);
        }


    }

    void SearchEnemy()
    {
        enemies = SpawnManager.Instance.enemiesAlive;
        //pega uma distancia mt grande para ter como parâmetro inicial
        float shortesDistance = Mathf.Infinity;


        foreach (GameObject atualEnemy in enemies)
        {

            if (atualEnemy == null)
            {
                continue;
            }
            //calcular a distancia entre o inimigo e o player 
            float distance = Vector3.Distance(transform.position, atualEnemy.transform.position);

            //verifica se a distancia atual é menor que a distancia inicial, se sim, distancia inicial = atual, assim seleciona o mais perto
            if (distance < shortesDistance)
            {
                shortesDistance = distance;
                targetEnemy = atualEnemy;
            }

        }
    }



}
