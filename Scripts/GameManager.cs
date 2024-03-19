using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour //Actually, this script is about inventory system.
{
    public static GameManager instance;
    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    private void Awake()
    {
        instance = this; //Call and use this script when start the game or start this scene.
    }

    void Start()
    {
        DisplayItems(); //use "DisplayItem" function.
    }

    private void DisplayItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
                slots[i].transform.GetChild(1).gameObject.SetActive(true);
        }
        for (int i = 0; i < slots.Length; i++) //Create slot for inventory bar.
        {
            if (i < items.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
                slots[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }


    public void AddItem(Item item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log("You already have this item");
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                {
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItems();
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            for (int i=0; i < items.Count; i++)
            {
                if (item == items[i])
                {
                    itemNumbers[i]--;
                    if (itemNumbers[i] == 0)
                    {
                        items.Remove(item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("There is no " + items + " in my bag.");
        }
        DisplayItems();
    }
}