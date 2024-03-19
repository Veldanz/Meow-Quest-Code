using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public int buttonID;
    private Item thisItem;


    public void CloseButton()
    {
        GameManager.instance.RemoveItem(GetThisItem());
    }

    private Item GetThisItem()
    {
        for(int i=0; i < GameManager.instance.items.Count; i++)
        {
            if (buttonID == 1)
            {
                thisItem = GameManager.instance.items[i];
            }    
        }
        return thisItem;
    }
}