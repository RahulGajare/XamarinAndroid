using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Gms.Auth.Api;
using Android.Gms.Common;
using Android.Content.PM;
using Java.Security;

namespace LoginRegister
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            PackageInfo info = this.PackageManager.GetPackageInfo("LoginRegister.LoginRegister", PackageInfoFlags.Signatures );

            foreach (Android.Content.PM.Signature signature in info.Signatures)
            {
                MessageDigest md = MessageDigest.GetInstance("SHA");
                md.Update(signature.ToByteArray());

                string keyhash = Convert.ToBase64String(md.Digest());
                Console.WriteLine("etwwt",keyhash);
            }

            var button = FindViewById<Button>(Resource.Id.Register_clicked);
            button.Click += OnRegister_Clicked;
            var socialButton = FindViewById<Button>(Resource.Id.button2);                   
        }
       
        private void OnRegister_Clicked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Register));
            StartActivity(intent);
        }

      

    }
}