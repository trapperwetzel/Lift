using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand {
    void Execute();
    void Exit();
}

// Invoker:
// This is what will invoke or execute the lift.

// The command pattern will use a queue, to chain actions. 
// This will be useful for our "Powerlifts" 
// We can do this for the Squat, and Bench Press. 