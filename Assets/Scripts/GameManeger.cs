using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{

    public static GameManeger Instance;

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
