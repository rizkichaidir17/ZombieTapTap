using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager SM;
    public AudioSource bgmSource,sfxSound;
    [SerializeField] Sound[] BGM,SFX;
    // Start is called before the first frame update
    private void Awake()
    {
        if (SM == null)
        {
            SM = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        BgmPlay("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SfxPlay(string name)
    {
        Sound s = Array.Find(SFX, s => s.name == name);
        if (s != null)
        {
            sfxSound.PlayOneShot(s.clip);
        }
    }

    public void BgmPlay(string name)
    {
        Sound s = Array.Find(BGM, s => s.name == name);
        if (s != null)
        {
            bgmSource.clip = s.clip;
            bgmSource.Play();
        }
    }
}
