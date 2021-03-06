using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class PersonaAdapter:Adapter
    {
        public List<Persona> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Persona> personas = new List<Persona>();
            //abrimos la conexi�n a la base de datos con el m�todo que creamos antes
            try { 
                this.OpenConnection();
                //creamos un objeto SqlComand que ser� la sentencia SQL que vamos a ejecutar contra la base de datos (los datos dela BD persona, contrase�a, servidor, etc.
                //estan en el connection string)
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", SqlConn);
                //instanciamos un objeto DataReader que ser� el que recuperar� los datos de la DB
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                //Read() lee una fila de las devueltas por el comando sql carga los datos en drPersonas para poder accederlos, devuelve verdadero mientras haya podido leer datos
                //y avanza a la fila siguiente para el proximo read
                while(drPersonas.Read())
                {
                    //creamos un objeto Persona de la capa de entidades parta copiar los datos de la fila del DataReader al objeto entidades
                    Persona per = new Persona();
                    // ahora copiamos los datos de la fila al objeto
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    //agregamos el objeto con datos a la lista que devolveremos
                    personas.Add(per);
                }
                //cerramos la el DataReader y la conexi�n a la DB
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            //devolvemos el objeto
            return personas;
        }
        public Business.Entities.Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                }
                drPersonas.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }
        protected void Update (Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET  nombre = @nombre, apellido = @apellido, " +
                "direccion = @direccion, email = @email, fecha_nac = @fecha_nac, id_plan = @id_plan, legajo = @legajo, telefono = @telefono, tipo_persona = @tipo_persona, "
                + "nombre_usuario = @nombre_usuario, clave = @clave, habilitado = @habilitado WHERE id_persona = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = Convert.ToInt32(persona.TipoPersona);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = persona.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = persona.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert (Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into personas (nombre, apellido, direccion, email, fecha_nac, id_plan, legajo, telefono, tipo_persona, nombre_usuario, clave, habilitado) " +
                    "values (@nombre, @apellido, @direccion, @email, @fecha_nac, @id_plan, @legajo, @telefono, @tipo_persona, @nombre_usuario, @clave, @habilitado) " +
                    "select @@identity", //esta l�nea es para recuperar el ID que asign� el sql autom�ticamente
                    SqlConn);
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = Convert.ToInt32(persona.TipoPersona);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = persona.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = persona.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;

                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //As� se obtiene el ID que asign� al BD autom�ticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            try
            {
                //abrimos la conexi�n
                this.OpenConnection();

                //creamos la sentencia sql y asignamos un valor al par�metro
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //ejecutamos la sentencia sql
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            persona.State = BusinessEntity.States.Unmodified;            
        }
    }
}
