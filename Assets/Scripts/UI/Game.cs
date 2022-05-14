using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] StartScreen _startScreen;
    [SerializeField] GameOverScreen _gameOverScreen;
    [SerializeField] EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _startScreen.ExitButtonClicked += OnExitButtonClick;
        _startScreen.StartButtonClicked += OnStartButtonClick;
        _gameOverScreen.RestartButtonClicked += OnRestartButtonClisk;
        _gameOverScreen.ExitButtonClicked += OnExitButtonClick;
        _endGameScreen.ExitButtonClicked += OnExitButtonClick;
        _player.GameOver += OnGameOver;
        _spawner.GameEnded += OnGameEnd;
    }

    private void OnDisable()
    {
        _startScreen.ExitButtonClicked -= OnExitButtonClick;
        _startScreen.StartButtonClicked -= OnStartButtonClick;
        _gameOverScreen.RestartButtonClicked -= OnRestartButtonClisk;
        _gameOverScreen.ExitButtonClicked -= OnExitButtonClick;
        _endGameScreen.ExitButtonClicked -= OnExitButtonClick;
        _player.GameOver -= OnGameOver;
        _spawner.GameEnded -= OnGameEnd;
    }

    private void Start()
    {
        _startScreen.Open();
        Time.timeScale = 0;
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClisk()
    {
        _gameOverScreen.Close();
        _endGameScreen.Close();
        RestartGame();
    }
    
    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        _player.ResetPlayer();
        Time.timeScale = 1;
    }

    private void RestartGame()
    {
        _player.ResetPlayer();
        _spawner.ResetWaves();
        Time.timeScale = 1;
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }

    private void OnGameEnd()
    {
        _endGameScreen.Open();
        Time.timeScale = 0;
    }
}
