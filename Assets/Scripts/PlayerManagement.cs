using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    EntittyAtributes player;
    EntittyAtributes enemy;
    public Slider hpBar;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<EntittyAtributes>();
        

        player.hp = player.maxHP;
        hpBar.maxValue = player.maxHP;
        hpBar.value = player.hp;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Enemy")
        {
            EntittyAtributes enemyAttr = collision.gameObject.GetComponent<EntittyAtributes>();
            TakeDamage(enemyAttr.enemyAttackDamage);
            Destroy(collision.gameObject);
            GameManeger.Instance.GainXP(30);
        }
    }

    void TakeDamage(float damage)
    {
        player.hp -= damage;
        hpBar.value = player.hp;

        if(player.hp <= 0)
        {
            GameManeger.Instance.GameOver();
        }
    }



}
