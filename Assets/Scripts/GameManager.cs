using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;

    [SerializeField]
    AudioSource _explosionSound;

    private void Update()
    {
        if ((_isGameOver == true) && (Input.GetKeyDown(KeyCode.R)))
        {
            RestartScene();
        }
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
}
