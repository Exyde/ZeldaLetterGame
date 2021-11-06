using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour{
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _timerText;

    [Space]

    public int _score;
    public float _timer;

    PlayerController _playerController;
    bool isGamePlaying = true;

    private void Start() {
        _score = 0;
        _scoreText.SetText("Score \n {0}", _score);
        _playerController = FindObjectOfType<PlayerController>();
        isGamePlaying = true;

    }

    private void Update() {

        if (isGamePlaying){
            _timer -= Time.deltaTime;
            _timerText.SetText("Timer \n {0:0}", _timer);
        }

        if (_timer <= 0){
            isGamePlaying = false;
            _timerText.SetText("Timer \n {0:0}", 0);
            _playerController.enabled = false;
            //Show replay

        }

    }

    public void UpdateScore(){
        _score += 100;
        _scoreText.SetText("Score \n {0}", _score);

    }

}
