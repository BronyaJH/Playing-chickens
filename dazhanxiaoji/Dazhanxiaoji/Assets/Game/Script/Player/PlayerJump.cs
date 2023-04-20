using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    public float jumpPower = 10;

    private float _speedY;
    public PlayerGroundDetecter groundDetecter;
    private PlayerMovePosition _movePosition;
    private bool _isFloating { get { return !groundDetecter.isGrounded; } }
    private bool _isAttacking;
    private bool _isDead;
    public float gravity = 9;

    private void Start()
    {
        _movePosition = GetComponent<PlayerMovePosition>();
    }

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
        if (_speedY <= 0 && !_isFloating)
        {
            _speedY = 0;
            return;
        }

        _movePosition.AddMovement(Vector3.up * _speedY);
        _speedY -= gravity * Time.fixedDeltaTime;
    }

    public void OnGrounded()
    {
        _speedY = 0;
        _movePosition.Stop();
    }
}