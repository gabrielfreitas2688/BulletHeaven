using UnityEngine;
using UnityEngine.UI;

public class EnemyManagement : MonoBehaviour
{
    EntittyAtributes enemyAtributes;
    public Slider HPBar;
    void Start()
    {
        enemyAtributes = gameObject.GetComponent<EntittyAtributes>();
        HPBar.maxValue = enemyAtributes.enemyMaxHP;
        enemyAtributes.enemyHP = enemyAtributes.enemyMaxHP;    
        HPBar.value = enemyAtributes.enemyHP;
    }

    
    void Update()
    {
        TakeDamage();
    }

    void TakeDamage()
    {
        HPBar.value = enemyAtributes.enemyHP;

        if(enemyAtributes.enemyHP <= 0)
        {
            Destroy(gameObject);
            GameManeger.Instance.GainXP(20);
        }
    }
}
