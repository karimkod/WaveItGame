using UnityEngine;

public interface Movement
{

    void NextPoint();
    void Reset();
    Vector3 Current { get; set; }
}
