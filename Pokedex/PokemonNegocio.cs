﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pokedex
{
    class PokemonNegocio
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
                conexion.ConnectionString = "server= NOELIA; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, Descripcion from POKEMONS"; //consulta sql
                comando.Connection = conexion; //ejecuta el comando en la conexion que establezco

                conexion.Open();

               //realiza la lectura
                lector = comando.ExecuteReader();

                //el lector es un objeto asi que si hay registro posiciona un puntero en la siguiente ejecucion e ingresa al while
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon(); //crea nueva instancia de Pokemon
                    //lo cargo con los datos del lector del registro
                    aux.Numero = (int)lector["Numero"]; //devuelve un object porque puede leer cualquier cosa, por eso se castea
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

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
    }
}
