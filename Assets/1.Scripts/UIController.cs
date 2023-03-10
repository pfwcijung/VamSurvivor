using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public struct UpData
{
    public int dataType;
    public string dataName;
    public float dataDamage;
    public float dataDelay;
}

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
    [SerializeField] private List<Button> upgradeButton = new List<Button>();

    [Header("#Pause UI")]
    [SerializeField] private TMP_Text pauseInfo;
    [SerializeField] private TMP_Text playerInfo;
    [SerializeField] private TMP_Text weaponInfo;
    [SerializeField] private TMP_Text exitInfo;


    float sec = 0;
    float min = 0;

    List<int> temps = new List<int>();

    void Start()
    {
        expImage.fillAmount = 0;
    }
    void Update()
    {
        if (GameController.instance.isGameEnd)
        {
            if (GameController.instance.player.isLive)
                GameController.instance.GameClearUI.SetActive(true);
            else
                GameController.instance.GameOverUI.SetActive(true);
        }

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

        hpImage.fillAmount = GameController.instance.player.curHp / GameController.instance.player.maxHp;
        expImage.fillAmount = GameController.instance.playerCurEXP / GameController.instance.playerMaxEXP;

        time.text = string.Format($"{min:00}:{sec:00}");
        level.text = string.Format($"Lv.{GameController.instance.level:00}");
        killcount.text = string.Format($"{GameController.instance.killCount:000}");

        if(GameController.instance.isPause)
        {
            GameController.instance.pauseUI.SetActive(true);

            PauseUI();
        }
        else
        {
            GameController.instance.pauseUI.SetActive(false);
        }

        if (GameController.instance.isLevelUp)
        {
            Time.timeScale = 0;
            SetLevelupUI();
            GameController.instance.levelUpUI.SetActive(true);
            GameController.instance.isLevelUp = false;
        }
        
    }
    public void SetLevelupUI()
    {
        List<int> temp = new List<int>();

        for (int i = 0; i < GameController.instance.imageData.ImageDatas.Length; i++)
        {
            temp.Add(i);
        }

        for (int i = temp.Count - 1; i >= 0; i--)
        {
            int rand = Random.Range(0, temp.Count);
            temps.Add(temp[rand]);

            if (temps.Count >= 3)
                break;

            temp.RemoveAt(temp[rand]);
        }

        for (int i = 0; i < 3; i++)
        {
            Debug.Log(temps[i]);
        }
        for (int i = 0; i < 3; i++)
        {
            LevelupUI(i, temps[i]);
        }

    }

    public void PauseUI()
    {
        pauseInfo.text = string.Format("일시 정지");
        playerInfo.text = string.Format
            ($"플레이어 정보\n체력 :: {GameController.instance.player.curHp}/{GameController.instance.player.maxHp}" +
            $"\n속도 :: {GameController.instance.player.speed}m/s\n줍기 범위 :: {GameController.instance.itemArea}m");
        weaponInfo.text = string.Format
            ($"삽 레벨 :: {(GameController.instance.ThrowDamage / 20) - 1}\n" +
            $"총알 레벨 :: {(GameController.instance.ShootingDamage / 10) -1 }\n" +
            $"폭탄 레벨 :: {(GameController.instance.BoomDamage / 50) - 1}");
        exitInfo.text = string.Format("ESC를 눌러 계속합니다.");
    }

    public void LevelupUI(int i, int index)
    {
        Sprite sprite = GameController.instance.imageData.SetImageSpriteData(index);
        string str = GameController.instance.imageData.SetImageInfoText(index);

        upgradeImage[i].sprite = sprite;
        upgradeText[i].text = str;

        switch (i)
        {
            case 0:
                onButtonClick_1(index);
                break;
            case 1:
                onButtonClick_2(index);
                break;
            case 2:
                onButtonClick_3(index);
                break;
        }
    }

    public void onButtonClick_1(int index)
    {
        Time.timeScale = 1;
        GameController.instance.UpgradePlayer(index);
        GameController.instance.levelUpUI.SetActive(false);
        temps.RemoveRange(0, temps.Count);

    }
    public void onButtonClick_2(int index)
    {
        Time.timeScale = 1;
        GameController.instance.UpgradePlayer(index);
        GameController.instance.levelUpUI.SetActive(false);
        temps.RemoveRange(0, temps.Count);
    }
    public void onButtonClick_3(int index)
    {
        Time.timeScale = 1;
        GameController.instance.UpgradePlayer(index);
        GameController.instance.levelUpUI.SetActive(false);
        temps.RemoveRange(0, temps.Count);
    }
}
