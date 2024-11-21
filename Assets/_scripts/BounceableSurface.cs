using System.Linq;
using UnityEngine;

public class BounceableSurface : MonoBehaviour
{
	[UnityEngine.Range(0, 10.0f)]
	[SerializeField]
	float bounceability = 1f;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out BounceableObject bounceable))
		{
			bounceable.BounceObject(collision.impulse * bounceability);
		}
		else
		{
			Debug.LogWarning("No BounceableObject component found on " + collision.gameObject.name);
		}
	}
}
