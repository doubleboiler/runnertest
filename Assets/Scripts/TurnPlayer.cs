using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    public float yRotation;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.rotation = new Quaternion(0, yRotation, 0, 0);
        }
    }
}
