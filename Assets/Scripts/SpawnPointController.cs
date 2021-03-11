using System.Collections;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    public int openingDirection;

    private int rand;
    private bool spawned;

    void Update()
    {
        Invoke(nameof(SpawnCorridor), 0.1f);
    }

    void SpawnCorridor()
    {
        if (!spawned && !CorridorManager.GetInstance().paused)
        {
            if (openingDirection == 1)
            {
                // Need to spawn a BOTTOM corridor.
                rand = Random.Range(0,CorridorManager.GetInstance().bottomCorridors.Length);
                GameObject obs = Instantiate(CorridorManager.GetInstance().bottomCorridors[rand], transform.position,
                    CorridorManager.GetInstance().bottomCorridors[rand].transform.rotation * transform.rotation);
                obs.transform.SetParent(CorridorManager.GetInstance().transform);
            }
            else if (openingDirection == 2)
            {
                // Need to spawn a TOP corridor.
                rand = Random.Range(0,CorridorManager.GetInstance().topCorridors.Length);
                GameObject obs = Instantiate(CorridorManager.GetInstance().topCorridors[rand], transform.position,
                    CorridorManager.GetInstance().topCorridors[rand].transform.rotation * transform.rotation);
                obs.transform.SetParent(CorridorManager.GetInstance().transform);
            }
            else if (openingDirection == 3)
            {
                // Need to spawn a LEFT corridor.
                rand = Random.Range(0,CorridorManager.GetInstance().leftCorridors.Length);
                GameObject obs = Instantiate(CorridorManager.GetInstance().leftCorridors[rand], transform.position,
                    CorridorManager.GetInstance().leftCorridors[rand].transform.rotation * transform.rotation);
                obs.transform.SetParent(CorridorManager.GetInstance().transform);
            }
            else if (openingDirection == 4)
            {
                // Need to spawn a RIGHT corridor.
                rand = Random.Range(0,CorridorManager.GetInstance().rightCorridors.Length);
                GameObject obs = Instantiate(CorridorManager.GetInstance().rightCorridors[rand], transform.position,
                    CorridorManager.GetInstance().rightCorridors[rand].transform.rotation * transform.rotation);
                obs.transform.SetParent(CorridorManager.GetInstance().transform);
            }

            spawned = true;
        }
    }


}
