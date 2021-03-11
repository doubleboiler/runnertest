using System.Collections;
using UnityEngine;

public class CorridorSpawner : MonoBehaviour
{
    public float waitTime = 4f;

    void Start()
    {
        SpawnPauseCheck();
        CorridorManager.GetInstance().corridors.Add(gameObject);
    }

    private void SpawnPauseCheck()
    {
        CorridorManager.GetInstance().paused = gameObject.transform.childCount > 2;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && CorridorManager.GetInstance().paused && gameObject.transform.childCount > 2)
        {
            CorridorManager.GetInstance().paused = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Destroy());
            HighScoreManager.GetInstance().AddScore(50);
            if (CorridorManager.GetInstance().startRoom != null) { Destroy(CorridorManager.GetInstance().startRoom); }
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
