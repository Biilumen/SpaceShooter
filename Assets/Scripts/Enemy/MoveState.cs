using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Enemy.WaitAreaPoint , Enemy.Speed * Time.deltaTime);
    }
}
