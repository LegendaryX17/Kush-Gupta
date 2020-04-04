using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour {

    public GameObject enemyBody;
    public float health = 100f;

    public void HeadShotDamage(float x){
        health -= x * 10;
        if (health <= 0)
        {
            Destroy(enemyBody);
        }
    }
}
