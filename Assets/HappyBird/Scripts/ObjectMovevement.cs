using UnityEngine;


public class ObjectMovevement : MonoBehaviour 
{
	void FixedUpdate () 
	{
		transform.position = new Vector3(transform.position.x - 0.03f, transform.position.y , 0);

		if (transform.position.x <= -7.5f)
		{
			Destroy(gameObject);
		}
	}
}
