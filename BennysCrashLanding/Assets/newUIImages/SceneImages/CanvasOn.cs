using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("OnInvoke", 1.5f);
        //GC = this.GameObjec.GetComponent<Image>();
    }
    void OnInvoke()
    {
       Debug.Log("invoke");
       gameObject.SetActive(true);

       Invoke("EndScene", 2.0f);
	}
    void EndScene()
    {
        SceneManager.LoadScene("BacktoHome");
	}



}
