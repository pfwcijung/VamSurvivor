using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public SpawnEnemy spawnEnemy;
    public SpawnWeapon spawnWeapon;
    public SpawnItem spawnItem;
    public UIImageData imageData;
    public Player player;

    //게임 난이도 상승
    public float level = 0;
    public float enemyUpgrade = 1;
    private float upgradeCount = 5;

    //플레이어 관련
    public float setMaxHp = 0;
    public float setSpeed = 0;
    public float playerLevel = 0;
    public float playerCurEXP = 0;
    public float playerMaxEXP = 100;
    public float itemArea = 1f;
    public bool magnetActive = false;
    float temp = 0;
    float timer = 0;
    public float killCount = 0;

    //게임 시간
    public float gameTime;

    //UI 활성/비활성
    public bool isPause = false;
    public bool isLevelUp = false;
    public bool isGameEnd = false;
    public GameObject pauseUI;
    public GameObject levelUpUI;
    public GameObject GameOverUI;
    public GameObject GameClearUI;

    //무기 레벨업/활성화 관련
    public float ThrowDamage = 0;
    public float ThrowDelay = 0;
    public bool ThrowActive = false;
    public float ShootingDamage = 0;
    public float ShootingDelay = 0;
    public bool ShootingActive = false;
    public float BoomDamage = 0;
    public bool BoomActive = false;
    void Awake()
    {
        instance = this;

        switch (PlayerInfo.instance.Act)
        {
            case "Throw":
                setMaxHp = 100;
                setSpeed = 3;
                ThrowActive = true;
                break;
            case "Shoot":
                setMaxHp = 100;
                setSpeed = 3;
                ShootingActive = true;
                break;
            case "Boom":
                setMaxHp = 100;
                setSpeed = 3;
                BoomActive = true;
                break;
        }
    }


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

        if (magnetActive)
        {
            timer += Time.deltaTime;
            itemArea = 10f;

            if (timer > 1f)
            {
                itemArea = temp;
                magnetActive = false;
                timer = 0;
            }
        }
        else
            storeItemAreaData();

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

        if (!player.isLive || level >= 60)
        {
            isGameEnd = true;
            Time.timeScale = 0;
        }
    }

    void storeItemAreaData()
    {
        if (magnetActive)
            return;

        temp = itemArea;
    }

    public void UpgradePlayer(int index)
    {
        switch (index)
        {
            case 0:
                {
                    if (!ThrowActive)
                        ThrowActive = true;
                    else
                    {
                        ThrowDamage += 20f;
                        ThrowDelay += 0.05f;
                    }
                    break;
                }
            case 1:
                {
                    if (!ShootingActive)
                        ShootingActive = true;
                    else
                    {
                        ShootingDamage += 10f;
                        ShootingDelay += 0.02f;
                    }
                    break;
                }
            case 2:
                {
                    if (!BoomActive)
                        BoomActive = true;
                    else
                    {
                        BoomDamage += 50f;
                    }
                    break;
                }
            default:
                break;
        }
    }
}
