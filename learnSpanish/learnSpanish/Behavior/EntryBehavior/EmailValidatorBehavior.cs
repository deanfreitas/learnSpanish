using System.Text.RegularExpressions;
using learnSpanish.Constants;
using Xamarin.Forms;

namespace learnSpanish.Behavior.EntryBehavior
{
    public class EmailValidatorBehavior : Behavior<Entry>
    {
        static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EmailValidatorBehavior), false);

        public bool IsValid
        {
            get => (bool) GetValue(IsValidProperty);
            private set => SetValue(IsValidProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += BindableOnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= BindableOnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;
            var emailEntry = sender as Entry;

            IsValid = Regex.IsMatch(email, ConstantsView.EmailRegex, RegexOptions.IgnoreCase) &&
                      !string.IsNullOrEmpty(email);
            if (emailEntry != null) emailEntry.BackgroundColor = IsValid ? Color.Default : Color.Red;
        }
    }
}