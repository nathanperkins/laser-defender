using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
	}

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
	}

    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverWithDelay());
	}

    public IEnumerator LoadGameOverWithDelay()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("GameOver");
	}

    public void QuitGame()
    {
        Application.Quit();
	}
}
