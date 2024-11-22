using UnityEngine;

public class BounceableSurface : MonoBehaviour
{
	[UnityEngine.Range(0, 10.0f)]
	[SerializeField]
	private float bounceability = 1f;
	public float Bounceability => bounceability;


	private void OnTriggerEnter(Collider other)
	{
		Debug.LogWarning("trigger");
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.LogWarning("collision");
	}
}
