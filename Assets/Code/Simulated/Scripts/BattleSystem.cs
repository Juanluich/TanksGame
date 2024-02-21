using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    [SerializeField] PlayerTurn _Player1;
    [SerializeField] EnemyTurn _Player2;

    [SerializeField] PlayerHealth _PlayerHealth1;
    [SerializeField] PlayerHealth _PlayerHealth2;

    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;

    void Start()
    {
        state = BattleState.PLAYERTURN;
        SetPlayerTurn();
    }


    private void Update()
    {
        if(_PlayerHealth1.currentHealth <= 0) { state = BattleState.LOST;}
        if(_PlayerHealth2.currentHealth <= 0) { state = BattleState.WON;}

        switch (state)
        {
            case BattleState.START:
                // Tutorial stuff
                break;
            case BattleState.PLAYERTURN:
                SetPlayerTurn();
                break;
            case BattleState.ENEMYTURN:
                SetEnemyTurn();
                break;
            case BattleState.WON:
                SetWon();
                break;
            case BattleState.LOST:
                SetGameOver();
                break;
        }
    }
    void SetPlayerTurn()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        _Player1.MovementTurn();

        if (_Player1.turnEnded) 
        { 
            state = BattleState.ENEMYTURN; 
            _Player1.DisableFunctionality();
        }
    }

    void SetEnemyTurn()
    {
        if (state != BattleState.ENEMYTURN)
            return;
        _Player2.MovementTurn();

        if (_Player2.turnEnded) 
        { 
            state = BattleState.PLAYERTURN; 
            _Player2.DisableFunctionality();
        }
    }

    void SetWon()
    {
        WinPanel.SetActive(true);
        _Player1.DisableFunctionality();
        _Player2.DisableFunctionality();
    }

    void SetGameOver()
    {
        LosePanel.SetActive(true);
        _Player1.DisableFunctionality();
        _Player2.DisableFunctionality();
    }
    
}