using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Firebase.Auth;

namespace LoginRegister
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        LinearLayout snbar;
        string email;
        string password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RegisterPage);
           var registerButton = FindViewById<Button>(Resource.Id.Register2);
            registerButton.Click += registerButton_ClickedAsync;
           

        }

        private async void registerButton_ClickedAsync(object sender, EventArgs e)
        {
            var email = FindViewById<EditText>(Resource.Id.Email);
            this.email = email.Text;
            var password = FindViewById<EditText>(Resource.Id.Password);
            this.password = password.Text;
            var response = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(this.email, this.password);

            Snackbar snackbar = Snackbar.Make(snbar, "Registered Successfully ", Snackbar.LengthShort);
                snackbar.Show();
            
        }
    }
}