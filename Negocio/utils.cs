using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    /// <author>
    /// Jose Javier Pardines Garcia
    /// </author>
    public class utils
    {
        /// <summary>
        /// Devuelve un listado con las opciones del comboBox
        /// </summary>
        /// <returns></returns>
        public static List<string> comboBoxActive()
        {
            List<string> listActive = new List<string>();
            listActive.Add("S");
            listActive.Add("N");
            return listActive;
        }
        /// <summary>
        /// Devuelve un listado con las opciones del comboBox
        /// </summary>
        /// <returns></returns>
        public static List<Entidades.Rol> comboBoxRol()
        {
            List<Entidades.Rol> _listRol = new List<Entidades.Rol>();
            Mundial _mundial = new Mundial();
            _listRol = _mundial.getRoles();
            return _listRol;
        }

        /// <summary>
        /// Devuelve un listado con los usuarios de la app
        /// </summary>
        /// <returns></returns>
        public static List<Entidades.Usuario> getUsuarios()
        {
            List<Entidades.Usuario> _listUsuarios;
            Mundial _mundial;

            try
            {
                _listUsuarios = new List<Entidades.Usuario>();
                _mundial = new Mundial();
                _listUsuarios = _mundial.getUsuarios();
                return _listUsuarios;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Codifica una cadena de texto en MD5
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string txt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(txt));
            byte[] txtEncrypted = md5.Hash;
            StringBuilder txtMD5 = new StringBuilder();

            for (int i = 0; i < txtEncrypted.Length; i++)
            {
                txtMD5.Append(txtEncrypted[i].ToString("x2"));
            }

            return txtMD5.ToString();
        }

        /// <summary>
        /// Comprueba que una contraseña tenga minúsculas, mayúsculas y números
        /// </summary>
        /// <param name="psw"></param>
        /// <returns></returns>
        public static bool isValidPsw(string psw)
        {
            var expresion = new Regex(@"^(?=\S*?[A-Z])(?=\S*?[a-z])(?=\S*?[0-9])\S+$");
            return expresion.Match(psw).Success;
        }

        /// <summary>
        /// Comprueba que un email sea del tipo usuario@dominio.tld
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool isValidEmail(string email)
        {
            var expresion = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            return expresion.Match(email).Success;
        }

        /// <summary>
        /// Comprueba si el usuario ya existe
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public static bool isRegisteredNick(string nick)
        {
            bool result = false;
            foreach (var user in getUsuarios())
            {
                if (user.nick == nick)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Transforma una imagen de un PictureBox en un array de bytes
        /// </summary>
        /// <param name="imagePB"></param>
        /// <returns></returns>
        public static byte[] getBloob(PictureBox imagePB)
        {
            MemoryStream _memoryStram;
            byte[] _imageByte = new byte[0];

            try
            {
                _memoryStram = new MemoryStream();
                imagePB.Image.Save(_memoryStram, ImageFormat.Jpeg);
                _imageByte = new byte[_memoryStram.Length];
                _memoryStram.Position = 0;
                _memoryStram.Read(_imageByte, 0, _imageByte.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return _imageByte;
        }

        /// <summary>
        /// Transforma un objeto a un array de byte
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }

}
