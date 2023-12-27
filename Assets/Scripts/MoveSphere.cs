using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    bool logMode = true;
    string logText = null;
    string pathToBallMoveLogFile = null;
    // Start is called before the first frame update
    void Start()
    {
        string[] args = Environment.GetCommandLineArgs();
        for(int i=0; i < args.Length; i++)
        {
            if(args[i].Contains("-logMode"))
            {
                logMode = true;
                if(args[i+1].Contains(":/") || args[i+1].Contains(":\\"))
                {
                    pathToBallMoveLogFile = args[i+1];
                    i += 2;
                }
                else
                {
                    i++;
                }
            }
        }
        StartCoroutine(MoveSphereInX());
        StartCoroutine(MoveSphereInY());
    }

    void Update()
    {
        if(transform.position.x >= 2 && transform.position.y >= 2)
        {
            Application.Quit();
        }
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
            if(logMode)
            {
                logText += $"\n[DEBUG] {transform.position}";
                File.WriteAllText(pathToBallMoveLogFile, logText);
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
