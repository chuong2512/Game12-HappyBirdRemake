using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Jackal.Singleton<GameManager>
{
    public GameObject objects;

    public TextMesh scoreLabel;
    public static int score;

    public GameObject loseGameObj;

    public static int addPoint = 0;

    public int Score
    {
        set
        {
            score = value;

            scoreLabel.text = Score.ToString();
        }
        get { return score; }
    }

    void Start()
    {
        addPoint = 0;
        
        IAPManager.OnPurchaseSuccess = Continue;

        if (PlayerPrefs.GetInt("Save", 0) > 0)
        {
            Score = PlayerPrefs.GetInt("Score", 0);
        }
        else
        {
            Score = 0;
        }

        InvokeRepeating("CreateObjects", 1, 2);
    }

    void CreateObjects()
    {
        Instantiate(objects, new Vector3(7.5f, Random.Range(-2f, 2.1f), 0), Quaternion.identity);
    }

    public void LoseGame()
    {
        loseGameObj.SetActive(true);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("Save", 1);
        PlayerPrefs.SetInt("Score", score + addPoint);
        SceneManager.LoadScene("Game");
    }

    public void Retry()
    {
        if (score > 0)
        {
            score = 0;
        }

        PlayerPrefs.SetInt("Save", 0);
        SceneManager.LoadScene("Game");
    }
}