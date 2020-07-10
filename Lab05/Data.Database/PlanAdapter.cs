using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
{

    public List<Plan> GetAll()
    {
        //instanciamos el objeto lista a retornar
        List<Plan> Planes = new List<Plan>();
        //abrimos la conexión a la base de datos con el método que creamos antes
        try
        {
            this.OpenConnection();
            //creamos un objeto SqlComand que será la sentencia SQL que vamos a ejecutar contra la base de datos (los datos dela BD usuario, contraseña, servidor, etc.
            //estan en el connection string)
            SqlCommand cmdPlanes = new SqlCommand("select * from Planes", SqlConn);
            //instanciamos un objeto DataReader que será el que recuperará los datos de la DB
            SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
            //Read() lee una fila de las devueltas por el comando sql carga los datos en drUsuarios para poder accederlos, devuelve verdadero mientras haya podido leer datos
            //y avanza a la fila siguiente para el proximo read
            while (drPlanes.Read())
            {
                //creamos un objeto Usuario de la capa de entidades parta copiar los datos de la fila del DataReader al objeto entidades
                Plan pla = new Plan();
                // ahora copiamos los datos de la fila al objeto
                pla.ID = (int)drPlanes["id_Plan"];
                pla.Descripcion = (string)drPlanes["desc_Plan"];
                //agregamos el objeto con datos a la lista que devolveremos
                Planes.Add(pla);
            }
            //cerramos la el DataReader y la conexión a la DB
            drPlanes.Close();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar lista de Planes", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
        //devolvemos el objeto
        return Planes;
    }
    public Plan GetOne(int ID)
    {
        Plan pla = new Plan();
        try
        {
            this.OpenConnection();
            SqlCommand cmdPlanes = new SqlCommand("select * from Planes where id_Plan = @id", SqlConn);
            cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
            if (drPlanes.Read())
            {
                pla.ID = (int)drPlanes["id_Plan"];
                pla.Descripcion = (string)drPlanes["desc_Plan"];

            }
            drPlanes.Close();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar datos de Plan", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
        return pla;
    }
    protected void Update(Plan Plan)
    {
        try
        {
            this.OpenConnection();
            SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET desc_Plan = @desc_Plan " +
            "WHERE id_Plan = @id", SqlConn);

            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Plan.ID;
            cmdSave.Parameters.Add("@desc_Plan", SqlDbType.VarChar, 50).Value = Plan.Descripcion;
            cmdSave.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al modificar datos de la Plan", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
    }
    protected void Insert(Plan Plan)
    {
        try
        {
            this.OpenConnection();
            SqlCommand cmdSave = new SqlCommand(
                "insert into Planes (desc_Plan) " +
                "values (@desc_Plan) " +
                "select @@identity", //esta línea es para recuperar el ID que asignó el sql automáticamente
                SqlConn);
            cmdSave.Parameters.Add("@desc_Plan", SqlDbType.VarChar, 50).Value = Plan.Descripcion;
            Plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            //Así se obtiene el ID que asignó al BD automáticamente
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al crear Plan", Ex);
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
            //abrimos la conexión
            this.OpenConnection();

            //creamos la sentencia sql y asignamos un valor al parámetro
            SqlCommand cmdDelete = new SqlCommand("delete Planes where id_Plan=@id", SqlConn);
            cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

            //ejecutamos la sentencia sql
            cmdDelete.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al eliminar Plan", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }

    }
    public void Save(Plan Plan)
    {
        if (Plan.State == BusinessEntity.States.New)
        {
            this.Insert(Plan);
        }
        else if (Plan.State == BusinessEntity.States.Modified)
        {
            this.Update(Plan);
        }
        else if (Plan.State == BusinessEntity.States.Deleted)
        {
            this.Delete(Plan.ID);
        }
        Plan.State = BusinessEntity.States.Unmodified;
    }
}
}