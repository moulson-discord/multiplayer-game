using UnityEngine;
using UnityEngine.Networking;

public class PlayerNet : NetworkBehaviour
{
	public Camera childCam;
	public GameObject bullet;
	public GameObject barrel;
	public override void OnStartLocalPlayer()
	{
		GetComponent<FPSInputController>().enabled = true;
		GetComponent<CharacterMotor>().enabled = true;
		GetComponent<MouseLook>().enabled = true;

		childCam.gameObject.SetActive(true);
		childCam.enabled = true;

	}

	void Update()
	{
		if (!isLocalPlayer)
			return;

		if (Input.GetMouseButtonDown(0))
		{
			CmdShoot();
		}
	}

	[Command]
	void CmdShoot()
	{
		// create bullets on each client, not spawned on server
		RpcShoot();
	}

	[ClientRpc]
	void RpcShoot()
	{
		var b = (GameObject)Instantiate(bullet, barrel.transform.position, transform.rotation);
		b.GetComponent<Rigidbody>().velocity = transform.forward * 20;
		Destroy(b, 3.0f);
	}
}
