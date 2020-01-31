using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
	public Vector3 linearVelocity;
	public float angularVelocity;
	public GameObject target;
	public int mode;
	SteeringOutput steering;

	void Start()
	{
		if (this.gameObject.tag == "Missile")
		{
			target = GameObject.Find("Enemy");
		}
		if(this.gameObject.tag == "Enemy")
		{
			target = GameObject.Find("Player");
		}
	}

	// Update is called once per frame
	void Update()
    {
		//update position and rotation
		transform.position += linearVelocity * Time.deltaTime;
		transform.eulerAngles += new Vector3(0, angularVelocity * Time.deltaTime, 0);
		Seek mySeek = new Seek();
		mySeek.character = this;
		mySeek.target = target;
		steering = mySeek.getSteering();
		if (steering != null)
		{
			linearVelocity += steering.linear * Time.deltaTime;
		}
		RotAI(mode);

		//update linear and angular velocities
		
    }

	void RotAI(int mode)
	{
		switch (mode)
		{
			case 0:
				Align myAlign = new Align();
				myAlign.character = this;
				myAlign.target = target;
				steering = myAlign.getSteering();
				if (steering != null)
				{
					angularVelocity += steering.angular * Time.deltaTime;
				}
				Debug.Log("Align");
				break;
			case 1:
				Face myFace = new Face();
				myFace.character = this;
				myFace.target = target;
				steering = myFace.getSteering();
				if (steering != null)
				{
					angularVelocity += steering.angular * Time.deltaTime;
				}
				Debug.Log("Face");
				break;
			case 2:
				LookWhereGoing myLook = new LookWhereGoing();
				myLook.character = this;
				myLook.target = target;
				steering = myLook.getSteering();
				if (steering != null)
				{
					angularVelocity += steering.angular * Time.deltaTime;
				}
				Debug.Log("Look");
				break;
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "enemy" && this.gameObject.tag == "missle")
		{
			Destroy(collision.gameObject);
			Destroy(this.gameObject);
		}
		if (collision.gameObject.tag == "missile" && this.gameObject.tag == "enemy")
		{
			Destroy(collision.gameObject);
			Destroy(this.gameObject);
		}
	}
}
