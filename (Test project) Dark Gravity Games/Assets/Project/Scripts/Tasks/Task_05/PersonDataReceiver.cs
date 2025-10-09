using UnityEngine;

public class PersonDataReceiver : MonoBehaviour
{
    [SerializeField] private int id; // For unique ID we can make any function or something else.
    [SerializeField] private Transform personTransform;

    public int Id => id;
   public PersonData GetCurrentData()
   {
       return new PersonData(id, personTransform);
   }
}