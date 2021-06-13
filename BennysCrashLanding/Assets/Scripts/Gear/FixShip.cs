using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FixShip : MonoBehaviour
{
    [SerializeField]
    private float range; // ���ּ����� �ִ� �Ÿ�

    private bool fixActivated = false; //��ġ�� �����ϸ� true

    bool NowEscape;
    //���� false ���ٰ� ���߿� ������ ������ ������ true�� ���ؾ��ϴµ� ������ �����ϱ� �� true.

    bool GageReady = false;

    private RaycastHit hittInfoo; // �浹ü ���� ����.

    //���ּ����� �����ϰ� ���̾� ����ũ ����
    [SerializeField]
    private LayerMask shipLayerMask;

    //�ʿ��� ������Ʈ
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

            if(Input.GetKeyDown(KeyCode.E))  //E �ߺ��ŵ� ��������..? �����µ�...?
            {
                //CheckShip(); 
                CanFixShipOn();
         }
      }
        else
        {
            Debug.Log("���� ���� �غ� �ȵ�");  
      }
   }

    //background Ȱ��ȭ
    public void CanFixShipOn()
    {
        if(fixActivated)
        {
            Debug.Log("open fixWindow");
            if(hittInfoo.transform != null)
            {
                Debug.Log("background ������"); 
                fixship_background.gameObject.SetActive(true);
                fixship_bar.gameObject.SetActive(true);
                GageReady = true;

                //CanFixShip();
                GageUp();
         }
      }
   }

    //������ Ȱ��ȭ GetKeyDown�� �ȸ���. �Լ� ������ ��.
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
        Debug.Log("GageUp ȣ��");

        if(fixship_bar.fillAmount < 1)
        {
              //fixship_bar.fillAmount += (Time.deltaTime / totalTime);
              fixship_bar.fillAmount += Time.deltaTime * 0.06f;

              if(fixship_bar.fillAmount == 1)
              {
                    Debug.Log("1�Ѵ�");   
                    SceneManager.LoadScene("StartScene"); //�̸��� start�� ��� end��.
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
        fixshipText.text = "���ּ� ��ġ��" + "<color=green>" + " (EŰ)" + "</color>";
   
        TryFix();
    }

    private void FixShipInfoDisappear()
    {
        fixActivated = false;
        fixshipText.gameObject.SetActive(false);
   }
}
