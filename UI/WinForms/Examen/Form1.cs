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
    public partial class AgendaWinForm : System.Windows.Forms.Form
    {
        // List<Contacto> _contactos;
        protected override void OnLoad(EventArgs e)
        {

            dtg_data.CellMouseDoubleClick += Dtg_data_CellMouseDoubleClick;
            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            /*
            dtg_data.Rows.Clear();
            IContactoManager contactoManager = FactoryManager.GetContactoManager();
            _contactos = contactoManager.ObtenerTodos(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("@Opcion", 1),
            }));

            _contactos.ForEach(item => dtg_data.Rows.Add(CreateRow(item)));
            */
        }

        private DataGridViewRow CreateRow(/*Contacto item*/)
        {
            DataGridViewRow row = new DataGridViewRow();
            /*
            row.CreateCells(dtg_data, item.IdContacto, item.Nombre, item.ApellidoPaterno, item.ApellidoMaterno, item.Telefono, item.EstadoCivil, item.TipoContacto, item.Genero, item.Edad);
            row.DefaultCellStyle.BackColor = item.Edad < 18 ? Color.Red : Color.Green;
            row.DefaultCellStyle.ForeColor = Color.White;
            */
            return row;
        }

        private void Dtg_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
            Core.COMMON.Models.Contacto itemSelected = _contactos[e.RowIndex];
            DetallesContacto(itemSelected);
            */
        }

        public AgendaWinForm()
        {
            InitializeComponent();

        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            //DetallesContacto();
        }
        /*
        private void DetallesContacto(Contacto contacto=null)
        {
            this.Hide();
            if (new DetallesContacto(contacto).ShowDialog(this) == DialogResult.OK)
                ActualizarDatos();
                
            this.Show();
        }
        */
    }
}
