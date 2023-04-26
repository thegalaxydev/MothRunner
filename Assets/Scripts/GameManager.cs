using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject Player;
    public static int Score;

    [SerializeField]
    private GameObject _playerReference;

    void Awake()
    {
        Player = _playerReference;
    }
}
