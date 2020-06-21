using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{


    public Grid grid;
    public Tilemap rocksToDig, wall, gold, explodium, hardRock, teleport, lava,check;
    public TileBase wholeRock, brokenRock, lavaRock, lavaTile;
    public GameObject player;

    public float timer = 11;

    public int lavaPos = -5;

    public Text timerText;

    public Camera Camera;

    void Update()
    {
        if (timer < 0)
        {
            timer = 11;
            onLevelUp();
        }

        timer -= Time.deltaTime;
        timerText.text = timer.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(grid.WorldToCell(pos).y);
            if (Vector2.Distance(pos, player.transform.position) < 1.5f)
            {
                if (rocksToDig.HasTile(grid.WorldToCell(pos)))
                {
                    Debug.Log(rocksToDig.GetTile(grid.WorldToCell(pos)));
                    if (rocksToDig.GetTile(grid.WorldToCell(pos))==wholeRock)
                    {
                        rocksToDig.SetTile(grid.WorldToCell(pos), brokenRock);
                    }else if(rocksToDig.GetTile(grid.WorldToCell(pos)).Equals(brokenRock))
                    {
                        rocksToDig.SetTile(grid.WorldToCell(pos), null);
                    }
                }else if (gold.HasTile(grid.WorldToCell(pos)))
                {
                    player.GetComponent<Character>().addcoin();
                    gold.SetTile(grid.WorldToCell(pos), null);
                }
                else if (teleport.HasTile(grid.WorldToCell(pos)))
                {
                    if (pos.x<player.transform.position.x)
                    {
                        var newpos = grid.WorldToCell(pos);
                        newpos.x += 15;
                        rocksToDig.SetTile(newpos, null);
                        player.transform.position = new Vector3(newpos.x,player.transform.position.y,0);
                    }
                    else
                    {
                        var newpos = grid.WorldToCell(pos);
                        newpos.x -= 15;
                        rocksToDig.SetTile(newpos, null);
                        player.transform.position = new Vector3(newpos.x,player.transform.position.y,0);
                    }
                }else if (explodium.HasTile(grid.WorldToCell(pos)))
                {
                    for (int f = grid.WorldToCell(pos).x-5; f < grid.WorldToCell(pos).x + 5; f++)
                    {
                        for (int c = grid.WorldToCell(pos).y - 5; c < grid.WorldToCell(pos).y + 5; c++)
                        {
                            rocksToDig.SetTile(new Vector3Int(f,c,0), null);
                        }
                    }
                }                              
            }         
        }
    }



    public void onLevelUp()
    {
        Vector3 posOld = player.transform.position;

        for (int i = -15; i < 15; i++) lava.SetTile(grid.WorldToCell(new Vector3(posOld.x, lavaPos, 0) + new Vector3(i, 0, 0)), lavaTile);

        lavaPos++;
        player.GetComponent<Character>().addLevel();
        

    }

    public void updateLava()
    {
        lavaPos = 9;
        Vector3 posOld = player.transform.position;

        for (int j = -4; j < lavaPos; j++)
        {
            for (int i = -15; i < 15; i++) lava.SetTile(grid.WorldToCell(new Vector3(posOld.x, j, 0) + new Vector3(i, 0, 0)), lavaTile);
        }

        for (int j = 30; j > lavaPos; j--)
        {
            for (int i = -15; i < 15; i++) lava.SetTile(grid.WorldToCell(new Vector3(posOld.x, j, 0) + new Vector3(i, 0, 0)), null);
        }
    }

    public void checkPont()
    {
        check.ClearAllTiles();
    }

    }
