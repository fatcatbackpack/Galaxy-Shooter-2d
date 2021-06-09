using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to text
    [SerializeField]
    private Text _scoreText;

    private int _scoreActual;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreActual = 0;
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
}
