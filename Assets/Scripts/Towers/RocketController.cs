using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] float speed;

    private Transform Target;
	
    public void Seek ( Transform _Target)
    {
        Target = _Target;
    }
    void Update ()
    {
		if(Target == null || Target.position.x <= -4)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = Target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}
}
