using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletAction : MonoBehaviour
{
    GameObject scoreText;
    Text score_text;
    private float point = 1;
    GameObject Shooting;
    Shooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("SCORE");
        score_text = scoreText.GetComponent<Text>();

        Shooting = GameObject.Find("Shooting");
        shooting = Shooting.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<ParticleSystem>().Play();
            this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            Destroy(this.gameObject,1);

            shooting.score += point;
            shooting.totalScore = shooting.score*300;
            score_text.text = "SCORE  " + shooting.totalScore.ToString();
        }
    }
}
