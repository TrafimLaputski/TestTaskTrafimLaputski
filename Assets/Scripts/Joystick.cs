using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    public Action<Vector2> InputAction;

    [SerializeField] private RectTransform _handler = null;

    private RectTransform _backGround = null;

    private Vector2 _radius = Vector2.zero;
    private Vector2 _input = Vector2.zero;

    private bool _isDragging = false;

    private void Start()
    {
        JoystickAssembly();
    }

    private void JoystickAssembly()
    {
        _backGround = gameObject.GetComponent<RectTransform>();

        _radius = new Vector2(_backGround.rect.width / 2, _backGround.rect.height / 2);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _input = Vector2.zero;
        _handler.localPosition = Vector2.zero;
        InputAction?.Invoke(Vector2.zero);

        _isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _isDragging = true;

        float x = (eventData.position.x - transform.position.x) / _radius.x;
        float y = (eventData.position.y - transform.position.y) / _radius.y;

        _input.x = x;
        _input.y = y;

        if (_input.magnitude > 1)
        {
            _input = _input.normalized;
        }

        _handler.localPosition = _input * _radius;
    }

    private void Update()
    {
        if (_isDragging)
        {
            InputAction?.Invoke(_input);
        }
    }
}