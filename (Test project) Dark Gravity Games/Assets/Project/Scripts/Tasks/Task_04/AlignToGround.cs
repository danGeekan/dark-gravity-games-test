using UnityEngine;

public class AlignToGround : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask groundMask;

    public void PlaceObject()
    {
        if (Physics.Raycast(target.position, Vector3.down, out RaycastHit hit, raycastDistance, groundMask))
        {
            target.position = hit.point +  new Vector3(0, target.localScale.y / 2, 0); //Raise up by half of the object's length.
            target.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }
}