using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] TMP_Text _scoreText;

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
