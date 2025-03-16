using UnityEngine;

public class ButtonJump : MonoBehaviour
{
    public void OnJumpButtonPressed()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null )
        {
            PlayerController controller = player.GetComponent<PlayerController>();
            if ( controller != null )
            {
                controller.Jump();
            }
        }    
    }    
}
