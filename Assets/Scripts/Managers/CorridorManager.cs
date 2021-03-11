using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorManager : Singleton<CorridorManager>
{
    public GameObject[] bottomCorridors;
    public GameObject[] topCorridors;
    public GameObject[] leftCorridors;
    public GameObject[] rightCorridors;
    public GameObject startRoom;

    [HideInInspector]
    public bool paused;

    public List<GameObject> corridors;

    //private Stack<GameObject> turnCorridors = new Stack<GameObject>();
    //private Stack<GameObject> straightCorridors = new Stack<GameObject>();

}
