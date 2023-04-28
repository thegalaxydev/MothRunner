using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject Player;
	public int Score = 0;
	public float GameSpeedMultiplier = 1;

	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (!_instance)
				_instance = FindObjectOfType<GameManager>();

			if (!_instance)
			{
				Debug.Log("No GameManager found in scene. Creating one.");
				_instance = new GameObject("GameManager").AddComponent<GameManager>();
			}

			return _instance;
		}
	}

	[SerializeField]
	private GameObject _playerReference;

	private float timePassed;

	void Awake()
	{
		Player = _playerReference;
	}

	private void Update() 
	{
		timePassed += Time.deltaTime;
		if (timePassed > 1)
		{
			timePassed = 0;
			
			if (GameSpeedMultiplier < 5)
				GameSpeedMultiplier += 0.01f;

			Score += 1 * (int)GameSpeedMultiplier;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
