using DGMKCollections.Score;
using DGMKCollections.Patterns.Singleton;
using UnityEngine;
using DGMKCollections.Timer;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private Score _score;
    [SerializeField]
    private Timer _timer;

    void OnEnable() 
    {
        _score.MaxScoreReached += GameOver;
    }

    void OnDisable()
    {
        _score.MaxScoreReached -= GameOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //Colocamos al player en la posición inicial

        //Reseteamos Timers
        _timer.ResetTimer();
        //Reseteamos Score
        _score.ResetScore();
        //Reseteamos Coins
        
        //Empezamos el juego despues de la cuenta atrás.

        //Activamos inputs
    }

    public void GameOver()
    {
        //Desactivamos Inputs
        Debug.Log("GAME OVER");
        //Paramos el juego y aviso al jugador
        _timer.PauseTimer();
        //Terminamos el juego
    }
}
