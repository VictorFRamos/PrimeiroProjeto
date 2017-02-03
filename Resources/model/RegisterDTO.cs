using System;
namespace PrimeiroProjeto
{
	public class RegisterDTO
	{
		public bool Erro { get; set; }
		public string Descricao { get; set; }
		public UsuarioDTO Usuario { get; set; }
	}

	public class UsuarioDTO
	{
		public string Id { get; set; }				
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
	}
}