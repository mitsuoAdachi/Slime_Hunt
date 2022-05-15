using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponSlash : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var targetMob = other.gameObject.transform.root.gameObject.GetComponent<MobStatus>();
            //if (null == targetMob) return;
            targetMob.Damage(Random.Range(1, 3));
        }
    }
}
