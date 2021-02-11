using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float offset;
    private Transform target;
    private Vector3 posTarget;

    private void Start()
    {
        if (!target)
        {
            target = FindObjectOfType<Hero>().transform;//todo вслучае вдвух трёх
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            
            posTarget = target.position;
            posTarget.z = -10f;
            PushButton();
        }
    }

    public void PushButton()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x + offset < posTarget.x)
            {
                MoveToTarget();
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > posTarget.x + offset)
            {
                MoveToTarget();
            }
        }
    }

    public void MoveToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, posTarget, Time.deltaTime);
    }
}