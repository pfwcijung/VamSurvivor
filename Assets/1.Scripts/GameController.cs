using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public SpawnEnemy spawnEnemy;
    public Player player;
    public AttackArea attackArea;

    public float level = 0;
    public float enemyUpgrade = 1;

    public float playerLevel = 0;
    public float playerCurEXP = 0;
    public float playerMaxEXP = 100;

    public float gameTime;
    private float upgradeCount = 5;
    void Awake() => instance = this;

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= 10)
        {
            gameTime = 0;
            level++;
        }

        if(level >= upgradeCount)
        {
            upgradeCount *= 2;
            enemyUpgrade++;
        }

        if (playerCurEXP >= playerMaxEXP)
        {
            playerCurEXP = 0;
            playerLevel++;
            playerMaxEXP += playerMaxEXP;
        }
    }
}
