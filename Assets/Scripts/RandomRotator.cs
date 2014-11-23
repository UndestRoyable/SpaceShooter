using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
	public float tumble; //holds max tumble value

	void Start()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;  
			/*angularVelocity sets how fast rigidbody object is rotating
			Doing it with Random.insideUnitSphere	- returns vector3 value that can be applied 
			to rigidbody's angularVelocity*
			Gets tumble value from the editor!*/
	}
}
