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
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EntittyAtributes>();

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
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage()
    {
        player.hp -= enemy.enemyAttackDamage;
        hpBar.value = player.hp;

        if(player.hp <= 0)
        {
            GameManeger.Instance.GameOver();
        }
    }



}
