using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid
{
	public class PlayerControl : MonoBehaviour
	{
		public GameObject ball; // Тут наш префаб шарика, как ни странно
		public Transform respawnPoint; // Точка появления шарика
		public int ballSpeed; // Скорость шарика
		private float maxPositionX = 6.8f;
		private float minPositionX = -6.8f; // Макс. и мин. позиции для платформы по оси Х
		public float speed = 10f; // Скорость платформы
		public GameObject ballClone; // Созданный шарик

		void Respawn()
		{
			// Если не выиграл и не проиграл, создаем шарик, задаем его скорость и добавляем силу
			if (!Manager.win && !Manager.lose)
			{
				ballClone = Instantiate(ball, respawnPoint.position, Quaternion.identity) as GameObject;
				ballClone.GetComponent<Ball>().speed = ballSpeed;
				ballClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-ballSpeed, ballSpeed), ballSpeed));
			}
		}

		void Update()
		{
			// Управление платформаой A - влево, D - вправо
			if (transform.position.x < maxPositionX && Input.GetKey(KeyCode.D))
			{
				transform.Translate(speed * Time.deltaTime, 0, 0);
			}
			else if (Input.GetKey(KeyCode.A) && transform.position.x > minPositionX)
			{
				transform.Translate(-speed * Time.deltaTime, 0, 0);
			}
			// Пробел - создать шарик
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Destroy(ballClone); // Прежде чем создать новый, уничтожаем старый
				Respawn();
			}
		}
	}
}