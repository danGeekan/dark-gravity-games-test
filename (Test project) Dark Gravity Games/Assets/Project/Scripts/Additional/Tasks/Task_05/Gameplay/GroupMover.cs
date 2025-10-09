using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GroupMover : MonoBehaviour
{
    [Header("Objects")] 
    [SerializeField] private List<Transform> units;
    [SerializeField] private List<Animator> animators;
    
    [Header("Settings")] 
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 1500f;

    private readonly List<Vector3> _offsets = new();
    private Coroutine _moveCoroutine;
    private Vector3 _target;
    private bool _hasTarget;

    void Start()
    {
        FindOffsets();
    }

    #region Find offsets

    private void FindOffsets()
    {
        Vector3 center = GetGroupCenter();
        foreach (var unit in units)
        {
            _offsets.Add(unit.position - center);
        }
    }

    private Vector3 GetGroupCenter()
    {
        Vector3 sum = Vector3.zero;
        foreach (var unit in units)
            sum += unit.position;
        return sum / units.Count;
    }

    #endregion

    #region Moving states

    public void StartMove(Vector3 target)
    {
        _target = target;

        if (_hasTarget && _moveCoroutine != null) StopCoroutine(_moveCoroutine);
        if (!_hasTarget) animators.ForEach(animator => animator.SetTrigger(PeopleAnimStates.Run.ToString()));

        _moveCoroutine = StartCoroutine(Moving());
    }

    public void EndMove()
    {
        StopCoroutine(_moveCoroutine);
        animators.ForEach(animator => animator.SetTrigger(PeopleAnimStates.Stop.ToString()));
        _hasTarget = false;
    }

    #endregion

    private IEnumerator Moving()
    {
        _hasTarget = true;

        while (_hasTarget)
        {
            for (int i = 0; i < units.Count; i++)
            {
                Move(i);
                Rotate(i);
            }

            yield return null;
        }
    }

    #region Move

    private void Move(int objectNum)
    {
        Vector3 targetPos = _target + _offsets[objectNum];
        units[objectNum].position = Vector3.MoveTowards(units[objectNum].position, targetPos, speed * Time.deltaTime);

        if (IsObjectReachedTarget(targetPos))
        {
            EndMove();
        }
    }

    private bool IsObjectReachedTarget(Vector3 targetPos)
    {
        foreach (var unit in units)
        {
            if (Vector3.Distance(unit.position, targetPos) <= 0.1f)
            {
                return true;
            }
        }

        return false;
    }

    #endregion

    #region Rotate

    private void Rotate(int objectNum)
    {
        Vector3 direction = _target - units[objectNum].position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            ChangeObjectRotation(objectNum, direction);
        }
    }

    private void ChangeObjectRotation(int objectNum, Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        units[objectNum].rotation =
            Quaternion.RotateTowards(units[objectNum].rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    #endregion
}