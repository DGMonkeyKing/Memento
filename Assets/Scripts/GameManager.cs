using DGMKCollections.Score;
using DGMKCollections.Patterns.Singleton;
using UnityEngine;
using DGMKCollections.Timer;
using System;
using System.Collections;
using DGMKCollections.Memento.UI;

public class GameManager : Singleton<GameManager>
{    
    [Header("Game manage references.")]
    [SerializeField]
    private Mementer _mementer;

    [SerializeField]
    private Score _score;
    [SerializeField]
    private Timer _timer;

    [SerializeField]
    private InitialPanel _canvasRanking;
    [SerializeField]
    private PutNamePanel _canvasName;


    void OnEnable() 
    {
        _score.MaxScoreReached += GameOver;
        _canvasRanking.OnEnterPressed += StartGame;
        _canvasName.OnEnterPressed += ShowRanking;
        _canvasName.NameInput += SaveName;
    }

    void OnDisable()
    {
        _score.MaxScoreReached -= GameOver;
        _canvasRanking.OnEnterPressed -= StartGame;
        _canvasName.OnEnterPressed -= ShowRanking;
        _canvasName.NameInput -= SaveName;
    }

    private void ResetScene()
    {
        DeactivateInputs();
        _timer.StopTimer();
    }

    private void DeactivateInputs()
    {
        
    }

    void Start()
    {
        //Estado inicial. Mostramos ranking y reseteamos scena
        ShowRanking();
        ResetScene();
    }

    public void StartGame()
    {
        //Desactivamos canvases
        _canvasRanking.Deactivate();
        _canvasName.Deactivate();

        //Colocamos al player en la posición inicial
        _mementer.Reset();
        //Reseteamos Timers
        _timer.StopTimer();
        //Reseteamos Score
        _score.ResetScore();

        //Empezamos el juego despues de la cuenta atrás.
        StartCoroutine(CountdownToPlay());
    }

    IEnumerator CountdownToPlay()
    {
        _mementer.EnableInputs();
        _timer.StartTimer();
        
        yield return 0;
    }

    public void SaveName(string name)
    {
        _canvasRanking.ChangeRanking(name, _timer.MillisecondsCount);
    }

    public void ShowRanking()
    {
        _canvasRanking.Activate();
        _canvasName.Deactivate();
    }
    public void ShowPutName()
    {
        _canvasRanking.Deactivate();
        _canvasName.Activate();
    }

    public void GameOver()
    {
        //Desactivamos Inputs
        _mementer.DisableInputs();
        //Paramos el juego y aviso al jugador
        _timer.PauseTimer();
        //Terminamos el juego
        if(_canvasRanking.CheckPosition(_timer.MillisecondsCount) >= 0)
        {
            ShowPutName();
        }
        else
        {
            ShowRanking();
        }
    }
}
