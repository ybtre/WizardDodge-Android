using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private float destroyVFX_Duration = 1f;

    [SerializeField] private Player myPlayer;


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 8){
            // DestroyVFX();
            Destroy(this.gameObject);
        }
    }

    // private void DestroyVFX(){
    //     GameObject explosion = Instantiate(destroyVFX, transform.position, transform.rotation);
    //     Destroy(explosion, destroyVFX_Duration);
    // }
}
