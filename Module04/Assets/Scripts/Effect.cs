
using UnityEngine;
using UnityEngine.UI;


public class Effect : MonoBehaviour
{
    // Start is called before the first frame update
    private Image image = null;
    private float alpha;
    [SerializeField]
    private GameObject player;
    private bool isPlayerDead = false;
    [SerializeField]
    private GameObject playerRef;
    private Vector3 playerPos;
    void Start()
    {
        alpha = 0;
        image = GetComponent<Image>();
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha >= 1)
        {
            player = Instantiate(playerRef, playerPos, Quaternion.identity);
            print("alfa is 1");
        }
        if ((player != null && player.GetComponent<PlayerController>().Hp <= 0) || player == null)
        {
            isPlayerDead = true;

        }
        else
        {
            isPlayerDead = false;
        }
        if (isPlayerDead)
        {
            image.color = new Color(0,0,0,alpha);
            if (alpha < 1)
            {
                alpha += Time.deltaTime / 4;
            }
        }
        else
        {
            image.color = new Color(0,0,0,alpha);
            if (alpha > 0)
            {
                alpha -= Time.deltaTime / 4;
            }
        }
    }
}
