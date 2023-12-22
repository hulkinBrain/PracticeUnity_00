using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveSphereInX());
        StartCoroutine(MoveSphereInY());
    }

    IEnumerator MoveSphereInX()
    {
        while(transform.position.x < 2)
        {
            transform.position += new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
        
    }

    IEnumerator MoveSphereInY()
    {
        while(transform.position.y < 2)
        {
            transform.position += new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
