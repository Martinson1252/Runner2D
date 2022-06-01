using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveLoadManager : MonoBehaviour
{

  
    public void RefreshCatalog()
    {
        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
    }
    public void SavePlayerData(GameUI UIdata)
    {   
            BinaryFormatter bf = new BinaryFormatter();
            BinaryFormatter bb = new BinaryFormatter();
            FileStream Datstream = new FileStream((Application.persistentDataPath+ "/Pdat.dat"), FileMode.Create);
            
            PlayerData data = new PlayerData(UIdata);
            bf.Serialize(Datstream, data);
            Datstream.Close();
        if (SaveIF(UIdata))
        {
            FileStream Recstream = new FileStream((Application.persistentDataPath + "/Prec.dat"), FileMode.Create);
            PlayerRecord Rec = new PlayerRecord(UIdata);
            bb.Serialize(Recstream, Rec);
            Recstream.Close();
        }

    } 
    
 

    public PlayerData LoadData()
    {
        if(File.Exists(Path.Combine(Application.persistentDataPath+ "/Pdat.dat"))) 
        {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream((Application.persistentDataPath+ "/Pdat.dat"), FileMode.Open);
        PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }else
        {
            Debug.Log("File doesn't exist");
            return null;
        }
        
    }
    public PlayerRecord LoadRecord()
    {
        if(File.Exists(Path.Combine(Application.persistentDataPath+ "/Prec.dat"))) 
        {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream((Application.persistentDataPath+ "/Prec.dat"), FileMode.Open);
        PlayerRecord data = bf.Deserialize(stream) as PlayerRecord;
            stream.Close();
            return data;
        }else
        {
            Debug.Log("File doesn't exist");
            return null;
        }
        
    }

  
    public SettingsManager LoadSettings()
	{
        if (File.Exists(Path.Combine(Application.persistentDataPath + "/settings.set")))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream((Application.persistentDataPath + "/settings.set"), FileMode.Open);
            SettingsManager data = bf.Deserialize(stream) as SettingsManager;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("File doesn't exist");
            return null;
        }
    }

    public void SaveSettings(Settings set)
	{
        BinaryFormatter bf = new BinaryFormatter();
        FileStream Datstream = new FileStream((Application.persistentDataPath + "/settings.set"), FileMode.Create);

        SettingsManager data = new SettingsManager(set);
        bf.Serialize(Datstream, data);
        Datstream.Close();
    }

    public bool SaveIF(GameUI BT)
    { if (File.Exists(Application.persistentDataPath + "/Prec.dat"))
        {   
            //BestTime[0] -minuty, BestTime[1] -sekundy
            float[] readedData = LoadRecord().BestTime;
            if (BT.BestTiming[0] > readedData[0]) return true;
            if (BT.BestTiming[0] == readedData[0] && BT.BestTiming[1] >= readedData[1]) return true;
            return false;
        }
        else return true;
    }

    public string EraseData()
{
        if (File.Exists(Path.Combine(Application.persistentDataPath, "Pdat.dat")))
        {
            string path = Path.Combine(Application.persistentDataPath, "Pdat.dat");
            File.Delete(path );
            if (File.Exists(path))
            { File.Delete(path); }
                RefreshCatalog();
           
        }
       if (File.Exists(Path.Combine(Application.persistentDataPath, "Prec.dat")))
        {
            string path = Path.Combine(Application.persistentDataPath, "Prec.dat");
            File.Delete(path );
            if (File.Exists(path))
            { File.Delete(path); }
                RefreshCatalog();
            return "User data file deleted.";
        }
        else return "User data doesn't exist.";
    }

}


[Serializable]
public class PlayerData
{
    public float money,BlueBalls,YellowBalls,RedBalls,levelUnlocked;
    public PlayerData(GameUI UIdata)
    {
       
        this.money = UIdata.money;
        BlueBalls = UIdata.BlueBalls;
        YellowBalls = UIdata.YellowBalls;
        RedBalls = UIdata.RedBalls;
        levelUnlocked = UIdata.levelUnlocked;
    }
}

[Serializable]
public class PlayerRecord
{
    public float[] BestTime;
  
    public PlayerRecord(GameUI Record)
    {
        //BestTime[0] -minuty, BestTime[1] -sekundy
        BestTime = new float[2];
        BestTime[0] = Record.BestTiming[0];
        BestTime[1] = Record.BestTiming[1];
       
    }
}

[Serializable]
public class SettingsManager
{
    public float Music_Volume, Sound_Volume;

    public SettingsManager(Settings set)
	{
        Music_Volume = set.MusicVolume;
        Sound_Volume = set.SoundVolume;
	}
}