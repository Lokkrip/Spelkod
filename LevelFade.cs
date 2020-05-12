using UnityEngine;

public class LevelFade : MonoBehaviour
{
    public Animator animator;
 
    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void FadeToLevel (int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }

}
