using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;

[System.Serializable]
public struct SoundFX
{

    public string name;
    public AudioClip audio;
    [Range(0f, 1f)]
    public float volume;
    public AudioSource source;

}
public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public Slider musicS, soundS;
    public SoundFX[] FXsound;
    Settings set = new Settings();

	
	// Start is called before the first frame update
	void Start()
    {
        set.LoadSettings();
        for (int s = 0; s < FXsound.Length; s++)
        {
            FXsound[s].source = gameObject.AddComponent<AudioSource>();
            FXsound[s].source.clip = FXsound[s].audio;
            FXsound[s].source.volume = set.SoundVolume;
        }
        music.volume = set.MusicVolume;
    }

   public void SetSliders()
	{
        musicS.value = set.MusicVolume;
        soundS.value = set.SoundVolume;
	}

    public void ChangeMusicVolume()
	{
        music.volume = musicS.value;
       
	}

    public void ChangeEffectsVolume()
	{
        for (int s = 0; s < FXsound.Length; s++)
        {
            FXsound[s].source = gameObject.AddComponent<AudioSource>();
            FXsound[s].source.clip = FXsound[s].audio;
            FXsound[s].source.volume = soundS.value;
        }
    }

    public void ExitAndSave()
	{
        set.MusicVolume = music.volume;
        set.SoundVolume = soundS.value;
        set.SaveSettings();
       
	}

    public void PlayFX(string name)
	{
        SoundFX s = Array.Find(FXsound, sound => sound.name == name);
        s.source.Play();
    }

    public void StopFX(string name)
	{
        SoundFX s = Array.Find(FXsound, sound => sound.name == name);
        s.source.Stop();
	}

    public bool IsPlaying(string name)
	{
        SoundFX s = Array.Find(FXsound, sound => sound.name == name);
        return s.source.isPlaying;
	}
}
