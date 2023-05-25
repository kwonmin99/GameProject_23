using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
	[Header(" # Game Control")]
	public float gameTime;
	public float maxGameTime = 2 * 10f;
	public bool isLive = true;
	[Header(" # Game Object")]
	public PoolManager poolManager;
    public Player player;
	public LevelUp uiLevelUp;

	[Header(" # Player Info")]
	public int health;
	public int maxHealth = 100;
	public int level;
	public int kill;
	public int exp;
	public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };

	private void Awake()
	{
		instance = this;
	}

	// public void GameStart(int id){
	// 	playerId = id;
	// 	health = maxHealth;

	// 	player.gameObject.SetActive(true);
	// 	uiLevelUp.Select(playerId % 2);
	// 	Resume();
	// 	AudioManager.Instance.PlaySfx(AudioManager.Sfx.Select);
	// }

	// public void GameOver(){
	// 	StartCourtine(GameoverRoutine());
	// }

	// IEnumerator GameoverRoutine(){
	// 	isLive = false;

	// 	yield return new WaitForSeconds(0.5f);

	// 	uiResult.gameObject.SetActive(true);
	// 	uiResult.Lose();
	// 	Stop();

	// 	AudioManager.instance.PlayBgm(false);
	// 	AudioManager.instance.PlaySfx(AudioManager.Sfx.Lose);
		
	// }

    private void Start()
    {
		health = maxHealth;

		uiLevelUp.Select(0);
		AudioManager.instance.PlayBgm(true);
		AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }

	// public void GameVictory(){
	// 	StartCourtine(GameVictoryRoutine());
	// }

	// IEnumerator GameVictoryRoutine(){
	// 	isLive = false;
	// 	enemyCleaner.SetActive(true);

	// 	yield return new WaitForSeconds(0.5f);

	// 	uiResult.gameObject.SetActive(true);
	// 	uiResult.Win();
	// 	Stop();
	// 	AudioManager.Instance.PlaySfx(AudioManager.Sfx.Win);
	// }

    void Update()
	{
		if (!isLive)
			return;

		gameTime += Time.deltaTime;

		if (gameTime > maxGameTime)
		{
			gameTime = maxGameTime;
		}
	}

	public void GetExp()
    {
		exp++;
		if (exp == nextExp[Mathf.Min(level,nextExp.Length-1)])
        {
			level++;
			exp = 0;
			uiLevelUp.Show();
        }
    }

	public void Stop()
	{
		isLive = false;
		Time.timeScale = 0;
	}

	public void Resume()
	{
		isLive = true;
		Time.timeScale = 1;
	}
}
