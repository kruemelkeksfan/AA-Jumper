using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class PlayerControls : MonoBehaviour
{
    public static bool buildingButtons = false;
    public static bool ammunitionDisplayed = true;

    [SerializeField] float speed = 10.0f;
    [SerializeField] float turnSpeed = 2f;
    [SerializeField] float jumpPower = 100.0f;
    [SerializeField] Transform respawnPoint;
    [SerializeField] Text respawnTimeDisplay;
    [SerializeField] GameObject controllsHelpText;
    [SerializeField] GameObject escapeMenuWindow;
    [SerializeField] GameObject buildingButtonDisplay;

    float horizontalThrow;
    float jumpHorizontalThrow = 0;
    float rewiveTime;
    int respawnTime;
    bool movementEnabled, verticalThrow, collectable;
    bool pause = false;
    bool controllsEnabled = true;
    bool helpTextActive = false;
    static bool gameLost = false;
    Rigidbody rigidBody;

    List<Collider> hittingWreck = new List<Collider>();

    private void Awake()
    {
        Time.timeScale = 1;
        gameLost = false;
    }
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        respawnTime = DifficultyData.respawnTime;
    }
    void Update ()
    {
        if (rewiveTime >= Time.time)
        {
            respawnTimeDisplay.text = Mathf.RoundToInt(rewiveTime - Time.time).ToString();
        }
        else
        {
            respawnTimeDisplay.text = "";
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            helpTextActive = !helpTextActive;
            controllsHelpText.SetActive(helpTextActive);
        }
        if (!gameLost)
        {
            if (Input.GetKeyDown("escape"))
            {
                if (escapeMenuWindow.activeSelf)
                {
                    escapeMenuWindow.SetActive(false);
                }
                else
                {
                    escapeMenuWindow.SetActive(true);
                }
                TogglePause();
            }
            if (Input.GetKeyDown("p"))
            {
                TogglePause();
            }
            if (Input.GetKeyDown(KeyCode.R) && DifficultyData.ammunitionActiv)
            {
                ammunitionDisplayed = !ammunitionDisplayed;
            }
            if (controllsEnabled)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    buildingButtons = !buildingButtons;
                    buildingButtonDisplay.SetActive(buildingButtons);
                }
                if (movementEnabled == true && !DifficultyData.controlsWhileFlyingActive)
                {
                    horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
                    if (CrossPlatformInputManager.GetButtonDown("Jump") == true)
                    {
                        rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                    }
                }
                if (DifficultyData.controlsWhileFlyingActive)
                {
                    horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
                    if (CrossPlatformInputManager.GetButtonDown("Jump") && movementEnabled)
                    {
                        rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                    }
                }
                if (!DifficultyData.wreckAutoCollectActiv && hittingWreck.Count > 0 && Input.GetKeyDown("e"))
                {
                    CollectWrecks();
                }
                if (DifficultyData.wreckAutoCollectActiv && hittingWreck.Count > 0)
                {
                    CollectWrecks();
                }
            }
        }
    HorizontalMovement();
    }
    private void CollectWrecks()
    {
        ScrapManager.scrapCount = ScrapManager.scrapCount + DifficultyData.wreckValue * hittingWreck.Count;
        for (int I = hittingWreck.Count - 1; I > -1; --I)
        {
            Destroy(hittingWreck[I].gameObject);
            hittingWreck.Remove(hittingWreck[I]);
        }
    }
    public static void OnGameLost()
    {
        gameLost = true;
        Time.timeScale = 0;
        buildingButtons = false;
    }
    private void TogglePause()
    {
        if (!pause)
        {
            pause = true;
            controllsEnabled = false;
            Time.timeScale = 0;
        }
        else if (pause)
        {
            pause = false;
            controllsEnabled = true;
            Time.timeScale = 1;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment")
        {
            movementEnabled = true;
            jumpHorizontalThrow = 0;
        }
        if (other.tag == "Scrap")
        {
            hittingWreck.Add(other);
        }
        if (other.tag == "Ground")
        {
            Invoke("Respawn", respawnTime);
            rewiveTime = Time.time + respawnTime;
        }
        if (other.tag == "Factory")
        {
            transform.position = new Vector3(2.2f, transform.position.y, transform.position.z);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Environment")
        {
            movementEnabled = false;
            if (DifficultyData.controlsWhileFlyingActive)
            {
                jumpHorizontalThrow = horizontalThrow;
            }
        }
        if (other.tag == "Scrap")
        {
            hittingWreck.Remove(other);
        }
    }
    void Respawn()
    {
        gameObject.transform.position = respawnPoint.position;
        rigidBody.velocity = new Vector3(0, 0, 0);
    }
    void HorizontalMovement()
    {
        float xOffset = Mathf.Clamp((horizontalThrow + jumpHorizontalThrow), -1, 1) * speed * Time.deltaTime;
        float newXPos = transform.position.x + xOffset;
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
        if (xOffset < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * turnSpeed);
        }
        else if (xOffset > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * turnSpeed);
        }
    }
}
