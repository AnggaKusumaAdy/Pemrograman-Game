using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                KembaliKeMenu();
            }
        }
    }

    public void MulaiPermainan()
    {
        SceneManager.LoadScene("Level1-1");
        {
            Time.timeScale = 1;
        }
    }


    public void KeluarPermainan ()
    {
        Application.Quit();
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level1-2");
        {
            Time.timeScale = 1;

        }
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level1-3");
        {
            Time.timeScale = 1;
        }
    }

    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
