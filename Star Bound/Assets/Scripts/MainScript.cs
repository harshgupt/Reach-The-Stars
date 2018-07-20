using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    public GameObject mainObject;
    public GameObject title;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject homeButton;
    public GameObject playAgainButton;
    public GameObject highscoreButton;
    public GameObject highscoreScreen;
    public GameObject scoreValue;
    public GameObject bubble;
    public GameObject bouncingStar;
    public GameObject bouncingStar1;
    public GameObject bouncingStar2;
    public GameObject bouncingStar3;
    public GameObject bouncingStar4;

    public static bool isGameOver;

    public Animator scoreAnimator;

    public AudioSource audioSource;
    public AudioClip buttonPress;
    public AudioClip gameOver;

    public Transform bouncingStarPrefab;

    private void Start()
    {
        title.SetActive(true);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        bubble.SetActive(false);
        bouncingStar.SetActive(false);
        homeButton.SetActive(false);
        playAgainButton.SetActive(false);
        highscoreButton.SetActive(false);
        StarSpawner.spawnStars = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            isGameOver = false;
            OnGameOver();
        }

        if(StarScript.decreaseSize || CharacterController.decreaseSize)
        {
            StarScript.decreaseSize = false;
            CharacterController.decreaseSize = false;
            bouncingStar.transform.localScale -= new Vector3(0.1f, 0.1f);
            bouncingStar1.transform.localScale -= new Vector3(0.1f, 0.1f);
            bouncingStar2.transform.localScale -= new Vector3(0.1f, 0.1f);
            bouncingStar3.transform.localScale -= new Vector3(0.1f, 0.1f);
            bouncingStar4.transform.localScale -= new Vector3(0.1f, 0.1f);
            bubble.transform.localScale -= new Vector3(0.1f, 0.1f);
        }

        if(StarScript.increaseStarCount || CharacterController.increaseStarCount)
        {
            StarScript.increaseStarCount = false;
            CharacterController.increaseStarCount = false;
            if (!bouncingStar1.activeSelf)
            {
                bouncingStar1.SetActive(true);
            }
            else if (!bouncingStar2.activeSelf)
            {
                bouncingStar2.SetActive(true);
            }
            else if (!bouncingStar3.activeSelf)
            {
                bouncingStar3.SetActive(true);
            }
            else if (!bouncingStar4.activeSelf)
            {
                bouncingStar4.SetActive(true);
            }
        }
    }

    public void OnGameStart()
    {
        audioSource.PlayOneShot(buttonPress);
        title.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        bubble.SetActive(true);
        bouncingStar.SetActive(true);
        scoreValue.SetActive(true);
        homeButton.SetActive(true);
        StarSpawner.spawnStars = true;
        CharacterController.speed = 100.0f;
    }

    public void OnTutorial()
    {
        title.SetActive(false);
        quitButton.SetActive(false);
    }

    public void OnGameOver()
    {
        audioSource.PlayOneShot(gameOver);
        scoreAnimator.SetTrigger("gameOver");
        StarSpawner.spawnStars = false;
        playAgainButton.SetActive(true);
        highscoreButton.SetActive(true);
        GameObject[] shadowStars = GameObject.FindGameObjectsWithTag("Shadow Star");
        foreach(GameObject star in shadowStars)
        {
            Destroy(star);
        }
        GameObject[] brightStars = GameObject.FindGameObjectsWithTag("Bright Star");
        foreach(GameObject star in brightStars)
        {
            Destroy(star);
        }
        GameObject[] bouncingStars = GameObject.FindGameObjectsWithTag("Bouncing Star");
        foreach(GameObject star in bouncingStars)
        {
            Destroy(star);
        }
        bubble.SetActive(false);
        bouncingStar.SetActive(false);
        homeButton.SetActive(false);
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnHighscoreClick()
    {
        audioSource.PlayOneShot(buttonPress);
        highscoreScreen.SetActive(true);
        highscoreButton.SetActive(false);
        scoreValue.SetActive(false);
        playAgainButton.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
