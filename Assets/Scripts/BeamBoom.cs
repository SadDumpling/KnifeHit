using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBoom : MonoBehaviour
{
    public GameObject[] woods;
    public GameObject beam;
    private Rigidbody2D rb2d;
    public static bool beamBoom = false;
    public void Boom()
    {
        beamBoom = true;
        Destroy(beam.gameObject.GetComponent<SpriteRenderer>());
        Destroy(beam.gameObject.GetComponent<Collider2D>());
        Destroy(beam.gameObject.GetComponent<Rigidbody2D>());
        Destroy(beam.gameObject.GetComponent<BeamRotation>());
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        if(apples != null)
        {
            for (int i = 0; i < apples.Length; i++)
            {
                ItemExplosion(apples[i], apples[i].gameObject.GetComponent<Rigidbody2D>());
            }            
        }
        for (int i = 0; i < woods.Length; i++)
        {
            woods[i].gameObject.SetActive(true);
            var rb2d = woods[i].gameObject.GetComponent<Rigidbody2D>();
            ItemExplosion(woods[i], rb2d);           
        }
        Vibration.VibratePeek();
    }
    private void ItemExplosion(GameObject gameObject,Rigidbody2D rb2d)
    {
        rb2d.AddTorque(Random.Range(5, 15));
        int tempXVel = beam.transform.position.x < gameObject.transform.position.x ? Random.Range(1, 3) : Random.Range(-3, -1);
        int tempYVel = beam.transform.position.y < gameObject.transform.position.y ? Random.Range(2, 5) : 1;
        rb2d.velocity = new Vector2(tempXVel, tempYVel);
        rb2d.gravityScale = 1;
    }
}
