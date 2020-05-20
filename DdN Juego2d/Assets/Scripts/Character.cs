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
    
    
    private int coins=0;
    public Text cointext;

    private int level;
    public Text Leveltext;
    
    public GridController gridController;

    public Vector2 mov;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rgb.AddForce(movement * speed);
        if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
        {
            gridController.onLevelUp();
        }
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
}
