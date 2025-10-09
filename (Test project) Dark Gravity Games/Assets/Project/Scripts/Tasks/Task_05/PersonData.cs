using UnityEngine;

[System.Serializable]
public class PersonData
{
    public int id;
    public SerializableVector3 position;

    public PersonData(int id, Transform personTransform)
    {
        this.id = id;
        position = new SerializableVector3(personTransform.position);
    }
}