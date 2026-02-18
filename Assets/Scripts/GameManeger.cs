using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    GameObject[] enemys;
    public static GameManeger Instance;
    public int currentWave = 1;

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
        
    }

    void Update()
    {
 
    }

    public void GameOver()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
