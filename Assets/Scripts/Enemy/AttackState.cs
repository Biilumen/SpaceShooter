using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _distanceScale;
    [SerializeField] private int _speedScale;
    private Vector2 _targetPosition;  
   
    void Start()
    {
        _targetPosition = Target.transform.position;
    }

    private void Update()
    {
        transform.Translate(_targetPosition * Enemy.Speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            player.AplyDamage();
    }
}
