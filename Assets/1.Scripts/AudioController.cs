using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }


    public BgmType[] BGMList;

    private AudioSource BGM;
    public string NowBGMname = "";

    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = false;
        if (BGMList.Length > 0)
            PlayBGM(BGMList[0].name);
    }

    public void PlayBGM(string name)
    {
        //현재 재생 중인 bgm 이름
        if (NowBGMname.Equals(name)) 
            return;

        //미리 리스트에 넣어둔 이름값에 따라 bgm을 재생하기 위함
        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                NowBGMname = name;
            }
    }
}
