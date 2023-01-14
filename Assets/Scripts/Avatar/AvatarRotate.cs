
using UnityEngine;
using UnityEngine.EventSystems;

public class AvatarRotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float RotateSpeed = 90;

    private bool _clicked;

    public void OnMouseDrag()
    {
        var rotationX = Input.GetAxis("Mouse X") * RotateSpeed * Mathf.Deg2Rad;
     //   var rotationY = Input.GetAxis("Mouse Y") * RotateSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, -rotationX);
      //  transform.Rotate(Vector3.left, -rotationY);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _clicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _clicked = false;
    }
}
