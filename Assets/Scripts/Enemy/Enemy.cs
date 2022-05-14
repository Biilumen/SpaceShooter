using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _minHeath;
    [SerializeField] private int _maxHeath;
    [SerializeField] private int _speed;
    [SerializeField] private ParticleSystem _explosion;

    private int _health;
    private float _reward;
    private Player _target;
    private Vector2 _waitAreaPoint;

    public int Speed => _speed;
    public Player Target => _target;
    public float Reward => _reward;
    public Vector2 WaitAreaPoint => _waitAreaPoint;

    public event UnityAction<Enemy> Diyng;

    public void Init(Player target, Vector2 waitAreaPoint)
    {
        _target = target;
        _waitAreaPoint = waitAreaPoint;
        SetHealth();
        SetReward();
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _explosion.gameObject.SetActive(true);
            _explosion.Play();
            Destroy(gameObject, 0.3f);
            
            Diyng?.Invoke(this);
        }
    }
    
    private void SetHealth()
    {
        _health = Random.Range(_minHeath, _maxHeath);
    }

    private void SetReward()
    {
        _reward = _health/2;
    }
}
