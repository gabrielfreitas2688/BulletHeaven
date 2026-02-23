using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    EntittyAtributes player;
    EntittyAtributes enemy;
    public Slider hpBar;
    public Text[] statsInfo;
    public GameObject levelUpScreen;
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
            GameManeger.Instance.GainXP(20);
        }
    }

    public void TakeDamage(float damage)
    {
        player.hp -= damage;
        hpBar.value = player.hp;

        if(player.hp <= 0)
        {
            GameManeger.Instance.GameOver();
        }
    }

    public void AddStats (string stat)
    {
        if(stat == "hp")
        {
            player.maxHP += 5;
            player.hp += 5;
        }
        if(stat == "moovespeed")
        {
            player.mooveSpeed += 2;
        }
        if (stat == "atkspeed")
        {
            player.attackSpeed += 2;
        }
        if (stat == "atkvelocity")
        {
            player.bulletVelocity += 2;
        }
        if (stat == "damage")
        {
            player.damage += 2;
        }


        levelUpScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void SelectionStats()
    {
        levelUpScreen.SetActive(true);

        statsInfo[0].text = player.maxHP.ToString();
        statsInfo[1].text = player.mooveSpeed.ToString();
        statsInfo[2].text = player.attackSpeed.ToString();
        statsInfo[3].text = player.bulletVelocity.ToString();
        statsInfo[4].text = player.damage.ToString();
    }



}
