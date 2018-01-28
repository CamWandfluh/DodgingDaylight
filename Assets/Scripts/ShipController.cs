using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipController : MonoBehaviour
{

	[SerializeField] float movementSpeed = 50f;
	[SerializeField] float turnSpeed = 60f;

	Transform shipTransform;

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	private float roll = 0.0f;

	private void Awake()
	{
		shipTransform = transform;
        Cursor.visible = false;
	}

    void Update()
	{
		Turn();
		Thrust();
	}

	void Turn()
	{
		yaw += turnSpeed * Input.GetAxis("Mouse X");

        pitch += turnSpeed * Input.GetAxis("Mouse Y");
        roll -= (turnSpeed / 50) * Input.GetAxis("Roll");
		//shipTransform.Rotate(pitch, yaw, roll);
		shipTransform.eulerAngles = new Vector3(-pitch, yaw, roll);
	}

	void Thrust()
	{
		transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

	}
}
