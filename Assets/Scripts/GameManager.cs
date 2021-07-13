using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;

    [SerializeField]
    AudioSource _explosionSound;

    [SerializeField]
    private GameObject _escMenu;

    private void Start()
    {
        _escMenu.SetActive(false);
    }

    private void Update()
    {
        if ((_isGameOver == true) && (Input.GetKeyDown(KeyCode.R)))
        {
            RestartScene();
        }

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeMenu();
        }
        //quit application
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayExplosionSound()
    {
        _explosionSound.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        _escMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void EscapeMenu()
    {
        _escMenu.SetActive(true);
        Time.timeScale = 0;
    }


}
