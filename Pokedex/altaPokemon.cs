using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
namespace Pokedex
{
    public partial class altaPokemon : Form
    {
        public altaPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Pokemon nuevoPokemon = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                nuevoPokemon.Numero = int.Parse(txtNumero.Text);
                nuevoPokemon.Nombre = txtNombre.Text;
                nuevoPokemon.Descripcion = txtDescripcion.Text;
                nuevoPokemon.Tipo = (Elemento)cbxTipo.SelectedItem;//me devuelve un objeto, por eso lo casteo
                nuevoPokemon.Debilidad = (Elemento)cbxDebilidad.SelectedItem;
                nuevoPokemon.UrlImagen = txtUrlImage.Text;
                negocio.agregar(nuevoPokemon);
                MessageBox.Show("Agregado exitosamente");
                Close(); //vuelve a la ventana del listado
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void altaPokemon_Load(object sender, EventArgs e)
        {
            //carga cbx
            ElementoNegocio eleNegocio = new ElementoNegocio();
            try
            {
                //lista los elementos desde negocio 
                cbxTipo.DataSource = eleNegocio.listar();
                cbxDebilidad.DataSource = eleNegocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImage_Leave(object sender, EventArgs e)
        {
            //carga imagen en tiempo real
            cargarImagen(txtUrlImage.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxPokemon.Load(imagen);
            }
            catch (Exception)
            {

                pbxPokemon.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

    }
}
