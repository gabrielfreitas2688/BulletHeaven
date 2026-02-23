using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public Slider xpBar;
    public static GameManeger Instance;
    public int currentWave;
    public Text waveText;

    int currentXP = 0;
    int playerLevel = 1;

    void Awake()
    {

        if (Instance == null)
        {

            Instance = this;

        }
        else
        {

            Destroy(gameObject);
        }
    }
    void Start()
    {
        xpBar.maxValue = 100;
        xpBar.value = 0;
        
    }

    void Update()
    {

    }

    public void GameOver()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GainXP(int xp)
    {
        currentXP += xp;

        xpBar.value = currentXP;
        int maxXP = playerLevel * 100;


        if (currentXP >= maxXP)
        {
            
            PlayerManagement player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagement>();
            playerLevel++;
            currentXP = 0;
            xpBar.value = currentXP;
            player.SelectionStats();
            Time.timeScale = 0;

        }

        xpBar.maxValue = maxXP;
    }
}
