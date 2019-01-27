using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public class Usuario
    {
        /// <summary>
        /// Atributos
        /// </summary>
        public byte[] avatar { get; set; }
        public int idUser { get; set; }
        public string nick { get; set; }
        public string psw { get; set; }
        public string psw2 { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime? startDate { get; set; }
        public int? idRol { get; set; }
        public string active { get; set; }

        /// <summary>
        /// Constructor sin argumentos
        /// </summary>
        public Usuario(){}

        /// <summary>
        /// Constructor con argumentos
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="psw"></param>
        /// <param name="psw2"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="startDate"></param>
        /// <param name="rol"></param>
        /// <param name="active"></param>
        public Usuario(
            string nick,
            string psw,
            string email,
            string name,
            string surname,
            DateTime startDate,
            int idRol,
            string active
            )
        {
            this.nick = nick;
            this.psw = psw;
            this.email = email;
            this.name = name;
            this.surname = surname;
            this.startDate = startDate;
            this.idRol = idRol;
            this.active = active;
        }
        /// <summary>
        /// Constructor Copia
        /// </summary>
        /// <param name="previousUsuario"></param>
        public Usuario(Usuario previousUsuario)
        {
            this.avatar = previousUsuario.avatar;
            this.idUser = previousUsuario.idUser;
            this.nick = previousUsuario.nick;
            this.psw = previousUsuario.psw;
            this.psw2 = previousUsuario.psw2;
            this.email = previousUsuario.email;
            this.name = previousUsuario.name;
            this.surname = previousUsuario.surname;
            this.startDate = previousUsuario.startDate;
            this.idRol = previousUsuario.idRol;
            this.active = previousUsuario.active;
        }
        /// <summary>
        /// Destructor
        /// </summary>
        ~Usuario()
        {
            this.avatar = null;
            this.nick = "";
            this.psw = "";
            this.psw2 = "";
            this.email = "";
            this.name = "";
            this.surname = "";
            this.startDate = DateTime.Now;
            this.idRol = 0;
            this.active = "N";
        }
        /// <summary>
        /// Devuelve el objeto en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ this.idUser }#{ this.nick }#{ this.psw }#{ this.email }#{ this.name }#{ this.surname }#{ this.startDate.ToString() }#{ this.idRol }#{ this.active }";
        }
    }
}
