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
using SQLite;

namespace PrimeiroProjeto.Resources.services
{
    public class Account 
    {
		public static Context ctx = new Context();

		public static bool LogIn(string email, string senha)
		{
			LoginSend login = new LoginSend { grant_type = "password", password = senha, username = email };
		
			RootToken retorno =  JsonConvert
				.DeserializeObject<RootToken>(
					Utils.Json(Method.POST,"/Token", login,false, null)
				);

			Biblioteca.SetToken(retorno.access_token);

			if (retorno != null)
			{
				UsuarioDTO userinfo = JsonConvert
					.DeserializeObject<UsuarioDTO>(
						Utils.Json(Method.GET, "/api/Account/UserInfo", null, true, Biblioteca.GetToken())
					);

				if (userinfo != null)
				{
					AddOrUpdate(userinfo);
					Biblioteca.SetSessao(userinfo);

					return true;
				}
				else 
				{
					return false;
				}
			}
			else 
			{
				return false;
			}
		}
	
		public static RegisterDTO Register(RegisterBindingModel model)
		{
			return JsonConvert
				.DeserializeObject<RegisterDTO>(
					Utils.Json(Method.POST,"/api/Account/Register", model, false, null)
				);
		}


		public static bool AddOrUpdate(UsuarioDTO objeto)
		{
			try
			{
				using (var db = new SQLiteConnection(ctx.conn))
				{
					var usu = db.Table<UsuarioDTO>().Where(x => x.Email == objeto.Email).FirstOrDefault();

					if (usu != null)
					{
						try
						{
							usu.Nome = objeto.Nome;
							usu.Telefone = objeto.Telefone;
							db.Update(objeto);
							return true;
						}
						catch(Exception e)
						{ 
							return false;
						}

					}
					else 
					{
						try
						{
							db.Insert(objeto);
							return true;
						}
						catch (Exception exe)
						{
							return false;
						}
					}
				}
			}
			catch (SQLiteException ex)
			{
				return false;
			}
		}

		public static List<Users> Select()
		{
			try
			{
				using (var connection = new SQLiteConnection(ctx.conn))
				{
					return connection.Table<Users>().ToList();
				}
			}
			catch (SQLiteException ex)
			{
				return null;
			}
		} 
    }
}