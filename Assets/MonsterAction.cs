using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAction : MonoBehaviour
{
    private float scale;
    private float minScale = 150;
    private float maxScale = 170;
    private string status;

    // Start is called before the first frame update
    void Start()
    {float x = Random.Range(-8, 8);
     this.gameObject.transform.position = new Vector3(x, 0, 140);

     scale = minScale;
     status = "up";
    }

    // Update is called once per frame
    void Update()
    {
      this.gameObject.transform.Translate(0, 0, 1);

      if(status == "up"){
          scale += 8;
          if(scale >= maxScale){
              scale = maxScale;
              status = "down";
          }
      }else{
             scale -= 8;
             if(scale <= minScale){
                 scale = minScale;
                 status = "up";
             }
      }
      this.gameObject.transform.localScale = new Vector3(scale, scale, scale);
      if(this.gameObject.transform.position.z < 50){
          Destroy(this.gameObject);
      }
    }
}
