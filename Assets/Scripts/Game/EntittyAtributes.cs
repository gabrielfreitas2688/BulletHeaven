using UnityEngine;

public class EntittyAtributes : MonoBehaviour
{
    [Header("Player")]
    //Player Atributes
    public float hp;
    public float maxHP = 100;
    public float mooveSpeed = 7;
    public float attackSpeed = 4;
    public float bulletVelocity;
    public float damage = 5;

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
        bulletVelocity = Mathf.Round(mooveSpeed * 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
