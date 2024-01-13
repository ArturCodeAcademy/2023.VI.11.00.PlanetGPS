using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SphereCollider))]
public class Earth : MonoBehaviour, IPointerClickHandler
{
	public Action<Vector3> Click;

    public float Radius => _collider.radius;

    private SphereCollider _collider;

	private void Awake()
	{
		_collider = GetComponent<SphereCollider>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
			Click?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
	}
}
