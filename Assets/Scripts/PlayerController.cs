using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class PlayerController : MonoBehaviour
{
    private AudioSource playerAudio;
    private Animator playerAnim;
    private Rigidbody playerRb;
    public float jumpForce = 700;
    public float gravityModifier = 1.5f;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip collectSound;
    public AudioSource backgroundmusic;
    public AudioClip gameMusic;
    public GameObject Stone;
    public Button restartButton;
    public GameObject gameOvertxt;
    public GameObject panel;
    public bool isOnGround = true;
    public bool gameOver = false;
    public int foodCollected = 0;
    public int foodTarget = 100;

    public string currentSceneName;
    public string nextSceneName;

    private bool gameEnded = false;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        backgroundmusic.clip = gameMusic;

        Physics.gravity *= gravityModifier;

        currentSceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (foodCollected >= foodTarget && !gameEnded)
        {
            gameEnded = true;
            gameOvertxt.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);
            float originalTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            StartCoroutine(LoadNextScene(originalTimeScale));
            Debug.Log("Game Over!!!");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(Stone, transform.position, Stone.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            foodCollected++;
            playerAudio.PlayOneShot(collectSound, 1.0f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GameOver!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            backgroundmusic.Stop();
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);

        SceneManager.LoadScene(currentSceneName);
    }

    private IEnumerator LoadNextScene(float originalTimeScale)
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = originalTimeScale;

        if (currentSceneName == "Prototype 3")
        {
            nextSceneName = "Scene 3";
        }
        else if (currentSceneName == "Scene 4")
        {
            nextSceneName = "Scene 5";
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
