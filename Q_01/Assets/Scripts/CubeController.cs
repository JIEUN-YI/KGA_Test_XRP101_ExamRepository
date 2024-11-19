using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get; private set; }

    public void SetPosition(Vector3 SetPoint)
    {
        transform.position = SetPoint;
    }

    /*
    public void SetPosition()
    {
        transform.position = SetPoint;
    }*/
}
