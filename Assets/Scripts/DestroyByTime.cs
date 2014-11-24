using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	public float lifetime;
	void Start()
	{
		Destroy (gameObject, lifetime); // Destroys object after amount of time, specified as its lifetime
	}
}
