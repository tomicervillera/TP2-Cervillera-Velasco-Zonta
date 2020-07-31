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
        List<Plan> Planes = new List<Plan>();
        try
        {
            this.OpenConnection();
            SqlCommand cmdPlanes = new SqlCommand("select * from Planes", SqlConn);

            SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
            while (drPlanes.Read())
            {
                Plan pla = new Plan();

                pla.ID = (int)drPlanes["id_Plan"];
                pla.Descripcion = (string)drPlanes["desc_Plan"];
                pla.IdEspecialidad = (int)drPlanes["id_especialidad"];

                Planes.Add(pla);
            }
            drPlanes.Close();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes.", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
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
                pla.IdEspecialidad = (int)drPlanes["id_especialidad"];

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
            SqlCommand cmdSave = new SqlCommand("UPDATE Planes SET desc_Plan = @desc_Plan, id_especialidad = @id_especialidad " +
            "WHERE id_plan = @id", SqlConn);

            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Plan.ID;
            cmdSave.Parameters.Add("@desc_Plan", SqlDbType.VarChar, 50).Value = Plan.Descripcion;
            cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int, 50).Value = Plan.IdEspecialidad;
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
                "insert into Planes (desc_Plan, id_especialidad) " +
                "values (@desc_Plan, @id_especialidad) " +
                "select @@identity", //esta línea es para recuperar el ID que asignó el sql automáticamente
                SqlConn);
            cmdSave.Parameters.Add("@desc_Plan", SqlDbType.VarChar, 50).Value = Plan.Descripcion;
            cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int, 50).Value = Plan.IdEspecialidad;
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
            this.OpenConnection();

            SqlCommand cmdDelete = new SqlCommand("delete Planes where id_Plan=@id", SqlConn);
            cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
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