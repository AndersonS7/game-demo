using UnityEngine;

public class EffectParallax : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetString("Start") == "start")
        {
            if (!PlayerController.isWall)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.position += new Vector3(-0.55f * Time.deltaTime, 0, 0);
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.position += new Vector3(0.55f * Time.deltaTime, 0, 0);
                }
            }
        }
    }
}
