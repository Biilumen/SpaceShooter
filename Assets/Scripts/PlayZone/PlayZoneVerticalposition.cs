using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZoneVerticalposition : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private bool _inUp;

    private void Start()
    {
        SetPosition();    
    }

    private void SetPosition()
    {
        Vector2 safeAreaPosition = _inUp ? Screen.safeArea .max : Screen.safeArea .min;
        float yPosition = _camera.ScreenToWorldPoint(safeAreaPosition).y;
        transform.position = new Vector2 (transform.position.x, yPosition);
    }
}
