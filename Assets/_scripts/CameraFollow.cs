using UnityEditor;
using UnityEngine;

//[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{

	[SerializeField]
	private float cameraDistance = 2.0f, cameraHeight = 1.3f, cameraSpeed = 2f, cameraZOffset = 20f;

	[SerializeField]
	private Transform playerTrackerTransform = null;

	private Vector3 desiredCameraPosition
		=> new Vector3(playerTrackerTransform.position.x, playerTrackerTransform.position.y + cameraHeight, playerTrackerTransform.position.z) + -playerTrackerTransform.forward * cameraDistance;

	void Start()
	{
		SetCameraPositionImmediate();
	}


	void Update()
	{
		SetCameraPositionLerped();
	}

	void SetCameraPositionImmediate()
	{
		if (playerTrackerTransform == null)
		{
			Debug.LogError("Player tracker transform is not set in the camera follow script");
			return;
		}

		transform.position = desiredCameraPosition;
		transform.LookAt(playerTrackerTransform.position + playerTrackerTransform.forward * cameraZOffset);

	}

	private void SetCameraPositionLerped()
	{
		if (playerTrackerTransform == null)
		{
			Debug.LogError("Player tracker transform is not set in the camera follow script");
			return;
		}

		transform.position = Vector3.Lerp(
			transform.position,
			desiredCameraPosition,
			Time.deltaTime * cameraSpeed);

		transform.rotation = Quaternion.Lerp(
			transform.rotation,
			Quaternion.LookRotation(playerTrackerTransform.position + playerTrackerTransform.forward * cameraZOffset - transform.position),
			Time.deltaTime * cameraSpeed);
	}

	private void OnDrawGizmos()
	{
		if (playerTrackerTransform == null)
		{
			return;
		}

		Gizmos.color = Color.red;
		Gizmos.DrawSphere(playerTrackerTransform.position + playerTrackerTransform.forward * cameraZOffset, 0.1f);
	}
}
