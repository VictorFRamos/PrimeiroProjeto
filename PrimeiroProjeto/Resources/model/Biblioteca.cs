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
        public static string server = "http://192.168.1.24";

        public static Sessao sessao { get; set; }

		static string Token { get; set; }

		public static void SetSessao(UsuarioDTO usu)
		{
			sessao = new Sessao { Usuario = usu};
		}

		public static void SetToken(string t)
		{
			Token = t;
		}

		public static string GetToken()
		{
			return Token;
		}
    }

    public class Sessao
    {
		public UsuarioDTO Usuario { get; set; }
        
    }

}