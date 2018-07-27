using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGenerator : MonoBehaviour
{
    public float differntialDistanceToSpawn;
    private Vector3 lastSpawnPosition;
    public GameObject ColliderAsset;
    public int numberOfColliderAsset;
    public static Queue<GameObject> ColliderAssets; 
    public Vector3 offset;
    public Animator _animator; 
    // Use this for initialization
    void Start()
    {
        lastSpawnPosition = transform.position; 
        ColliderAssets = new Queue<GameObject>(); 
        for (int i = 0; i < numberOfColliderAsset; i++)
        {
            ColliderAssets.Enqueue(Instantiate(ColliderAsset)); 
        }
        StartCoroutine(SpawnCollider());

    }


    IEnumerator SpawnCollider()
    {
        while(true)
        {

            if ((Vector3.Magnitude(transform.position - lastSpawnPosition) > differntialDistanceToSpawn))
            {
                if (ColliderAssets.Count == 0)
                {
                    float ActualSpeed = _animator.GetFloat("GameSpeed");
                    _animator.SetFloat("GameSpeed", 0.0f);
                    yield return new WaitUntil(() => (ColliderAssets.Count > 0));
                    getCollider();
                    _animator.SetFloat("GameSpeed", ActualSpeed);

                }
                else
                {
                    getCollider();
                }
            }
            yield return null;

        }

    }


    void getCollider()
    {

        GameObject instantiated;
        instantiated = ColliderAssets.Dequeue();
        instantiated.transform.position = transform.position + offset;
        instantiated.transform.rotation = Quaternion.identity;
        instantiated.SetActive(true);
        lastSpawnPosition = transform.position;
        return;
    }

    
}
