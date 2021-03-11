using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum Side {Left, Mid, Right}

public class PlayerController : MonoBehaviour
{
    public Side m_Side = Side.Mid;
    [HideInInspector]
    public bool swipeLeft, swipeRight;

    public float deltaValue = 1.15f;
    public float strafeSpeed;
    public float forwardSpeed = 5f;
    private float currentSpeed;
    private bool dealDamagePause;

    public GameObject shot;
    public Transform shotSpawn;

    private Vector3 moveVector;
    private float newXPos = 5f;
    private CharacterController m_Char;
    private Animator m_Animator;
    private float x = 5f;

    void Start()
    {
        m_Char = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        transform.position = new Vector3(5, -0.2f, -8);
    }

    void Update()
    {
        if (!dealDamagePause)
        {
            swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        }


        if (Input.GetKeyDown(KeyCode.Space) && GameController.GetInstance().currentAmmo > 0)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GameController.GetInstance().currentAmmo--;
        }

        if (dealDamagePause)
        {
            forwardSpeed = 0f;

            StartCoroutine(PauseBreak());
        }

        if (swipeLeft)
        {
            m_Animator.Play("LeftStrafe");
            if (m_Side == Side.Mid)
            {
                DoStrafe(-deltaValue);
                m_Side = Side.Left;
            }
            else if (m_Side == Side.Right)
            {
                DoStrafe(-deltaValue);
                m_Side = Side.Mid;
            }

            moveVector = new Vector3(x - transform.position.x, 0f, forwardSpeed * Time.deltaTime);
            x = Mathf.Lerp(x, newXPos, Time.deltaTime * strafeSpeed);
        }
        else if (swipeRight)
        {
            m_Animator.Play("RightStrafe");

            if (m_Side == Side.Mid)
            {
                DoStrafe(deltaValue);
                m_Side = Side.Right;
            }
            else if (m_Side == Side.Left)
            {
                DoStrafe(deltaValue);
                m_Side = Side.Mid;
            }
        }

        moveVector = new Vector3(x - transform.position.x, 0f, forwardSpeed * Time.deltaTime);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * strafeSpeed);

        m_Char.Move(moveVector);

    }

    void DoStrafe(float delta)
    {
        newXPos += delta;
        moveVector = new Vector3(x - transform.position.x, 0f, forwardSpeed * Time.deltaTime);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * strafeSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "RotateLeft":
                CorridorManager.GetInstance().transform.RotateAround(transform.position, Vector3.up, 90);
                SpeedUp();
                break;

            case "RotateRight":
                CorridorManager.GetInstance().transform.RotateAround(transform.position, Vector3.up, -90);
                SpeedUp();
                break;

            case "Bonus":
                Destroy(other.gameObject);
                if (Random.value < 0.5f)
                {
                    GameController.GetInstance().FillAmmo();
                }
                else
                {
                    GameController.GetInstance().BonusHeath();
                }
                break;

            case "Barrel":
                dealDamagePause = true;
                currentSpeed = forwardSpeed;
                m_Animator.Play("Dying");
                GameController.GetInstance().DealDamage();
                break;
        }
    }

    void SpeedUp()
    {
        forwardSpeed += 0.3f;
    }

    private IEnumerator PauseBreak()
    {
        yield return new WaitForSeconds(1.4f);

        if (GameController.GetInstance().gameover)
        {
            GameController.GetInstance().GameOver();
        }

        dealDamagePause = false;
        forwardSpeed = currentSpeed;
    }
}
