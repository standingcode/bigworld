using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class DetermineSlopeBelow : MonoBehaviour
{
	[SerializeField]
	private float slopeCheckFrequency = 0.05f;

	private RaycastHit hit;
	private float slopeAngle = 0f;


	// b / sin(b) = 1 / sin(90f - slope angle)
	public float SlopeMultiplier => GetTheMultiplier();

	private float GetTheMultiplier()
	{

		if (slopeAngle == 0) return 1;

		float relativeLengthOfTheHyp = Mathf.Sin((90f - slopeAngle) * Mathf.Deg2Rad);

		float relativeLengthOfTheHypNormalised = 1f / relativeLengthOfTheHyp;

		float returningThisShit = Mathf.Clamp01((1f / relativeLengthOfTheHypNormalised));

		return returningThisShit;

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

			float bullshit = 0.0f;

			yield return null;

			//yield return new WaitForSeconds(slopeCheckFrequency);
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
		else
		{
			//Debug.Log("No slope detected");
		}
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}
}
