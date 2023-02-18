using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour 
{
	public string levelName;

	void OnMouseDown()
	{
	}
	
	void OnMouseUp()
	{

		PlayerPrefs.SetInt("Save", 0);
		
		SceneManager.LoadScene(levelName);
	}
}
