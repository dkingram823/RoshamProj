using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int[] layout; // north,south,east,west
    public bool gen = false;

    public Room()
    {
        layout = new int[4] { 0, 0, 0, 0 };
        gen = true;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
