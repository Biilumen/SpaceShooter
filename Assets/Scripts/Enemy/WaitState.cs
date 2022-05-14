using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State
{
    [SerializeField] private float _maxWaitTime;

    private float _pastTime;
    private float _waitTime;

    public float WaitTime => _waitTime;
    public float PastTime => _pastTime;

    private void Start()
    {
        _waitTime = Random.Range(0, _maxWaitTime);
    }

    private void Update()
    {
        _pastTime += Time.deltaTime;
    }
}