using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILiftState 
{
    public void EnterState(IExerciseMiniGame MiniGame);
    
    public void UpdateState(IExerciseMiniGame MiniGame);


    public void ExitState(IExerciseMiniGame MiniGame);
    
}
