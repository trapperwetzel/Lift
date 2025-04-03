using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExerciseMiniGame
{
    void StartExercise();

    void DoExercise();

    bool IsSuccessful(float timer);

    void EndExercise(); 
   
}


