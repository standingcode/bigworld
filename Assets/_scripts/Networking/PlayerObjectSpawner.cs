using Mirror;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerObjectSpawner : NetworkBehaviour
{
	[SerializeField] private GameObject[] gameobjectEnables;
	[SerializeField] private Behaviour[] behaviourEnables;


	public override void OnStartLocalPlayer()
	{
		base.OnStartLocalPlayer();

		foreach (var gameObject in gameobjectEnables)
		{
			gameObject.SetActive(true);
		}

		foreach (var behaviour in behaviourEnables)
		{
			behaviour.enabled = true;
		}

		return;
	}
}
