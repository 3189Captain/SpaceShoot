using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek
{
	public Kinematic character;
	public GameObject target;

	float maxAcceleration = 30f;

	public SteeringOutput getSteering()
	{
		SteeringOutput result = new SteeringOutput();
		//result.linear = new Vector3(0, 0, 1);
		//result.angular = 5f;

		//get direction to target
		result.linear = target.transform.position - character.transform.position;

		//give full accel
		result.linear.Normalize();
		result.linear *= maxAcceleration;

		return result;
	}
}
