using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _score;
    private Vector3 _startPosition;

    public float Score => _score;

    public event UnityAction ScoreChange;
    public event UnityAction GameOver;

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void AplyDamage()
    {
        GameOver?.Invoke();
        gameObject.SetActive(false);
    }

    public void AddScore(float reward)
    {
        _score += reward;
        ScoreChange?.Invoke();
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChange?.Invoke();
        transform.position = _startPosition;
        gameObject.SetActive(true);
    }
}
