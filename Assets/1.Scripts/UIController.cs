using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public struct UpData
{
    public int dataType;
    public string dataName;
    public float dataDamage;
    public float dataDelay;
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
    [SerializeField] private Image upgradeImage_1;
    [SerializeField] private TMP_Text upgradeData_1;
    [SerializeField] private Image upgradeImage_2;
    [SerializeField] private TMP_Text upgradeData_2;
    [SerializeField] private Image upgradeImage_3;
    [SerializeField] private TMP_Text upgradeData_3;

    [Header("#Pause UI")]
    [SerializeField] private TMP_Text pauseInfo;
    [SerializeField] private TMP_Text playerInfo;
    [SerializeField] private TMP_Text weaponInfo;
    [SerializeField] private TMP_Text gameInfo;
    [SerializeField] private TMP_Text exitInfo;


    float sec = 0;
    float min = 0;

    void Start()
    {
        expImage.fillAmount = 0;
    }
    void Update()
    {
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
        level.text = string.Format($"Lv.{GameController.instance.playerLevel:00}");
        killcount.text = string.Format($"{GameController.instance.killCount:000}");

        if(GameController.instance.isPause == true)
        {
            GameController.instance.pauseUI.SetActive(true);

            PauseUI();
        }
        else
        {
            GameController.instance.pauseUI.SetActive(false);
        }

        if (GameController.instance.isLevelUp == true)
        {
            Time.timeScale = 0;
            GameController.instance.levelUpUI.SetActive(true);
        }
    }

    public void PauseUI()
    {
        pauseInfo.text = string.Format("�Ͻ� ����");
        playerInfo.text = string.Format
            ($"�÷��̾� ����\nü�� :: {GameController.instance.player.curHp}/{GameController.instance.player.maxHp}" +
            $"\n�ӵ� :: {GameController.instance.player.speed}m/s\n�ݱ� ���� :: {GameController.instance.player.speed}m");//�ݱ� ���� �ӽ�
        weaponInfo.text = string.Format($"����(�̸�) ���� {GameController.instance.playerLevel}");
        gameInfo.text = string.Format($"�÷��� �ð� :: {min:00}:{sec:00}\nų �� :: {GameController.instance.killCount}");
        exitInfo.text = string.Format("ESC�� ���� ����մϴ�.");
    }

    public void LevelupUI(int index)
    {
        switch (index)
        {
            case 0:
                
                break;
            default:
                break;
        }
    }

    public void onButtonClick_1()
    {
        Time.timeScale = 1;
        GameController.instance.isLevelUp = false;
        GameController.instance.levelUpUI.SetActive(false);
        
    }
    public void onButtonClick_2()
    {
        Time.timeScale = 1;
        GameController.instance.isLevelUp = false;
        GameController.instance.levelUpUI.SetActive(false);
    }
    public void onButtonClick_3()
    {
        Time.timeScale = 1;
        GameController.instance.isLevelUp = false;
        GameController.instance.levelUpUI.SetActive(false);
    }
}
