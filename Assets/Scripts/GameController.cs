using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public GameObject player;
    CanvasManager canvasManager;

    public Text gameOverText;
    public GameObject heart1, heart2, heart3;
    public int health;

    [HideInInspector]
    public int currentAmmo;
    private static int fullAmmo = 5;
    public Text currentAmmoText;

    private GameObject playerGO;
    private Vector3 playersStartPos;

    [HideInInspector]
    public bool gameover;

    void Start()
    {
        playersStartPos = new Vector3(5, 0f, -10);
        SpawnPlayer();
        canvasManager = canvasManager = CanvasManager.GetInstance();

        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

        gameOverText.text = "";
    }

    void Update()
    {
        currentAmmoText.text = currentAmmo.ToString();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        playerGO.GetComponent<PlayerController>().forwardSpeed = 5f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        ResumeGame();
    }

    public void SpawnPlayer()
    {
        playerGO = Instantiate(player, playersStartPos, new Quaternion());
        playerGO.GetComponent<PlayerController>().forwardSpeed = 0f;
        Camera.main.GetComponent<CameraController>().target = playerGO.transform;
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        canvasManager.SwitchCanvas(CanvasType.GameOver);
        PauseGame();
    }

    public void DealDamage()
    {
        health--;
        HealthCounter();

    }

    public void BonusHeath()
    {
        health = 3;
        HealthCounter();
    }

    void HealthCounter()
    {
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameover = true;
                break;
        }
    }

    public void FillAmmo()
    {
        currentAmmo = fullAmmo;
    }
}
