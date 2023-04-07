using System;
using System.Windows.Forms;
using dominio;
using negocio;
namespace Pokedex
{
    public partial class altaPokemon : Form
    {
        //cuando se crea el pokemon, se ejecuta el primer constructor y mi atributo pokemon 
        //queda nulo, cuando se modifica se ejecuta el constructor con parametro se modifica
        private Pokemon pokemon = null;
        public altaPokemon()
        {
            InitializeComponent();
        }
        public altaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Pokemon";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
          
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                //esta en nulo originalmente, por eso crea un pokemon
                if(pokemon == null)
                {
                    pokemon = new Pokemon();
                }
                    
                
                //mapea datos
                pokemon.Numero = int.Parse(txtNumero.Text);
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.Tipo = (Elemento)cbxTipo.SelectedItem;//me devuelve un objeto, por eso lo casteo
                pokemon.Debilidad = (Elemento)cbxDebilidad.SelectedItem;
                pokemon.UrlImagen = txtUrlImage.Text;

                //si se esta modificando, tiene un id existente. sino, no tiene. usamos eso para 
               
                if(pokemon.Id != 0)
                {
                    negocio.modificar(pokemon);
                    MessageBox.Show("Modificado exitosamente");

                }
                else
                {
                    negocio.agregar(pokemon);
                    MessageBox.Show("Agregado exitosamente");

                }

                Close(); //vuelve a la ventana del listado
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void altaPokemon_Load(object sender, EventArgs e)
        {
            //usará esta misma ventana para agregar y para modificar
            //carga cbx
            ElementoNegocio eleNegocio = new ElementoNegocio();
            try
            {
                //lista los elementos desde negocio 
                cbxTipo.DataSource = eleNegocio.listar();
                //le digo al desplegable cual es su clave y cual su key (asi lo maneja el cbx)
                cbxTipo.ValueMember = "Id"; //value member es valor clave
                cbxTipo.DisplayMember = "Descripcion"; //displaymember lo que va a mostrar
                //id y descripcion sonm los atributos de la clase elemento

                cbxDebilidad.DataSource = eleNegocio.listar();
                cbxDebilidad.ValueMember = "Id";
                cbxDebilidad.DisplayMember = "Descripcion";

                //precarga para modificar. si no es null lo precarga
                if (pokemon != null)
                {
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImage.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);
                    //preselecciona lo que yo elegi arriba
                    cbxTipo.SelectedValue = pokemon.Tipo.Id;
                    cbxDebilidad.SelectedValue = pokemon.Debilidad.Id;
                }
                   

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
