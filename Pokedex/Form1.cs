using System;
using System.Collections.Generic;
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

            cargar();

        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            //cuando el indice de la grilla se cambia
            if(dgvPokemons.CurrentRow != null)
            {
                Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem; //devuelve un object, por eso se castea 
                cargarImagen(seleccionado.UrlImagen);

            }

        }
        private void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                //invoca lectura a db y carga grilla
                listaPokemon = negocio.Listar(); //datasource recibe origen de datos y lo modela en la tabla
                                                 //dgvPokemons es la grilla
                dgvPokemons.DataSource = listaPokemon; // agarra un objeto y enlaza los datos en cada columna
                ocultarColumna();
                cargarImagen(listaPokemon[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumna()
        {
            dgvPokemons.Columns["UrlImagen"].Visible = false; //oculta la columna
            dgvPokemons.Columns["Id"].Visible = false;
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
            //llama al constructor vacio
            altaPokemon alta = new altaPokemon();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //le paso por parametro el objeto pokemon a modificar
            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            //se lo paso como parametro al constructor de la clase altaPokemon
            altaPokemon modificar = new altaPokemon(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }
        //false significa que es opcional, si es false sera eliminar logico
        private void eliminar(bool logico = false)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado;
            try
            {
                //el metodo messabox devuelve un enum dialogresult, lo guardo en una variable. guarda si o no
                DialogResult respuesta = MessageBox.Show("Seguro que quieres eliminar?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

                    //llamamos a uno u otro dependiendo el valor de la bandera
                    if (logico)
                    {
                        negocio.suspender(seleccionado.Id);
                    }
                    else
                    {
                        negocio.eliminar(seleccionado.Id);
                    }
                    
                    //actualiza grilla
                    cargar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {


            
        }

        //textchanged  sirve para que se actualice el filtro cada vez que vamos tocando teclas
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro.Length >= 3)
            //si no hay parametro de busqueda en el txt
            {
                //traigo todos los objetos que coincidan y los voy guardando en la lista listaFiltrada 
                listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()) || x.Tipo.Descripcion.ToLower().Contains(filtro.ToLower()));
                //contains permite que traiga palabras a medias, sin poner el nombre completo.          trae los que son del tipo que estamos pidiendo (planta, fuego, agua)
            }
            else
            {
                //si no hay filtro, pongo la lista original
                listaFiltrada = listaPokemon;
            }
            //limpio la grilla
            dgvPokemons.DataSource = null;
            dgvPokemons.DataSource = listaFiltrada;
            ocultarColumna();
        }

    }
}
