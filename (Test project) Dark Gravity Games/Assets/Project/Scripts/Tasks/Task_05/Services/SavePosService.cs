using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavePosService : ISave
{
    public void SaveData(List<PersonDataReceiver> personsData)
    {
        StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + "/SaveData.json");

        foreach (var personData in personsData)
        {
            string jsonPersonData = JsonUtility.ToJson(personData.GetCurrentData());
            streamWriter.WriteLine(jsonPersonData);
        }
        
        streamWriter.Close();
        
        Debug.Log("Data is saved!");
    }
}