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

    public Sprite SetImageSpriteData(int index)
    {
        Sprite sp = ImageDatas[index];

        return sp;
    }

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
                        str = string.Format($"���� �������� {0:0}�ø��� �߻�ӵ��� ������ŵ�ϴ�", GameController.instance.ThrowUpgradeDamage);
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
                        str = string.Format($"�Ѿ��� �������� {0:0}�ø��� �߻�ӵ��� ������ŵ�ϴ�", GameController.instance.ShootingUpgradeDamage);
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
                        str = string.Format($"��ź�� �������� {0:0}�ø��ϴ�", GameController.instance.BoomUpgradeDamage);
                    }
                    break;
                }
            case 3:
                {
                    str = string.Format($"1�ʰ� 100m���� �������� ��� ȹ���մϴ�");
                    break;
                }
            case 4:
                {
                    str = string.Format($"�̵� �ӵ��� {0:0}�����մϴ�", GameController.instance.upgradeSpeed);
                    break;
                }
            case 5:
                {
                    str = string.Format($"�ִ� ü���� {0:0} �����մϴ�", GameController.instance.upgradeHp);
                    break;
                }
            default:
                break;
        }

        return str;
    }
}
