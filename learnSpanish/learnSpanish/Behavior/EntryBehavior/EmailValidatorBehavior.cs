using System;
using System.Text.RegularExpressions;
using learnSpanish.Constants;
using Xamarin.Forms;

namespace learnSpanish.Behavior.EntryBehavior
{
    public class EmailValidatorBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EmailValidatorBehavior), false,
                BindingMode.TwoWay);

        public bool IsValid
        {
            get => (bool) GetValue(IsValidProperty);
            private set => SetValue(IsValidProperty, value);
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
            var email = e.NewTextValue;
            var emailEntry = sender as Entry;

            IsValid = Regex.IsMatch(email, ConstantsView.EmailRegex, RegexOptions.IgnoreCase) &&
                      !string.IsNullOrEmpty(email);

            if (emailEntry != null) emailEntry.BackgroundColor = IsValid ? Color.Default : Color.Red;
        }
        
        private void BindableOnBindingContextChanged(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            BindingContext = entry?.BindingContext;
        }
    }
}