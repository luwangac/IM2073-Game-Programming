/* ==================================================================================
// BallManager.cs: This script is attached to the GameManager GameObject. The script
// 1. manages the Game States
// 2. declares the winner
// ==================================================================================		
// This material is meant for teaching/studying purposes only at Nanyang Technological University.		
// Author: Christopher Luwanga
// Nanyang Technological University
// ================================================================================== */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    //public GameObject destroyedVersion;
    public GameObject _spawnPointContainer;
    public GameObject _ballPrefab; //assigned via the inspector

    public delegate void OnOneBallLeft(Ball winner); //delegate is a function pointer. Points to an arbitrary function that takes type Ball as the input
    public OnOneBallLeft dOnOneBallLeft = null;


    protected Color[] mPlayerColors =
    {
        Color.blue,
        Color.red,
        Color.cyan,
    };
    protected int mPlayerCount;
    protected List<Ball> mBalls = new List<Ball>();
    //A note about declaring vs initializing
    // Here we are declaring AND initializing a list called mSpawnPoints. If we just have "protected List<Transform> mSpawnPoints" we would have declared a new variable
    //but we'd not be able to add anything to the list until we initialize it. Think of 'declaring' as letting the system know that we want space to store something of type X. And initializing may be thought of as 
    // putting into the reserved memory slot something of type X. 
    // You can see that until we actually put something of type X, it does not make sense to do anything with that variable.
    protected List<Transform> mSpawnPoints = new List<Transform>();

    private void Awake()
    {
        // Setup the spawn points from spawn parent
        Transform spawnTrans = _spawnPointContainer.transform;
        for (int i = 0; i < spawnTrans.childCount; i++)
        {
            mSpawnPoints.Add(spawnTrans.GetChild(i));

        }

        SpawnBalls ();
    }


    public void Restart()
    {
        foreach (Ball ball in mBalls)
        {
            Vector3 someVec = new Vector3(Random.Range(0, 2), 0.25f, Random.Range(0, 5));
            Quaternion someRotation = new Quaternion(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 10));
            int num = ball._playerNum;
            ball.Restart(mSpawnPoints[num].position, mSpawnPoints[num].rotation);
        }
        mPlayerCount = mBalls.Count;
    }

    // Spawn and setup their color
    public void SpawnBalls()
    {
        mPlayerCount = mSpawnPoints.Count;

        for (int i = 0; i < mPlayerCount; i++)
        {
            // Spawn ball and store it
            GameObject ball = Instantiate(_ballPrefab, mSpawnPoints[i].position, mSpawnPoints[i].rotation);
            mBalls.Add(ball.GetComponent<Ball>()); //get the ball script (it is a component attached to the prefab "prefabBall")
            mBalls[i]._playerNum = i;

            // Color Setup
            MeshRenderer[] renderers = mBalls[i].GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer rend in renderers)
                rend.material.color = mPlayerColors[i];
               
        }
    }

    public Transform[] GetBallsTransform()
    {
        int count = mBalls.Count;
        Transform[] ballsTrans = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            ballsTrans[i] = mBalls[i].transform;
        }

        return ballsTrans;
    }

    public int NumberOfPlayers
    {
        get { return mSpawnPoints.Count; }
    }
}
