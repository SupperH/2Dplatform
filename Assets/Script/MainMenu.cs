using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //������ý�����UI��panel������
    public GameObject loadingScrean;
    //������
    public Slider slider;
    //�ı����󣬽���������
    public Text progressText;
/*    public void PlayGame()
    {
        �����ʼ�����һ������
        SceneManager.LoadScene(1);
    }*/

    //���ؽ���
    public void LoadLever(int sceneIndex)
    {
        //����Э��
        StartCoroutine(AsyncLoadLevel(sceneIndex));
    }


    //Э��
    IEnumerator AsyncLoadLevel(int sceneIndex)
    {
        //�첽���볡����Ȼ����ʾ������
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScrean.SetActive(true);

        //�ж���Ϸ�Ƿ������
        while (!operation.isDone)
        {
            //���������ȣ�����0.9����Ϊprogress��0-0.9�ķ�Χ�����Գ���0.9����1
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            //FloorToIntת����int ת���ɰٷ���
            progressText.text = Mathf.FloorToInt(progress * 100f) + "%";
            //����null���� �������Э�̻ᱨ��
            yield return null;
        }
    }

    public void QuitGame()
    {
        //�˳���Ϸ
        Application.Quit();
    }
}
