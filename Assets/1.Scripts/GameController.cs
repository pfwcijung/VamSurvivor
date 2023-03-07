using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public SpawnEnemy spawnEnemy;
    public SpawnWeapon spawnWeapon;
    public SpawnItem spawnItem;
    public Player player;

    public float level = 0;
    public float enemyUpgrade = 1;

    public float playerLevel = 0;
    public float playerCurEXP = 0;
    public float playerMaxEXP = 100;

    public float killCount = 0;

    public float gameTime;
    private float upgradeCount = 5;

    public bool isPause = false;
    public bool isLevelUp = false;
    public GameObject pauseUI;
    public GameObject levelUpUI;
    void Awake() => instance = this;

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= 20)
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
            playerCurEXP = playerCurEXP - playerMaxEXP;
            playerLevel++;
            isLevelUp = true;
            playerMaxEXP += (playerMaxEXP / 2);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            isPause = false;
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            isPause = true;
            Time.timeScale = 0;
        }
    }
}
