using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanetionTransition : Transition 
{ 
    private void Update()
    {
        if(transform.position.x == Enemy.WaitAreaPoint.x)
            NeedTransit = true;   
    }
}
