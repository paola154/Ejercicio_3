using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Windows.Forms;

namespace Ejercicio_3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            UsuariosDA usuarioDA = new UsuariosDA();

            usuario = usuarioDA.Login(UsuariotextBox.Text, ClavetextBox.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos Erroneos");
                return;
            }
            else if (!usuario.Estado)
            {
                MessageBox.Show("Usuario Inactivo");
                return;
            }

            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.Show();
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
