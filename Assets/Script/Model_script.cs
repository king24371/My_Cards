using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardBase", menuName = "Create new cardBase")]
public class Model_script : ScriptableObject {

    [SerializeField]
    public List<data_card> listCard;
	

}
