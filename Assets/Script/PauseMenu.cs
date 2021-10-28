using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    //游戏是否是暂停状态
    public static bool GameIsPaused = false;

    //暂停页面
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //如果是在暂停状态下，按下了ese那就是恢复游戏，反之
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //恢复游戏，关闭暂停页面
        pauseMenuUI.SetActive(false);
        //把时间流逝恢复为1
        Time.timeScale = 1.0f;

        GameIsPaused = false;
    }

    public void Pause()
    {
        //暂停打开暂停页面
        pauseMenuUI.SetActive(true);
        //把时间流逝设置为0，这个可以用来做魔女时间
        Time.timeScale = 0.0f;
        GameIsPaused = true;


    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        //也可以通过场景的名字跳转场景，场景的文件名
        SceneManager.LoadScene("Menu");
    }
}
