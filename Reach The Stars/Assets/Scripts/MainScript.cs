using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    public GameObject mainObject;
    public GameObject mainUI;
    public GameObject title;
    public GameObject playButton;
    public GameObject tutorialButton;
    public GameObject tutorialImage;
    public GameObject quitButton;
    public GameObject homeButton;
    public GameObject playAgainButton;
    public GameObject highscoreButton;
    public GameObject highscoreScreen;
    public GameObject scoreValue;
    public static bool isGameOver;
    public Animator scoreAnimator;
    public Animator bgAnimator;
    public Animator playButtonAnimator;
    public Animator playAgainButtonAnimator;
    public Animator highscoreButtonAnimator;
    public AudioSource audioSource;
    public AudioClip buttonPress;

    private void Start()
    {
        mainUI.SetActive(true);
        title.SetActive(true);
        playButton.SetActive(true);
        tutorialButton.SetActive(true);
        tutorialImage.SetActive(false);
        quitButton.SetActive(true);
        homeButton.SetActive(false);
        playAgainButton.SetActive(false);
        highscoreButton.SetActive(false);
        mainObject.GetComponent<AppleSpawner>().enabled = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            isGameOver = false;
            OnGameOver();
        }
    }

    public void OnGameStart()
    {
        audioSource.PlayOneShot(buttonPress);
        mainUI.SetActive(false);
        title.SetActive(false);
        playButton.SetActive(false);
        tutorialButton.SetActive(false);
        tutorialImage.SetActive(false);
        quitButton.SetActive(false);
        homeButton.SetActive(true);
        mainObject.GetComponent<AppleSpawner>().enabled = true;
        CharacterController.speed = 10.0f;
    }

    public void OnTutorial()
    {
        title.SetActive(false);
        playButtonAnimator.SetTrigger("isTutorial");
        tutorialButton.SetActive(false);
        tutorialImage.SetActive(true);
        quitButton.SetActive(false);
    }

    public void OnGameOver()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject apple in apples)
        {
            Destroy(apple);
        }
        GameObject[] silverApples = GameObject.FindGameObjectsWithTag("Silver Apple");
        foreach (GameObject apple in silverApples)
        {
            Destroy(apple);
        }
        GameObject[] goldApples = GameObject.FindGameObjectsWithTag("Golden Apple");
        foreach (GameObject apple in goldApples)
        {
            Destroy(apple);
        }
        mainObject.GetComponent<AppleSpawner>().enabled = false;
        scoreAnimator.SetTrigger("GameOver");
        bgAnimator.SetTrigger("GameOver");
        playAgainButton.SetActive(true);
        highscoreButton.SetActive(true);
        homeButton.SetActive(false);
        playAgainButtonAnimator.SetTrigger("GameOver");
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnHighscoreClick()
    {
        audioSource.PlayOneShot(buttonPress);
        mainUI.SetActive(true);
        highscoreScreen.SetActive(true);
        highscoreButton.SetActive(false);
        scoreValue.SetActive(false);
        playAgainButton.SetActive(true);
        playAgainButtonAnimator.SetTrigger("OnHighscoreClick");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
