using UnityEngine;

public class AvatarRotate : MonoBehaviour
{
    public float RotateSpeed = 90;

    private float _rotationX;

    private bool _clicked;
    
    public float sensitivity = 100f;
    public float smoothing = 2f;
    Vector2 mouseLook;
    Vector2 smoothV;

    [SerializeField] private Rigidbody _rigidbody;


    public void OnMouseDrag()
    {
        var mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 1f / smoothing);
        mouseLook += smoothV;
        
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.x, -Vector3.up);
        
       _rigidbody.angularDrag = smoothV.magnitude;
    }
}
