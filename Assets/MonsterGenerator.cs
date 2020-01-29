using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject slimeRedPrefab;
    private float counter;
    private float countLimit = 3;
    GameObject Shooting;
    Shooting shooting;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        Shooting = GameObject.Find("Shooting");
        shooting = Shooting.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting.totalTime > 0){
            counter += Time.deltaTime;
            if(counter >= countLimit){
            counter = 0;
            GameObject slimeRed = Instantiate(slimeRedPrefab) as GameObject;
            }
        }
        
    }
}
