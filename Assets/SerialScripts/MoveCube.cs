using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        transform.localPosition = new Vector3(Mathf.Sin(Time.time * speed) * 10f, 0, 0);
    }
}
