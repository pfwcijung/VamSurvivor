using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageData : MonoBehaviour
{
    public Sprite[] ImageDatas;
    List<Sprite>[] ImageList;
    void Start()
    {
        ImageList = new List<Sprite>[ImageDatas.Length];

        for (int i = 0; i < ImageDatas.Length; i++)
        {
            ImageList[i] = new List<Sprite>();
        }
    }

    //������ UI�� Image����
    public Sprite SetImageSpriteData(int index)
    {
        Sprite sp = ImageDatas[index];

        return sp;
    }

    //������ UI�� Text ����
    public string SetImageInfoText(int index)
    {
        string str = "";

        switch (index)
        {
            case 0:
                {
                    if (!GameController.instance.ThrowActive)
                    {
                        str = string.Format("�� ���⸦ Ȱ��ȭ�մϴ�");
                    }
                    else
                    {
                        str = string.Format($"���� �������� {GameController.instance.ThrowUpgradeDamage}�ø��� �߻�ӵ��� ������ŵ�ϴ�");
                    }
                    break;
                }
            case 1:
                {
                    if (!GameController.instance.ShootingActive)
                    {
                        str = string.Format("�Ѿ� ���⸦ Ȱ��ȭ �մϴ�");
                    }
                    else
                    {
                        str = string.Format($"�Ѿ��� �������� {GameController.instance.ShootingUpgradeDamage}�ø��� �߻�ӵ��� ������ŵ�ϴ�");
                    }
                    break;
                }
            case 2:
                {
                    if (!GameController.instance.BoomActive)
                    {
                        str = string.Format("��ź ���⸦ Ȱ��ȭ �մϴ�");
                    }
                    else
                    {
                        str = string.Format($"��ź�� �������� {GameController.instance.BoomUpgradeDamage}�ø��ϴ�");
                    }
                    break;
                }
            case 3:
                {
                    str = string.Format($"������ ȹ�� ������ {GameController.instance.upgradeItemArea}�����մϴ�.");
                    break;
                }
            case 4:
                {
                    str = string.Format($"�̵� �ӵ��� {GameController.instance.upgradeSpeed}�����մϴ�");
                    break;
                }
            case 5:
                {
                    str = string.Format($"�ִ� ü���� {GameController.instance.upgradeHp} �����մϴ�");
                    break;
                }
            default:
                break;
        }

        return str;
    }
}
