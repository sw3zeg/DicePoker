using System.Collections;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public int boneNum { get; set; }
    private System.Random rand = new System.Random();

    private void Awake()
    {
        Physics.gravity *= 1.3f;
    }

    public void Rotate()
    {
        StartCoroutine(Rotation());
    }

    private IEnumerator Rotation()
    {
        transform.Rotate(new Vector3(rand.Next(3) * 90, rand.Next(3) * 90, rand.Next(3) * 90));

        float elepsedTiem = 0;

        while (elepsedTiem < 1.7f)
        {
            transform.Rotate(rand.Next(3)/1, rand.Next(3) / 1, rand.Next(3) / 1);
            elepsedTiem += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

}
