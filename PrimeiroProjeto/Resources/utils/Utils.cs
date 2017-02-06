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
using System.Threading.Tasks;
using System.Net;
using System.IO;
using PrimeiroProjeto.Resources.model;
using RestSharp;
using System.Collections.Specialized;
using RestSharp.Extensions.MonoHttp;
using Newtonsoft.Json;

namespace PrimeiroProjeto.Resources.utils
{
    public class Utils
    {
		public static string Json(Method metodo,string requestUrl,Object objeto, bool auth, string token = null)
        {
			var client = new RestClient(Biblioteca.server + requestUrl);

			var request = new RestRequest(metodo);

			if (auth)
			{
				request.AddHeader("Authorization","Bearer " + token);
			}

			request.AddHeader("content-type", "application/x-www-form-urlencoded");

			if (objeto != null)
			{
				request.AddParameter("application/x-www-form-urlencoded", ConstructQueryString(objeto), ParameterType.RequestBody);
			}
			IRestResponse response = client.Execute(request);
			return response.Content;
        }

		static object ConstructQueryString(Object o)
		{
			Type t = o.GetType();
			NameValueCollection nvc = new NameValueCollection();
			foreach (var p in t.GetProperties())
			{
				var name = p.Name;
				var value = p.GetValue(o, null).ToString();
				nvc.Add(name, value);
			}

			List<string> items = new List<string>();
			foreach (string name in nvc)
				items.Add(String.Concat(name, "=", HttpUtility.UrlEncode(nvc[name])));
			return string.Join("&", items.ToArray());
		}

		public static Sessao RetornaSessao(string extra)
		{
			return JsonConvert.DeserializeObject<Sessao>(extra);
		}
}
}