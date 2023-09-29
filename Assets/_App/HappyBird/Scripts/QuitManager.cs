using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitManager : MonoBehaviour
{
    public string ParentLeveleName;

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (ParentLeveleName == "Quit")
            Application.Quit();
        else
            SceneManager.LoadScene(ParentLeveleName);
    }
}