using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image hpImage;
    [SerializeField] private Image expImage;
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text level;
    [SerializeField] private TMP_Text killcount;

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
    }
}
