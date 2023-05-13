using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

	[Header("#Game Control")]
	public bool isLive;
	public float gameTime;
	public float maxGameTime = 2*10f;

	[Header("#Player Info")]
	public int playerId;
	public float health;
	public float maxHealth = 100;
	public int level;
	public int kill;
	public int exp;
	public int[] nextExp = {3, 5, 10 ,100, 150, 210, 280, 360, 450, 600};

	[Header("#Game Object")]
	public PoolManager pool;
	public Player player;
	// public LevelUp uiLevelUp;
	// public Result uiResult;
	public GameObject enemyCleaner;

	private void Awake()
	{
		instance = this;
	}

	public void GameStart(int id){

	}
}
