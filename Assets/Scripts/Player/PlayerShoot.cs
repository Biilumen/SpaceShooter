using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var deley = new WaitForSeconds(_delay);

        while (true)
        {
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            yield return deley;
        }
    }
}
