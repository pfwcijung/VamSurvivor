using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Spawn spawn;
    public UIImageData imageData;
    public Player player;
    public GameObject CameraObj;
    public GameObject BGMobj;

    //게임 난이도 상승
    [Header("#Game Level")]
    public float level = 0;
    public float enemyUpgrade = 1;
    private float upgradeCount = 5;

    //플레이어 관련
    [Header("#Player Stat")]
    public float setMaxHp = 0;
    public float upgradeHp = 10;
    public float setSpeed = 0;
    public float upgradeSpeed = 1;
    public float playerLevel = 0;
    public float playerCurEXP = 0;
    public float playerMaxEXP = 100;
    public float nextExp = 100;
    public float itemArea = 1f;
    public float upgradeItemArea = 1f;
    public bool magnetActive = false;
    float temp = 0;
    float timer = 0;
    public float killCount = 0;

    //게임 시간
    public float gameTime;


    [Header("#UI")]
    //UI 활성/비활성
    public bool isPause = false;
    public bool isLevelUp = false;
    public bool isGameEnd = false;
    public GameObject pauseUI;
    public GameObject levelUpUI;
    public GameObject GameOverUI;
    public GameObject GameClearUI;

    //무기 기본 정보
    [Header("#Weapon Info")]
    public float ThrowDamage;
    public float ThrowDelay;
    public float ShootingDamage;
    public float ShootingDelay;
    public float BoomDamage;

    //무기 레벨업/활성화 관련
    [Header("#Weapon LevelUp Info")]
    public float ThrowUpgradeDamage = 20;
    public float ThrowUpgradeDelay = 0.05f;
    public bool ThrowActive = false;
    public float ShootingUpgradeDamage = 10;
    public float ShootingUpgradeDelay = 0.025f;
    public bool ShootingActive = false;
    public float BoomUpgradeDamage = 50;
    public bool BoomActive = false;
    void Awake()
    {
        instance = this;

        //Bgm위치 설정을 위함
        CameraObj = GameObject.Find("Main Camera");

        //무기 기본 설정
        ThrowDamage = 20;
        ThrowDelay = 1f;
        ShootingDamage = 10;
        ShootingDelay = 0.5f;
        BoomDamage = 50;

        //플레이어 인포에서 받아 온 정보를 바탕으로 플레이어 스탯 설정, 무기 활성화
        switch (PlayerInfo.instance.Act)
        {
            case "Throw":
                setMaxHp = 150;
                setSpeed = 5;
                ThrowActive = true;
                break;
            case "Shoot":
                setMaxHp = 100;
                setSpeed = 3;
                ShootingActive = true;
                break;
            case "Boom":
                setMaxHp = 200;
                setSpeed = 4;
                BoomActive = true;
                break;
        }
    }


    void Update()
    {
        gameTime += Time.deltaTime;

        //20초마다 레벨 상승(새로운 적 등장)
        if (gameTime >= 20)
        {
            gameTime = 0;
            level++;
        }

        //5, 10, 15 단위로 적 스탯을 증가시키기 위함
        if(level >= upgradeCount)
        {
            upgradeCount *= 2;
            enemyUpgrade++;
        }

        //플레이어 레벨업
        if (playerCurEXP >= playerMaxEXP)
        {
            playerCurEXP = playerCurEXP - playerMaxEXP;
            playerLevel++;
            isLevelUp = true;
            CameraObj.GetComponent<AudioController>().PlayBGM("LevelUp");
            playerMaxEXP += nextExp;
        }

        //자석 아이템 먹었을 경우
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

        //Pause UI 활성/비활성
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

        //플레이어가 죽었을 경우(게임 오버) / 스테이지 60에 도달했을 경우(게임 클리어)
        if (!player.isLive || level >= 60)
        {
            isGameEnd = true;
            Time.timeScale = 0;
            BGMobj.SetActive(false);
        }
    }

    //플레이어의 기존 아이템 습득 범위 저장용
    void storeItemAreaData()
    {
        if (magnetActive)
            return;

        temp = itemArea;
    }

    //플레이어 업그레이드
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
                        ThrowDamage += ThrowUpgradeDamage;
                        ThrowDelay -= ThrowUpgradeDelay;
                    }
                    break;
                }
            case 1:
                {
                    if (!ShootingActive)
                        ShootingActive = true;
                    else
                    {
                        ShootingDamage += ShootingUpgradeDamage;
                        ShootingDelay -= ShootingUpgradeDelay;
                    }
                    break;
                }
            case 2:
                {
                    if (!BoomActive)
                        BoomActive = true;
                    else
                    {
                        BoomDamage += BoomDamage;
                    }
                    break;
                }
            case 3:
                {
                    itemArea += upgradeItemArea;                    
                    break;
                }
            case 4:
                {
                    player.speed += upgradeSpeed;
                    break;
                }
            case 5:
                {
                    player.maxHp += upgradeHp;
                    player.curHp += upgradeHp;
                    break;
                }
            default:
                break;
        }
    }
}
