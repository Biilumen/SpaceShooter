using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _player.ScoreChange += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChange -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _scoreText.text = ($"Score: {_player.Score}");
    }
}
