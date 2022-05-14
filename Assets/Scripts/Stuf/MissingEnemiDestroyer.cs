using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingEnemiDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            Destroy(enemy.gameObject);
    }
}
