using System;
using Xamarin.Forms;

namespace learnSpanish.Behavior.EntryBehavior
{
    public class ConfirmPasswordBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EmailValidatorBehavior), false,
                BindingMode.TwoWay);

        public static readonly BindableProperty CompareToEntryProperty =
            BindableProperty.Create(nameof(CompareToEntry), typeof(Entry), typeof(EmailValidatorBehavior), null,
                BindingMode.TwoWay);

        public bool IsValid
        {
            get => (bool) GetValue(IsValidProperty);
            private set => SetValue(IsValidProperty, value);
        }

        public Entry CompareToEntry
        {
            get => (Entry) GetValue(CompareToEntryProperty);
            private set => SetValue(CompareToEntryProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
            bindable.BindingContextChanged += BindableOnBindingContextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
            bindable.BindingContextChanged -= BindableOnBindingContextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var password = CompareToEntry.Text;
            var confirmPassword = e.NewTextValue;
            var confirmPasswordEntry = sender as Entry;

            if (password != null) IsValid = !string.IsNullOrEmpty(password) && password.Equals(confirmPassword);
            if (confirmPasswordEntry != null)
                confirmPasswordEntry.BackgroundColor = IsValid ? Color.Default : Color.Red;
        }

        private void BindableOnBindingContextChanged(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            BindingContext = entry?.BindingContext;
        }
    }
}