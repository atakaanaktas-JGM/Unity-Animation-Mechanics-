using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
   private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedVFX, transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
