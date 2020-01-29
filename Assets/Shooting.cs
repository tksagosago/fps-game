using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shotSpeed;
    public int shotCount = 30;
    private float shotInterval;
    public float score = 0;
    public float totalScore = 0;
    public float totalTime = 30;
    GameObject timeText;
    Text time_text;
    bool gameOverFlg;
    GameObject ResultPanel;
    Text result_text;


    void Awake(){
        ResultPanel = GameObject.Find("ResultPanel");
        ResultPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("TIME");
        time_text = timeText.GetComponent<Text>();

        gameOverFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && totalTime != 0)
        {
 
            shotInterval += 1;
 
            if (shotInterval % 5 == 0 && shotCount > 0)
            {
                shotCount -= 1;
 
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);
 
 
                Destroy(bullet, 3.0f);
            }
 
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 30;
        }

        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            time_text.text = "TIME  " + totalTime.ToString("f2");

        } else if (gameOverFlg == false) {
            gameOverFlg = true;
            totalTime = 0;
            time_text.text = "TIME  0";
            ResultPanel.SetActive(true);
            result_text = GameObject.Find("ResultText").GetComponent<Text>();
            result_text.text = "TOTAL SCORE  " + Mathf.RoundToInt(totalScore).ToString("d6");
        }
    }
}
