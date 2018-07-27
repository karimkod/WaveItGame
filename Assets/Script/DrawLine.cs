using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer _linerenderer;
    public float differntialDistanceToSpawn;
    protected Vector3 lastSpawnPosition;
    protected int lastPostitionIndex;
    public int numberOptimize;
    public int indexBegin = 30;

	// Use this for initialization
	void Start ()
    {
        lastSpawnPosition = transform.position;
        lastPostitionIndex = 1;
        StartCoroutine(DrawALine());


    }


    public void RemoveLines()
    {

        int newNumPos = lastPostitionIndex - indexBegin;

        for (int j = indexBegin, i = 0; j <= lastPostitionIndex; j++, i++)
        {
            _linerenderer.SetPosition(i, _linerenderer.GetPosition(j));
        }
        _linerenderer.positionCount = newNumPos;
        lastPostitionIndex = newNumPos - 1;

    }

    public IEnumerator DrawALine()
    {
        while (true)
        {
            if (Vector3.Magnitude(transform.position - lastSpawnPosition) > differntialDistanceToSpawn)
            {
                _linerenderer.positionCount++;
                lastPostitionIndex++;

                lastSpawnPosition = transform.position;
                _linerenderer.SetPosition(lastPostitionIndex, lastSpawnPosition);
                if (lastPostitionIndex >= numberOptimize)
                    RemoveLines();

            }
            yield return null;
        }
    }
      

}
