using Newtonsoft.Json;
using SGF.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGF.BussinessLogic
{
    public partial class Logic
    {

        [OperationContract]
        public SGF_Producto Producto_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_Producto.First(x => x.ProductoID == id);
        }
        [OperationContract]
        public List<SGF_Producto> Producto_ObtenerTodo()
        {
            DataModel model = new DataModel();
            return model.SGF_Producto.ToList();
        }
        [OperationContract]
        public List<SGF_Producto> Producto_ObtenerPorVariedad(Guid variedadID)
        {
            DataModel model = new DataModel();
            return model.SGF_Producto.Where(x => x.VariedadID == variedadID).ToList();
        }

        [OperationContract]
        public List<SGF_Producto_VTA> Producto_ObtenerPorVariedadVTA(Guid variedadID)
        {
            DataModel model = new DataModel();
            return model.SGF_Producto_VTA.Where(x => x.VariedadID == variedadID && x.Estado == 1).ToList();
        }
        [OperationContract]
        public void Producto_Grabar(SGF_Producto newProducto, string nomPC, string ip)
        {
            DataModel model = new DataModel();
            // Crear y configurar el JsonSerializer
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
            {
                Formatting = Formatting.Indented // Para una salida JSON más legible
            });

            // Serializar el objeto a JSON string
            using (var stringWriter = new StringWriter())
            {
                jsonSerializer.Serialize(stringWriter, newProducto);
                string jsonString = stringWriter.ToString();
                SGF_Auditoria _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Producto", Tipo = "Insert", Campo = "Objeto", ValorAnterior = "", ValorNuevo = jsonString, FechaRegistro = DateTime.Now, Usuario = newProducto.Usuario, RegistroID = newProducto.ProductoID.ToString(), IPAddress = ip, namePC = nomPC, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria);
            }
            /*
             * CÓDIGO PARA DESERIALIZAR OBJETO
             *  // Crear y configurar el JsonSerializer
        var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            Formatting = Formatting.Indented // Para una salida JSON más legible
        });

        // Deserializar la cadena JSON a un objeto Persona
        using (var stringReader = new StringReader(jsonString))
        using (var jsonTextReader = new JsonTextReader(stringReader))
        {
            Persona persona = jsonSerializer.Deserialize<Persona>(jsonTextReader);
            Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}, Correo: {persona.Correo}");
        }
             */
            model.AddToSGF_Producto(newProducto);

            model.SaveChanges();
        }
        [OperationContract]
        public int Producto_ValidarProducto(SGF_Producto newProducto)
        {
            DataModel model = new DataModel();
            int resultado = 0;
            foreach (SGF_Producto item in model.SGF_Producto.Where(X => X.Estado == 1).ToList())
            {
                if (newProducto.PaisID == Guid.Empty && newProducto.MercadoID == Guid.Empty)
                {
                    if (item.CalidadID == newProducto.CalidadID && item.TalloID == newProducto.TalloID && item.LongitudID == newProducto.LongitudID)
                    {
                        resultado = 1;
                    }
                }
                else
                {
                    if (newProducto.PaisID != Guid.Empty && newProducto.MercadoID != Guid.Empty)
                    {
                        if (item.CalidadID == newProducto.CalidadID && item.TalloID == newProducto.TalloID && item.LongitudID == newProducto.LongitudID && item.MercadoID == newProducto.MercadoID && item.PaisID == newProducto.PaisID)
                        {
                            resultado = 1;
                        }
                    }
                    else
                    {
                        if (newProducto.PaisID == Guid.Empty && newProducto.MercadoID != Guid.Empty)
                        {
                            if (item.CalidadID == newProducto.CalidadID && item.TalloID == newProducto.TalloID && item.LongitudID == newProducto.LongitudID && item.MercadoID == newProducto.MercadoID)
                            {
                                resultado = 1;
                            }
                        }
                    }
                }
            }
            return resultado;
        }

    }
}
