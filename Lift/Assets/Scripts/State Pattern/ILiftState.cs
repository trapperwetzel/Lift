using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILiftState 
{
    public void EnterState(IExerciseMiniGame exercise);
    
    public void UpdateState(IExerciseMiniGame exercise);

    public void ExitState(IExerciseMiniGame exercise);
    
}
