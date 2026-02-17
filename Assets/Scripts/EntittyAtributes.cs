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

    [Header("Enemies")]
    //Enemy Atributes
    public float enemyAttackDamage;
    public float enemyMooveSpeed;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
