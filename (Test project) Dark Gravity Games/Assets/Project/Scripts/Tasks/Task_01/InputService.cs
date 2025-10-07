using UnityEngine;

public class InputService : MonoBehaviour
{
    [Header("Observer")] [SerializeField] AutoLookAt autoLookAt;

    [Header("Target")] [SerializeField] HorizontalObjectMove horizontalObjectMove;
    [SerializeField] VerticalObjectMove verticalObjectMove;

    public void Update()
    {
        CheckHorizontalMovement();
        CheckVerticalMovement();
    }

    private void CheckHorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal == 0 && vertical == 0)
        {
            horizontalObjectMove.StopMoving();
            autoLookAt.EndCheckRotate();
        }
        else
        {
            horizontalObjectMove.StartMoving(horizontal, vertical);
            autoLookAt.CheckRotate();
        }
    }

    private void CheckVerticalMovement()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            verticalObjectMove.StartMoving(KeyboardButtons.Q);
            autoLookAt.CheckRotate();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            verticalObjectMove.StartMoving(KeyboardButtons.E);
            autoLookAt.CheckRotate();
        }
        else
        {
            verticalObjectMove.StopMoving();
            autoLookAt.EndCheckRotate();
        }
    }

    /*private void IsPressedQ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            verticalObjectMove.StartMoving(KeyboardButtons.Q);
            autoLookAt.CheckRotate();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            verticalObjectMove.StopMoving();
            autoLookAt.EndCheckRotate();
        }
    }

    private void IsPressedE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            verticalObjectMove.StartMoving(KeyboardButtons.E);
            autoLookAt.CheckRotate();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            verticalObjectMove.StopMoving();
            autoLookAt.EndCheckRotate();
        }
    }*/
}