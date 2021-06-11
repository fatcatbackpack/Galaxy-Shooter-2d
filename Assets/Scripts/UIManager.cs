using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;

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
        //Display img sprite
        //give new one based on current lives
        _LivesImg.sprite = _liveSprites[currentLives];

    }

    public void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
    }

}
