using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item itemData;

    private void OnTriggerEnter2D(Collider2D other) //Make a condition if the player is touching this object.
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject); //Destroy this object.
            GameManager.instance.AddItem(itemData); //Call the function in the game manager script and pass it the data of the item that we picked up.
        }
    }
}