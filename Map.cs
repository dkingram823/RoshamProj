using System;
using System.Collections.Generic;
using System.Text;

namespace RoSham
{
    class Map
    {
        Room[] map;
        int mapSize;
        int tiles;

        public Map(int mapSi)
        {
            mapSize = mapSi;
            map = new Room[mapSi*mapSi];
            foreach (Room n in map){
                n.Room();
            }
            do
            {
                tiles = 0;
                map = new Room[mapSi * mapSi];
                genMap(0, 0);
            } while (tiles < (mapSize*mapSize)*.75); //regens the map until 75% or more of the available tiles are filled
            
            
        }

        public void genMap(int x, int y)
        {
            if((x >= 0 && x < mapSize && y >= 0 && y < mapSize) && !map[(y*mapSize)+(x)].gen)
            {
                
                // north
                if (y != 0)
                {
                    if (map[(y-1 * mapSize) + (x)].gen) //above tile is already generated
                    {
                        map[(y * mapSize) + (x)].layout[0] = map[(y-1 * mapSize) + (x)].layout[0];
                    }
                    else
                    {
                        switch (Random.Next(3))
                        {
                            case (2):
                                map[(y * mapSize) + (x)].layout[0] = 2; //room connector
                                genMap(x, y - 1);
                                break;
                            case (1):
                                map[(y * mapSize) + (x)].layout[0] = 1; //room doorway
                                genMap(x, y - 1);
                                break;
                            case (0):
                            default:
                                map[(y * mapSize) + (x)].layout[0] = 0; //room wall
                                break;

                        }
                    }
                }
                //south
                //east
                //west
                tiles = tiles + 1;

            }


        }




    }
}
