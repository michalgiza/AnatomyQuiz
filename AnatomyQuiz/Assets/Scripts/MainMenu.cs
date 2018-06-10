
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void PlayGame()
    {
        SceneManager.LoadScene("InitScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	 public void Option()
    {
        SceneManager.LoadScene("Option");
    }
    public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
    }


}
