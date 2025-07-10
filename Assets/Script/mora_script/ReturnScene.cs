//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ReturnScene : MonoBehaviour {

//	public static ReturnScene inst;
//	public GameObject obj;
//    public Button skip;

//	void Awake()
//    {
//		inst = this;
//    }

//	// Use this for initialization
//	void Start () {
//        skip.onClick.AddListener(Skip);
//	}
	
//	// Update is called once per frame
//	void Update () {
//        //if()
		
//	}

//	public IEnumerator PlayDenO_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayDenO_H();
//		yield return new WaitForSeconds(15.5f);
//		obj.SetActive(true);

//		AudioManager.current.VideoR();
//	}

//	public IEnumerator PlayDenO_S_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayDenO_S_H();
//		yield return new WaitForSeconds(13.5f);
//		obj.SetActive(true);

//		AudioManager.current.VideoR();
//	}

//	public IEnumerator PlayGhost_B_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayGhost_B_H();
//		yield return new WaitForSeconds(18.5f);
//		obj.SetActive(true);

//		AudioManager.current.VideoR();
//	}

//	public IEnumerator PlayGhost_M_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayGhost_M_H();
//		yield return new WaitForSeconds(21.5f);
//		obj.SetActive(true);

//		AudioManager.current.VideoR();
//	}

//	public IEnumerator PlayBuild_RR_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayBuild_RR_H();
//		yield return new WaitForSeconds(30.5f);
//		obj.SetActive(true);

//		AudioManager.current.VideoR();
//	}

//	public IEnumerator PlayBiuld_TT_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayBuild_TT_H();
//		yield return new WaitForSeconds(28.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayBuild_G_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayBuild_G_H();
//		yield return new WaitForSeconds(30.5f);
//		yield return new WaitForSeconds(3);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlaySaber_C_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlaySaber_C_H();
//		yield return new WaitForSeconds(24.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlaySaber_DK_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlaySaber_DK_H();
//		yield return new WaitForSeconds(30.5f);
//		yield return new WaitForSeconds(4);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}



//	public IEnumerator PlayEvol_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayEvol_H();
//		yield return new WaitForSeconds(9.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayEvol_M_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayEvol_M_H();
//		yield return new WaitForSeconds(31.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayJadrg_H()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayJadrg_H();
//		yield return new WaitForSeconds(19.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}


//	public IEnumerator PlayDenO_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayDenO_A();
//		yield return new WaitForSeconds(11.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayDenO_S_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayDenO_S_A();
//		yield return new WaitForSeconds(7.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayGhost_B_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayGhost_B_A();
//		yield return new WaitForSeconds(25.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayGhost_M_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayGhost_M_A();
//		yield return new WaitForSeconds(13.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayBuild_RR_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayBuild_RR_A();
//		yield return new WaitForSeconds(11.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayBiuld_TT_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayBuild_TT_A();
//		yield return new WaitForSeconds(17.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayBuild_G_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayBuild_G_A();
//		yield return new WaitForSeconds(16.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlaySaber_C_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlaySaber_C_A();
//		yield return new WaitForSeconds(14.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlaySaber_DK_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlaySaber_DK_A();
//		yield return new WaitForSeconds(12.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}



//	public IEnumerator PlayEvol_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayEvol_A();
//		yield return new WaitForSeconds(17.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayEvol_M_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayEvol_M_A();
//		yield return new WaitForSeconds(18.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//	public IEnumerator PlayJadrg_A()
//	{
//		obj.SetActive(false);
//		VideoManager.Vcurrent.PlayJadrg_A();
//		yield return new WaitForSeconds(19.5f);
//		obj.SetActive(true);

//		AudioManager.VideoR();
//	}

//    void Skip()
//    {
//        StopAllCoroutines();

//        obj.SetActive(true);
//        AudioManager.VideoR();
//    }
//}
