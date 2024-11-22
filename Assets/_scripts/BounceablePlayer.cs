using StarterAssets;
using System.Collections;
using UnityEngine;

public class BounceablePlayer : MonoBehaviour
{
	[SerializeField]
	private ThirdPersonController thirdPersonController;

	private bool checkWhenNotGroundedIsRunning = false;

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (checkWhenNotGroundedIsRunning)
			return;

		if (hit.gameObject.TryGetComponent(out BounceableSurface bounceableSurface))
		{
			thirdPersonController.AddVerticalVelocityToPlayer(bounceableSurface.Bounceability);
			StartCoroutine(CheckWhenNotGrounded());
		}
	}

	private IEnumerator CheckWhenNotGrounded()
	{
		checkWhenNotGroundedIsRunning = true;

		while (thirdPersonController.IsGrounded)
		{
			yield return null;
		}

		checkWhenNotGroundedIsRunning = false;
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}
}
