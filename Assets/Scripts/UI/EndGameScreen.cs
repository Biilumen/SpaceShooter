using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndGameScreen : UIScreen
{
    [SerializeField] private Button _exitButton;

    public event UnityAction ExitButtonClicked;

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
    }
   
    public void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }

}
