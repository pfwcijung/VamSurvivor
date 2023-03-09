using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;
    public string Act;
    void Awake()
    {
        if (instance != null)
            return;

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Data(int i)
    {
        switch (i)
        {
            case 0:
                Act = "Throw";
                break;
            case 1:
                Act = "Shoot";
                break;
            case 2:
                Act = "Boom";
                break;
        }
    }
}
