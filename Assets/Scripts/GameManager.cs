using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject winPanel;
    public GameObject failPanel;
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isGameWin = false;
    [HideInInspector] public bool isFinish = false;
    [HideInInspector] public bool isGameStart = false;
    private void Awake()
    {
        instance = this;
    }

    public void WinPanel()
    {
        StartCoroutine(WinPanelDelay());
    }

    IEnumerator WinPanelDelay()
    {
        yield return new WaitForSeconds(1f);
        winPanel.SetActive(true);
    }

    public void FailPanel()
    {
        StartCoroutine(FailPanelDelay());
    }

    IEnumerator FailPanelDelay()
    {
        yield return new WaitForSeconds(1f);
        failPanel.SetActive(true);
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        CoinManager.instance.CounterUpdate();
        StartCoroutine(WaitSwitch());
    }
    
    IEnumerator WaitSwitch()
    {
        Debug.Log("Wait Started");
        yield return new WaitForSeconds(3f);
        Debug.Log("Wait Ended");
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level 0":
                SceneManager.LoadScene("Level 1");
                PlayerPrefs.SetInt("Scene", 1);
                break;
            case "Level 1":
                SceneManager.LoadScene("Level 2");
                PlayerPrefs.SetInt("Scene", 2);
                break;
            case "Level 2":
                SceneManager.LoadScene("Level 3");
                PlayerPrefs.SetInt("Scene", 3);
                break;
            case "Level 3":
                SceneManager.LoadScene("Level 4");
                PlayerPrefs.SetInt("Scene", 4);
                break;
            case "Level 4":
                SceneManager.LoadScene("Level 2");
                PlayerPrefs.SetInt("Scene", 2);
                break;
        }
    }
}
