using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax; // Clamp's boundaries
}

public class PlayerController : MonoBehaviour 
{
	public float speed; // ship movement speed, available in unity
	public float tilt; // tilt factor
	public Boundary boundary; //reference of the boundary class

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update()
	{
		if (Input.GetKey("space") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); //gets user input
		float moveVertical = Input.GetAxis ("Vertical"); // gets user input
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // using vector to move horizonntal and vertical
		//x,y,z axis - x for horiz, y is set to 0, z for vertical
		rigidbody.velocity = movement * speed;//The object can now move with given speed
		//Control of an object's position through physics simulation.
		rigidbody.position = new Vector3
			(
				//mathf - collection of math functions
				//Clamp - Clamps a value between a minimum float and maximum float value.
				//gets 3 args - current, min, max
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt); //tilts object arround axis 
		//x velocity(speed)* -(tilt factor), otherwise ship will tilt in oposite direction
	}
	
	
}
