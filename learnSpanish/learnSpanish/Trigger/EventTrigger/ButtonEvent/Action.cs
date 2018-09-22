using Xamarin.Forms;

namespace learnSpanish.Trigger.EventTrigger.ButtonEvent
{
    public class Action : TriggerAction<Button>
    {
        protected override async void Invoke(Button button)
        {
            await button.ScaleTo(0.95, 50, Easing.CubicOut);
            await button.ScaleTo(1, 50, Easing.CubicIn);
        }
    }
}