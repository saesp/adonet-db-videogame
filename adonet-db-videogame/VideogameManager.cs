using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace adonet_db_videogame
{
    internal class VideogameManager
    {
        //CREAZIONE
        public static void CreateVideogame()
        {
            Console.WriteLine("Inserisci i dati del nuovo videogioco:");

            //nome
            string name = "";
            // finché la stringa è vuota 
            while (string.IsNullOrEmpty(name)) // IsNullOrEmpty() verifica se una sringa è null o vuota
            {
                Console.Write("Nome: ");
                name = Console.ReadLine();
            }

            // descrizione
            string overview = "";
            while (string.IsNullOrEmpty(overview))
            {
                Console.Write("Descrizione: ");
                overview = Console.ReadLine();
            }

            // data di rilascio
            Console.Write("Data di rilascio (gg/mm/aaaa): ");
            DateTime releaseDate = Convert.ToDateTime(Console.ReadLine());

            // software house id
            Console.Write("Id casa produttrice: ");
            int softwareHouseId =  Convert.ToInt32(Console.ReadLine());

            try
            {
                //stringa di connessione per rintracciare il database 
                string connectionString = "Data Source=localhost;Initial Catalog=db-videogames-query;Integrated Security=True";

                using SqlConnection sqlConn = new(connectionString);

                sqlConn.Open();

                //dichiarare quey
                string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@name, @overview, @releaseDate, @softwareHouseId)";

                //creare comando
                using SqlCommand command = new SqlCommand(query, sqlConn);
                
                //aggiunta valori
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@overview", overview);
                command.Parameters.AddWithValue("@releaseDate", releaseDate);
                command.Parameters.AddWithValue("@softwareHouseId", softwareHouseId);

                //scrivere comando
                int result = command.ExecuteNonQuery();

                Console.WriteLine($"Inserito {result} record nella tabella videogames");
            }
                
            catch (Exception ex) // gestione di eventuali errori
            {
                Console.WriteLine($"ERRORE: {ex.Message}");
            }
            // non serve usare 'finally' con close() per chiudere la risorsa grazie a using()
        }
    }
}
