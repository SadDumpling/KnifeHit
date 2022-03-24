using UnityEngine;

public class BeamRotation : MonoBehaviour
{
    public int speed;
    public float startTime;
    public float rotationTime;

    private void Start()
    {
        speed = 1;
        startTime = Time.time;
    }
    private void FixedUpdate()
    {
        if (startTime + rotationTime < Time.time)
        {
            ChangeRotation();
        }
        transform.Rotate(new Vector3(0, 0, speed));
    }
    private void ChangeRotation()
    {
        int tempSpeedChange = Random.Range(1, 3);
        if (Random.Range(0, 10) == 0) tempSpeedChange = 0;
        if (speed < 0) speed = tempSpeedChange;
        else speed = -tempSpeedChange;
        int tempRotChange;
        if (tempSpeedChange == 0) tempRotChange = 2;
        else tempRotChange = Random.Range(4, 8);
        rotationTime += tempRotChange;
    }
    public void InstantTurn()
    {
        var randomRotation = Random.Range(20, 85);
        transform.Rotate(new Vector3(0, 0, randomRotation));
    }
    public void RandomRotation()
    {
        var randomRotation = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, 0, randomRotation));
    }

}
