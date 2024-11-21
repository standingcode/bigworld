using StarterAssets;
using UnityEngine;

public class BounceablePlayer : MonoBehaviour
{
	[SerializeField]
	private ThirdPersonController thirdPersonController;

	public void BouncePlayer(float bounceMultiplier)
	{
		if (thirdPersonController.VerticalVelocity <= 0.0f)
		{
			thirdPersonController.SetVerticalVelocity(-thirdPersonController.VerticalVelocity * bounceMultiplier);
		}
	}
}
