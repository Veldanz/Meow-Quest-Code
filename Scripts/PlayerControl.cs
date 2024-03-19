using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int PlayerAct;
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    float playerInput;
    int speed = 5;
    Vector2 movement;
    public int countHP = 100;
    public int countItem = 0;
    public Text showHP;
    public AudioSource playSoundHurt;
    public AudioSource playSoundCollect;
    public AudioSource playSoundDoorBack;
    public AudioSource playSoundDoorIn;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        showHP.text = countHP.ToString(); //Convert to string and display HP value on UI text.
        movement.x = Input.GetAxis("Horizontal"); //Do a check for horizontal input from user.
        PlayerAct = 0; 
        movement.y = Input.GetAxis("Vertical");
        PlayerAct = 0;

        if (countHP <= 0) //Make a condition that when the HP is zero, it will
        {
            PlayerAct = 5; 
            Destroy(gameObject); //Destroy this gameobject.
            SceneManager.LoadScene("GameOver"); //Load scene name "GameOver" after destroying this object.
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime); // Moves the character based on the normalized.
    }
    private void OnTriggerEnter2D(Collider2D Collision) //Do a check when the player enters a trigger area.
    {
        if (Collision.gameObject.CompareTag("DoorOutSide")) //If the player hit the door with tag "DoorOutSide".
        {
            SceneManager.LoadScene("InSide"); //Load scene name "InSide".
            playSoundDoorIn.Play(); //Play sound that attached.
        }
        if (Collision.gameObject.CompareTag("DoorInSide")) //If the player hit an object with tag "DoorInSide",
        {
            SceneManager.LoadScene("BackYard"); //Load scene name "BackYard".
            playSoundDoorBack.Play(); //Play sound that attached.
        }
        if (Collision.gameObject.CompareTag("RockOutSide")) //If the player hit an object with the tag "RockOutSide".
        {
            countHP -= 10; //Decreaes HP by 10 each time hit with an enemy.
            playSoundHurt.Play(); //Play sound that attached.
        }
        if (Collision.gameObject.CompareTag("item")) //If the player hit  something with the tag "item".
        {
            Destroy(Collision.gameObject); //Destroy that object.
            playSoundCollect.Play(); //Play sound.
            countItem++; //+ that item to inventory.
            if (countItem == 15) //If item in the inventory has reach 15.
            {
                SceneManager.LoadScene("Victory"); //Load scene name "Victory".
            }
        }
    }

}