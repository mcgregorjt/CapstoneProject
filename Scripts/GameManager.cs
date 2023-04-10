using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 	public GameObject gameOverUI;
	public GameObject player;
	
    void Start()
    {
        Cursor.visible = false;
	Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
	{
	Cursor.visible = true;
	Cursor.lockState = CursorLockMode.None;
	}
	else 
	{
	Cursor.visible = false;
	Cursor.lockState = CursorLockMode.Locked;
	}
    }

	public void gameOver()
	{
		gameOverUI.SetActive(true);
	}
	
	public void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void mainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
	public void quit()
	{
		Application.Quit();
	//	Debug.Log(quit);
	}
}
