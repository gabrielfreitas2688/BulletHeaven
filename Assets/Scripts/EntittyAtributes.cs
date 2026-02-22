using UnityEngine;

public class EntittyAtributes : MonoBehaviour
{
    [Header("Player")]
    //Player Atributes
    public float hp;
    public float maxHP;
    public float mooveSpeed;
    public float attackSpeed = 1;
    public float attackVelocity;
    public float damage;

    [Header("Enemie Simple")]
    //Enemy Atributes
    public float enemyAttackDamage;
    public float enemyMooveSpeed;
    public float enemyMaxHP;
    public float enemyHP;

    [Header("Enemie Shooter")]
    public float enemyShooterDamage;

    [Header("Enemie Charger")]
    public float enemyChargerVelocity;
    public float enemyChargerDSForce;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
