using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target = null;  
    [SerializeField] private Vector3 _offset = Vector3.zero; 
    [SerializeField] private float _smoothSpeed =1f;
    [SerializeField] private bool _followX = true; 
    [SerializeField] private bool _followZ = true;  

    void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = transform.position;

        if (_followX)
        {
            smoothedPosition.x = Mathf.Lerp(transform.position.x, desiredPosition.x, _smoothSpeed * Time.deltaTime);
        }
        if (_followZ)
        {
            smoothedPosition.z = Mathf.Lerp(transform.position.z, desiredPosition.z, _smoothSpeed * Time.deltaTime);
        }

        transform.position = smoothedPosition;
    }
}
