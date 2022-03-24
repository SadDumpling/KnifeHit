using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool inBeam = false;
    private Collider2D knifeColl;
    private KnifesInStock knifesInStock;
    private GameOver gameOver;
    public bool startKnife = false;
    private Vector3 beamVector;
    LevelMaster levelNaster;

    void Awake()
    {
        beamVector = new Vector3(0, 2.5f, 0);
        rb2d = GetComponent<Rigidbody2D>();
        knifeColl = GetComponent<Collider2D>();
        knifesInStock = FindObjectOfType<KnifesInStock>();
    }
    private IEnumerator AppleDestroy(GameObject apple)
    {
        yield return new WaitForSeconds(1);
        Destroy(apple);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beam" && !GameOver.gameOver)
        {
            inBeam = true;
            GameObject target = collision.gameObject;
            rb2d.velocity = Vector2.zero;
            transform.parent = collision.transform;
            if (!startKnife)
            {
                knifesInStock.KnifeStockDecrease();
                Vibration.VibratePop();
            }
        }
        if (collision.gameObject.tag == "BeamBoom" && BeamBoom.beamBoom)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddTorque(Random.Range(80, 300));
            int tempXVel = beamVector.x < transform.position.x ? Random.Range(2, 5) : Random.Range(-5, -2);
            int tempYVel = beamVector.y < transform.position.y ? Random.Range(2,4) : Random.Range(1, 3);
            rb2d.velocity = new Vector2(tempXVel, tempYVel);
            rb2d.gravityScale = 1;
            GameObject target = collision.gameObject;
            transform.parent = collision.transform;
        }
        if (collision.gameObject.tag == "Knife" && collision.gameObject.GetComponent<Knife>().inBeam == true && !inBeam && !BeamBoom.beamBoom)
        {
            gameOver = FindObjectOfType<GameOver>();
            rb2d.velocity = Vector2.zero;
            rb2d.gravityScale = 1;
            Destroy(knifeColl);
            rb2d.AddTorque(270);
            Destroy(knifeColl);
            Vibration.VibratePeek();
            gameOver.Lose();
        }
        if (collision.gameObject.tag == "Apple" && !BeamBoom.beamBoom)
        {
            var collrb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            collrb2d.gravityScale = 1;
            collrb2d.AddTorque(270);
            StartCoroutine(AppleDestroy(collision.gameObject));
            collision.gameObject.transform.parent = null;
            var anim = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("Destroy", true);
            var coll = collision.gameObject.GetComponent<Collider2D>();
            Destroy(coll);
            levelNaster = FindObjectOfType<LevelMaster>();
            levelNaster.applesScore++;
            var ui = FindObjectOfType<UI>();
            ui.UpdateUI();
        }
    }       
}
