using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSaveManager : MonoBehaviour
{
    //In a real project, we can add objects to this list during spawning.
    //Alternatively, we can create an external class that stores lists of all objects that need to be saved.
    [SerializeField] private List<PersonDataReceiver> personDataReceiver; 
    
    private List<PersonData> _tempPersonData = new ();
    private ISave _personsPosSave;
    private ILoad _personsPosLoad;

    [Inject]
    private void Construct(ISave personsPosSave, ILoad personsPosLoad)
    {
        _personsPosSave = personsPosSave;
        _personsPosLoad = personsPosLoad;
    }

    public void Save()
    {
        _personsPosSave.SaveData(personDataReceiver);
    }

    public void Load()
    {
        _tempPersonData = _personsPosLoad.LoadData();
        RespawnPersons();
    }

    private void RespawnPersons()
    {
        foreach (var personData in personDataReceiver)
        {
            foreach (var tempPersonData in _tempPersonData)
            {
                if (personData.Id == tempPersonData.id)
                {
                    personData.transform.position = tempPersonData.position.ToVector3();
                }
            }
        }
    }
}
