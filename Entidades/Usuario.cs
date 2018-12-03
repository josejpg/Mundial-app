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
        private byte[] _avatar;
        private int _idUser;
        private string _nick;
        private string _psw;
        private string _psw2;
        private string _email;
        private string _name;
        private string _surname;
        private DateTime? _startDate;
        private int? _idRol;
        private string _active;

        /// <summary>
        /// Variables
        /// </summary>
        public byte[] Avatar
        {
            get => this._avatar;
            set => this._avatar = value;
        }
        public int IdUser
        {
            get => this._idUser;
            set => this._idUser = value;
        }
        public string Nick
        {
            get => this._nick;
            set => this._nick = value;
        }
        public string Psw
        {
            get => this._psw;
            set => this._psw = value;
        }
        public string Psw2
        {
            get => this._psw2;
            set => this._psw2 = value;
        }
        public string Email
        {
            get => this._email;
            set => this._email = value;
        }
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }
        public string Surname
        {
            get => this._surname;
            set => this._surname = value;
        }
        public DateTime? StartDate
        {
            get => this._startDate;
            set => this._startDate = value;
        }
        public int? IdRol
        {
            get => this._idRol;
            set => this._idRol = value;
        }
        public string Active
        {
            get => this._active;
            set => this._active = value;
        }

        /// <summary>
        /// Constructor sin argumentos
        /// </summary>
        public Usuario()
        {
            this._avatar = null;
            this._idUser = 0;
            this._nick = string.Empty;
            this._psw = string.Empty;
            this._psw2 = string.Empty;
            this._email = string.Empty;
            this._name = string.Empty;
            this._surname = string.Empty;
            this._startDate = DateTime.Now;
            this._idRol = 0;
            this._active = "n";
        }

        /// <summary>
        /// Constructor con argumentos
        /// </summary>
        /// <param name="avatar"></param>
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
            byte[] avatar,
            int id,
            string nick,
            string psw,
            string psw2,
            string email,
            string name,
            string surname,
            DateTime startDate,
            int idRol,
            string active
            )
        {
            this._avatar = avatar;
            this._idUser = id;
            this._nick = nick;
            this._psw = psw;
            this._psw2 = psw2;
            this._email = email;
            this._name = name;
            this._surname = surname;
            this._startDate = startDate;
            this._idRol = idRol;
            this._active = active;
        }
        /// <summary>
        /// Constructor Copia
        /// </summary>
        /// <param name="previousUsuario"></param>
        public Usuario(Usuario previousUsuario)
        {
            this._avatar = previousUsuario.Avatar;
            this._idUser = previousUsuario.IdUser;
            this._nick = previousUsuario.Nick;
            this._psw = previousUsuario.Psw;
            this._psw2 = previousUsuario.Psw2;
            this._email = previousUsuario.Email;
            this._name = previousUsuario.Name;
            this._surname = previousUsuario.Surname;
            this._startDate = previousUsuario.StartDate;
            this._idRol = previousUsuario.IdRol;
            this._active = previousUsuario.Active;
        }
        /// <summary>
        /// Destructor
        /// </summary>
        ~Usuario()
        {
            this._avatar = null;
            this._nick = string.Empty;
            this._psw = string.Empty;
            this._psw2 = string.Empty;
            this._email = string.Empty;
            this._name = string.Empty;
            this._surname = string.Empty;
            this._startDate = DateTime.Now;
            this._idRol = 0;
            this._active = "n";
        }
        /// <summary>
        /// Devuelve el objeto en formato string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ this._idUser }#{ this._nick }#{ this._psw }#{ this._email }#{ this._name }#{ this._surname }#{ this._startDate.ToString() }#{ this._idRol }#{ this._active }";
        }
    }
}
