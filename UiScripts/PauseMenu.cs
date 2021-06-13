using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string sceneName = "GameTitle";

    [SerializeField] private GameObject go_BaseUi; // �Ͻ� ���� UI �г�
    [SerializeField] private SaveNLoad theSaveNLoad;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!GameManager.isPause)
                CallMenu();
            else
                CloseMenu();
        }
    }

    private void CallMenu()
    {
        GameManager.isPause = true;
        go_BaseUi.SetActive(true);
        Time.timeScale = 0f; // �ð��� �帧 ����. 0���. �� �ð��� ����.
    }

    private void CloseMenu()
    {
        GameManager.isPause = false;
        go_BaseUi.SetActive(false);
        Time.timeScale = 1f; // 1��� (���� �ӵ�)
    }

    public void ClickSave()
    {
        Debug.Log("���̺�");
        theSaveNLoad.SaveData();
    }

    public void ClickLoad()
    {
        Debug.Log("�ε�");
        theSaveNLoad.LoadData();
    }

    public void ClickExit()
    {
        Debug.Log("���� ����");
        Application.Quit();
        SceneManager.LoadScene(sceneName);
    }
}