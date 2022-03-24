using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemsInBeam : MonoBehaviour
{
    public AppleData appleData;
    public GameObject knifePrefab;
    public GameObject applePrefab;
    private float yAppleOffset = -1.568f;
    private float yKnifeOffset = -0.995f;
    private float zKnifeOffset = 2;
    private BeamRotation beamRotation;
    void Start()
    {
        beamRotation = FindObjectOfType<BeamRotation>();
        ItemCreator();
    }
    private void ItemCreator()
    {
        AppleCreator();
        beamRotation.InstantTurn();
        for (int i = 0; i < Random.Range(1,4); i++)
        {
            KnifeCreator();
            beamRotation.InstantTurn();
        }
    }
    private void KnifeCreator()
    {
        var tempPos = transform.position;
        tempPos.y += yKnifeOffset;
        tempPos.z += zKnifeOffset;
        knifePrefab.GetComponent<Knife>().startKnife = true;
        ItemInstantiator(knifePrefab, tempPos, 0);
        knifePrefab.GetComponent<Knife>().startKnife = false;
    }
    private void AppleCreator()
    {
        if(appleData.AppleChance >= Random.Range(1,101))
        {
            var tempPos = transform.position;
            tempPos.y += yAppleOffset;
            ItemInstantiator(applePrefab, tempPos, 180);
        }
    }
    private void ItemInstantiator(GameObject item,Vector3 tempPos,int zRotation)
    {
        var thisItem = Instantiate(item, tempPos, new Quaternion(0, 0, 0, 0), transform.parent);
        thisItem.transform.rotation *= Quaternion.Euler(0, 0, zRotation);
        thisItem.transform.parent = transform;

    }
}
