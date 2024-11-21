using UnityEngine;

public class BounceableObject : MonoBehaviour
{
	[SerializeField]
	private Rigidbody rb;

	public void BounceObject(Vector3 directionAndBounce)
	{
		if (rb != null)
		{
			//rb.angularVelocity = Vector3.zero;
			//rb.linearVelocity = Vector3.zero;
			rb.AddForce(directionAndBounce, ForceMode.Impulse);
		}
	}
}
