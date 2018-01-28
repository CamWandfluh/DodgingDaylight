using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -6f);
	[SerializeField] float distanceDamp = 0.15f;

	Transform shipTransform;

	private Vector3 velocity = Vector3.one;

	private void Awake()
	{
		shipTransform = transform;
	}

	private void LateUpdate()
	{
		SmoothFollow();
	}

	void SmoothFollow()
	{
		Vector3 toPos = target.position + (target.rotation * defaultDistance);
		Vector3 curPos = Vector3.SmoothDamp(shipTransform.position, toPos, ref velocity, distanceDamp);
		shipTransform.position = curPos;

		shipTransform.LookAt(target, target.up);
	}
}
