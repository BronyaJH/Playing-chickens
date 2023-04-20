using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private PlayerMovePosition _movePosition;
    private float _speedX;
    public Transform flipTransfrom;

    void Start()
    {
        _movePosition = GetComponent<PlayerMovePosition>();
    }

    void Update()
    {
        ReadInput();
    }

    /// <summary>
    /// FixedUpdate is called once per fixed interval
    /// This interval can be set by user
    /// the default value is 0.02
    /// the FixedUpdate is the Unity physics system's interval of calculating collisions
    /// </summary>
    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// read the input from keyboard to set the move parameters
    /// </summary>
    void ReadInput()
    {
        _speedX = 0;
        if (Input.GetKey(KeyCode.A))
            _speedX = _speedX - 1;
        if (Input.GetKey(KeyCode.D))
            _speedX = _speedX + 1;

        if (_speedX > 0)
            FlipRight();
        else if (_speedX < 0)
            FlipLeft();
    }

    /// <summary>
    /// Use the move parameters to move the player
    /// </summary>
    void Move()
    {
        _movePosition.AddMovement(Vector3.right * _speedX * speed);
    }

    void FlipRight()
    {
        flipTransfrom.localScale = new Vector3(1, 1, 1);
    }

    void FlipLeft()
    {
        flipTransfrom.localScale = new Vector3(-1, 1, 1);
    }
}