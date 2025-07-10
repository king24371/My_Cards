using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager Vcurrent;

	public VideoPlayer H_player;
	public AudioSource Audio;

	[Header("變身影像")]
	public VideoClip DenO_H_clip;
	public VideoClip DenO_S_H_clip;
	public VideoClip Ghost_B_H_clip;
	public VideoClip Ghost_M_H_clip;
	public VideoClip Build_RR_H_clip;
	public VideoClip Build_TT_H_clip;
	public VideoClip Build_G_H_clip;
	public VideoClip Saber_C_H_clip;
	public VideoClip Saber_DK_H_clip;

	public VideoClip Evol_H_clip;
	public VideoClip Evol_M_H_clip;
	public VideoClip Jadrg_H_clip;

	[Header("必殺影像")]
	public VideoClip DenO_A_clip;
	public VideoClip DenO_S_A_clip;
	public VideoClip Ghost_B_A_clip;
	public VideoClip Ghost_M_A_clip;
	public VideoClip Build_RR_A_clip;
	public VideoClip Build_TT_A_clip;
	public VideoClip Build_G_A_clip;
	public VideoClip Saber_C_A_clip;
	public VideoClip Saber_DK_A_clip;

	public VideoClip Evol_A_clip;
	public VideoClip Evol_M_A_clip;
	public VideoClip Jadrg_A_clip;

	//[Header("抽取BGM")]
	//public AudioClip rollclip;

	public int i;



	void Awake()
	{
		if (Vcurrent == null)
		{
			Vcurrent = this;

			//DontDestroyOnLoad(this.gameObject
			//Playtittle();

			//H_player = gameObject.AddComponent<VideoPlayer>();

		}
	}

	void Start()
	{
		
	}




	public void ChangeValue(float audio_volue) //設定背景音樂控制
    {
        //aso.volume = audio_volue;
    }

}
