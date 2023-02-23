using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public SpawnEnemy spawnEnemy;
    public Player player;

    void Awake() => instance = this;
}
