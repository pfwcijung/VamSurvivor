using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public struct LevelImage
{
    public Image Image;
    public TMP_Text text;
}

public class UIController : MonoBehaviour
{
    [Header("#Base UI")]
    [SerializeField] private Image hpImage;
    [SerializeField] private Image expImage;
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text level;
    [SerializeField] private TMP_Text killcount;

    [Header("#LevelUp UI")]
    [SerializeField] private List<Image> upgradeImage = new List<Image>();
    [SerializeField] private List<TMP_Text> upgradeText = new List<TMP_Text>();
    List<int> temps = new List<int>();

    [Header("#Pause UI")]
    [SerializeField] private TMP_Text pauseInfo;
    [SerializeField] private TMP_Text playerInfo;
    [SerializeField] private TMP_Text weaponInfo;
    [SerializeField] private TMP_Text exitInfo;


    float sec = 0;
    float min = 0;


    void Start()
    {
        expImage.fillAmount = 0;
    }
    void Update()
    {
        //게임 오버, 게임 클리어에 따른 UI, Bgm 설정
        if (GameController.instance.isGameEnd)
        {
            GameEnd();
        }

        //플레이어 사망
        if (!GameController.instance.player.isLive)
        {
            hpImage.enabled = false;
            return;
        }

        sec += Time.deltaTime;
        if (sec > 59)
        {
            sec = 0;
            min++;
        }

        BaseUI();
        
        //Pause UI 활성 / 비활성화
        if(GameController.instance.isPause)
        {
            GameController.instance.pauseUI.SetActive(true);

            PauseUI();
        }
        else
        {
            GameController.instance.pauseUI.SetActive(false);
        }

        //레벨업 UI 활성화
        if (GameController.instance.isLevelUp)
        {
            SetLevelupUI();
            GameController.instance.levelUpUI.SetActive(true);
            GameController.instance.isLevelUp = false;
        }
        
    }

    void GameEnd()
    {
        if (GameController.instance.player.isLive)
        {
            GameController.instance.CameraObj.GetComponent<AudioController>().PlayBGM("Clear");
            GameController.instance.GameClearUI.SetActive(true);
        }
        else
        {
            GameController.instance.CameraObj.GetComponent<AudioController>().PlayBGM("Over");
            GameController.instance.GameOverUI.SetActive(true);
        }
    }

    void BaseUI()
    {
        //플레이어 Hp UI
        hpImage.fillAmount = GameController.instance.player.curHp / GameController.instance.player.maxHp;
        //플레이어 Exp UI
        expImage.fillAmount = GameController.instance.playerCurEXP / GameController.instance.playerMaxEXP;
        //게임 진행 시간 UI
        time.text = string.Format($"{min:00}:{sec:00}");
        //게임 난이도 UI
        level.text = string.Format($"Stage:{GameController.instance.level:00}");
        //죽은 적 수 UI
        killcount.text = string.Format($"{GameController.instance.killCount:000}");

    }
    public void SetLevelupUI()
    {
        Time.timeScale = 0;

        //중복 값이 temps에 들어가는 것 방지 위함
        List<int> temp = new List<int>();
        
        for (int i = 0; i < GameController.instance.imageData.ImageDatas.Length; i++)
        {
            temp.Add(i);
        }

        //temps에 넣은 temp값을 삭제하여 중복을 방지
        for (int i = temp.Count - 1; i >= 0; i--)
        {
            int rand = Random.Range(0, temp.Count);
            temps.Add(temp[rand]);

            if (temps.Count >= 3)
                break;

            temp.Remove(temp[rand]);
        }
        for (int i = 0; i < 3; i++)
        {
            LevelupUI(i, temps[i]);
        }

    }
    string weapon1, weapon2, weapon3;
    public void PauseUI()
    {
        SetWeaponInfoText();
        pauseInfo.text = string.Format("일시 정지");
        playerInfo.text = string.Format
            ($"플레이어 정보\n체력 :: {GameController.instance.player.curHp}/{GameController.instance.player.maxHp}" +
            $"\n속도 :: {GameController.instance.player.speed}m/s\n줍기 범위 :: {GameController.instance.itemArea}m");
        weaponInfo.text = string.Format
            ($"삽 레벨 :: {weapon1}\n" +
            $"총알 레벨 :: {weapon2}\n" +
            $"폭탄 레벨 :: {weapon3}");
        exitInfo.text = string.Format("ESC를 눌러 계속합니다.");
    }

    public void SetWeaponInfoText()
    {
        //무기 활성 / 비활성에 따라 무기 정보 제공
        if (GameController.instance.ThrowActive)
            weapon1 = string.Format($"{GameController.instance.ThrowDamage / GameController.instance.ThrowUpgradeDamage}");
        else
            weapon1 = "비활성화";

        if (GameController.instance.ShootingActive)
            weapon2 = string.Format($"{GameController.instance.ShootingDamage / GameController.instance.ShootingUpgradeDamage}");
        else
            weapon2 = "비활성화";

        if (GameController.instance.BoomActive)
            weapon3 = string.Format($"{GameController.instance.BoomDamage / GameController.instance.BoomUpgradeDamage}");
        else
            weapon3 = "비활성화";

    }

    public void LevelupUI(int i, int index)
    {
        Sprite sprite = GameController.instance.imageData.SetImageSpriteData(index);
        string str = GameController.instance.imageData.SetImageInfoText(index);

        upgradeImage[i].sprite = sprite;
        upgradeText[i].text = str;
    }
    //버튼 클릭하면 다시 게임이 진행되며 넣어진 데이터만큼 플레이어 스탯 상승
    public void onButtonClick_1()
    {
        Time.timeScale = 1;
        GameController.instance.UpgradePlayer(temps[0]);
        GameController.instance.levelUpUI.SetActive(false);
        GameController.instance.CameraObj.GetComponent<AudioController>().PlayBGM("Base");
        temps.Clear();
    }
    public void onButtonClick_2()
    {
        Time.timeScale = 1;
        GameController.instance.UpgradePlayer(temps[1]);
        GameController.instance.levelUpUI.SetActive(false);
        GameController.instance.CameraObj.GetComponent<AudioController>().PlayBGM("Base");
        temps.Clear();
    }
    public void onButtonClick_3()
    {
        Time.timeScale = 1;
        GameController.instance.UpgradePlayer(temps[2]);
        GameController.instance.levelUpUI.SetActive(false);
        GameController.instance.CameraObj.GetComponent<AudioController>().PlayBGM("Base");
        temps.Clear();
    }
}
