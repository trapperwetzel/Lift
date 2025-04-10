using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILiftAnimationStrategy 
{
    void PlayAnimation(Animator animator, IExerciseMiniGame aMiniGame);
}
