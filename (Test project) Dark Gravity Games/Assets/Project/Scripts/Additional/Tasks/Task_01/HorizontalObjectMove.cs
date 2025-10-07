using System.Collections;
using UnityEngine;

public class HorizontalObjectMove : MonoBehaviour
{
    [SerializeField] FirstTaskData firstTaskData;

    private Coroutine _moveCoroutine;
    private bool _isMoving;
    
    private float _horizontal;
    private float _vertical;

    public void StartMoving(float horizontal, float vertical)
    {
        _horizontal = horizontal;
        _vertical = vertical;

        StartMoveCoroutine();
    }

    private void StartMoveCoroutine()
    {
        if (!_isMoving)
        {
            _moveCoroutine = StartCoroutine(HorizontalMoveObject());
            _isMoving = true;
        }
    }

    public void StopMoving()
    {
        if (_moveCoroutine != null) StopCoroutine(_moveCoroutine);
        _isMoving = false;
    }

    private IEnumerator HorizontalMoveObject()
    {
        while (true)
        {
            Vector3 moveDirection = new Vector3(_horizontal, 0f, _vertical);
            moveDirection = transform.TransformDirection(moveDirection);

            transform.position += moveDirection * (firstTaskData.MoveSpeed * Time.deltaTime);

            yield return null;
        }
    }
}