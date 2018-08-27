using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
	public Text highScoreText;
	void Start()
	{
		//showing the high score at the main menu which is stored in the registry 
		highScoreText.text="HighScore: "+((int)PlayerPrefs.GetFloat("highscore")).ToString();
	}
	public void ToGame()
	{
		//restarting game 
		SceneManager.LoadScene("Game"); 
	}
}