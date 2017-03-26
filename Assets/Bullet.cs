using UnityEngine;


public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		var combat = col.gameObject.GetComponent<Combat>();
		if (combat != null)
		{
			combat.TakeDamage(10);
		}

		Destroy(gameObject);
	}

}
