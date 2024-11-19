using System.Collections;
using UnityEngine;

public class DetermineSlopeBelow : MonoBehaviour
{
	[SerializeField]
	private float slopeCheckFrequency = 0.05f;

	private RaycastHit hit;
	private float slopeAngle = 0f;

	public float SlopeMultiplier => GetTheMultiplier();

	private float GetTheMultiplier()
	{
		if (slopeAngle == 0) return 1;

		float relativeLengthOfTheHyp = 1f / Mathf.Sin((90f - slopeAngle) * Mathf.Deg2Rad);
		return Mathf.Clamp01((1f / relativeLengthOfTheHyp));
	}

	private void Start()
	{
		StartCoroutine(DetermineSlope());
	}

	private IEnumerator DetermineSlope()
	{
		while (true)
		{
			RaycastAndDetermineSlope();

			yield return new WaitForSeconds(slopeCheckFrequency);
		}
	}

	private void RaycastAndDetermineSlope()
	{
		// Create raycast and assign the output to a variable
		if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
		{
			// Calculate the angle of the slope
			slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

			//// Print the angle of the slope
			//Debug.Log("Slope angle: " + slopeAngle);
		}
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}
}
