using UnityEngine;

public class MenuButtonInvoker : MonoBehaviour {
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void OnButtonPressed()
    {
        if (command != null)
        {
            command.Execute();
        }
    }
}
