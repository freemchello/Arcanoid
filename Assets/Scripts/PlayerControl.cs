using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid
{
	public class PlayerControl : MonoBehaviour
	{
		public GameObject ball; // ��� ��� ������ ������, ��� �� �������
		public Transform respawnPoint; // ����� ��������� ������
		public int ballSpeed; // �������� ������
		private float maxPositionX = 6.8f;
		private float minPositionX = -6.8f; // ����. � ���. ������� ��� ��������� �� ��� �
		public float speed = 10f; // �������� ���������
		public GameObject ballClone; // ��������� �����

		void Respawn()
		{
			// ���� �� ������� � �� ��������, ������� �����, ������ ��� �������� � ��������� ����
			if (!Manager.win && !Manager.lose)
			{
				ballClone = Instantiate(ball, respawnPoint.position, Quaternion.identity) as GameObject;
				ballClone.GetComponent<Ball>().speed = ballSpeed;
				ballClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-ballSpeed, ballSpeed), ballSpeed));
			}
		}

		void Update()
		{
			// ���������� ����������� A - �����, D - ������
			if (transform.position.x < maxPositionX && Input.GetKey(KeyCode.D))
			{
				transform.Translate(speed * Time.deltaTime, 0, 0);
			}
			else if (Input.GetKey(KeyCode.A) && transform.position.x > minPositionX)
			{
				transform.Translate(-speed * Time.deltaTime, 0, 0);
			}
			// ������ - ������� �����
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Destroy(ballClone); // ������ ��� ������� �����, ���������� ������
				Respawn();
			}
		}
	}
}