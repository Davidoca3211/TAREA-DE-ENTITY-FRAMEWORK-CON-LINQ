using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicioentititemprano
{
    public partial class Recetas : Form
    {
        public Recetas()
        {
            InitializeComponent();
        }

        private void Recetas_Load(object sender, EventArgs e)
        {

        }
        EjercicioEntiEntities Ent = new EjercicioEntiEntities();

        private void Mostrar()
        {
            DatagridR.DataSource = Ent.Recetas1.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recetas re = new Recetas();
            re.Nombre = txtNombre.Text;
            re.Descipcion = txtDes.Text;
            re.Tiempo = Txttime.Text;
            Ent.Recetas1.Add(re);
            Ent.SaveChanges();
            Message.Show("La receta fue a;adida Correctamente c: ");
            Mostrar();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int BorrarId = Convert.ToInt32(txtID.Text);
            using (EjercicioEntiEntities objBorrar = new EjercicioEntiEntities())
            {
                Recetas Borrar = (from q in objBorrar.Recetas1
                                  where q.id == BorrarId
                                  select q).First();
                objBorrar.Recetas1.Remove(Borrar);
                objBorrar.SaveChanges();
                MessageBox.Show("Receta Eliminda");
                Mostrar();

            }
        }
    }
}
