using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float jumpForce = 2.0f;
    private bool isJumping = false;

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject westWall;
    public GameObject northWall;
    public GameObject southWall;
    public GameObject eastWall;
    public GameObject gameOverTextObject;
    public GameObject retryButton;
    public GameObject mainMenuButton;



    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
        gameOverTextObject.SetActive(false);
        retryButton.SetActive(false);
        mainMenuButton.SetActive(false);
        retryButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RestartGame);
        mainMenuButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(LoadMainMenu);

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            mainMenuButton.SetActive(true);
            winTextObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            gameOverTextObject.SetActive(true);
            retryButton.SetActive(true);
            mainMenuButton.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void RestartGame()
    {
        gameOverTextObject.SetActive(false);
        retryButton.SetActive(false);
        mainMenuButton.SetActive(false);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}