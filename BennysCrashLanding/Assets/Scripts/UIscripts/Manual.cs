using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manual : MonoBehaviour
{
    public string sceneName = "DemoDay";
    

    public void ClickStart()
    {
        Debug.Log("·Îµù");
        SceneManager.LoadScene(sceneName);
    }

}