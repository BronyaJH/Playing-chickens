using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rb;
    private float _speedX;
    public Transform flipTransfrom;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.A))
            _speedX = _speedX - 1;
        if (Input.GetKeyDown(KeyCode.D))
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
        var destination = transform.position + Vector3.right * _speedX * speed * Time.fixedDeltaTime;
        _rb.MovePosition(destination);
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