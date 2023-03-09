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
                        str = string.Format("던지기 무기를 활성화합니다");
                    }
                    else
                    {
                        str = string.Format($"던지기의 데미지를 20올리고 발사속도를 증가시킵니다.");
                    }
                    break;
                }
            case 1:
                {
                    if (!GameController.instance.ShootingActive)
                    {
                        str = string.Format("총알 무기를 활성화 합니다");
                    }
                    else
                    {
                        str = string.Format($"총알의 데미지를 10올리고 발사속도를 증가시킵니다");
                    }
                    break;
                }
            case 2:
                {
                    if (!GameController.instance.BoomActive)
                    {
                        str = string.Format("폭탄 무기를 활성화 합니다");
                    }
                    else
                    {
                        str = string.Format($"폭탄의 데미지를 50올립니다");
                    }
                    break;
                }
            case 3:
                {
                    str = string.Format($"1초간 100m내의 아이템을 모두 획득합니다");
                    break;
                }
            case 4:
                {
                    str = string.Format($"이동 속도가 {0}증가합니다", 5);
                    break;
                }
            case 5:
                {
                    str = string.Format($"최대 체력을 {0} 증가합니다", 5);
                    break;
                }
            default:
                break;
        }

        return str;
    }
}
