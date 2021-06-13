using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject go_BaseUi; // 일시 정지 UI 패널
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
        Time.timeScale = 0f; // 시간의 흐름 설정. 0배속. 즉 시간을 멈춤.
    }

    private void CloseMenu()
    {
        GameManager.isPause = false;
        go_BaseUi.SetActive(false);
        Time.timeScale = 1f; // 1배속 (정상 속도)
    }

    public void ClickSave()
    {
        Debug.Log("세이브");
        theSaveNLoad.SaveData();
    }

    public void ClickLoad()
    {
        Debug.Log("로드");
        theSaveNLoad.LoadData();
    }

    public void ClickExit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
