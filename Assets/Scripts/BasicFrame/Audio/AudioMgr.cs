using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioMgr : Singleton<AudioMgr>
{
    private AudioSource BGM = null;
    private float BGMVolume = 1f;

    private GameObject soundCarrier = null;
    private float audioVolume = 1f;
    private List<AudioSource> audioList = new List<AudioSource>();

    public AudioMgr()
    {
        MonoMgr.Instance.AddUpdateListener(Update);
    }

    private void Update()
    {
        for (int i = audioList.Count-1; i >= 0; --i)
        {
            if (!audioList[i].isPlaying)
            {
                Object.Destroy(audioList[i]);
                audioList.RemoveAt(i);
            }
        }
    }
    
    public void PlayBGM(string name)
    {
        if (BGM == null)
        {
            GameObject obj = new GameObject("BGMCarrier");
            GameObject.DontDestroyOnLoad(obj);
            BGM = obj.AddComponent<AudioSource>();
        }
        
        ResMgr.Instance.LoadAsync<AudioClip>("Music/BGM/" + name, (audioClip) =>
        {
            BGM.clip = audioClip;
            BGM.loop = true;
            BGM.volume = BGMVolume;
            BGM.Play();
        });
    }

    public void ChangeBGMVolume(float volume)
    {
        BGMVolume = volume;
        if (BGM == null) return;
        BGM.volume = BGMVolume;
    }
    
    
    public void PauseBGM()
    {
        if (BGM == null) return;
        BGM.Pause();
        
    }
    
    public void StopBGM()
    {
        if (BGM == null) return;
        BGM.Stop();
    }

    public void PlayAudio(string name, bool isLoop, UnityAction<AudioSource> afterPlay = null)
    {
        if (soundCarrier == null)
        {
            soundCarrier = new GameObject ( "SoundCarrier");
        }
        
        ResMgr.Instance.LoadAsync<AudioClip>("Music/Audio/" + name, (audioClip) =>
        {
            AudioSource source = soundCarrier.AddComponent<AudioSource>();
            source.clip = audioClip;
            source.loop = isLoop;
            source.volume = audioVolume;
            source.Play();
            audioList.Add(source);

            if(afterPlay != null)
                afterPlay(source);
        });
    }

    public void ChangeAudioVolume(float volume)
    {
        audioVolume = volume;
        foreach (AudioSource source in audioList)
        {
            source.volume = volume;
        }
    }

    public void StopAudio(AudioSource source)
    {
        if (audioList.Contains(source))
        {
            audioList.Remove(source);
            source.Stop();
            Object.Destroy(source);
        }
        
    }

    public void ClearAudio()
    {
        audioList.Clear();
    }

    
    
}
