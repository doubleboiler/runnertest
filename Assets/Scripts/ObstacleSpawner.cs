using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    void Start()
    {
        int rand = Random.Range(0, obstaclePrefab.Length);
        GameObject obs = Instantiate(obstaclePrefab[rand]);
        obs.transform.position = transform.position;
        obs.transform.rotation = transform.parent.rotation;
        obs.transform.SetParent(transform);
    }
}
