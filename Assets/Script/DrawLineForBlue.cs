using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineForBlue : DrawLine
{

    public Animator _BlueAnimator;
    public Transform _RedTransform;

    void Start()
    {
        lastSpawnPosition = transform.position;
        lastPostitionIndex = 1;
        StartCoroutine(DrawALine());   
    }


    public new IEnumerator DrawALine()
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
                {
                    float previousSpeed = _BlueAnimator.GetFloat("GameSpeed");
                    _BlueAnimator.SetFloat("GameSpeed", 0.0f);
                    yield return new WaitUntil(() => (_linerenderer.GetPosition(indexBegin).y < _RedTransform.position.y - 5f));
                    RemoveLines();
                    _BlueAnimator.SetFloat("GameSpeed", previousSpeed);


                }

            }
            yield return null;



        }
    }
}