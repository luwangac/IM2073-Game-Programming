
/* ==================================================================================
// GameManager.cs: This script is attached to the GameManager GameObject. The script
// 1. manages the Game States
// 2. declares the winner
// ==================================================================================		
// This material is meant for teaching/studying purposes only at Nanyang Technological University.		
// Author: Christopher Luwanga
// Nanyang Technological University. 2019.12
// ================================================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallManager _ballManager;
    public GameObject playGround;
    private int[] mWinHistory;
    public enum State
    {
        GameLoads = 0,
        GamePrep,
        GameLoop,
        GameEnds
    };
    private State mState = State.GameLoads;

    private void Start()
    {
        playGround = GameObject.FindGameObjectWithTag("playGround");
        mWinHistory = new int[_ballManager.NumberOfPlayers];
        _ballManager.dOnOneBallLeft = OnLastBall; //we want the pointer to point to OnLastBall. You could make it point to any function that accepts type Ball as argument.
        //but you cannot, for example, make it point to InitGamePrep.
        state = State.GamePrep;
    }

    public void OnLastBall(Ball winner)
    {
        if (state == State.GameLoop)
        {
            // Record wins
            int winnerPlayerNum = winner._playerNum;
            mWinHistory[winnerPlayerNum]++;

            // End the round
            state = State.GameEnds;
        }
    }

    private void InitGamePrep()
    {
        // Initialize all balls
        _ballManager.Restart();

        // Change state to game loop
        state = State.GameLoop;
    }
    private bool FellOff(Ball lost)
    {
        if (lost.transform.position.y < 0)
        {
            return true;
        }
            

        return false;
    }
    private IEnumerator InitGameEnd()
    {
        // Delay before starting a new round
        yield return new WaitForSeconds(3f);

        // Reinitialize balls


        state = State.GamePrep;
    }

    public State state
    {
        get { return mState; }
        set
        {
            if(mState != value)
            {
                mState = value;

                switch (value)
                {
                    case State.GamePrep:
                        InitGamePrep();
                        break;

                    case State.GameLoop:
                        break;

                    case State.GameEnds:
                        StartCoroutine(InitGameEnd());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
