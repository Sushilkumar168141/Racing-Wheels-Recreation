using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{

	public movement mv;
	/*public void GetInput()
	{
		m_horizontalInput = Input.GetAxis("Horizontal");
		m_verticalInput = Input.GetAxis("Vertical");
	}*/

	/*private void Steer()
	{
		m_steeringAngle = maxSteerAngle * m_horizontalInput;
		frontDriverW.steerAngle = m_steeringAngle;
		frontPassengerW.steerAngle = m_steeringAngle;
	}*/

	public float decelarationForce = 100f;
	private void Accelerate()
	{
		//if (frontDriverW.rpm <= 10)
		//{
			frontDriverW.motorTorque = motorForce;
			//frontDriverW.brakeTorque = 0f;
		//}
		//frontPassengerW.motorTorque = m_verticalInput * motorForce;
		
		/*else if (frontDriverW.rpm > 10)
		{
			//frontDriverW.brakeTorque = decelarationForce;
			motorForce = 10f;
		}*/
		//print(frontDriverW.rpm);
	}

	private void UpdateWheelPoses()
	{
		UpdateWheelPose(frontDriverW, frontDriverT);
		/*UpdateWheelPose(frontPassengerW, frontPassengerT);
		UpdateWheelPose(rearDriverW, rearDriverT);
		UpdateWheelPose(rearPassengerW, rearPassengerT);*/
	}

	private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
	{
		Vector3 _pos = _transform.position;
		Quaternion _quat = _transform.rotation;

		_collider.GetWorldPose(out _pos, out _quat);

		_transform.position = _pos;
		//_transform.rotation = _quat;
	}

	private void FixedUpdate()
	{
        /*if (mv.increase)
        {
            motorForce = 100f;
        }
        if (mv.decrease)
        {
            motorForce = 50f;
        }*/
        //GetInput();
        //Steer();
        Accelerate();
		UpdateWheelPoses();
	}

	/*private float m_horizontalInput;
	private float m_verticalInput;
	private float m_steeringAngle;*/

	public WheelCollider frontDriverW;
	public Transform frontDriverT;
	//public float maxSteerAngle = 30;
	public float motorForce = 40f;
}
