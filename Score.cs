using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
	private flaot score=0.0f;
	public Text scoreText;
	private int difficultyLevel=1;
	private int maxDifficultyLevel=10;
	private int scoreToMaxLevel=10;
	public DeathMenu deathMenu;
	private bool isDead=false;

	void Update()
	{
		if(isDead)
			return;
		if(score>scoreToMaxLevel)
			LevelUp();
		score+=Time.DeltaTime*difficultyLevel;
		//Debug.Log(score);
		//setting the incresed score at the time of game playing
		scoreText.text=((int)score).ToString();
	}
	void LevelUp()
	{
		if(difficultyLevel==maxDifficultyLevel)
			return;
		scoreToMaxLevel*=2;
		difficultyLevel++;
		//calling function SetSpeed of Player script
		GetComponent<Player>().SetSpeed(difficultyLevel);
		//Debug.Log(difficultyLevel);
	}

	public void onDeath()
	{
		isDead=true;
		if(PlayerPrefs.GetFloat("highScore")<score)
		{
			// to setting the high score in the registry
			PlayerPrefs.SetFloat("highScore",score);
		}
		//to toggle end menu with score
		deathMenu.ToggleEndMenu(float score);
	}
}