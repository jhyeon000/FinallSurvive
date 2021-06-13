using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BacktoStart", 2.5f);
    }

    void BacktoStart()
    {
        Debug.Log("back");
        SceneManager.LoadScene("GameTitle");
	}
}
