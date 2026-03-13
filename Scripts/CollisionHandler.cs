using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 [SerializeField] GameObject destroyedVFX;
   private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedVFX, transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
   

    private void OnTriggerEnter(Collider other)
    {
         Instantiate(destroyedVFX, transform.position,Quaternion.identity);
        Destroy(this.gameObject);
        Debug.Log(other.name);
    }

}
