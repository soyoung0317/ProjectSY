using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D target;
    private Rigidbody2D myRigid;
    private SpriteRenderer mySpriter; 

    public bool isAlive;
    public float speed;

    [SerializeField] float repositionDistance = 10f;

    private void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        mySpriter = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            target = player.GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (!isAlive) return;

        Vector2 dirVec = target.position - myRigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        myRigid.MovePosition(myRigid.position + nextVec);
    }
    private void Update()
    {
        if (!isAlive) return;

        float dist = Vector2.Distance(transform.position, target.position);
        bool needReposition = dist > repositionDistance;

        if (needReposition)
        {
            Reposition();
            needReposition = false;
            return;
        }
    }

    private void LateUpdate()
    {
        if (!isAlive) return;

        mySpriter.flipX = target.position.x < myRigid.position.x;
    }

    private void Reposition()
    {
        if (!isAlive) return;

        Vector2 dir = (myRigid.position - (Vector2)target.position).normalized;
        Vector2 repositionPos = (Vector2)target.position + dir * repositionDistance * 0.7f;

        myRigid.position = repositionPos;
    }
    public bool GetIsAlive()
    {
        return isAlive;
    }
}
