using UnityEngine;

public class KnifeMaster : MonoBehaviour
{
    [SerializeField] private float power = 25f;
    private float tapTime;
    [SerializeField] private float pauseTime = 0.35f;
    public GameObject knifePrefab;
    private GameObject newKnife;
    private bool knifeFly = false;
    private KnifesInStock knifesInStock;
    void Start()
    {
        knifesInStock = FindObjectOfType<KnifesInStock>();
        tapTime = Time.time;
        newKnife = Instantiate(knifePrefab);
    }
    private void KnifeFly()
    {
        var tempRB2D = newKnife.GetComponent<Rigidbody2D>();
        tempRB2D.velocity = new Vector2(tempRB2D.velocity.x, power);
    }
    void Update()
    {
        if (Input.touchCount > 0 && !knifeFly)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                knifeFly = true;
                tapTime = Time.time;
                KnifeFly();
                newKnife = null;
            }
        }
        if (tapTime + pauseTime < Time.time && knifeFly && knifesInStock.numbersOfKnifes > 0 && !GameOver.gameOver)
        {
            knifeFly = false;
            newKnife = Instantiate(knifePrefab);
        }
    }
}
