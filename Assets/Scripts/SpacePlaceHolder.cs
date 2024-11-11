using UnityEngine;

[CreateAssetMenu(fileName = "SpacePlaceHolder", menuName = "Scriptable Objects/SpacePlaceHolder")]
public class SpacePlaceHolder : ScriptableObject
{
    //will receive instructions that determines what space will be spawned

    public GameObject PrefabtoSpawn;

    private GameObject CurrPrefab;

    public void OnEnable()
    {
        if(CurrPrefab != null)
        {
            CurrPrefab.SetActive(true);
        }
        else
        {
            Instantiate(PrefabtoSpawn);
        }
        
    }

    public void SetSpace(GameObject WhatSpaceAmI)
    {
        CurrPrefab = WhatSpaceAmI;
    }



    public void OnDisable()
    {
        CurrPrefab.SetActive(false);
    }


}
