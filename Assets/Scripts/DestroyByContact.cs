using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public int scoreValue;

    private HighScoreManager highScoreManager;

    void Start()
	{
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        highScoreManager = gameControllerObject.GetComponent<HighScoreManager>();

    }

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Corridors") || other.CompareTag("Barrel"))
		{
			return;
		}
		
		if(explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
            highScoreManager.AddScore(scoreValue);
		}

		if(other.CompareTag("Bolt"))
		{
            Destroy(other.gameObject);
		}

		Destroy(gameObject);
	}
}
