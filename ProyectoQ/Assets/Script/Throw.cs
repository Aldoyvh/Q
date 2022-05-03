using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [Header("TeacherThrower")]
    public GameObject Projectile;
    public float nextShot;
    public Transform parent;
    public float fireRate;
    public IEnumerator ieInstatiate;

   
    void OnEnable()
    {
        InvokeRepeating("InstatiateFireball", fireRate, nextShot);
        //ieInstatiate= IEInstatiateFireballs(nextShot);
        //StartCoroutine(ieInstatiate);
    }

    private void OnDisable()
    {
        CancelInvoke();
        StopAllCoroutines();   
    }

    IEnumerator IEInstatiateFireballs(float _nextshot)
    {
        yield return new WaitForSeconds(_nextshot);
        InstatiateFireball();
        StartCoroutine(IEInstatiateFireballs(_nextshot));
    }

    void InstatiateFireball()
    {
        GameObject go = Instantiate(Projectile, parent);
        go.transform.rotation = Quaternion.identity;
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<Object>().speedMovement *= -1;
        go.GetComponent<Object>().SetUp();
    }
}
