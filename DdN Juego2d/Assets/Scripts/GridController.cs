using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{


    public Grid grid;
    public Tilemap rocasCavar;
    public TileBase rocaDura, rocaRota;
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
            Debug.Log("Pulsado");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(pos, player.transform.position) < 1.5f)
            {
                Debug.Log("Rango");
                if (rocasCavar.GetTile(grid.WorldToCell(pos)).Equals(rocaDura))
                    rocasCavar.SetTile(grid.WorldToCell(pos), rocaRota);
                else if(rocasCavar.GetTile(grid.WorldToCell(pos)).Equals(rocaRota))
                {
                    rocasCavar.SetTile(grid.WorldToCell(pos), null);
                    Debug.Log("destruido");
                }
            }
            
         //rocasCavar.HasTile(grid.WorldToCell(pos));
         
        }
    }
}
