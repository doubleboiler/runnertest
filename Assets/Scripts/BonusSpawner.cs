using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject bonusPrefab;

    void Start()
    {
        int appearance = Random.Range(0, 7);
        if (appearance == 1)
        {
            GameObject obs = Instantiate(bonusPrefab);
            obs.transform.position = transform.position + new Vector3(0, 0.2f, 0);
            obs.transform.SetParent(transform);
        }
    }
}
