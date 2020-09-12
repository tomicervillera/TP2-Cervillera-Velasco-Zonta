using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> ModulosUsuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios", SqlConn);

                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();
                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modUs = new ModuloUsuario();

                    modUs.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modUs.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modUs.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modUs.PermiteAlta = (Boolean)drModulosUsuarios["alta"];
                    modUs.PermiteBaja = (Boolean)drModulosUsuarios["baja"];
                    modUs.PermiteModificacion = (Boolean)drModulosUsuarios["modificacion"];
                    modUs.PermiteConsulta = (Boolean)drModulosUsuarios["consulta"];

                    ModulosUsuarios.Add(modUs);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de módulos por usuarios.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ModulosUsuarios;
        }
        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario modUs = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios where id_modulo_usuario = @id", SqlConn);
                cmdModulosUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();
                if (drModulosUsuarios.Read())
                {
                    modUs.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modUs.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modUs.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modUs.PermiteAlta = (Boolean)drModulosUsuarios["alta"];
                    modUs.PermiteBaja = (Boolean)drModulosUsuarios["baja"];
                    modUs.PermiteModificacion = (Boolean)drModulosUsuarios["modificacion"];
                    modUs.PermiteConsulta = (Boolean)drModulosUsuarios["consulta"];

                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de ModuloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modUs;
        }
        protected void Update(ModuloUsuario ModuloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos_usuarios SET id_modulo = @id_modulo, id_usuario = @id_usuario, alta = @alta, baja = @baja, modificacion = @modificacion, " +
                "consulta = @consulta WHERE id_modulo_usuario = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = ModuloUsuario.ID;
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int, 50).Value = ModuloUsuario.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int, 50).Value = ModuloUsuario.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit, 50).Value = ModuloUsuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit, 50).Value = ModuloUsuario.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit, 50).Value = ModuloUsuario.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit, 50).Value = ModuloUsuario.PermiteConsulta;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de ModuloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(ModuloUsuario ModuloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta) " +
                    "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta) " +
                    "select @@identity", //esta línea es para recuperar el ID que asignó el sql automáticamente
                    SqlConn);
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int, 50).Value = ModuloUsuario.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int, 50).Value = ModuloUsuario.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit, 50).Value = ModuloUsuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit, 50).Value = ModuloUsuario.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit, 50).Value = ModuloUsuario.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit, 50).Value = ModuloUsuario.PermiteConsulta;
                ModuloUsuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Así se obtiene el ID que asignó al BD automáticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear ModuloUsuario", Ex);
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

                SqlCommand cmdDelete = new SqlCommand("delete modulos_usuarios where id_modulo_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar ModuloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(ModuloUsuario ModuloUsuario)
        {
            if (ModuloUsuario.State == BusinessEntity.States.New)
            {
                this.Insert(ModuloUsuario);
            }
            else if (ModuloUsuario.State == BusinessEntity.States.Modified)
            {
                this.Update(ModuloUsuario);
            }
            else if (ModuloUsuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(ModuloUsuario.ID);
            }
            ModuloUsuario.State = BusinessEntity.States.Unmodified;
        }
    }

}