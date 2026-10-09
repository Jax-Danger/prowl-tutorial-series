// TUTORIAL pt18-01  New file: Assets/Scripts/GameMenu.cs
// Put this on an empty Game UI object. Start builds a canvas, a text line, and a button.
// CHECK: Escape, then click the button. The line flips. Enter the car and the button is still there.

using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Runtime.UI;
using Prowl.Vector;

public class GameMenu : MonoBehaviour
{
    TextComponent? _label;
    bool _open;
    bool _built;

    public override void Start()
    {
        if (_built || GameObject.Scene.IsNotValid())
            return;
        _built = true;

        // TUTORIAL pt18-02  GameCanvas lays out RectTransforms. It draws without an EventSystem.
        // EventSystem is what turns a click into UIButton.OnClick. One enabled EventSystem per scene.
        var canvasObject = new GameObject("Canvas");
        canvasObject.EnsureRectTransform();
        canvasObject.AddComponent<GameCanvas>();
        canvasObject.AddComponent<EventSystem>();

        var labelObject = new GameObject("Hint");
        labelObject.SetParent(canvasObject, false);
        RectTransform labelRect = labelObject.EnsureRectTransform();
        labelRect.AnchorMin = new Float2(0.5f, 0f);
        labelRect.AnchorMax = new Float2(0.5f, 0f);
        labelRect.Pivot = new Float2(0.5f, 0f);
        labelRect.SizeDelta = new Float2(360f, 32f);
        labelRect.AnchoredPosition = new Float2(0f, 76f);
        TextComponent label = labelObject.AddComponent<TextComponent>();
        label.Text = "Gate is shut";
        label.Size = 22;
        label.Alignment = TextAlignment.CenterMiddle;
        label.Color = new Color(1f, 1f, 1f, 1f);
        _label = label;

        // TUTORIAL pt18-03  UIImage is the graphic. UIButton.TargetGraphic is that image.
        // Sprite.LoadDefault(DefaultSprite.UIPanel) is the built-in panel. OnClick is a C# event.
        var buttonObject = new GameObject("Toggle");
        buttonObject.SetParent(canvasObject, false);
        RectTransform buttonRect = buttonObject.EnsureRectTransform();
        buttonRect.AnchorMin = new Float2(0.5f, 0f);
        buttonRect.AnchorMax = new Float2(0.5f, 0f);
        buttonRect.Pivot = new Float2(0.5f, 0f);
        buttonRect.SizeDelta = new Float2(220f, 44f);
        buttonRect.AnchoredPosition = new Float2(0f, 24f);

        UIImage image = buttonObject.AddComponent<UIImage>();
        image.Sprite = Sprite.LoadDefault(DefaultSprite.UIPanel);
        image.Color = new Color(0.15f, 0.35f, 0.55f, 1f);
        UIButton button = buttonObject.AddComponent<UIButton>();
        button.TargetGraphic = image;
        button.OnClick += Toggle;

        var captionObject = new GameObject("Caption");
        captionObject.SetParent(buttonObject, false);
        RectTransform captionRect = captionObject.EnsureRectTransform();
        captionRect.AnchorMin = Float2.Zero;
        captionRect.AnchorMax = new Float2(1f, 1f);
        captionRect.SizeDelta = Float2.Zero;
        captionRect.AnchoredPosition = Float2.Zero;
        TextComponent caption = captionObject.AddComponent<TextComponent>();
        caption.Text = "Toggle";
        caption.Size = 18;
        caption.Alignment = TextAlignment.CenterMiddle;
        caption.Color = new Color(1f, 1f, 1f, 1f);

        GameObject.Scene.Add(canvasObject);
    }

    void Toggle()
    {
        PhysicsGate? gate = FindGate();
        if (gate.IsValid())
            gate.ToggleDoor();

        _open = gate.IsValid() ? gate.IsOpen : !_open;
        if (_label.IsValid())
            _label.Text = _open ? "Gate is open" : "Gate is shut";
    }

    static PhysicsGate? FindGate()
    {
        if (Prowl.Runtime.Resources.Scene.Current.IsNotValid())
            return null;

        foreach (PhysicsGate? gate in Prowl.Runtime.Resources.Scene.Current.FindObjectsOfType<PhysicsGate>())
        {
            if (gate.IsValid())
                return gate;
        }
        return null;
    }
}
