using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILiftObserver
{
   

    void OnLiftStarted();
    void OnCommandIssued();
    void OnLiftCompleted();
    void OnSetCompleted();
    void OnLiftFailed();
}
    

public struct LiftResult
{
    public string QualityOfLift;
    public int RequiredNumberOfReps;
    public int RepsCompleted;
    public float LiftTime;
    
    public LiftResult(string qualityoflift, int requirednumberofreps, int repscompleted, float lifttime)
    {
        QualityOfLift = qualityoflift;
        RequiredNumberOfReps = requirednumberofreps;
        RepsCompleted = repscompleted;
        LiftTime = lifttime;
    }
}




