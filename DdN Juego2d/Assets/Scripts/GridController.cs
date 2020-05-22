using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{


    public Grid grid;
    public Tilemap rocasCavar, muro, oro, Explodium, RocaDura, Teleport, Lava;
    public TileBase rocaEntera, rocaRota,RocaLava, lavaTile;
    public GameObject player;

    public float timer = 7;

    public int lavaPos = -5;

    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            timer = 7;
            onLevelUp();
        }

        timer -= Time.deltaTime;
      

        if (Input.GetMouseButtonDown(0))
        {

            
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(grid.WorldToCell(pos).y);
            if (Vector2.Distance(pos, player.transform.position) < 1.5f)
            {
                if (rocasCavar.HasTile(grid.WorldToCell(pos)))
                {
                    Debug.Log(rocasCavar.GetTile(grid.WorldToCell(pos)));
                    if (rocasCavar.GetTile(grid.WorldToCell(pos))==rocaEntera)
                    {
                        rocasCavar.SetTile(grid.WorldToCell(pos), rocaRota);
                    }else if(rocasCavar.GetTile(grid.WorldToCell(pos)).Equals(rocaRota))
                    {
                        rocasCavar.SetTile(grid.WorldToCell(pos), null);
                    }
                }else if (oro.HasTile(grid.WorldToCell(pos)))
                {
                    player.GetComponent<Character>().addcoin();
                    oro.SetTile(grid.WorldToCell(pos), null);
                }
                else if (Teleport.HasTile(grid.WorldToCell(pos)))
                {
                    if (pos.x<player.transform.position.x)
                    {
                        var newpos = grid.WorldToCell(pos);
                        newpos.x += 15;
                        rocasCavar.SetTile(newpos, null);
                        player.transform.position = new Vector3(newpos.x,player.transform.position.y,0);
                    }
                    else
                    {
                        var newpos = grid.WorldToCell(pos);
                        newpos.x -= 15;
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

        for (int i = -15; i < 15; i++)
        {
            //rocasCavar.SetTile(grid.WorldToCell(new Vector3(posOld.x, lavaPos, 0) + new Vector3(i, 0, 0)), null);
            //RocaDura.SetTile(grid.WorldToCell(new Vector3(posOld.x, lavaPos, 0) + new Vector3(i, 0, 0)), null);
            //oro.SetTile(grid.WorldToCell(new Vector3(posOld.x, lavaPos, 0) + new Vector3(i, 0, 0)), null);
            Lava.SetTile(grid.WorldToCell(new Vector3(posOld.x,lavaPos,0) + new Vector3(i,0,0)), lavaTile);
        }
        lavaPos++;

            //    Vector3 posOld = player.transform.position;
            //    Vector3 pos = player.transform.position+ new Vector3(0,1,0);

            //    if (rocasCavar.GetTile(grid.WorldToCell(pos))==null&&oro.GetTile(grid.WorldToCell(pos))==null&&
            //        muro.GetTile(grid.WorldToCell(pos))==null&&Explodium.GetTile(grid.WorldToCell(pos))==null&&RocaDura.GetTile(grid.WorldToCell(pos))==null)
            //    {

            //        Debug.Log("Puede Subir");
            //        player.GetComponent<Character>().addLevel();
            //        player.transform.position+=new Vector3(0,1,0);
            //        for (int i = -15; i<15; i++)
            //        {
            //            muro.SetTile(grid.WorldToCell(posOld+new Vector3(i,0,0)), RocaLava);

            //        }

            //    }else
            //        Debug.Log("No puedes subir");



            }

    public void updateLava()
    {
        lavaPos = 9;
        Vector3 posOld = player.transform.position;

        for (int j = -4; j < lavaPos; j++)
        {
            for (int i = -15; i < 15; i++)
            {

                //rocasCavar.SetTile(grid.WorldToCell(new Vector3(posOld.x, j, 0) + new Vector3(i, 0, 0)), null);
                //RocaDura.SetTile(grid.WorldToCell(new Vector3(posOld.x, j, 0) + new Vector3(i, 0, 0)), null);
                //oro.SetTile(grid.WorldToCell(new Vector3(posOld.x, j, 0) + new Vector3(i, 0, 0)), null);
                Lava.SetTile(grid.WorldToCell(new Vector3(posOld.x, j, 0) + new Vector3(i, 0, 0)), lavaTile);
            }
        }

        for (int j = 30; j > lavaPos; j--)
        {
            for (int i = -15; i < 15; i++)
            {
                
                Lava.SetTile(grid.WorldToCell(new Vector3(posOld.x, j, 0) + new Vector3(i, 0, 0)), null);
            }
        }
    }

    }
