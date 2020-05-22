using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{


    public Grid grid;
    public Tilemap rocasCavar, muro, oro, Explodium, RocaDura, Teleport;
    public TileBase rocaEntera, rocaRota,RocaLava;
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
                if (rocasCavar.HasTile(grid.WorldToCell(pos)))
                {
                    Debug.Log("TIEN ROCA PARA CABAR");
                    Debug.Log(rocasCavar.GetTile(grid.WorldToCell(pos)));
                    if (rocasCavar.GetTile(grid.WorldToCell(pos))==rocaEntera)
                    {
                        rocasCavar.SetTile(grid.WorldToCell(pos), rocaRota);
                        Debug.Log("Mitad Destruida");
                    }else if(rocasCavar.GetTile(grid.WorldToCell(pos)).Equals(rocaRota))
                    {
                        rocasCavar.SetTile(grid.WorldToCell(pos), null);
                        Debug.Log("destruido");
                    }
                }else if (oro.HasTile(grid.WorldToCell(pos)))
                {
                    player.GetComponent<Character>().addcoin();
                }else if (Teleport.HasTile(grid.WorldToCell(pos)))
                {
                    if (pos.x<player.transform.position.x)
                    {
                        var newpos = grid.WorldToCell(pos);
                        Debug.Log(grid.WorldToCell(pos).x);
                        newpos.x += 15;
                        Debug.Log(newpos.x);
                        rocasCavar.SetTile(newpos, null);
                        player.transform.position = new Vector3(newpos.x,player.transform.position.y,0);
                    }
                    else
                    {
                        var newpos = grid.WorldToCell(pos);
                        Debug.Log(grid.WorldToCell(pos).x);
                        newpos.x -= 15;
                        Debug.Log(newpos.x);
                        rocasCavar.SetTile(newpos, null);
                        player.transform.position = new Vector3(newpos.x,player.transform.position.y,0);
                    }
                }
               
                
            }
            
         //rocasCavar.HasTile(grid.WorldToCell(pos));
         
        }
    }



    public void onLevelUp()
    {
        Vector3 posOld = player.transform.position;
        Vector3 pos = player.transform.position+ new Vector3(0,1,0);
        
        if (rocasCavar.GetTile(grid.WorldToCell(pos))==null&&oro.GetTile(grid.WorldToCell(pos))==null&&
            muro.GetTile(grid.WorldToCell(pos))==null&&Explodium.GetTile(grid.WorldToCell(pos))==null&&RocaDura.GetTile(grid.WorldToCell(pos))==null)
        {
            
            Debug.Log("Puede Subir");
            player.GetComponent<Character>().addLevel();
            player.transform.position+=new Vector3(0,1,0);
            for (int i = -15; i<15; i++)
            {
                muro.SetTile(grid.WorldToCell(posOld+new Vector3(i,0,0)), RocaLava);
                
            }
            
        }else
            Debug.Log("No puedes subir");

        
        
    }
    
}
