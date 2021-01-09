/* ==================================================================================
// Ball.cs: This script is attached to the prefabBall. The script defines the behavior of the ball including:
// 1. translating from place to place
// 2. spinning at the same location
// ==================================================================================		
// This material is meant for teaching/studying purposes only at Nanyang Technological University.		
// Author: Christopher Luwanga
// Nanyang Technological University
// ================================================================================== */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float _moveSpeed; //this is an exposed variable so be sure to initialize in inspector of object to which this script is attached
    public float _rotationSpeed; //this is an exposed variable which you can initialize in inspector (Unity)
    protected Rigidbody mRigidbody;

    protected string mVerticalAxisInputName = "Vertical";
    protected string mHorizontalAxisInputName = "Horizontal";
    protected float mVerticalInputValue = 0f;
    protected float mHorizontalInputValue = 0f;

    public bool _inputIsEnabled = true;

    public int _playerNum;

    // Awake is called right at the beginning if the object is active. Only run once in a lifetime
    private void Awake()
    {
        // Reference the component from the object. The component must be in the object for it to be referenced, else it will return null
        mRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Capture movement input
        MovementInput();
    }

    // Physics update. Update regardless of FPS
    void FixedUpdate()
    {
        Move();
        Spin();
    }

    // Record the value from the input dictionary
    protected void MovementInput()
    {
        mVerticalInputValue = Input.GetAxis(mVerticalAxisInputName + _playerNum );
        mHorizontalInputValue = Input.GetAxis(mHorizontalAxisInputName + _playerNum);
    }


    // Move the ball based on speed
    public void Move()
    {
        Vector3 moveVect = transform.forward * _moveSpeed * Time.deltaTime * mVerticalInputValue;
        mRigidbody.MovePosition(mRigidbody.position + moveVect);
    }

    // Spin the ball without changing its location. During game play mode, see inspector view-->Transform--> Rotation field to see the changes in angle.
    public void Spin()
    {
        float rotationDegree = _rotationSpeed * Time.deltaTime * mHorizontalInputValue;
        Quaternion rotQuat = Quaternion.Euler(0f, rotationDegree, 0f);
        mRigidbody.MoveRotation(mRigidbody.rotation * rotQuat);
    }

    public void Restart( Vector3 pos, Quaternion rot)
    {
        // Reset position, rotation
        transform.position = pos;
        transform.rotation = rot;
       

        // Activate the gameobject and input
        gameObject.SetActive(true);
        if(!_inputIsEnabled)
            _inputIsEnabled = true;

    }
}
