using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> DocentesCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos", SqlConn);

                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();
                while (drDocentesCursos.Read())
                {
                    DocenteCurso docCur = new DocenteCurso();

                    docCur.ID = (int)drDocentesCursos["id_dictado"];
                    docCur.IDCurso= (int)drDocentesCursos["id_curso"];
                    docCur.IDDocente= (int)drDocentesCursos["id_docente"];
                    docCur.Cargo = (DocenteCurso.TiposCargos)drDocentesCursos["cargo"];

                    DocentesCursos.Add(docCur);
                }
                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes por cursos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return DocentesCursos;
        }
        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docCur = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos where id_dictado = @id", SqlConn);
                cmdDocentesCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();
                if (drDocentesCursos.Read())
                {
                    docCur.ID = (int)drDocentesCursos["id_dictado"];
                    docCur.IDCurso = (int)drDocentesCursos["id_curso"];
                    docCur.IDDocente = (int)drDocentesCursos["id_docente"];
                    docCur.Cargo = (DocenteCurso.TiposCargos)drDocentesCursos["cargo"];

                }
                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de docentes por cursos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docCur;
        }
        protected void Update(DocenteCurso DocenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso = @id_curso, id_docente = @id_docente, cargo= @cargo " +
                "WHERE id_dictado = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = DocenteCurso.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int, 50).Value = DocenteCurso.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int, 50).Value = DocenteCurso.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int, 50).Value = DocenteCurso.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de docente por curso. ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(DocenteCurso DocenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO docentes_cursos (id_curso, id_docente, cargo) " +
                    "VALUES (@id_curso, @id_docente, @cargo) " +
                    "SELECT @@identity", //esta línea es para recuperar el ID que asignó el sql automáticamente
                    SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = DocenteCurso.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int, 50).Value = DocenteCurso.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int, 50).Value = DocenteCurso.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int, 50).Value = (int)DocenteCurso.Cargo;
                DocenteCurso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Así se obtiene el ID que asignó al BD automáticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear docente por curso. ", Ex);
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

                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar docente por curso. ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(DocenteCurso DocenteCurso)
        {
            if (DocenteCurso.State == BusinessEntity.States.New)
            {
                this.Insert(DocenteCurso);
            }
            else if (DocenteCurso.State == BusinessEntity.States.Modified)
            {
                this.Update(DocenteCurso);
            }
            else if (DocenteCurso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(DocenteCurso.ID);
            }
            DocenteCurso.State = BusinessEntity.States.Unmodified;
        }
    }

}