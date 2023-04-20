using UnityEngine;
using System.Collections;

public class PlayerMovePosition : MonoBehaviour
{
    private CharacterController _cc;
    private Vector3 _movement;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _cc.Move(_movement * Time.fixedDeltaTime);
        Stop();
    }

    public void AddMovement(Vector3 mm)
    {
        _movement += mm;
    }

    public void Stop()
    {
        _movement = Vector3.zero;
    }
}
