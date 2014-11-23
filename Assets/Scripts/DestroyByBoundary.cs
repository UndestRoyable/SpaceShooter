using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
	//When the object (bolt or other)leave the boundary of the screen, its being destroyed.
}
