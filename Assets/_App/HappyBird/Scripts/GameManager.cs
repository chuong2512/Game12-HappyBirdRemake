using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[DefaultExecutionOrder(-999)]
public class GameManager : Jackal.Singleton<GameManager>
{
    public GameObject objects;

    public TextMesh scoreLabel;
    public TextMesh heartLabel;
    public static int score;

    public int Heart
    {
        get => _heart;
        set
        {
            _heart = value;
            heartLabel.text = _heart.ToString();
        }
    }

    public GameObject loseGameObj;
    private int _heart;

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
        Heart = 3;

        if (PlayerPrefs.GetInt("Save", 0) > 0)
        {
            Score = PlayerPrefs.GetInt("Score", 0);
        }
        else
        {
            Score = 0;
        }

        InvokeRepeating(nameof(CreateObjects), 1, 2);
    }

    void CreateObjects()
    {
        Instantiate(objects, new Vector3(7.5f, Random.Range(-2f, 2.1f), 0), Quaternion.identity);
    }

    public void LoseGame()
    {
        Heart--;
        if (Heart <= 0)
        {
            loseGameObj.SetActive(true);
        }
    }

    public void Continue()
    {
        Heart = 1;
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

        Heart = 3;
        PlayerPrefs.SetInt("Save", 0);
        SceneManager.LoadScene("Game");
    }
}