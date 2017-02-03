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


namespace PrimeiroProjeto.Resources.services
{
    public class Account
    {
        public void LogIn()
        {
			
		}
	
		public static RegisterDTO Register(RegisterBindingModel model)
		{
			return JsonConvert.DeserializeObject<RegisterDTO>(Utils.GetJson("/Account/Register", model));
		}
		
       
    }
}