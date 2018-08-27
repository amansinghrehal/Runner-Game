using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
	public Text scoreText;
	void Start()
	{
		//initilaly set Death menu to not show
		gameObject.SetActive(false);
	}
	
	public void ToggleEndMenu(float score)
	{
		//when Player collide this function will called with current score as argument
		gameObject.SetActive(true);
		//set score at death menu
		scoreText.text=((int)score).ToString();
	}
	//this function will be called when user press on restart button
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	//this function will be called when user press on Menu button
	public void ToMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}