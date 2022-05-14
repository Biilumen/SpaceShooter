using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : UIScreen
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    public event UnityAction StartButtonClicked;
    public event UnityAction ExitButtonClicked;

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
    }
    public void OnStartButtonClicked()
    {
        StartButtonClicked?.Invoke();
    }
    public void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }
}
