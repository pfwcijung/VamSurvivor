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
        if (NowBGMname.Equals(name)) 
            return;

        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                NowBGMname = name;
            }
    }
}
