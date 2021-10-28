using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    //��Ϸ�Ƿ�����ͣ״̬
    public static bool GameIsPaused = false;

    //��ͣҳ��
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
            //���������ͣ״̬�£�������ese�Ǿ��ǻָ���Ϸ����֮
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
        //�ָ���Ϸ���ر���ͣҳ��
        pauseMenuUI.SetActive(false);
        //��ʱ�����Żָ�Ϊ1
        Time.timeScale = 1.0f;

        GameIsPaused = false;
    }

    public void Pause()
    {
        //��ͣ����ͣҳ��
        pauseMenuUI.SetActive(true);
        //��ʱ����������Ϊ0���������������ħŮʱ��
        Time.timeScale = 0.0f;
        GameIsPaused = true;


    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        //Ҳ����ͨ��������������ת�������������ļ���
        SceneManager.LoadScene("Menu");
    }
}
