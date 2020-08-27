using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> Cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", SqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.IDMateria= (int)drCursos["id_materia"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    Cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Cursos;
        }
        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso = @id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de curso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }
        protected void Update(Curso Curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_comision = @id_comision, id_materia = @id_materia, anio_calendario = @anio_calendario, cupo = @cupo " +
                "WHERE id_curso = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Curso.ID;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int, 50).Value = Curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int, 50).Value = Curso.IDMateria;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int, 50).Value = Curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int, 50).Value = Curso.Cupo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Curso Curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO cursos (id_comision, id_materia, anio_calendario, cupo) " +
                    "VALUES (@id_comision, @id_materia, @anio_calendario, @cupo) " +
                    "SELECT @@identity", //esta línea es para recuperar el ID que asignó el sql automáticamente
                    SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Curso.ID;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int, 50).Value = Curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int, 50).Value = Curso.IDMateria;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int, 50).Value = Curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int, 50).Value = Curso.Cupo;
                Curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Así se obtiene el ID que asignó al BD automáticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
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

                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(Curso Curso)
        {
            if (Curso.State == BusinessEntity.States.New)
            {
                this.Insert(Curso);
            }
            else if (Curso.State == BusinessEntity.States.Modified)
            {
                this.Update(Curso);
            }
            else if (Curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(Curso.ID);
            }
            Curso.State = BusinessEntity.States.Unmodified;
        }
    }

}