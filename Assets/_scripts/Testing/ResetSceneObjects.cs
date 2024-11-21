using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetSceneObjects : MonoBehaviour
{
	[SerializeField]
	private List<Transform> objectsToReset = new();

	private List<Vector3> positions = new();
	private List<Quaternion> rotations = new();

	private void Start()
	{
		foreach (var obj in objectsToReset)
		{
			positions.Add(obj.position);
			rotations.Add(obj.rotation);
		}
	}

	public void OnMove(InputValue value)
	{
		ResetObjects();
	}

	private void ResetObjects()
	{
		foreach (var obj in objectsToReset)
		{
			obj.position = positions[objectsToReset.IndexOf(obj)];
			obj.rotation = rotations[objectsToReset.IndexOf(obj)];
			obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			obj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
		}
	}
}
