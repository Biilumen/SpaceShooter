using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delay;

    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_delay < _time )
        {
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            _time = 0;
        }
    }
}
