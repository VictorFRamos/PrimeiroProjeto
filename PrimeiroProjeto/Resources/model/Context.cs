using System;
using System.Collections.Generic;
using Android.Util;
using SQLite;

namespace PrimeiroProjeto
{
	public class Context
	{
		static  string folder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		static string dbName = "MobileTeste.db";
		public String conn = System.IO.Path.Combine(folder, dbName);

		public bool CreateDB()
		{
			try
			{
				using (var connection = new SQLiteConnection(conn))
				{
					//tabela referente ao profile
					connection.CreateTable<UsuarioDTO>();

					//tabela referente aos demais usuarios
					connection.CreateTable<Users>();
					return true;
				}
			}
			catch(SQLiteException ex)
			{
				Log.Info("SQLLiteEx", ex.Message);
				return false;
			}
		}




	}
}
