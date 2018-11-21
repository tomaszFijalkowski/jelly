using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private ParticleSystem leaves;

    [SerializeField] private Animation treeAnimation;

    private void OnMouseEnter()
    {
        ShakeTree();
    }

    private void OnMouseExit()
    {
        ShakeTree();
    }

    private void ShakeTree()
    {
        if (!treeAnimation.IsPlaying("TreeShake") && !GameController.GamePaused)
        {
            leaves.Emit(Random.Range(2, 4));
            treeAnimation.Play("TreeShake");
            treeAnimation.PlayQueued("TreeIdle");
        }
    }
}