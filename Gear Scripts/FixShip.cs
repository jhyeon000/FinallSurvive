using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FixShip : MonoBehaviour
{
    [SerializeField]
    private float range; // 우주선과의 최대 거리

    private bool fixActivated = false; //고치기 가능하면 true

    bool NowEscape;
    //원래 false 였다가 나중에 숨겨진 아이템 먹으면 true로 변해야하는데 지금은 없으니까 걍 true.

    bool GageReady = false;

    private RaycastHit hittInfoo; // 충돌체 정보 저장.

    //우주선에만 반응하게 레이어 마스크 설정
    [SerializeField]
    private LayerMask shipLayerMask;

    //필요한 컴포넌트
    [SerializeField]
    private Text fixshipText;
    [SerializeField]
    private GameObject fixship_background;
    [SerializeField]
    //private GameObject fixship_bar;
    private Image fixship_bar;
    [SerializeField]
    private GameObject gear;

    void Start()
    {
        //bool NowEscape = GameObject.Find("ShipGear").GetComponent<Gear>().NowEscape;
        fixship_background.gameObject.SetActive(false);
        fixship_bar.gameObject.SetActive(false);
        fixship_bar.fillAmount = 0;
   }

    // Update is called once per frame
    void Update()
    {
        if(gear == null)
        {
            NowEscape = true;  
      }
        CheckShip();
        //TryFix();

        if(GageReady == true)
        {
            GageUp();  
      }

    }

    private void TryFix()
    {
        if(NowEscape == true)
        {
            Debug.Log("NowEscape is true");

            if(Input.GetKeyDown(KeyCode.E))  //E 중복돼도 괜찮을까..? 괜차는듯...?
            {
                //CheckShip(); 
                CanFixShipOn();
         }
      }
        else
        {
            Debug.Log("아직 떠날 준비 안됨");  
      }
   }

    //background 활성화
    public void CanFixShipOn()
    {
        if(fixActivated)
        {
            Debug.Log("open fixWindow");
            if(hittInfoo.transform != null)
            {
                Debug.Log("background 떠야함"); 
                fixship_background.gameObject.SetActive(true);
                fixship_bar.gameObject.SetActive(true);
                GageReady = true;

                //CanFixShip();
                GageUp();
         }
      }
   }

    //게이지 활성화 GetKeyDown이 안먹음. 함수 실행은 됨.
    /*public void CanFixShip()
    {
        if(fixActivated)
        {
              Debug.Log("haha");
              if(Input.GetKeyDown(KeyCode.C))
              {
                     Debug.Log("fixing...");
                     //fixship_background.gameObject.SetActive(true);
                     fixship_bar.gameObject.SetActive(true);
           }
      }
   }*/

    public void GageUp()
    {
        Debug.Log("GageUp 호출");

        if(fixship_bar.fillAmount < 1)
        {
              //fixship_bar.fillAmount += (Time.deltaTime / totalTime);
              fixship_bar.fillAmount += Time.deltaTime * 0.06f;

              if(fixship_bar.fillAmount == 1)
              {
                    Debug.Log("1됏다");   
                    SceneManager.LoadScene("StartScene"); //이름만 start고 사실 end임.
			  }
        }
        
   }


    private void CheckShip()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hittInfoo, range, shipLayerMask))
        {
            if(hittInfoo.transform.name == "SpaceShip")  
            {
                FixShipInfoAppear();     
         }
      }
        else
            FixShipInfoDisappear();
   }

    private void FixShipInfoAppear()
    {
        fixActivated = true;
        fixshipText.gameObject.SetActive(true);
        fixshipText.text = "우주선 고치기" + "<color=green>" + " (E키)" + "</color>";
   
        TryFix();
    }

    private void FixShipInfoDisappear()
    {
        fixActivated = false;
        fixshipText.gameObject.SetActive(false);
   }
}
