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

namespace PrimeiroProjeto.Resources.model
{
    public class Biblioteca
    {
        public static string server = "http://192.168.1.24/api";

        public static Sessao sessao { get; set; }

		public static void SetSessao(string id,string nome,string email)
		{
			sessao = new Sessao { UserID = id, UserEmail = email, UserName = nome };
		}
    }

    public class Sessao
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
        public DateTime Expire { get; set; }
    }

}