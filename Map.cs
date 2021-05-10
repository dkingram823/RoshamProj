using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : MonoBehaviour
{

    Room[] map;
    int mapSize;
    int tiles;
    System.Random rnd;

    public Map(int mapSi)
    {
        mapSize = mapSi;
        map = new Room[mapSi * mapSi];
        for(int i = 0; i<mapSi*mapSi;i++)
        {
            map[i] = new Room();
        }
        do
        {
            tiles = 0;
            map = new Room[mapSi * mapSi];
            genMap(0, 0);
        } while (tiles < (mapSize * mapSize) * .75); //regens the map until 75% or more of the available tiles are filled


    }

    public void genMap(int x, int y)
    {
        if ((x >= 0 && x < mapSize && y >= 0 && y < mapSize) && !map[(y * mapSize) + (x)].gen)
        {

            // north
            if (y > 0)
            {
                if (map[((y - 1) * mapSize) + (x)].gen) //above tile is already generated
                {
                    map[(y * mapSize) + (x)].layout[0] = map[(y - 1 * mapSize) + (x)].layout[1];
                }
                else
                {
                    switch (rnd.Next(3))
                    {
                        case (2):
                            map[(y * mapSize) + (x)].layout[0] = 2; //room connector
                            map[(y * mapSize) + x].gen = true;
                            genMap(x, y + 1);
                            map[(y * mapSize) + x].gen = false;
                            break;
                        case (1):
                            map[(y * mapSize) + (x)].layout[0] = 1; //room doorway
                            map[(y * mapSize) + x].gen = true;
                            genMap(x, y + 1);
                            map[(y * mapSize) + x].gen = false;
                            break;
                        case (0):
                        default:
                            map[(y * mapSize) + (x)].layout[0] = 0; //room wall
                            break;

                    }
                }
            }
            //south
            if (y < mapSize-1)
            {
                if (map[((y + 1) * mapSize) + (x)].gen) //below tile is already generated
                {
                    map[(y * mapSize) + (x)].layout[1] = map[(y + 1 * mapSize) + (x)].layout[0];
                }
                else
                {
                    switch (rnd.Next(3))
                    {
                        case (2):
                            map[(y * mapSize) + (x)].layout[1] = 2; //room connector
                            map[(y * mapSize) + x].gen = true;
                            genMap(x, y + 1);
                            map[(y * mapSize) + x].gen = false;
                            break;
                        case (1):
                            map[(y * mapSize) + (x)].layout[1] = 1; //room doorway
                            map[(y * mapSize) + x].gen = true;
                            genMap(x, y + 1);
                            map[(y * mapSize) + x].gen = false;
                            break;
                        case (0):
                        default:
                            map[(y * mapSize) + (x)].layout[1] = 0; //room wall
                            break;

                    }
                }
            }
            //east
            if (x < mapSize - 1)
            {
                if (map[((y) * mapSize) + (x + 1)].gen) //right tile is already generated
                {
                    map[(y * mapSize) + (x)].layout[2] = map[(y * mapSize) + (x+1)].layout[3];
                }
                else
                {
                    switch (rnd.Next(3))
                    {
                        case (2):
                            map[(y * mapSize) + (x)].layout[2] = 2; //room connector
                            map[(y * mapSize) + x].gen = true;
                            genMap(x+1,y);
                            map[(y * mapSize) + x].gen = false;
                            break;
                        case (1):
                            map[(y * mapSize) + (x)].layout[2] = 1; //room doorway
                            map[(y * mapSize) + x].gen = true;
                            genMap(x+1, y);
                            map[(y * mapSize) + x].gen = false;
                            break;
                        case (0):
                        default:
                            map[(y * mapSize) + (x)].layout[2] = 0; //room wall
                            break;

                    }
                }
            }
            //west
            if (x > 0)
            {
                if (map[((y) * mapSize) + (x - 1)].gen) //left tile is already generated
                {
                    map[(y * mapSize) + (x)].layout[3] = map[(y * mapSize) + (x - 1)].layout[2];
                }
                else
                {
                    switch (rnd.Next(3))
                    {
                        case (2):
                            map[(y * mapSize) + (x)].layout[3] = 2; //room connector
                            map[(y * mapSize) + x].gen = true;
                            genMap(x - 1, y);
                            map[(y * mapSize) + x].gen = false;
                            break;
                        case (1):
                            map[(y * mapSize) + (x)].layout[3] = 1; //room doorway
                            map[(y * mapSize) + x].gen = true;
                            genMap(x - 1, y);
                            map[(y * mapSize) + x].gen = false;
                            break;
                        case (0):
                        default:
                            map[(y * mapSize) + (x)].layout[3] = 0; //room wall
                            break;

                    }
                }
            }
            tiles++;
            map[(y* mapSize)+x].gen = true;
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
