using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Audio[] audioArray;
    public static AudioManager instance;

    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Audio x in audioArray) {
            x.source = gameObject.AddComponent<AudioSource>();
            x.source.clip = x.clip;
            x.source.volume = x.volume;
            x.source.loop = x.loop;
        }
        Play("BackgroundMusic");
    }

    public void Play(string name)
    {
        Audio x = Array.Find(audioArray, audio => audio.name == name);
        x.source.Play();
    }

    public void Stop(string name)
    {
        Audio x = Array.Find(audioArray, audio => audio.name == name);
        x.source.Stop();
    }

    public void changeVolume(string name, float val) {
        Audio x = Array.Find(audioArray, audio => audio.name == name);
        x.source.volume = val;
    }
}
 