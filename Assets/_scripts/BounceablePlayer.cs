using StarterAssets;
using System.Collections;
using UnityEngine;

public class BounceablePlayer : MonoBehaviour
{
	[SerializeField]
	private ThirdPersonController thirdPersonController;

	private bool grounded = false;

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (grounded)
			return;

		grounded = true;

		if (hit.gameObject.TryGetComponent(out BounceableSurface bounceableSurface))
		{
			thirdPersonController.AddVerticalVelocityToPlayer(bounceableSurface.Bounceability);
			StartCoroutine(CheckWhenNotGrounded());
		}
	}

	private IEnumerator CheckWhenNotGrounded()
	{
		while (thirdPersonController.IsGrounded)
		{
			yield return null;
		}

		grounded = false;
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}
}
