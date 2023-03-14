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
        //���� ����, ���� Ŭ��� ���� UI, Bgm ����
        if (GameController.instance.isGameEnd)
        {
            GameEnd();
        }

        //�÷��̾� ���
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
        
        //Pause UI Ȱ�� / ��Ȱ��ȭ
        if(GameController.instance.isPause)
        {
            GameController.instance.pauseUI.SetActive(true);

            PauseUI();
        }
        else
        {
            GameController.instance.pauseUI.SetActive(false);
        }

        //������ UI Ȱ��ȭ
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
        //�÷��̾� Hp UI
        hpImage.fillAmount = GameController.instance.player.curHp / GameController.instance.player.maxHp;
        //�÷��̾� Exp UI
        expImage.fillAmount = GameController.instance.playerCurEXP / GameController.instance.playerMaxEXP;
        //���� ���� �ð� UI
        time.text = string.Format($"{min:00}:{sec:00}");
        //���� ���̵� UI
        level.text = string.Format($"Stage:{GameController.instance.level:00}");
        //���� �� �� UI
        killcount.text = string.Format($"{GameController.instance.killCount:000}");

    }
    public void SetLevelupUI()
    {
        Time.timeScale = 0;

        //�ߺ� ���� temps�� ���� �� ���� ����
        List<int> temp = new List<int>();
        
        for (int i = 0; i < GameController.instance.imageData.ImageDatas.Length; i++)
        {
            temp.Add(i);
        }

        //temps�� ���� temp���� �����Ͽ� �ߺ��� ����
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
        pauseInfo.text = string.Format("�Ͻ� ����");
        playerInfo.text = string.Format
            ($"�÷��̾� ����\nü�� :: {GameController.instance.player.curHp}/{GameController.instance.player.maxHp}" +
            $"\n�ӵ� :: {GameController.instance.player.speed}m/s\n�ݱ� ���� :: {GameController.instance.itemArea}m");
        weaponInfo.text = string.Format
            ($"�� ���� :: {weapon1}\n" +
            $"�Ѿ� ���� :: {weapon2}\n" +
            $"��ź ���� :: {weapon3}");
        exitInfo.text = string.Format("ESC�� ���� ����մϴ�.");
    }

    public void SetWeaponInfoText()
    {
        //���� Ȱ�� / ��Ȱ���� ���� ���� ���� ����
        if (GameController.instance.ThrowActive)
            weapon1 = string.Format($"{GameController.instance.ThrowDamage / GameController.instance.ThrowUpgradeDamage}");
        else
            weapon1 = "��Ȱ��ȭ";

        if (GameController.instance.ShootingActive)
            weapon2 = string.Format($"{GameController.instance.ShootingDamage / GameController.instance.ShootingUpgradeDamage}");
        else
            weapon2 = "��Ȱ��ȭ";

        if (GameController.instance.BoomActive)
            weapon3 = string.Format($"{GameController.instance.BoomDamage / GameController.instance.BoomUpgradeDamage}");
        else
            weapon3 = "��Ȱ��ȭ";

    }

    public void LevelupUI(int i, int index)
    {
        Sprite sprite = GameController.instance.imageData.SetImageSpriteData(index);
        string str = GameController.instance.imageData.SetImageInfoText(index);

        upgradeImage[i].sprite = sprite;
        upgradeText[i].text = str;
    }
    //��ư Ŭ���ϸ� �ٽ� ������ ����Ǹ� �־��� �����͸�ŭ �÷��̾� ���� ���
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
