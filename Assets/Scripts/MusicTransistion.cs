using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransistion : MonoBehaviour
{
    public static MusicTransistion instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
