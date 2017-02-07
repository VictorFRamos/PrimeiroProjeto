
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using PrimeiroProjeto.Resources.model;
using PrimeiroProjeto.Resources.utils;

namespace PrimeiroProjeto
{
	[Activity(Label = "LoginActivity")]
	public class LoginActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			var Sessao = Utils.RetornaSessao(Intent.GetStringExtra("Sessao"));

			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Login);

			TextView t = FindViewById<TextView>(Resource.Id.textViewName);

			if (Sessao != null && Sessao != null)
			{
				t.Text = "Bem vindo " + Sessao.Usuario.Nome;
			}
		}
	}
}
