using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public bool NowEscape = false;

    // Update is called once per frame
    void Update()
    {
        if(this == null)
        {
            Debug.Log("Get Gear");
            NowEscape = true;
		}
    }
}
