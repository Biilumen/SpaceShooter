using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class PlayZoneHight : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private float _fullsize = 2f;

    private void Start()
    {
        SetSize();
    }
    private void SetSize()
    {
        float yScale = _camera.ScreenToWorldPoint(Screen.safeArea.max).y * _fullsize;
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D> ();
        boxCollider.size = new Vector2(boxCollider.size.x, yScale);
    }
}
