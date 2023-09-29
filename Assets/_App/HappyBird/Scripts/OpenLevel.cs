using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    void OnMouseUp()
    {
        PlayerPrefs.SetInt("Save", 0);
        SceneManager.LoadScene(levelName);
    }

    public string levelName;
}