using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;
public class GameManager : MonoBehaviour{
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _timerText;
    public TextMeshProUGUI _gameOverText;


    public GameObject _gameOverPanel;
    public GameObject _UIPanel;

    [Space]

    public int _score;
    int _bestScore = 0;
    string scoreFile = "score.txt";
    public float _timer;

    PlayerController _playerController;
    bool isGamePlaying = true;

    private void Start() {
        _score = 0;
        _scoreText.SetText("Score \n {0}", _score);
        _playerController = FindObjectOfType<PlayerController>();
        isGamePlaying = true;
        _gameOverPanel.SetActive(false);
        _UIPanel.SetActive(true);
        LoadBestScore();
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
            _UIPanel.SetActive(false);


            if (_score > _bestScore) SaveBestScore();
            _gameOverText.SetText("- Game Over - \n Score : {0} \n Best Score : {1} ", _score, _bestScore);
            _gameOverPanel.SetActive(true);
        }
    }

    public void UpdateScore(){
        _score += 1;
        _scoreText.SetText("Score \n {0}", _score);
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadBestScore(){
        //Load best score from a Data Path on user side.
        
        string dataPath = string.Format("{0}/{1}", Application.persistentDataPath, scoreFile);

        try
        {
            if (File.Exists(dataPath))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = File.Open(dataPath, FileMode.Open);
                _bestScore = (int)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to Load: " + e.Message);
        }

    }

    void SaveBestScore(){
        //Save best score to data path;

        string dataPath = string.Format("{0}/{1}", Application.persistentDataPath, scoreFile);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream;
        _bestScore = _score;

        try
        {
            if (File.Exists(dataPath))
            {
                File.WriteAllText(dataPath, string.Empty);
                fileStream = File.Open(dataPath, FileMode.Open);
            }
            else
            {
                fileStream = File.Create(dataPath);
            }

            binaryFormatter.Serialize(fileStream, _bestScore);
            fileStream.Close();


        }
        catch (Exception e)
        {
           Debug.LogError("Failed to Load: " + e.Message);
        }
    }

}
