using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
   public class PokemonNegocio
    {
        //metodos de accedo a datos para los pokemon
        public List<Pokemon> Listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector; //obtengo un objeto, no se instancia
            try
            {
                conexion.ConnectionString = "server=DESKTOP-BEH97V1\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select P.Id, Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad from POKEMONS P,ELEMENTOS E, ELEMENTOS D WHERE E.Id = P.IdTipo AND D.Id = P.IdDebilidad AND P.Activo = 1"; //consulta sql
                comando.Connection = conexion; //ejecuta el comando en la conexion que establezco

                conexion.Open();

               //realiza la lectura
                lector = comando.ExecuteReader();

                //el lector es un objeto asi que si hay registro posiciona un puntero en la siguiente ejecucion e ingresa al while
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon(); //crea nueva instancia de Pokemon
                                                 //lo cargo con los datos del lector del registro
                    aux.Id = (int)lector["Id"];
                    aux.Numero = (int)lector["Numero"]; //devuelve un object porque puede leer cualquier cosa, por eso se castea
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    if (!(lector["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)lector["UrlImagen"];
                    }

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"]; //tipo es un objeto sin instancia por eso se pone  aux.Tipo = new Elemento();
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];
                    lista.Add(aux); //agrego el pokemon a la lista
                }

                conexion.Close();
                return lista; //cuando no hay nada mas por leer 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void agregar(Pokemon poke)
        {
            //conecta a db
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //setear consulta
                datos.setearConsulta("INSERT INTO POKEMONS (Numero,Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + poke.Numero + ",'"+ poke.Nombre +"','" + poke.Descripcion +"',1, @IdTipo, @IdDebilidad, @UrlImagen)");
                datos.setearParametro("@idTipo", poke.Tipo.Id);
                datos.setearParametro("@IdDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@UrlImagen", poke.UrlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Pokemons SET Numero = @Numero, Nombre = @Nombre, Descripcion = @Descripcion, UrlImagen = @UrlImagen, IdTipo = @IdTipo, IdDebilidad = @IdDebilidad WHERE Id = @Id");
                datos.setearParametro("@Numero", poke.Numero);
                datos.setearParametro("@Nombre", poke.Nombre);
                datos.setearParametro("@Descripcion", poke.Descripcion);
                datos.setearParametro("@UrlImagen", poke.UrlImagen);
                datos.setearParametro("@IdTipo", poke.Tipo.Id);
                datos.setearParametro("@IdDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@Id", poke.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM POKEMONS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void suspender(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update pokemons set Activo = 0 where Id = @id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
