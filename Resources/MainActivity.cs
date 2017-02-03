﻿using Android.App;
using Android.Widget;
using Android.OS;
using PrimeiroProjeto.Resources.services;
using PrimeiroProjeto.Resources.model;
using Android.Content;
using Newtonsoft.Json;
using System;

namespace PrimeiroProjeto
{
	[Activity(Label = "PrimeiroProjeto", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			Button button = FindViewById<Button>(Resource.Id.btnEnviar);

			button.Click += delegate
			{
				RegisterBindingModel model = new RegisterBindingModel();
				model.Email = FindViewById<EditText>(Resource.Id.email).Text;
				model.Password = FindViewById<EditText>(Resource.Id.senha).Text;
				model.ConfirmPassword = FindViewById<EditText>(Resource.Id.senha).Text;

				var result = Account.Register(model);
				if (!result.Erro)
				{
					Biblioteca.SetSessao(result.Usuario.Id, result.Usuario.Nome, result.Usuario.Email);
					var loginActivity = new Intent(this, typeof(LoginActivity));
					var sessaoObject = JsonConvert.SerializeObject(Biblioteca.sessao);
					loginActivity.PutExtra("Sessao", sessaoObject);
					StartActivity(loginActivity);			
				}
				else {
				}
			};
		}


	}
}

