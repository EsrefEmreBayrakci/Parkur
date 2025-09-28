using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject panel; 
    public bool isGameOver = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver) 
        {
            if (panel.activeSelf)
                HidePanel();
            else
                ShowPanel();
        }
    }


    public void ShowPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void HidePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        StartCoroutine(RestartDelayed());
    }

    private IEnumerator RestartDelayed()
    {
        yield return null; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {

        Application.Quit();
    }

    public void SetGameOver()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }
}
