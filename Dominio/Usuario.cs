using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Usuario 
	{
		public enum EnumTipo
		{
			CLIENTE, OPERADOR
		}

		private string username;
		private string password;
		private EnumTipo tipo;
        private List<Compra> compras;

        public List<Compra> Compras
        {
            get { return compras; }
            //set { compras = value; }
        }



        #region Properties
        public string Username
		{
			get { return username; }
			set { username = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}


		public EnumTipo Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}
		#endregion

		public Usuario() 
		{

		}

		public Usuario(string username, string password, EnumTipo tipo) 
		{
			this.username = username;
			this.password = password;
			this.tipo = tipo;
			this.compras = new List<Compra>();

		}
	}
}
