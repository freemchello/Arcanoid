using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid
{
	public class Ball : MonoBehaviour
	{
		public int speed;
		//public AudioClip[] hit;
		private Rigidbody2D body;
		private int hitTimeOut;
		private float hitTimeOutPositionX;
		private float hitTimeOutPositionY;

		void Start()
		{
			body = GetComponent<Rigidbody2D>();
			hitTimeOut = 0;
			hitTimeOutPositionX = 0;
			hitTimeOutPositionY = 0;
		}

		void FixedUpdate()
		{
			// ����������� �������� �� ���� � � Y
			if (Mathf.Abs(body.velocity.x) > speed / 100f)
			{
				body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
			}
			if (Mathf.Abs(body.velocity.y) > speed / 100f)
			{
				body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
			}
		}

		void OnCollisionEnter2D(Collision2D coll)
		{
			// ���� ����� "��������" �� ��� �, �� ����� ��������� ����, ����� �������� ����������
			if (hitTimeOutPositionX != transform.position.x)
			{
				hitTimeOutPositionX = transform.position.x;
			}
			else
			{
				hitTimeOut++;
				if (hitTimeOut == 2)
				{
					hitTimeOut = 0;
					if (hitTimeOutPositionX < 0)
					{
						body.AddForce(new Vector2(speed, Random.Range(-speed, speed)));
					}
					else
					{
						body.AddForce(new Vector2(-speed, Random.Range(-speed, speed)));
					}
				}
			}
			// ���� ����� ��� Y
			if (hitTimeOutPositionY != transform.position.y)
			{
				hitTimeOutPositionY = transform.position.y;
			}
			else
			{
				hitTimeOut++;
				if (hitTimeOut == 2)
				{
					hitTimeOut = 0;
					if (hitTimeOutPositionY < 0)
					{
						body.AddForce(new Vector2(Random.Range(-speed, speed), speed));
					}
					else
					{
						body.AddForce(new Vector2(Random.Range(-speed, speed), -speed));
					}
				}
			}

			if (coll.transform.CompareTag("Block"))
			{
				Block block = coll.transform.GetComponent<Block>();
				//switch (block.ID)
				//{
				//	case 0: // ���� ID ����� = 0
				//			//AudioSource.PlayClipAtPoint(hit[0], transform.position);
				//		break;
				//	case 1:
				//		// � �.�.
				//		break;
				//}
				block.HP -= 1;
				if (block.HP <= 0)
				{
					Manager.score++;
					Destroy(coll.transform.gameObject);
				}
			}
		}

		void OnTriggerEnter2D(Collider2D coll)
		{
			if (coll.transform.CompareTag("BallLoss"))
			{
				if (!Manager.win && !Manager.lose)
				{
					if (Manager.playerLife > 1) Manager.playerLife--; else Manager.lose = true;
				}
				Destroy(gameObject);
			}
		}
	}
}