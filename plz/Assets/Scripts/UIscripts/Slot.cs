using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour /* , IPointerClickHandler*/ {

    public Item item; // 획득한 아이템.
    public int itemCount; // 획득한 아이템의 개수.
    public Image itemImage; // 아이템의 이미지.

     

    // 필요한 컴포넌트.
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    //private WeaponManager theWeaponManager; // 하이라키에 있는건 직접 넣어야함

    /*void Start()
    {
        theWeaponManager = FindObjectOfType<WeaponManager>();
    }*/

    // 이미지의 투명도 조절.
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 아이템 획득
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if(item.itemType != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }

    // 아이템 개수 조정.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    // 슬롯 초기화.
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    /*public void OnPointerClick(PointerEventData eventData)
    {
         if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item != null)
            {
                if(item.itemType == Item.ItemType.Equipment)
                {
                    StartCoroutine(theWeaponManager.ChangeWeaponCoroutine(item.weaponType, item.itemName));
                }
                else
                {
                    Debug.Log(item.itemName + " 을 사용했습니다");
                    SetSlotCount(-1);
                }
            }
        }
	}*/
}
