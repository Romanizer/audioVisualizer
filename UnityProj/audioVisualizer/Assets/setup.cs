using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setup : MonoBehaviour
{
    public GameObject[,,] AllBalls;
    [SerializeField] GameObject Sphere;
    [SerializeField] int CubeSize;

    // Start is called before the first frame update
    void Awake()
    {
        AllBalls = new GameObject[CubeSize, CubeSize, CubeSize];

        for (int i = 0; i < CubeSize; i++) // X
        {
            for (int j = 0; j < CubeSize; j++)  //  Y
            {
                for (int k = 0; k < CubeSize; k++)  // Z
                {

                    Vector3 pos = new Vector3(transform.position.x + (i - ((CubeSize - 1f) / 2)) * (transform.localScale.x / CubeSize),
                        transform.position.y + (j - ((CubeSize - 1f) / 2)) * (transform.localScale.x / CubeSize),
                        transform.position.z + (k - ((CubeSize - 1f) / 2)) * (transform.localScale.x / CubeSize));
                    AllBalls[i, j, k] = Instantiate(Sphere, transform, true);
                    AllBalls[i, j, k].transform.position = pos;
                }
            }
        }
        Debug.Log(transform.position);
        Debug.Log(transform.localScale.x);
    }


}
