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
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemon;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            //invoca lectura a db y carga grilla
            listaPokemon = negocio.Listar(); //datasource recibe origen de datos y lo modela en la tabla
            //dgvPokemons es la grilla
            dgvPokemons.DataSource = listaPokemon; // agarra un objeto y enlaza los datos en cada columna
            dgvPokemons.Columns["UrlImagen"].Visible = false; //oculta la columna
            cargarImagen(listaPokemon[0].UrlImagen);


        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem; //devuelve un object, por eso se castea 
            cargarImagen(seleccionado.UrlImagen);

           
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            altaPokemon alta = new altaPokemon();
            alta.ShowDialog();
        }
    }
}
