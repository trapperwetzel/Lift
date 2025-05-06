/*
using TinyGiantStudio.Modules;
using TinyGiantStudio.Text;
using System;

public interface IMenuButton {
    void SetLabel(string label);
    void SetOnClick(Action action);
}

public class TGButtonAdapter : IMenuButton {
    private readonly MText_UI_Button button;

    public TGButtonAdapter(MText_UI_Button btn) => button = btn;

    public void SetLabel(string label) => button.text = label;

    public void SetOnClick(Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => action());
    }
}
*/