using UnityEngine;
using UnityEngine.InputSystem;

public class LittleCubeRocket : MonoBehaviour
{
	[SerializeField]
	private Rigidbody rb;

	[Range(0, 1000f)]
	[SerializeField]
	private float yPower;

	private void OnCrouch(InputValue value)
	{
		Debug.Log("Crouch");

		rb.AddForce(new Vector3(0f, yPower, 0f));
	}
}
