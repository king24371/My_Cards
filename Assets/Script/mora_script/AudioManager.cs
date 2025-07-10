using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{
    public static AudioManager current;

	[Header("開頭BGM")]
	public AudioClip tittleclip;

	[Header("抽取BGM")]
	public AudioClip rollclip;

	[Header("抽取動畫")]
	public AudioClip rollplayerClip;

	[Header("腳色對白")]
	public AudioClip[] charactor;

	[Header("sword")]
	public AudioClip swordClip;

	[Header("gun")]
	public AudioClip gunClip;

	[Header("攻擊觸發")]
	public AudioClip trigger;

	[Header("戰鬥BGM")]
	public AudioClip[] battle_theme;

	[Header("WinLost")]
	public AudioClip WinClip;
	public AudioClip LostClip;

	public int i;

	AudioSource tittleSourse;
	AudioSource rollSourse;
	AudioSource roll_R_Sourse;
	AudioSource charaSourse;
	AudioSource trigSourse;
	AudioSource battleSourse;
	AudioSource WLSourse;

	void Awake()
	{
		if (current == null)
		{
			current = this;

			DontDestroyOnLoad(this.gameObject);

			tittleSourse = gameObject.AddComponent<AudioSource>();
			rollSourse = gameObject.AddComponent<AudioSource>();
			charaSourse = gameObject.AddComponent<AudioSource>();
			trigSourse = gameObject.AddComponent<AudioSource>();
			battleSourse = gameObject.AddComponent<AudioSource>();
			WLSourse = gameObject.AddComponent<AudioSource>();

			roll_R_Sourse = gameObject.AddComponent<AudioSource>();

			//Playtittle();
		}
	}

	public static void Playtittle()
    {
		current.rollSourse.Stop();
		current.battleSourse.Stop();
		current.tittleSourse.clip = current.tittleclip;
		current.tittleSourse.loop = true;
		current.tittleSourse.Play();
	}

	public static void Playroll()
	{
		current.tittleSourse.Stop();
		current.battleSourse.Stop();
		current.rollSourse.clip = current.rollclip;
		current.rollSourse.loop = true;
		current.rollSourse.volume = 0.086f;
		current.rollSourse.Play();
	}

    public static void PlayRollV()
    {
        current.roll_R_Sourse.clip = current.rollplayerClip;
        Debug.Log("Video has play");
        current.roll_R_Sourse.Play();
    }

    public static void Playcharactor()
	{
		current.charaSourse.clip = current.charactor[PlayerPrefs.GetInt("First roll")];
		Debug.Log("charactor:" + (PlayerPrefs.GetInt("First roll")+1));
		current.charaSourse.Play();
	}

	public static void Playsword()
	{
		current.trigSourse.clip = current.swordClip;
		current.trigSourse.Play();
	}

	public static void Playgun()
	{
		current.trigSourse.clip = current.gunClip;
		current.trigSourse.Play();
	}

	public static void Playtrigger()
	{
		current.trigSourse.clip = current.trigger;
		current.trigSourse.Play();
	}

	public static void Playbattle()
	{
		int i = Random.Range(0, 3);
		Debug.Log("music i:" + i);


		current.tittleSourse.Stop();
		current.rollSourse.Stop();
		current.battleSourse.clip = current.battle_theme[i];
		current.battleSourse.volume = 0.5f;
		current.battleSourse.loop = true;
		current.battleSourse.Play();
	}

	public void VideoD()
    {
		current.battleSourse.volume = 0.01f;
    }

	public void VideoR()
	{
		current.battleSourse.volume = 0.5f;
	}

	public void Win()
	{
		//current.battleSourse.Stop();
		current.WLSourse.clip = current.WinClip;
		current.WLSourse.Play();
	}

	public static void Lost()
	{
		//current.battleSourse.Stop();
		current.WLSourse.clip = current.LostClip;
		current.WLSourse.Play();
	}


	void Update()
    {
		//if (!current.battleSourse.isPlaying)
		//{
		//	i++;
		//	Debug.Log("music i:" + i);
		//	current.battleSourse.clip = current.battle_theme[i];
		//	current.battleSourse.Play();
		//}
		//if (i > 2)
		//{
		//	i = 0;
		//}
	}




	public void ChangeValue(float audio_volue) //設定背景音樂控制
    {
        //aso.volume = audio_volue;
    }

}
