using System.Collections;
using UnityEngine;

public class AutoLookAt : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool lockYAxis;

    private bool _startMove;

    public void CheckRotate()
    {
        if (!_startMove)
        {
            StartCoroutine(RotateLoop());
            _startMove = true;
        }
    }

    public void EndCheckRotate()
    {
        _startMove = false;
    }

    private IEnumerator RotateLoop()
    {
        bool isRotating = true;

        while (isRotating || _startMove)
        {
            isRotating = Rotate();
            yield return null;
        }
    }

    private bool Rotate()
    {
        var targetRotation = CalculationTargetPos();

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        return IsRotationFinished(targetRotation);
    }

    private Quaternion CalculationTargetPos()
    {
        Vector3 direction = target.position - transform.position;

        if (lockYAxis) direction.x = 0;
        if (direction == Vector3.zero) return transform.rotation;

        return Quaternion.LookRotation(direction);
    }

    private bool IsRotationFinished(Quaternion targetRotation)
    {
        float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);
        return angleDifference > 0;
    }
}