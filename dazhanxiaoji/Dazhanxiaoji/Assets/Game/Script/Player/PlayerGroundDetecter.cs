using UnityEngine;
using System.Collections.Generic;

public class PlayerGroundDetecter : MonoBehaviour
{
    public bool isGrounded;
    public List<GameObject> toIgnores;
    public PlayerJump jump;

    List<GameObject> _currentGrounds= new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (toIgnores.Contains(collision.gameObject))
            return;
       // Debug.Log("OnCollisionEnter2D " + collision.gameObject);
        if (!_currentGrounds.Contains(collision.gameObject))
            _currentGrounds.Add(collision.gameObject);
        isGrounded = _currentGrounds.Count > 0;
        jump.OnGrounded();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (toIgnores.Contains(collision.gameObject))
            return;
       // Debug.Log("OnCollisionExit2D " + collision.gameObject);
        if (_currentGrounds.Contains(collision.gameObject))
            _currentGrounds.Remove(collision.gameObject);
        isGrounded = _currentGrounds.Count > 0;
    }
}
