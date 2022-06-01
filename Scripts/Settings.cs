using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public float MusicVolume, SoundVolume;
    SaveLoadManager SL = new SaveLoadManager();


    public void SaveSettings()
	{
        SL.SaveSettings(this);
	}

    public Settings LoadSettings()
	{
        SettingsManager set = SL.LoadSettings();
        this.MusicVolume = set.Music_Volume;
        this.SoundVolume = set.Sound_Volume;
        return this;
	}
}
