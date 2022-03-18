
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class DetallesContacto : Form
    {
        // Contacto _contacto;
        public DetallesContacto(/*Contacto contacto = null*/)
        {
            InitializeComponent();
            /*
            _contacto = contacto;
            rdbFemenino.Checked = true;
            if (_contacto != null)
            {
                txtNombre.Text = _contacto.Nombre;
                txtApMaterno.Text = _contacto.ApellidoMaterno;
                txtApPaterno.Text = _contacto.ApellidoPaterno;
                txtTelefono.Text = _contacto.Telefono;
                cmbEstadoCivil.SelectedItem = _contacto.EstadoCivil;
                cmbTipoContacto.SelectedItem = _contacto.TipoContacto;
                dtpFechaNacimiento.Value = _contacto.FechaNacimiento;
                if (_contacto.Genero == "Masculino")
                    rdbMasculino.Checked = true;
                else
                    rdbFemenino.Checked = true;
            }
                    */
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*
            IContactoManager contactoManager = FactoryManager.GetContactoManager();
            //if (_contacto is null)
            {
                contactoManager.Crear(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("@Opcion",4),
                    new KeyValuePair<string, object>("@id",0),
                    new KeyValuePair<string, object>("@Nombre",txtNombre.Text),
                    new KeyValuePair<string, object>("@ApellidoMaterno",txtApMaterno.Text),
                    new KeyValuePair<string, object>("@ApellidoPaterno",txtApPaterno.Text),
                    new KeyValuePair<string, object>("@EstadoCivil","Soltero"),
                    new KeyValuePair<string, object>("@TipoContacto","Empresarial"),
                    new KeyValuePair<string, object>("@Genero",rdbFemenino.Checked?"Femenino":"Masculino"),
                    new KeyValuePair<string, object>("@FechaNacimiento",$"'{dtpFechaNacimiento.Value.ToString("yyyyMMdd")}'"),
                }));
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            */
        }
    }
}
