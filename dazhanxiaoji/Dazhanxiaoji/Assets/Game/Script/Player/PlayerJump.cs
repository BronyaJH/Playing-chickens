using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    public float jumpPower = 10;
    private Rigidbody2D _rb;
    private float _speedY;

    private bool _isFloating;
    private bool _isAttacking;
    private bool _isDead;
    public float gravity = 9;

    void Update()
    {
        ReadInput();
    }

    void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TryJump();
    }

    void TryJump()
    {
        if (canNotJump)
            return;

        DoJump();
    }

    bool canNotJump { get { return _isFloating || _isAttacking || _isDead; } }

    void DoJump()
    {
        _speedY = jumpPower;
    }

    private void FixedUpdate()
    {
        var destination = transform.position + Vector3.up * _speedY * Time.fixedDeltaTime;
        _rb.MovePosition(destination);

        _speedY -= gravity * Time.fixedDeltaTime;
    }
}