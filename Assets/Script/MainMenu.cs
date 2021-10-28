using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //用来获得进度条UI的panel父对象
    public GameObject loadingScrean;
    //进度条
    public Slider slider;
    //文本对象，进度条进度
    public Text progressText;
/*    public void PlayGame()
    {
        点击开始载入第一个场景
        SceneManager.LoadScene(1);
    }*/

    //加载进度
    public void LoadLever(int sceneIndex)
    {
        //启动协程
        StartCoroutine(AsyncLoadLevel(sceneIndex));
    }


    //协程
    IEnumerator AsyncLoadLevel(int sceneIndex)
    {
        //异步载入场景，然后显示进度条
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScrean.SetActive(true);

        //判断游戏是否加载完
        while (!operation.isDone)
        {
            //进度条进度，除以0.9是因为progress是0-0.9的范围，所以除以0.9就是1
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            //FloorToInt转换成int 转换成百分数
            progressText.text = Mathf.FloorToInt(progress * 100f) + "%";
            //返回null就行 不加这个协程会报错
            yield return null;
        }
    }

    public void QuitGame()
    {
        //退出游戏
        Application.Quit();
    }
}
