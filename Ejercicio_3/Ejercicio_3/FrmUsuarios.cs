using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Windows.Forms;

namespace Ejercicio_3
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        UsuariosDA usuarioDA = new UsuariosDA();
        string operacion = string.Empty;
        Usuarios user = new Usuarios();
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuarioDA.ListarUsuarios();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
            
            
        }

        private void HabilitarControles()
        {
            CodigotextBox.Enabled = true;
            NombretextBox.Enabled = true;
            EdadtextBox.Enabled = true;
            ClavetextBox.Enabled = true;
            RolcomboBox.Enabled = true;
            EstadocheckBox.Enabled = true;
            ProfesiontextBox.Enabled = true;

            Nuevobutton.Enabled = false;
            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;


        }

        private void DesabilitarControles()
        {
            CodigotextBox.Enabled = false;
            NombretextBox.Enabled = false;
            EdadtextBox.Enabled = false;
            ClavetextBox.Enabled = false;
            RolcomboBox.Enabled = false;
            EstadocheckBox.Enabled = false;
            ProfesiontextBox.Enabled = false;

            Nuevobutton.Enabled = true;
            Guardarbutton.Enabled = false;
            Cancelarbutton.Enabled = false;


        }

        private void LimpiarControles()
        {
            CodigotextBox.Clear();
            NombretextBox.Text = "";
            ClavetextBox.Text = string.Empty;
            EdadtextBox.Text = string.Empty;
            ProfesiontextBox.Text = string.Empty;
            RolcomboBox.Text = string.Empty;
            EstadocheckBox.Enabled = false;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            user.Codigo = CodigotextBox.Text;
            user.Nombre = NombretextBox.Text;
            user.Edad = EdadtextBox.Text;
            user.Rol = RolcomboBox.Text;
            user.Profesion = ProfesiontextBox.Text;
            user.Estado = EstadocheckBox.Checked;
            user.Clave = ClavetextBox.Text;

            if (operacion == "Nuevo")
            {
                bool inserto = usuarioDA.InsertarUsuario(user);

                if (inserto)
                {
                    MessageBox.Show("Usuario Creado");
                    ListarUsuarios();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Crear");
                }
            }
            else if (operacion == "Modificar")
            {
                bool modifico = usuarioDA.ModificarUsuario(user);
                if (modifico)
                {
                    MessageBox.Show("Usuario Modificado");
                    ListarUsuarios();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Modificar");
                }
            }

        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigotextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombretextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ClavetextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Clave"].Value.ToString();
                EdadtextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Edad"].Value.ToString();
                ProfesiontextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Profesion"].Value.ToString();
                RolcomboBox.Text = UsuariosDataGridView.CurrentRow.Cells["Rol"].Value.ToString();
                EstadocheckBox.Checked = Convert.ToBoolean(UsuariosDataGridView.CurrentRow.Cells["Estado"].Value);
                HabilitarControles();
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = usuarioDA.EliminarUsuario(UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    MessageBox.Show("Usuario Eliminado");
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Eliminar");
                }

            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }
    }
}
