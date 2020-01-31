using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereGoing : Align
{
	public override SteeringOutput getSteering()
	{
		SteeringOutput result = new SteeringOutput();
		
		//get the angle between the velocity and the forward face
		float rotation = Vector3.SignedAngle(character.transform.forward, character.linearVelocity, Vector3.up);
		float rotationSize = Mathf.Abs(rotation);

		if (rotationSize < targetRadius)
		{
			return null;
		}

		//if we are outside slow radius use max rotation
		float targetRotation = 0; //target angular velocity
		if (rotationSize > slowRadius)
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
		result.linear = character.linearVelocity;
		return result;
	}
}
