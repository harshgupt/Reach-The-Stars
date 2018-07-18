using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    public GameObject mainObject;
    public GameObject title;
    public GameObject playButton;
    //public GameObject tutorialButton;
    //public GameObject tutorialImage;
    public GameObject quitButton;
    public GameObject homeButton;
    public GameObject playAgainButton;
    public GameObject highscoreButton;
    public GameObject highscoreScreen;
    public GameObject scoreValue;
    public GameObject bubble;
    public GameObject bouncingStar;

    public static bool isGameOver;

    public Animator scoreAnimator;

    public AudioSource audioSource;
    public AudioClip buttonPress;

    public Transform bouncingStarPrefab;

    private void Start()
    {
        title.SetActive(true);
        playButton.SetActive(true);
        //tutorialButton.SetActive(true);
        //tutorialImage.SetActive(false);
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
            bubble.transform.localScale -= new Vector3(0.1f, 0.1f);
        }

        if(StarScript.increaseStarCount || CharacterController.increaseStarCount)
        {
            StarScript.increaseStarCount = false;
            CharacterController.increaseStarCount = false;
            Vector3 position = new Vector3(0, 5f);
            var temp = Instantiate(bouncingStarPrefab, position, Quaternion.identity);
            temp.gameObject.SetActive(true);
        }
    }

    public void OnGameStart()
    {
        audioSource.PlayOneShot(buttonPress);
        title.SetActive(false);
        playButton.SetActive(false);
        //tutorialButton.SetActive(false);
        //tutorialImage.SetActive(false);
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
        //tutorialButton.SetActive(false);
        //tutorialImage.SetActive(true);
        quitButton.SetActive(false);
    }

    public void OnGameOver()
    {
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
