using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PrimeiroProjeto.Resources.model;
using PrimeiroProjeto.Resources.utils;
using Newtonsoft.Json;
using RestSharp;


namespace PrimeiroProjeto.Resources.services
{
    public class Account
    {
		public static Sessao LogIn(string email, string senha)
		{
			LoginSend login = new LoginSend { grant_type = "password", password = senha, username = email };
		
			RootToken retorno =  JsonConvert
				.DeserializeObject<RootToken>(
					Utils.Json(Method.POST,"/Token", login,false, null)
				);

			if (retorno != null)
			{
				RootObject userinfo = JsonConvert
					.DeserializeObject<RootObject>(
						Utils.Json(Method.GET, "/api/Account/UserInfo", null, true, retorno.access_token)
					);

				if (userinfo != null)
				{
					Biblioteca.SetSessao("", userinfo.Email, userinfo.Email);

					return Biblioteca.sessao;
				}
				else 
				{
					return new Sessao();
				}
			}
			else 
			{
				return new Sessao();
			}
		}
	
		public static RegisterDTO Register(RegisterBindingModel model)
		{
			return JsonConvert
				.DeserializeObject<RegisterDTO>(
					Utils.Json(Method.POST,"/api/Account/Register", model, false, null)
				);
		}



       
    }
}