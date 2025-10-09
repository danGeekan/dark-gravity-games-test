using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadPosService : ILoad
{
    private readonly List<PersonData> _personDataList = new();
    
    public List<PersonData> LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.json"))
        {
            string[] readed = File.ReadAllLines(Application.persistentDataPath + "/SaveData.json");

            foreach (var t in readed)
            {
                PersonData personData = JsonUtility.FromJson<PersonData>(t);
                _personDataList.Add(personData);
            }
        }
        
        Debug.Log("Data is loaded");
        return _personDataList;
    }
}