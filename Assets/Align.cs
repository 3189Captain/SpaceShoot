using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align
{
	public Kinematic character;
	public GameObject target;

	protected float maxAngularAcceleration = 30f;
	protected float maxRotation = 50f; // maxSPeed

	protected float slowRadius =  2f;
	protected float targetRadius = 1f;
	protected float timeToTarget = 0.1f;
	public virtual SteeringOutput getSteering()
	{
		SteeringOutput result = new SteeringOutput();
		float rotation = Mathf.DeltaAngle(character.transform.eulerAngles.y, target.transform.eulerAngles.y);
		float rotationSize = Mathf.Abs(rotation);

		if(rotationSize < targetRadius)
		{
			return null;
		}

		//if we are outside slow radius use max rotation
		float targetRotation = 0; //target angular velocity
		if(rotationSize > slowRadius)
		{
			targetRotation = maxRotation;
		}
		else
		{
			targetRotation = maxRotation * rotationSize / slowRadius;
		}
		
		
		//add direction back
		targetRotation *= rotation / rotationSize;
		//acceleration tries to get to targetRotation
		result.angular = targetRotation - character.angularVelocity;
		result.angular /= timeToTarget;
		result.linear = Vector3.zero;
		return result;
	}
}
