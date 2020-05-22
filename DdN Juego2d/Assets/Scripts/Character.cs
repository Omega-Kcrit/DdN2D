using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private Rigidbody2D rgb;
    public float speed;

    public Vector2 checkPoint;
    
    private int coins=0;
    public Text cointext;

    private int level;
    public Text Leveltext;
    
    public GridController gridController;

    public Vector2 mov;

    public bool canDoubleJump;
    public bool grounded = true;
    public Transform topLeft;
    public Transform bottomRight;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        checkPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rgb.AddForce(movement * speed);
        rgb.velocity = new Vector3(moveHorizontal * speed, rgb.velocity.y, moveVertical * speed);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            //SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            //gridController.onLevelUp();
            

            if (grounded)
            {
                rgb.AddForce(Vector2.up * 250);
                canDoubleJump = true;
                grounded = false;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rgb.AddForce(Vector2.up * 200);
                }
            }
        }
    }

    private void FixedUpdate()
    {
     
    }

    public void addcoin()
    {
        coins++;
        cointext.text = coins.ToString();
    }
    public void addLevel()
    {
        level++;
        Leveltext.text = level.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground")) grounded = true;

        
        
    }

    private void OnTriggerExit(Collider other)
    {
        checkPoint = transform.position;
    }
    private void Die()
    {
        transform.position = checkPoint;
    }
}
