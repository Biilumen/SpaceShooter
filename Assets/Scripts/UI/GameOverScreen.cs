using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : UIScreen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    public event UnityAction RestartButtonClicked;
    public event UnityAction ExitButtonClicked;

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
    }

    public void OnRestartButtonClicked()
    {
        RestartButtonClicked?.Invoke();
    }

    public void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }
}
