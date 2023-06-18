using UnityEngine;
using UnityTask = System.Threading.Tasks.Task;

public class Bone : MonoBehaviour
{
    public int boneNum { get; set; }
    private Rigidbody rb;
    

    private void Awake()
    {
        Physics.gravity *= 1.2f;
        rb = GetComponent<Rigidbody>();
    }

    public async UnityTask Rotate()
    {
        EnableColliders();
        transform.rotation = Quaternion.identity;
        rb.AddForce(-transform.up * 5000);
        rb.AddTorque(Random.Range(-50000000,50000000),Random.Range(-50000000,50000000),Random.Range(-50000000,50000000));
    }
    
    public void DesableColliders()
    {
        for (int i = 1; i < 7; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }
    
    public void EnableColliders()
    {
        for (int i = 1; i < 7; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
}
