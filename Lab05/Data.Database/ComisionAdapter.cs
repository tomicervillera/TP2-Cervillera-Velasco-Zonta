using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", SqlConn);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision esp = new Comision();
                    esp.ID = (int)drComisiones["id_comision"];
                    esp.Descripcion = (string)drComisiones["desc_comision"];
                    esp.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    esp.IDPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(esp);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }
        public Comision GetOne(int ID)
        {
            Comision esp = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision = @id", SqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    esp.ID = (int)drComisiones["id_comision"];
                    esp.Descripcion = (string)drComisiones["desc_comision"];
                    esp.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    esp.IDPlan = (int)drComisiones["id_plan"];

                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;
        }
        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision, anio_especialidad= @anio_especialidad, id_plan = @id_plan " +
                "WHERE id_comision = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into comisiones (desc_comision,anio_especialidad,id_plan) " +
                    "values (@desc_comision,@anio_especialidad,@id_plan) " +
                    "select @@identity", //esta línea es para recuperar el ID que asignó el sql automáticamente
                    SqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Así se obtiene el ID que asignó al BD automáticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
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

                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            else if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
