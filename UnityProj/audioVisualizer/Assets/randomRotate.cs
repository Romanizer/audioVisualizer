using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRotate : MonoBehaviour
{
    Quaternion qto;
    [SerializeField] bool Isenabled;
    [SerializeField] float rotateSpeed;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] float minMag;
    [SerializeField] float maxMag;
    float nextTime;
    float timer = 0f;
    



    // Start is called before the first frame update
    void Start()
    {
        qto = Quaternion.Euler(randVec(randVector(), Random.Range(minMag, maxMag)));
        nextTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Isenabled) return;

        //if (qto == null)
        //    qto = Quaternion.Euler(randVec(randVector(), Random.Range(minMag, maxMag)));

        timer += Time.deltaTime;

        if (timer > nextTime)
        {
            qto = Quaternion.Euler(randVec(randVector(), Random.Range(minMag, maxMag)));
            timer = 0f;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, qto, Time.deltaTime * rotateSpeed);
    }

    Vector3 randVec(Vector3 _dir, float _mag)
    {
        return new Vector3(
            _dir.x * Random.Range(- _mag, _mag),
            _dir.y * Random.Range(- _mag, _mag),
            _dir.z * Random.Range(- _mag, _mag));
    }

    Vector3 randVector()
    {
        return new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)).normalized;
    }
}
