using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource playerBulletSound;
    public AudioSource mainMusic;
    public AudioSource enemyDestroySound;
    public AudioSource gameOverSound;
    public AudioSource gameFinishedSound;
    void Start()
    {
        GameMusic();
    }

    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }
    void Update()
    {
        
    }
    public void SoundPlayer(AudioSource source)
    {
        source.Play();
    }
    void GameMusic()
    {
        mainMusic.Play();
    }
}
