using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //handle to text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;

    private int _scoreActual;

    [SerializeField]
    private Image _LivesImg;

    [SerializeField]
    private Sprite[] _liveSprites;

    // Start is called before the first frame update
    void Start()
    {
        _scoreActual = 0;
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _scoreText.text = "Score: " + _scoreActual;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpScore(int points)
    {
        _scoreActual += points ;
        _scoreText.text = "Score: " + _scoreActual;
    }

    public void UpdateLives(int currentLives)
    {

        _LivesImg.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
        {
            _gameOverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlicker());
        }

        
    }

    IEnumerator GameOverFlicker()
    {
        while (true)
        {
            
            _gameOverText.text = "Game Over";
            yield return new WaitForSeconds(1.0f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(1.0f);
        }

    }


}
