using UnityEngine;

public class SetScore : MonoBehaviour 
{
	public TextMesh scoreLabel;
	public TextMesh bestScoreLabel;

	void Start () 
	{
		PlayerPrefs.SetInt("Save", 0);
		
		scoreLabel.text = "Score: " + GameManager.score.ToString();

		if (GameManager.score > 0)
		{
			if (PlayerPrefs.GetInt("Score", 0) < GameManager.score)
			{
				PlayerPrefs.SetInt("Score", GameManager.score);
				PlayerPrefs.Save();
			}
		}

		bestScoreLabel.text = "HighScore: " + PlayerPrefs.GetInt("Score", 0).ToString();
		GameManager.score = 0;
	}
}