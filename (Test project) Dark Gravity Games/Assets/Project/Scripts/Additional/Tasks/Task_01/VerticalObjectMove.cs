using System.Collections;
using UnityEngine;

public class VerticalObjectMove : MonoBehaviour
{
    [SerializeField] FirstTaskData firstTaskData;

    private Coroutine _moveCoroutine;
    private bool _isMoving;
    
    private KeyboardButtons _keyboardButtons;

    public void StartMoving(KeyboardButtons keyboardButtons)
    {
        _keyboardButtons = keyboardButtons;

        StartMoveCoroutine();
    }

    private void StartMoveCoroutine()
    {
        if (!_isMoving)
        {
            _moveCoroutine = StartCoroutine(MoveObject());
            _isMoving = true;
        }
    }

    public void StopMoving()
    {
        if (_moveCoroutine != null) StopCoroutine(_moveCoroutine);

        _isMoving = false;
        _keyboardButtons = KeyboardButtons.None;
    }

    private IEnumerator MoveObject()
    {
        while (true)
        {
            switch (_keyboardButtons)
            {
                case KeyboardButtons.E:
                    transform.position += Vector3.up * (firstTaskData.HeightSpeed * Time.deltaTime);
                    break;
                case KeyboardButtons.Q:
                    transform.position += Vector3.down * (firstTaskData.HeightSpeed * Time.deltaTime);
                    break;
            }

            yield return null;
        }
    }
}