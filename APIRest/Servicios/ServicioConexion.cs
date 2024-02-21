using Dapper;
using APIRest.Models;
using Microsoft.Data.SqlClient;

namespace APIRest.Servicios
{
    public interface IServicioConexion
    {
        Task<IEnumerable<navMenu>> ObtenerNav();
        Task<int> Crear(Persona persona);
        Task<IEnumerable<Persona>> EObetener();
        Task<int> Eliminar(PersonId personId);
        Task<int> verificaPersona(string dpi, int opcion = 1);
        Task<Persona> buscarPersona(string dpi, int opcion = 1);
        Task<int> Update(Persona persona);

    }
    public class ServicioConexion : IServicioConexion
    {
        private readonly string cadenaConexion;

        public ServicioConexion(IConfiguration configuracion)
        {
            this.cadenaConexion = configuracion.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<navMenu>> ObtenerNav()
        {
            using var connection = new SqlConnection(cadenaConexion);
            return (IEnumerable<navMenu>)await connection.QueryAsync<navMenu>("spc_obtener_nav_menu", commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> Crear(Persona persona)
        {
            using var connection = new SqlConnection(cadenaConexion);
            var id = await connection.QuerySingleAsync<int>("spi_persona",
                                                            new
                                                            {
                                                                persona.dpi,
                                                                persona.Nombre,
                                                                persona.Apellido,
                                                                persona.Profesion,
                                                                persona.FechaNacimiento,
                                                                persona.Edad,
                                                                persona.Telefono
                                                            }, commandType: System.Data.CommandType.StoredProcedure);
            return id;
        }

        public async Task<IEnumerable<Persona>> EObetener()
        {
            using var connection = new SqlConnection(cadenaConexion);
            return await connection.QueryAsync<Persona>("spc_persona", commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> Eliminar(PersonId personId)
        {
            using var connection = new SqlConnection(cadenaConexion);
            var id = await connection.QuerySingleAsync<int>("spd_persona",
                                                            new
                                                            {
                                                                personId.dpi,
                                                            }, commandType: System.Data.CommandType.StoredProcedure);
            return id;
        }


        public async Task<Persona> buscarPersona(string dpi, int opcion = 1)
        {
            using var connection = new SqlConnection(cadenaConexion);
            var persona = await connection.QuerySingleAsync<Persona>("sps_persona",
                                                            new
                                                            {
                                                                dpi,
                                                                opcion
                                                            }, commandType: System.Data.CommandType.StoredProcedure);

            return persona;
        }

        public async Task<int> verificaPersona(string dpi, int opcion = 1)
        {
            using var connection = new SqlConnection(cadenaConexion);
            var persona = await connection.QuerySingleAsync<int>("sps_persona",
                                                            new
                                                            {
                                                                dpi,
                                                                opcion
                                                            }, commandType: System.Data.CommandType.StoredProcedure);

            return persona;
        }

        public async Task<int> Update(Persona persona)
        {
            using var connection = new SqlConnection(cadenaConexion);
            var id = await connection.QuerySingleAsync<int>("spu_persona",
                                                            new
                                                            {
                                                                persona.dpi,
                                                                persona.Nombre,
                                                                persona.Apellido,
                                                                persona.Profesion,
                                                                persona.FechaNacimiento,
                                                                persona.Edad,
                                                                persona.Telefono
                                                            }, commandType: System.Data.CommandType.StoredProcedure);
            return id;
        }
    }
}
