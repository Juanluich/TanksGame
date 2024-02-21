using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    [SerializeField] PlayerTurn _Player1;
    [SerializeField] EnemyTurn _Player2;

    void Start()
    {
        state = BattleState.PLAYERTURN;
        SetPlayerTurn();
    }


    private void Update()
    {
        switch (state)
        {
            case BattleState.START:
                break;
            case BattleState.PLAYERTURN:
                SetPlayerTurn();
                break;
            case BattleState.ENEMYTURN:
                SetEnemyTurn();
                break;
            case BattleState.WON:
                break;
            case BattleState.LOST:
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

    }

    void SetGameOver()
    {

    }
    
}