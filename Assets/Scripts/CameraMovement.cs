using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private bool _invertX = false;
    [SerializeField] private bool _invertY = false;

    [SerializeField, Min(0.1f)] private float _movementSensitivity = 180;
    [SerializeField, Min(0.1f)] private float _zoomSensitivity = 10;

    [SerializeField, Min(0.1f)] private float _minFov = 10;
    [SerializeField, Min(0.1f)] private float _maxFov = 60;

    private float _fov = 60;
    private float _xRotation = 0;
    private float _yRotation = 0;

    private const float MIN_X_ROTATION = -90;
    private const float MAX_X_ROTATION = 90;

    private void Start()
    {
        Camera.main.fieldOfView = _fov;
        transform.rotation = Quaternion.Euler(_xRotation, 0, 0);
	}

	private void Update()
	{
		Vector2 movement = new (-Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (_invertX)
			movement.x *= -1;

        if (_invertY)
            movement.y *= -1;

        movement.Normalize();
        movement *= _movementSensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation + movement.y, MIN_X_ROTATION, MAX_X_ROTATION);
        _yRotation += movement.x;
        if (_yRotation > 360)
			_yRotation -= 360;
		else if (_yRotation < 0)
			_yRotation += 360;

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);

        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
			_fov = Mathf.Clamp(_fov - scroll * _zoomSensitivity, _minFov, _maxFov);
			Camera.main.fieldOfView = _fov;
		}
	}
}
