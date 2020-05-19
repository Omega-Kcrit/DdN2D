using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{


    public Grid grid;
    public Tilemap rocasCavar;
    public GameObject player;
    

    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(string.Format("Co-ords of mouse is [X: {0} Y: {0}]", pos.x, pos.y));
         if(Vector2.Distance(pos,player.transform.position)<1.5f)
            rocasCavar.SetTile(grid.WorldToCell(pos),null);
         //rocasCavar.HasTile(grid.WorldToCell(pos));
         
        }
    }
}
