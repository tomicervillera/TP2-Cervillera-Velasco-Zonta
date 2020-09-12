using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> AlumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("SELECT * from alumnos_inscripciones", SqlConn);

                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();
                while (drAlumnosInscripciones.Read())
                {
                    AlumnoInscripcion alIns = new AlumnoInscripcion();

                    alIns.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    alIns.IDAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    alIns.IDCurso= (int)drAlumnosInscripciones["id_curso"];
                    alIns.Condicion = (string)drAlumnosInscripciones["condicion"];
                    alIns.Nota = (int)drAlumnosInscripciones["nota"];

                    AlumnosInscripciones.Add(alIns);
                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones de alumnos.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return AlumnosInscripciones;
        }
        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion alIns = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("SELECT * from alumnos_inscripciones WHERE id_inscripcion = @id", SqlConn);
                cmdAlumnosInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();
                if (drAlumnosInscripciones.Read())
                {
                    alIns.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    alIns.IDAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    alIns.IDCurso = (int)drAlumnosInscripciones["id_curso"];
                    alIns.Condicion = (string)drAlumnosInscripciones["condicion"];
                    alIns.Nota = (int)drAlumnosInscripciones["nota"];

                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de inscripción de alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alIns;
        }
        protected void Update(AlumnoInscripcion AlumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno = @id_alumno, id_curso = @id_curso, condicion = @condicion, nota = @nota " +
                "WHERE id_inscripcion = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = AlumnoInscripcion.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int, 50).Value = AlumnoInscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int, 50).Value = AlumnoInscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = AlumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int, 50).Value = AlumnoInscripcion.Nota;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de inscripción de alumno. ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(AlumnoInscripcion AlumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO alumnos_inscripciones (id_alumno, id_curso, condicion, nota) " +
                    "VALUES (@id_alumno, @id_curso, @condicion, @nota) " +
                    "SELECT @@identity", //esta línea es para recuperar el ID que asignó el sql automáticamente
                    SqlConn);
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int, 50).Value = AlumnoInscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int, 50).Value = AlumnoInscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = AlumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int, 50).Value = AlumnoInscripcion.Nota;
                AlumnoInscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Así se obtiene el ID que asignó al BD automáticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear inscripción de alumno. ", Ex);
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

                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripción de alumno. ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(AlumnoInscripcion AlumnoInscripcion)
        {
            if (AlumnoInscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(AlumnoInscripcion);
            }
            else if (AlumnoInscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(AlumnoInscripcion);
            }
            else if (AlumnoInscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(AlumnoInscripcion.ID);
            }
            AlumnoInscripcion.State = BusinessEntity.States.Unmodified;
        }
    }

}