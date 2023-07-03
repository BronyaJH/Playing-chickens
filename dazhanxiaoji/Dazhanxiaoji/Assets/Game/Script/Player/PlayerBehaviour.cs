using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance;

    private void Awake()
    {
        instance = this;
    }
}