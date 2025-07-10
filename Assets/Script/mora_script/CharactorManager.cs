using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CharactorManager : MonoBehaviour
{
    public Model_script model;
    public data_card lion;
    public data_card panda;

    // Use this for initialization
    void Start()
    {
        lion = Instantiate( model.listCard[3]);
        panda = Instantiate( model.listCard[1]);

        print(string.Format($"Lion-Def:{lion.Def}"));
        lion.def += 5;
        print(string.Format($"Lion-Def:{lion.Def}"));
        lion.Def -= 7;
        print(string.Format($"Lion-Def:{lion.Def}"));

        print(string.Format($"Panda-Ep:{panda.EP},Hp: {panda.HP}"));
        panda.EP += 2;
        print(string.Format($"Panda-Ep:{panda.EP}"));
        panda.EP -= 10;
        panda.HP -= 20;
        print(string.Format($"Panda-Ep:{panda.EP},Hp: {panda.HP}"));

        lion.X();
        panda.X();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
