using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryTest_Keffny : MonoBehaviour
{
	public Transform target;
	public float firingAngle = 45.0f;
	public float gravity = 9.8f;

	public Transform projectile;
	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(SimulateProjectile());
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	IEnumerator SimulateProjectile()
	{
		yield return new WaitForSeconds(1.5f);

		projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

		float target_Distance = Vector3.Distance(projectile.position, target.position);

		float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

		float flightDuration = target_Distance / Vx;

		projectile.rotation = Quaternion.LookRotation(target.position - projectile.position);

		float elapse_time = 0;

		while(elapse_time < flightDuration)
		{
			projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

			elapse_time += Time.deltaTime;

			yield return null;
		}
	}

	/*public static Vector2 GetParableInitialVelocity(Vector3 origin, Vector3 target, float offsetY = 0.0f)
	{
		float gravity = Physics2D.gravity.magnitude;
		float height = Mathf.Abs(target.y - origin.y + offsetY);
		float dist = Mathf.Abs(target.x - origin.x);
		float vertVelocity = 0.0f;
		float time = 0.0f;
		float horzVelocity = 0.0f;

		if(height < 0.1f)height = 0.1f;
		if(gravity < 0.1f)gravity = 0.1f;

		if(target.y - origin.y > 1.0f)
		{
			vertVelocity = Mathf.Sqrt (2.0f * gravity * height);
			time = vertVelocity / gravity;
			horzVelocity = dist / time;
		}
		else if(target.y - origin.y < -1.0f)
		{
			vertVelocity = 0.0f;
			time = Mathf.Sqrt (2 * height / gravity);
			horzVelocity = dist / time;
		}
		else
		{
			height = dist / 4;
			vertVelocity = Mathf.Sqrt(2.0f * gravity * height);
			time = 2 * vertVelocity / gravity;
			horzVelocity = dist / time;
		}

		if(vertVelocity == 0.0f && horzVelocity == 0.0f)
		{
			return Vector2.zero;
		}

		if(target.x - origin.x > 0.0f && !float.IsNaN(vertVelocity) && !float.IsNaN(horzVelocity))
		{
			return new Vector2(horzVelocity, vertVelocity);
		}
		else if(!float.IsNaN(vertVelocity) && !float.IsNaN(horzVelocity))
		{
			return new Vector2(-horzVelocity, vertVelocity);
		}
		else
		{
			return Vector2.zero;
		}
	}*/
}
