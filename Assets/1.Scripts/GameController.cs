using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public SpawnEnemy spawnEnemy;
    public Player player;

    public float level;
    public float upgrade = 1;

    public float gameTime;
    private float upgradeCount = 5;
    void Awake() => instance = this;

    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= 5)
        {
            gameTime = 0;
            level++;
        }
        if(level >= upgradeCount)
        {
            upgradeCount *= 2;
            upgrade++;
        }
    }
}
