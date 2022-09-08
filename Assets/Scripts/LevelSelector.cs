using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    private int SceneNum = 0;
    void Awake()
    {
        SceneNum = PlayerPrefs.GetInt("Scene");
        switch (SceneNum)
        {
            case 0:
                 SceneManager.LoadScene("Level 0");
                 break;
            case 1:
                SceneManager.LoadScene("Level 1");
                break;
            case 2:
                SceneManager.LoadScene("Level 2");
                break;
            case 3:
                SceneManager.LoadScene("Level 3");
                break;
            case 4:
                SceneManager.LoadScene("Level 4");
                break;
        }
    }
}
