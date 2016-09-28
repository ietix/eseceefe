using BibliotecaSCF.Catalogos;
using BibliotecaSCF.Clases;
using BibliotecaSCF.ClasesComplementarias;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSFEv1;
using WSFEv1.Logica;
using WSFEv1.Logica.Wsfe;

namespace BibliotecaSCF.Controladores
{
    public class ControladorGeneral
    {
        #region Articulo

        public static void InsertarActualizarArticulo(int codigoArticulo, string descripcionCorta, string descripcionLarga, string marca, string nombreImagen, double precio, int codigoMoneda, int codigoUnidadMedida)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction transaccion = nhSesion.BeginTransaction();

            try
            {
                Articulo articulo;

                if (codigoArticulo == 0)
                {
                    articulo = new Articulo();
                }
                else
                {
                    articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);
                }

                HistorialPrecio histPrecio = (from h in articulo.HistorialesPrecio where h.FechaHasta == null select h).SingleOrDefault();

                if (histPrecio == null)
                {
                    histPrecio = new HistorialPrecio();
                    histPrecio.FechaDesde = DateTime.Now;
                    histPrecio.FechaHasta = null;
                    histPrecio.Precio = precio;
                    histPrecio.Moneda = CatalogoMoneda.RecuperarPorCodigo(codigoMoneda, nhSesion);

                    articulo.HistorialesPrecio.Add(histPrecio);
                }
                else
                {
                    if (histPrecio.Precio != precio || histPrecio.Moneda.Codigo != codigoMoneda)
                    {
                        histPrecio.FechaHasta = DateTime.Now.AddSeconds(-1);

                        HistorialPrecio histPrecioNuevo = new HistorialPrecio();
                        histPrecioNuevo.FechaDesde = DateTime.Now;
                        histPrecioNuevo.FechaHasta = null;
                        histPrecioNuevo.Precio = precio;
                        histPrecioNuevo.Moneda = CatalogoMoneda.RecuperarPorCodigo(codigoMoneda, nhSesion);

                        articulo.HistorialesPrecio.Add(histPrecioNuevo);
                    }
                }

                articulo.UnidadMedida = CatalogoUnidadMedida.RecuperarPorCodigo(codigoUnidadMedida, nhSesion);
                articulo.DescripcionCorta = descripcionCorta;
                articulo.DescripcionLarga = descripcionLarga;
                articulo.Marca = marca;
                articulo.NombreImagen = nombreImagen;

                CatalogoArticulo.InsertarActualizar(articulo, nhSesion);
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosArticulos()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulos = new DataTable();
                tablaArticulos.Columns.Add("codigoArticulo");
                tablaArticulos.Columns.Add("descripcionCorta");
                tablaArticulos.Columns.Add("descripcionLarga");
                tablaArticulos.Columns.Add("marca");
                tablaArticulos.Columns.Add("precio");
                tablaArticulos.Columns.Add("nombreImagen");
                tablaArticulos.Columns.Add("codigoArticuloCliente");
                tablaArticulos.Columns.Add("codigoCliente");
                tablaArticulos.Columns.Add("razonSocialCliente");
                tablaArticulos.Columns.Add("codigoUnidadMedida");
                tablaArticulos.Columns.Add("unidadMedidad");
                tablaArticulos.Columns.Add("codigoMoneda");
                tablaArticulos.Columns.Add("descripcionMoneda");

                List<Articulo> listaArticulos = CatalogoArticulo.RecuperarTodos(nhSesion);

                listaArticulos.Aggregate(tablaArticulos, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.DescripcionCorta, r.DescripcionLarga, r.Marca,
                        r.RecuperarHistorialPrecioActual().Precio, r.NombreImagen, string.Empty, string.Empty, string.Empty, r.UnidadMedida.Codigo, r.UnidadMedida.Descripcion,
                        r.RecuperarHistorialPrecioActual().Moneda.Codigo, r.RecuperarHistorialPrecioActual().Moneda.Descripcion); return dt;
                });

                return tablaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static string EliminarArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            try
            {
                List<NotaDePedido> listaNP = CatalogoNotaDePedido.RecuperarPorArticulo(codigoArticulo, nhSesion);

                if (listaNP.Count > 0)
                {
                    return "NotaDePedido";
                }

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);
                CatalogoArticulo.Eliminar(articulo, nhSesion);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarArticuloPorCodigoInternoCliente(string codigoInternoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulo = new DataTable();
                tablaArticulo.Columns.Add("codigoArticulo");
                tablaArticulo.Columns.Add("descripcionCorta");
                tablaArticulo.Columns.Add("descripcionLarga");
                tablaArticulo.Columns.Add("marca");
                tablaArticulo.Columns.Add("precio");
                tablaArticulo.Columns.Add("nombreImagen");
                tablaArticulo.Columns.Add("codigoArticuloCliente");
                tablaArticulo.Columns.Add("codigoCliente");
                tablaArticulo.Columns.Add("razonSocialCliente");
                tablaArticulo.Columns.Add("codigoMoneda");
                tablaArticulo.Columns.Add("descripcionMoneda");
                tablaArticulo.Columns.Add("codigoUnidadMedida");

                List<Articulo> listaArticulos = CatalogoArticulo.RecuperarPorCodigoInternoCliente(codigoInternoCliente, nhSesion);

                foreach (Articulo articulo in listaArticulos)
                {
                    foreach (ArticuloCliente artCli in articulo.ArticulosClientes.Where(x => x.CodigoInterno.Contains(codigoInternoCliente)))
                    {
                        tablaArticulo.Rows.Add(articulo.Codigo, articulo.DescripcionCorta, articulo.DescripcionLarga, articulo.Marca,
                        articulo.RecuperarHistorialPrecioActual().Precio, articulo.NombreImagen,
                        artCli.CodigoInterno, artCli.Codigo, artCli.Cliente.RazonSocial,
                        articulo.RecuperarHistorialPrecioActual().Moneda.Codigo, articulo.RecuperarHistorialPrecioActual().Moneda.Descripcion, articulo.UnidadMedida.Codigo);
                    }
                }

                return tablaArticulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarArticulosPorCodigoCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulo = new DataTable();
                tablaArticulo.Columns.Add("codigoArticulo");
                tablaArticulo.Columns.Add("descripcionCorta");
                tablaArticulo.Columns.Add("descripcionLarga");
                tablaArticulo.Columns.Add("marca");
                tablaArticulo.Columns.Add("precio");
                tablaArticulo.Columns.Add("nombreImagen");
                tablaArticulo.Columns.Add("codigoArticuloCliente");
                tablaArticulo.Columns.Add("codigoCliente");
                tablaArticulo.Columns.Add("razonSocialCliente");
                tablaArticulo.Columns.Add("codigoUnidadMedida");
                tablaArticulo.Columns.Add("unidadMedidad");
                tablaArticulo.Columns.Add("codigoMoneda");
                tablaArticulo.Columns.Add("descripcionMoneda");

                List<Articulo> listaArticulos = CatalogoArticulo.RecuperarTodos(nhSesion);

                foreach (Articulo articulo in listaArticulos)
                {
                    ArticuloCliente artCli = (from a in articulo.ArticulosClientes where a.Cliente.Codigo == codigoCliente select a).FirstOrDefault();

                    tablaArticulo.Rows.Add(articulo.Codigo, articulo.DescripcionCorta, articulo.DescripcionLarga, articulo.Marca,
                        articulo.RecuperarHistorialPrecioActual().Precio, articulo.NombreImagen,
                        artCli == null ? string.Empty : artCli.CodigoInterno, artCli == null ? string.Empty : artCli.Cliente.Codigo.ToString(),
                        artCli == null ? string.Empty : artCli.Cliente.RazonSocial, string.Empty, string.Empty, articulo.RecuperarHistorialPrecioActual().Moneda.Codigo,
                        articulo.RecuperarHistorialPrecioActual().Moneda.Descripcion);
                }

                return tablaArticulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region ArticuloCliente

        public static DataTable RecuperarArticulosClientesPorArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulosClientes = new DataTable();
                tablaArticulosClientes.Columns.Add("codigoArticuloCliente");
                tablaArticulosClientes.Columns.Add("codigoInterno");
                tablaArticulosClientes.Columns.Add("codigoCliente");
                tablaArticulosClientes.Columns.Add("razonSocialCliente");

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                articulo.ArticulosClientes.Aggregate(tablaArticulosClientes, (dt, r) => { dt.Rows.Add(r.Codigo, r.CodigoInterno, r.Cliente.Codigo, r.Cliente.RazonSocial); return dt; });

                return tablaArticulosClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarHistorialPreciosPorArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaHistorialPrecio = new DataTable();
                tablaHistorialPrecio.Columns.Add("codigoHistorialPrecio");
                tablaHistorialPrecio.Columns.Add("fechaDesde");
                tablaHistorialPrecio.Columns.Add("fechaHasta");
                tablaHistorialPrecio.Columns.Add("precio");
                tablaHistorialPrecio.Columns.Add("descripcionMoneda");

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                articulo.HistorialesPrecio.Aggregate(tablaHistorialPrecio, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaDesde, r.FechaHasta, r.Precio, r.Moneda.Descripcion); return dt; });

                return tablaHistorialPrecio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void InsertarActualizarArticuloCliente(int codigoArticuloCliente, int codigoArticulo, string codigoInterno, int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Articulo articulo;
                articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                ArticuloCliente articuloCliente;

                if (codigoArticuloCliente == 0)
                {
                    //validamos que no haya un articulo cliente ya existente para ese articulo y ese cliente
                    articuloCliente = (from a in articulo.ArticulosClientes where a.Cliente.Codigo == codigoCliente select a).SingleOrDefault();

                    if (articuloCliente == null)
                    {
                        articuloCliente = new ArticuloCliente();
                        articulo.ArticulosClientes.Add(articuloCliente);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    articuloCliente = (from ap in articulo.ArticulosClientes where ap.Codigo == codigoArticuloCliente select ap).SingleOrDefault();
                }

                articuloCliente.Cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);
                articuloCliente.CodigoInterno = codigoInterno;

                CatalogoArticulo.InsertarActualizar(articulo, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarArticuloCliente(int codigoArticuloCliente, int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Articulo art = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);
                ArticuloCliente artCl = art.ArticulosClientes.Where(x => x.Codigo == codigoArticuloCliente).SingleOrDefault();
                art.ArticulosClientes.Remove(artCl);
                CatalogoArticulo.InsertarActualizar(art, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarArticuloProveedor(int codigoArticuloProveedor, int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Articulo art = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);
                ArticuloProveedor artProv = art.ArticulosProveedor.Where(x => x.Codigo == codigoArticuloProveedor).SingleOrDefault();
                art.ArticulosProveedor.Remove(artProv);
                CatalogoArticulo.InsertarActualizar(art, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region ArticuloProveedor

        public static DataTable RecuperarArticulosProveedoresPorArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulosProveedores = new DataTable();
                tablaArticulosProveedores.Columns.Add("codigoArticuloProveedor");
                tablaArticulosProveedores.Columns.Add("codigoProveedor");
                tablaArticulosProveedores.Columns.Add("razonSocialProveedor");
                tablaArticulosProveedores.Columns.Add("costoActual");
                tablaArticulosProveedores.Columns.Add("tipoDocumento");
                tablaArticulosProveedores.Columns.Add("tipoMoneda");
                tablaArticulosProveedores.Columns.Add("nroDocumento");

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                articulo.ArticulosProveedor.Aggregate(tablaArticulosProveedores, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.Proveedor.Codigo, r.Proveedor.RazonSocial,
                        r.HistorialesCosto.Where(x => x.FechaHasta == null).Select(x => x.Costo).SingleOrDefault(),
                        r.Proveedor.TipoDocumento.Descripcion, r.HistorialesCosto.Where(x => x.FechaHasta == null).Select(x => x.Moneda.Descripcion).SingleOrDefault(),
                        r.Proveedor.NumeroDocumento); return dt;
                });

                return tablaArticulosProveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarHistorialCostosPorArticuloProveedor(int codigoArticuloProveedor)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaHistorialPrecio = new DataTable();
                tablaHistorialPrecio.Columns.Add("codigoHistorialCosto");
                tablaHistorialPrecio.Columns.Add("fechaDesde");
                tablaHistorialPrecio.Columns.Add("fechaHasta");
                tablaHistorialPrecio.Columns.Add("costo");

                ArticuloProveedor artProv = CatalogoArticuloProveedor.RecuperarPorCodigo(codigoArticuloProveedor, nhSesion);

                artProv.HistorialesCosto.Aggregate(tablaHistorialPrecio, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaDesde, r.FechaHasta, r.Costo); return dt; });

                return tablaHistorialPrecio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void InsertarActualizarArticuloProveedor(int codigoArticuloProveedor, int codigoArticulo, int codigoProveedor, double costo, int codigoMoneda)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction transaccion = nhSesion.BeginTransaction();

            try
            {
                Articulo articulo;
                articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                ArticuloProveedor articuloProveedor;

                if (codigoArticuloProveedor == 0)
                {
                    articuloProveedor = new ArticuloProveedor();
                    articulo.ArticulosProveedor.Add(articuloProveedor);
                }
                else
                {
                    articuloProveedor = (from ap in articulo.ArticulosProveedor where ap.Codigo == codigoArticuloProveedor select ap).SingleOrDefault();
                }

                articuloProveedor.Proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);

                HistorialCosto histPrecio = (from h in articuloProveedor.HistorialesCosto where h.FechaHasta == null select h).SingleOrDefault();

                if (histPrecio == null)
                {
                    histPrecio = new HistorialCosto();
                    histPrecio.FechaDesde = DateTime.Now;
                    histPrecio.FechaHasta = null;
                    histPrecio.Costo = costo;
                    histPrecio.Moneda = CatalogoMoneda.RecuperarPorCodigo(codigoMoneda, nhSesion);

                    articuloProveedor.HistorialesCosto.Add(histPrecio);
                }
                else
                {
                    if (histPrecio.Costo != costo || histPrecio.Moneda.Codigo != codigoMoneda)
                    {
                        histPrecio.FechaHasta = DateTime.Now.AddSeconds(-1);

                        HistorialCosto histPrecioNuevo = new HistorialCosto();
                        histPrecioNuevo.FechaDesde = DateTime.Now;
                        histPrecioNuevo.FechaHasta = null;
                        histPrecioNuevo.Costo = costo;
                        histPrecio.Moneda = CatalogoMoneda.RecuperarPorCodigo(codigoMoneda, nhSesion);

                        articuloProveedor.HistorialesCosto.Add(histPrecioNuevo);
                    }
                }

                CatalogoArticulo.InsertarActualizar(articulo, nhSesion);
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Cliente

        public static void InsertarActualizarCliente(int codigoUsuario, string razonSocial, string telefono, string fax, string mail, string numeroDocumento, string personaContacto, string numeroCuenta, string banco, string cbu, string observaciones, int numeroInterno, int codigoTipoDocumento, string codigoSCF)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Cliente cliente;

                if (codigoUsuario == 0)
                {
                    cliente = new Cliente();
                }
                else
                {
                    cliente = CatalogoCliente.RecuperarPorCodigo(codigoUsuario, nhSesion);
                }

                cliente.RazonSocial = razonSocial;
                cliente.Telefono = telefono;
                cliente.Fax = fax;
                cliente.Mail = mail;
                cliente.NumeroDocumento = numeroDocumento;
                cliente.PersonaContacto = personaContacto;
                cliente.NumeroCuenta = numeroCuenta;
                cliente.Banco = banco;
                cliente.Cbu = cbu;
                cliente.Observaciones = observaciones;
                cliente.IsInactivo = false;
                cliente.NumeroInterno = numeroInterno;
                cliente.TipoDocumento = CatalogoTipoDocumento.RecuperarPorCodigo(codigoTipoDocumento, nhSesion);
                cliente.CodigoSCF = codigoSCF;

                CatalogoCliente.InsertarActualizar(cliente, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosClientes(bool isInactivos)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaClientes = new DataTable();
                tablaClientes.Columns.Add("codigoCliente");
                tablaClientes.Columns.Add("razonSocial");
                tablaClientes.Columns.Add("provincia");
                tablaClientes.Columns.Add("localidad");
                tablaClientes.Columns.Add("direccion");
                tablaClientes.Columns.Add("telefono");
                tablaClientes.Columns.Add("mail");
                tablaClientes.Columns.Add("cuil");
                tablaClientes.Columns.Add("tipoDocumento");
                tablaClientes.Columns.Add("codigoTipoDocumento");
                tablaClientes.Columns.Add("personaContacto");
                tablaClientes.Columns.Add("numeroCuenta");
                tablaClientes.Columns.Add("banco");
                tablaClientes.Columns.Add("cbu");
                tablaClientes.Columns.Add("observaciones");
                tablaClientes.Columns.Add("fax");
                tablaClientes.Columns.Add("codigoSCF");

                List<Cliente> listaClientes = CatalogoCliente.RecuperarLista(x => x.IsInactivo == isInactivos, nhSesion);

                listaClientes.Aggregate(tablaClientes, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.RazonSocial, r.Direcciones.Count > 0 ? r.Direcciones[0].Provincia : string.Empty,
                        r.Direcciones.Count > 0 ? r.Direcciones[0].Localidad : string.Empty, r.Direcciones.Count > 0 ? r.Direcciones[0].Descripcion : string.Empty,
                        r.Telefono, r.Mail, r.NumeroDocumento, r.TipoDocumento.Descripcion,
                        r.TipoDocumento.Codigo, r.PersonaContacto, r.NumeroCuenta, r.Banco, r.Cbu, r.Observaciones, r.Fax, r.CodigoSCF); return dt;
                });

                return tablaClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void ActivarInactivarCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Cliente cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);

                if (cliente.IsInactivo)
                {
                    cliente.IsInactivo = false;
                }
                else
                {
                    cliente.IsInactivo = true;
                }

                CatalogoCliente.InsertarActualizar(cliente, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Cliente cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);

                CatalogoCliente.Eliminar(cliente, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarClientePorContratoMarco(int codigoContratoMarco)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            try
            {
                DataTable tablaCliente = new DataTable();
                tablaCliente.Columns.Add("codigoCliente");
                tablaCliente.Columns.Add("razonSocial");
                tablaCliente.Columns.Add("provincia");
                tablaCliente.Columns.Add("localidad");
                tablaCliente.Columns.Add("direccion");
                tablaCliente.Columns.Add("telefono");
                tablaCliente.Columns.Add("mail");
                tablaCliente.Columns.Add("cuil");
                tablaCliente.Columns.Add("personaContacto");
                tablaCliente.Columns.Add("numeroCuenta");
                tablaCliente.Columns.Add("banco");
                tablaCliente.Columns.Add("cbu");
                tablaCliente.Columns.Add("observaciones");

                ContratoMarco contratoMarco = CatalogoContratoMarco.RecuperarPorCodigo(codigoContratoMarco, nhSesion);

                tablaCliente.Rows.Add(new object[] { contratoMarco.Cliente.Codigo, contratoMarco.Cliente.RazonSocial, 
                    contratoMarco.Cliente.Direcciones.Count > 0 ? contratoMarco.Cliente.Direcciones[0].Provincia : string.Empty, 
                    contratoMarco.Cliente.Direcciones.Count > 0 ? contratoMarco.Cliente.Direcciones[0].Localidad : string.Empty,
                    contratoMarco.Cliente.Direcciones.Count > 0 ? contratoMarco.Cliente.Direcciones[0].Descripcion : string.Empty, contratoMarco.Cliente.Telefono, contratoMarco.Cliente.Mail, contratoMarco.Cliente.NumeroDocumento, contratoMarco.Cliente.PersonaContacto,
                    contratoMarco.Cliente.NumeroCuenta, contratoMarco.Cliente.Banco, contratoMarco.Cliente.Cbu, contratoMarco.Cliente.Observaciones});

                return tablaCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region ContratoMarco

        public static string InsertarActualizarContratosMarcosPorTabla(DataTable tablaItemsContratoMarco)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction trans = nhSesion.BeginTransaction();

            try
            {
                List<ContratoMarco> listaContratosMarco = new List<ContratoMarco>();
                List<Articulo> listaArticulos = new List<Articulo>();

                foreach (DataRow fila in tablaItemsContratoMarco.Rows)
                {
                    string descripcionCM = fila["CM"].ToString();

                    ContratoMarco cm = (from c in listaContratosMarco where c.Descripcion == descripcionCM select c).SingleOrDefault();

                    if (cm == null)
                    {
                        cm = CatalogoContratoMarco.RecuperarPor(x => x.Descripcion == descripcionCM, nhSesion);
                        if (cm == null)
                        {
                            cm = new ContratoMarco();
                            cm.Descripcion = descripcionCM;
                        }

                        cm.FechaInicio = Convert.ToDateTime(fila["INICIO"]);
                        cm.FechaFin = Convert.ToDateTime(fila["FIN"]);
                        cm.Comprador = fila["COMPRADOR"].ToString();

                        Cliente cliente = CatalogoCliente.RecuperarPorRazonSocial(fila["CLIENTE"].ToString(), nhSesion);

                        if (cliente == null)
                        {
                            return "Cliente inexistente: " + fila["CLIENTE"].ToString();
                        }

                        cm.Cliente = cliente;

                        listaContratosMarco.Add(cm);
                    }

                    string descripcionCorta = fila["DESCRIPCION"].ToString();
                    string codigoInterno = fila["PLANTA"].ToString();

                    Articulo articulo = CatalogoArticulo.RecuperarPorClienteYCodigoInternoCliente(codigoInterno, cm.Cliente.Codigo, nhSesion);

                    if (articulo == null)
                    {
                        articulo = CatalogoArticulo.RecuperarPor(x => x.DescripcionCorta == descripcionCorta, nhSesion);

                        if (articulo == null)
                        {
                            articulo = (from a in listaArticulos where a.DescripcionCorta == descripcionCorta select a).SingleOrDefault();
                            if (articulo == null)
                            {
                                articulo = new Articulo();
                                articulo.DescripcionCorta = descripcionCorta;
                                articulo.DescripcionLarga = string.Empty;
                                articulo.Marca = string.Empty;
                                articulo.NombreImagen = string.Empty;
                                articulo.UnidadMedida = CatalogoUnidadMedida.RecuperarPor(x => x.Abreviatura == fila["MEDIDA"].ToString(), nhSesion);
                                listaArticulos.Add(articulo);

                                if (articulo.UnidadMedida == null)
                                {
                                    return "No existe la unidad de medida: " + fila["MEDIDA"].ToString();
                                }
                            }
                        }
                    }

                    TipoMoneda moneda = CatalogoMoneda.RecuperarPor(x => x.Abreviatura == fila["MONEDA"].ToString(), nhSesion);
                    HistorialPrecio hist = (from h in articulo.HistorialesPrecio where h.FechaHasta == null select h).SingleOrDefault();
                    if (hist == null)
                    {
                        hist = new HistorialPrecio();
                        hist.FechaDesde = DateTime.Now;
                        hist.FechaHasta = null;
                        hist.Moneda = moneda;
                        hist.Precio = Convert.ToDouble(fila["PRECIO"]);

                        articulo.HistorialesPrecio.Add(hist);
                    }

                    ArticuloCliente artCl = (from a in articulo.ArticulosClientes where a.CodigoInterno == codigoInterno && a.Cliente.Codigo == cm.Cliente.Codigo select a).SingleOrDefault();

                    if (artCl == null)
                    {
                        artCl = (from a in articulo.ArticulosClientes where a.Cliente.Codigo == cm.Cliente.Codigo select a).SingleOrDefault();

                        if (artCl == null)
                        {
                            artCl = new ArticuloCliente();
                            artCl.CodigoInterno = codigoInterno;
                            artCl.Cliente = cm.Cliente;
                            articulo.ArticulosClientes.Add(artCl);
                        }
                    }

                    ItemContratoMarco itemCM = (from i in cm.ItemsContratoMarco where i.Articulo.DescripcionCorta == articulo.DescripcionCorta select i).SingleOrDefault();

                    if (itemCM == null)
                    {
                        itemCM = new ItemContratoMarco();
                        cm.ItemsContratoMarco.Add(itemCM);
                        itemCM.Articulo = articulo;
                    }

                    itemCM.Precio = Convert.ToDouble(fila["PRECIO"]);
                    itemCM.Posicion = Convert.ToInt32(fila["POSICION"]);
                    itemCM.TipoMoneda = moneda;

                    if (itemCM.TipoMoneda == null)
                    {
                        return "No existe moneda: " + fila["MONEDA"].ToString();
                    }
                }

                foreach (ContratoMarco cm in listaContratosMarco)
                {
                    CatalogoContratoMarco.InsertarActualizar(cm, nhSesion);
                }

                trans.Commit();
                return "ok";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        private static int RecuperarCodigoMoneda(string moneda)
        {
            switch (moneda)
            {
                case "USD":
                    return Constantes.Moneda.DOLAR;
                case "ARS":
                    return Constantes.Moneda.PESO;
                case "EUR":
                    return Constantes.Moneda.EURO;
                default:
                    return 1;
                    break;
            }
        }

        public static DataTable RecuperarContratosMarcoVigentePorCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaContratosMarco = new DataTable();
                tablaContratosMarco.Columns.Add("codigoContratoMarco");
                tablaContratosMarco.Columns.Add("fechaInicio");
                tablaContratosMarco.Columns.Add("fechaFin");
                tablaContratosMarco.Columns.Add("descripcion");

                List<ContratoMarco> listaContratosMarco = CatalogoContratoMarco.RecuperarLista(x => x.FechaInicio < DateTime.Now && x.FechaFin > DateTime.Now && x.Cliente.Codigo == codigoCliente, nhSesion);

                listaContratosMarco.Aggregate(tablaContratosMarco, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaInicio, r.FechaFin, r.Descripcion); return dt; });

                return tablaContratosMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarContratosMarcoVigentePorClienteYArticulo(int codigoCliente, int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaContratosMarco = new DataTable();
                tablaContratosMarco.Columns.Add("codigoContratoMarco");
                tablaContratosMarco.Columns.Add("fechaInicio");
                tablaContratosMarco.Columns.Add("fechaFin");
                tablaContratosMarco.Columns.Add("descripcion");

                List<ContratoMarco> listaContratosMarco = CatalogoContratoMarco.RecuperarVigentePorClienteYArticulo(codigoCliente, codigoArticulo, nhSesion);

                listaContratosMarco.Aggregate(tablaContratosMarco, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaInicio, r.FechaFin, r.Descripcion); return dt; });

                return tablaContratosMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosContratosMarcos(bool vigentes)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaContratosMarco = new DataTable();
                tablaContratosMarco.Columns.Add("codigoContratoMarco");
                tablaContratosMarco.Columns.Add("descripcion");
                tablaContratosMarco.Columns.Add("fechaInicio");
                tablaContratosMarco.Columns.Add("fechaFin");
                tablaContratosMarco.Columns.Add("codigoCliente");
                tablaContratosMarco.Columns.Add("cuilCliente");
                tablaContratosMarco.Columns.Add("razonSocialCliente");
                tablaContratosMarco.Columns.Add("comprador");

                List<ContratoMarco> listaContratosMarco = new List<ContratoMarco>();

                if (vigentes)
                {
                    listaContratosMarco = CatalogoContratoMarco.RecuperarLista(x => x.FechaFin >= DateTime.Now, nhSesion);
                }
                else
                {
                    listaContratosMarco = CatalogoContratoMarco.RecuperarLista(x => x.FechaFin <= DateTime.Now, nhSesion);
                }

                listaContratosMarco.Aggregate(tablaContratosMarco, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.Descripcion, r.FechaInicio, r.FechaFin, r.Cliente.Codigo,
                        r.Cliente.NumeroDocumento, r.Cliente.RazonSocial, r.Comprador); return dt;
                });

                return tablaContratosMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosItemsContratoMarco(int codigoContratoMarco)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaItemsContratoMarco = new DataTable();
                tablaItemsContratoMarco.Columns.Add("codigoItemContratoMarco");
                tablaItemsContratoMarco.Columns.Add("codigoArticulo");
                tablaItemsContratoMarco.Columns.Add("descripcioncorta");
                tablaItemsContratoMarco.Columns.Add("precio");

                ContratoMarco contratoMarco = CatalogoContratoMarco.RecuperarPorCodigo(codigoContratoMarco, nhSesion);

                contratoMarco.ItemsContratoMarco.Aggregate(tablaItemsContratoMarco, (dt, r) => { dt.Rows.Add(r.Codigo, r.Articulo.Codigo, r.Articulo.DescripcionCorta, r.Precio); return dt; });

                return tablaItemsContratoMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static string EliminarContratoMarco(int codigoContratoMarco)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                List<NotaDePedido> listaNP = CatalogoNotaDePedido.RecuperarLista(x => x.ContratoMarco.Codigo == codigoContratoMarco, nhSesion);
                if (listaNP.Count > 0)
                {
                    return "NotaDePedido";
                }
                else
                {
                    ContratoMarco cm = CatalogoContratoMarco.RecuperarPorCodigo(codigoContratoMarco, nhSesion);
                    CatalogoContratoMarco.Eliminar(cm, nhSesion);
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Entregas/Remitos

        public static DataTable RecuperarTodasEntregas(bool sinFacturaAsociada)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaEntrega = new DataTable();
                tablaEntrega.Columns.Add("codigoEntrega");
                tablaEntrega.Columns.Add("codigoNotaDePedido");
                tablaEntrega.Columns.Add("codigoCliente");
                tablaEntrega.Columns.Add("razonSocialCliente");
                tablaEntrega.Columns.Add("cuitCliente");//Agrego nro documento
                tablaEntrega.Columns.Add("codigoSCF");
                tablaEntrega.Columns.Add("fechaEmision");
                tablaEntrega.Columns.Add("numeroNotaDePedido");
                tablaEntrega.Columns.Add("numeroRemito");
                tablaEntrega.Columns.Add("codigoEstado");
                tablaEntrega.Columns.Add("observaciones");
                tablaEntrega.Columns.Add("codigoTransporte");
                tablaEntrega.Columns.Add("razonSocialTransporte");
                tablaEntrega.Columns.Add("direccion");
                tablaEntrega.Columns.Add("codigoDireccion");
                tablaEntrega.Columns.Add("domicilio");
                tablaEntrega.Columns.Add("localidad");
                tablaEntrega.Columns.Add("cai");
                tablaEntrega.Columns.Add("fechaVencimientoCai");

                List<Entrega> listaEntregas = new List<Entrega>();

                if (sinFacturaAsociada)
                {
                    List<Entrega> listaEntregasConFacturas = (from f in CatalogoFactura.RecuperarTodos(nhSesion) select f.Entregas).SelectMany(x => x).ToList();
                    listaEntregas = CatalogoEntrega.RecuperarLasQueNoEstanEnLaLista(listaEntregasConFacturas, nhSesion);
                }
                else
                {
                    listaEntregas = CatalogoEntrega.RecuperarTodos(nhSesion);
                }

                listaEntregas.OrderByDescending(x => x.CodigoEstado).Aggregate(tablaEntrega, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.NotaDePedido.Codigo, r.NotaDePedido.Cliente.Codigo,
                        r.NotaDePedido.Cliente.RazonSocial, r.NotaDePedido.Cliente.NumeroDocumento, r.NotaDePedido.Cliente.CodigoSCF,
                        r.FechaEmision.ToString("dd/MM/yyyy"), r.NotaDePedido.NumeroInternoCliente, r.NumeroRemito,
                        r.CodigoEstado, r.Observaciones, r.Transporte.Codigo, r.Transporte.RazonSocial,
                        r.Direccion.Descripcion + ", " + r.Direccion.Localidad + ", " + r.Direccion.Provincia, r.Direccion.Codigo, r.Direccion.Descripcion, r.Direccion.Localidad,
                        r.Cai, r.FechaVencimientoCai.ToString("dd/MM/yyyy")); return dt;
                });

                return tablaEntrega;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarUltimaEntrega()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaEntrega = new DataTable();
                tablaEntrega.Columns.Add("codigoEntrega");
                tablaEntrega.Columns.Add("fechaEmision");
                tablaEntrega.Columns.Add("numeroRemito");
                tablaEntrega.Columns.Add("codigoEstado");
                tablaEntrega.Columns.Add("observaciones");

                Entrega entrega = CatalogoEntrega.RecuperarUltima(nhSesion);

                if (entrega != null)
                {
                    tablaEntrega.Rows.Add(new object[] { entrega.Codigo, entrega.FechaEmision, entrega.NumeroRemito, entrega.CodigoEstado, entrega.Observaciones });
                }

                return tablaEntrega;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarUltimaNotaDePedido()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaNotaDePedido = new DataTable();
                tablaNotaDePedido.Columns.Add("codigoNotaDePedido");
                tablaNotaDePedido.Columns.Add("numeroInternoCliente");
                tablaNotaDePedido.Columns.Add("fechaEmision");
                tablaNotaDePedido.Columns.Add("codigoEstado");
                tablaNotaDePedido.Columns.Add("observaciones");


                NotaDePedido notaDePedido = CatalogoNotaDePedido.RecuperarUltima(nhSesion);

                if (notaDePedido != null)
                {
                    tablaNotaDePedido.Rows.Add(new object[] { notaDePedido.Codigo, notaDePedido.NumeroInternoCliente, notaDePedido.FechaEmision, notaDePedido.CodigoEstado, notaDePedido.Observaciones });
                }

                return tablaNotaDePedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void InsertarActualizarEntrega(int codigoEntrega, DateTime fechaEmision, int codigoNotaPedido, int numeroRemito, string observaciones, DataTable tablaItemsEntrega, int codigoTransporte, int codigoDireccion, string cai, DateTime fechaVencimientoCai)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction tran = nhSesion.BeginTransaction();

            try
            {
                Entrega entrega;
                if (codigoEntrega == 0)
                {
                    entrega = new Entrega();
                }
                else
                {
                    entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);
                }

                NotaDePedido notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaPedido, nhSesion);

                entrega.CodigoEstado = Constantes.Estados.VIGENTE;
                entrega.FechaEmision = fechaEmision;
                entrega.NotaDePedido = notaDePedido;
                entrega.NumeroRemito = numeroRemito;
                entrega.Observaciones = observaciones;
                entrega.Transporte = CatalogoTransporte.RecuperarPorCodigo(codigoTransporte, nhSesion);
                entrega.Direccion = CatalogoDireccion.RecuperarPorCodigo(codigoDireccion, nhSesion);
                entrega.Cai = cai;
                entrega.FechaVencimientoCai = fechaVencimientoCai;

                foreach (DataRow filaItem in tablaItemsEntrega.Rows)
                {
                    int codigoItemEntrega = Convert.ToInt32(filaItem["codigoItemEntrega"]);
                    ItemEntrega item;

                    if (codigoItemEntrega < 1)
                    {
                        item = new ItemEntrega();
                        item.Precio = (from i in notaDePedido.ItemsNotaDePedido where i.Codigo == Convert.ToInt32(filaItem["codigoItemNotaDePedido"]) select i.Precio).SingleOrDefault();
                        entrega.ItemsEntrega.Add(item);
                    }
                    else
                    {
                        item = (from i in entrega.ItemsEntrega where i.Codigo == codigoItemEntrega select i).SingleOrDefault();

                        if (item.Precio == 0)
                        {
                            item.Precio = (from i in notaDePedido.ItemsNotaDePedido where i.Codigo == Convert.ToInt32(filaItem["codigoItemNotaDePedido"]) select i.Precio).SingleOrDefault();
                        }

                        if (!Convert.IsDBNull(filaItem["isEliminada"]) && Convert.ToBoolean(filaItem["isEliminada"]))
                        {
                            entrega.ItemsEntrega.Remove(item);
                        }
                    }

                    item.CantidadAEntregar = Convert.ToInt32(filaItem["cantidad"]);
                    item.ArticuloProveedor = null;
                    item.ItemNotaDePedido = (from i in notaDePedido.ItemsNotaDePedido where i.Codigo == Convert.ToInt32(filaItem["codigoItemNotaDePedido"]) select i).SingleOrDefault();
                }

                CatalogoEntrega.InsertarActualizar(entrega, nhSesion);
                ValidarNotaDePedido(notaDePedido, nhSesion);

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        private static void ValidarNotaDePedido(NotaDePedido notaDePedido, ISession nhSesion)
        {
            try
            {
                int cantidadCumplidas = 0;
                List<Entrega> listaEntregas = CatalogoEntrega.RecuperarLista(x => x.NotaDePedido.Codigo == notaDePedido.Codigo && x.CodigoEstado != Constantes.Estados.ANULADA, nhSesion);
                if (listaEntregas.Count > 0) //calido que no haya alguna entrega que cumpla el item nota de pedido
                {
                    List<ItemNotaDePedido> listaBorrar = new List<ItemNotaDePedido>();

                    foreach (ItemNotaDePedido itemNP in notaDePedido.ItemsNotaDePedido)
                    {
                        List<ItemEntrega> listaItemsEntrega = (from e in listaEntregas where (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault() != null select (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault()).ToList();
                        int cantidadAEntregarTotal = (from e in listaItemsEntrega select e.CantidadAEntregar).Sum();

                        if (cantidadAEntregarTotal >= itemNP.CantidadPedida)
                        {
                            cantidadCumplidas++;
                        }
                    }
                }

                if (cantidadCumplidas == notaDePedido.ItemsNotaDePedido.Count)
                {
                    notaDePedido.CodigoEstado = Constantes.Estados.ENTREGADA;
                    CatalogoNotaDePedido.InsertarActualizar(notaDePedido, nhSesion);
                }
                else if (notaDePedido.CodigoEstado == Constantes.Estados.ENTREGADA)
                {
                    notaDePedido.CodigoEstado = Constantes.Estados.VIGENTE;
                    CatalogoNotaDePedido.InsertarActualizar(notaDePedido, nhSesion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActivarAnularEntrega(int codigoEntrega, string observaciones)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction tran = nhSesion.BeginTransaction();

            try
            {
                Entrega entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);

                if (entrega.CodigoEstado == Constantes.Estados.ANULADA)
                {
                    entrega.CodigoEstado = Constantes.Estados.VIGENTE;
                }
                else
                {
                    entrega.CodigoEstado = Constantes.Estados.ANULADA;
                }

                entrega.Observaciones = observaciones;

                CatalogoEntrega.InsertarActualizar(entrega, nhSesion);
                ValidarNotaDePedido(entrega.NotaDePedido, nhSesion);

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EntregadaPendienteEntrega(int codigoEntrega, string observaciones)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Entrega entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);

                if (entrega.CodigoEstado == Constantes.Estados.ENTREGADA)
                {
                    entrega.CodigoEstado = Constantes.Estados.VIGENTE;
                }
                else
                {
                    entrega.CodigoEstado = Constantes.Estados.ENTREGADA;
                }

                entrega.Observaciones = observaciones;

                CatalogoEntrega.InsertarActualizar(entrega, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static string EliminarEntrega(int codigoEntrega)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction trans = nhSesion.BeginTransaction();

            try
            {
                List<Factura> listaFacturas = CatalogoFactura.RecuperarPorEntrega(codigoEntrega, nhSesion);

                if (listaFacturas.Count > 0)
                {
                    return "Factura";
                }
                else
                {
                    Entrega entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);
                    ValidarNotaDePedido(entrega.NotaDePedido, nhSesion);
                    CatalogoEntrega.Eliminar(entrega, nhSesion);
                    trans.Commit();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region ItemEntrega

        public static DataTable RecuperarItemsEntrega(int codigoEntrega)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaItemsEntrega = new DataTable();
                tablaItemsEntrega.Columns.Add("codigoItemEntrega");
                tablaItemsEntrega.Columns.Add("codigoEntrega");
                tablaItemsEntrega.Columns.Add("codigoArticulo");
                tablaItemsEntrega.Columns.Add("descripcionCorta");
                tablaItemsEntrega.Columns.Add("cantidad");
                tablaItemsEntrega.Columns.Add("codigoProveedor");
                tablaItemsEntrega.Columns.Add("razonSocialProveedor");
                tablaItemsEntrega.Columns.Add("codigoItemNotaDePedido");
                tablaItemsEntrega.Columns.Add("posicion");
                tablaItemsEntrega.Columns.Add("codigoArticuloCliente");
                tablaItemsEntrega.Columns.Add("codigoNotaDePedido");
                tablaItemsEntrega.Columns.Add("numeroNotaDePedido");
                tablaItemsEntrega.Columns.Add("codigoSCF");
                tablaItemsEntrega.Columns.Add("precioUnitario");
                tablaItemsEntrega.Columns.Add("precioTotal");
                tablaItemsEntrega.Columns.Add("razonSocialCliente");
                tablaItemsEntrega.Columns.Add("nroDocumentoCliente");
                tablaItemsEntrega.Columns.Add("localidadCliente");
                tablaItemsEntrega.Columns.Add("direccionCliente");

                Entrega entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);

                if (entrega != null)
                {
                    entrega.ItemsEntrega.Aggregate(tablaItemsEntrega, (dt, r) =>
                    {
                        dt.Rows.Add(r.Codigo, entrega.Codigo, r.ItemNotaDePedido.Articulo.Codigo, r.ItemNotaDePedido.Articulo.DescripcionCorta, r.CantidadAEntregar,
                            r.ArticuloProveedor != null ? r.ArticuloProveedor.Proveedor.Codigo : 0, r.ArticuloProveedor != null ? r.ArticuloProveedor.Proveedor.RazonSocial : "",
                            r.ItemNotaDePedido.Codigo, "Posición:" + r.ItemNotaDePedido.Posicion,
                            r.ItemNotaDePedido.Articulo.ArticulosClientes.Where(x => x.Cliente.Codigo == entrega.NotaDePedido.Cliente.Codigo).SingleOrDefault() != null ?
                            r.ItemNotaDePedido.Articulo.ArticulosClientes.Where(x => x.Cliente.Codigo == entrega.NotaDePedido.Cliente.Codigo).SingleOrDefault().CodigoInterno : string.Empty,
                            entrega.NotaDePedido.Codigo, entrega.NotaDePedido.NumeroInternoCliente, entrega.NotaDePedido.Cliente.CodigoSCF, r.Precio, (double)decimal.Round((decimal)(r.Precio * r.CantidadAEntregar), 2),
                            entrega.NotaDePedido.Cliente.RazonSocial, entrega.NotaDePedido.Cliente.NumeroDocumento,
                            entrega.NotaDePedido.Cliente.Direcciones.Count > 0 ? entrega.NotaDePedido.Cliente.Direcciones[0].Localidad : string.Empty,
                            entrega.NotaDePedido.Cliente.Direcciones.Count > 0 ? entrega.NotaDePedido.Cliente.Direcciones[0].Descripcion : string.Empty); return dt;
                    });
                }

                return tablaItemsEntrega;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarItemsEntregaPorFactura(int codigoFactura)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaItemsEntrega = new DataTable();
                tablaItemsEntrega.Columns.Add("codigoEntrega");
                tablaItemsEntrega.Columns.Add("nroRemito");
                tablaItemsEntrega.Columns.Add("codigoItemEntrega");
                tablaItemsEntrega.Columns.Add("codigoArticulo");
                tablaItemsEntrega.Columns.Add("descripcionCorta");
                tablaItemsEntrega.Columns.Add("cantidad");
                tablaItemsEntrega.Columns.Add("codigoProveedor");
                tablaItemsEntrega.Columns.Add("razonSocialProveedor");
                tablaItemsEntrega.Columns.Add("codigoItemNotaDePedido");
                tablaItemsEntrega.Columns.Add("posicion");
                tablaItemsEntrega.Columns.Add("codigoArticuloCliente");
                tablaItemsEntrega.Columns.Add("codigoNotaDePedido");
                tablaItemsEntrega.Columns.Add("numeroNotaDePedido");
                tablaItemsEntrega.Columns.Add("codigoSCF");
                tablaItemsEntrega.Columns.Add("precioUnitario");
                tablaItemsEntrega.Columns.Add("precioTotal");
                tablaItemsEntrega.Columns.Add("razonSocialCliente");
                tablaItemsEntrega.Columns.Add("nroDocumentoCliente");
                tablaItemsEntrega.Columns.Add("localidadCliente");
                tablaItemsEntrega.Columns.Add("direccionCliente");
                tablaItemsEntrega.Columns.Add("razonSocialTransporte");

                Factura factura = CatalogoFactura.RecuperarPorCodigo(codigoFactura, nhSesion);

                foreach (Entrega entrega in factura.Entregas)
                {
                    if (entrega != null)
                    {
                        entrega.ItemsEntrega.Aggregate(tablaItemsEntrega, (dt, r) =>
                        {
                            dt.Rows.Add(entrega.Codigo, entrega.NumeroRemito, r.Codigo, r.ItemNotaDePedido.Articulo.Codigo, r.ItemNotaDePedido.Articulo.DescripcionCorta, r.CantidadAEntregar,
                                r.ArticuloProveedor != null ? r.ArticuloProveedor.Proveedor.Codigo : 0, r.ArticuloProveedor != null ? r.ArticuloProveedor.Proveedor.RazonSocial : "", r.ItemNotaDePedido.Codigo, "Posición:" + r.ItemNotaDePedido.Posicion,
                                r.ItemNotaDePedido.Articulo.ArticulosClientes.Where(x => x.Cliente.Codigo == entrega.NotaDePedido.Cliente.Codigo).SingleOrDefault() != null ?
                                r.ItemNotaDePedido.Articulo.ArticulosClientes.Where(x => x.Cliente.Codigo == entrega.NotaDePedido.Cliente.Codigo).SingleOrDefault().CodigoInterno : string.Empty,
                                entrega.NotaDePedido.Codigo, entrega.NotaDePedido.NumeroInternoCliente, entrega.NotaDePedido.Cliente.CodigoSCF, r.Precio, (double)decimal.Round((decimal)(r.Precio * r.CantidadAEntregar), 2),
                                entrega.NotaDePedido.Cliente.RazonSocial, entrega.NotaDePedido.Cliente.NumeroDocumento,
                                entrega.NotaDePedido.Cliente.Direcciones.Count > 0 ? entrega.NotaDePedido.Cliente.Direcciones[0].Localidad : string.Empty,
                                entrega.NotaDePedido.Cliente.Direcciones.Count > 0 ? entrega.NotaDePedido.Cliente.Direcciones[0].Descripcion : string.Empty, entrega.Transporte.RazonSocial); return dt;
                        });
                    }
                }

                return tablaItemsEntrega;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarNotaDePedido(int codigoNotaDePedido)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                NotaDePedido notadePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion);

                CatalogoNotaDePedido.Eliminar(notadePedido, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region ItemNotaDePedido

        public static DataTable RecuperarItemsNotaDePedido(int codigoNotaDePedido)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaItemsNotaDePedido = new DataTable();
                tablaItemsNotaDePedido.Columns.Add("codigoItemNotaDePedido");
                tablaItemsNotaDePedido.Columns.Add("codigoArticulo");
                tablaItemsNotaDePedido.Columns.Add("descripcionCorta");
                tablaItemsNotaDePedido.Columns.Add("descripcionLarga");
                tablaItemsNotaDePedido.Columns.Add("marca");
                tablaItemsNotaDePedido.Columns.Add("precio");
                tablaItemsNotaDePedido.Columns.Add("cantidad");
                tablaItemsNotaDePedido.Columns.Add("fechaEntrega");
                tablaItemsNotaDePedido.Columns.Add("cantidadEntregada");
                tablaItemsNotaDePedido.Columns.Add("codigoMoneda");
                tablaItemsNotaDePedido.Columns.Add("descripcionMoneda");
                tablaItemsNotaDePedido.Columns.Add("posicion");
                tablaItemsNotaDePedido.Columns.Add("subtotal");
                NotaDePedido notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion);

                List<Entrega> listaEntregas = CatalogoEntrega.RecuperarLista(x => x.NotaDePedido.Codigo == codigoNotaDePedido, nhSesion);

                foreach (ItemNotaDePedido item in notaDePedido.ItemsNotaDePedido)
                {
                    int cantidadEntregada = (from e in listaEntregas select (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == item.Codigo select i.CantidadAEntregar).SingleOrDefault()).Sum();

                    tablaItemsNotaDePedido.Rows.Add(item.Codigo, item.Articulo.Codigo, item.Articulo.DescripcionCorta, item.Articulo.DescripcionLarga, item.Articulo.Marca,
                    item.Precio, item.CantidadPedida, item.FechaEntrega.ToString("dd/MM/yyyy"), cantidadEntregada, item.Articulo.RecuperarHistorialPrecioActual().Moneda.Codigo,
                    item.Articulo.RecuperarHistorialPrecioActual().Moneda.Descripcion, item.Posicion, item.CantidadPedida * item.Precio);
                }


                return tablaItemsNotaDePedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Moneda

        public static DataTable RecuperarTodasMonedas()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaMonedas = new DataTable();
                tablaMonedas.Columns.Add("codigo");
                tablaMonedas.Columns.Add("descripcion");
                tablaMonedas.Columns.Add("abreviatura");

                List<TipoMoneda> listaMonedas = CatalogoMoneda.RecuperarTodos(nhSesion);

                listaMonedas.Aggregate(tablaMonedas, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion, r.Abreviatura); return dt; });

                return tablaMonedas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        public static DataTable RecuperarContratosMarcoVigente()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaContratosMarco = new DataTable();
                tablaContratosMarco.Columns.Add("codigoContratoMarco");
                tablaContratosMarco.Columns.Add("fechaInicio");
                tablaContratosMarco.Columns.Add("fechaFin");
                tablaContratosMarco.Columns.Add("descripcion");

                List<ContratoMarco> listaContratosMarco = CatalogoContratoMarco.RecuperarLista(x => x.FechaInicio < DateTime.Now, nhSesion);

                listaContratosMarco.Aggregate(tablaContratosMarco, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaInicio, r.FechaFin, r.Descripcion); return dt; });

                return tablaContratosMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #region NotaDePedido

        public static DataTable RecuperarTodasNotasDePedido(bool soloVigentes)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaNotasDePedido = new DataTable();
                tablaNotasDePedido.Columns.Add("codigoNotaDePedido");
                tablaNotasDePedido.Columns.Add("numeroInternoCliente");
                tablaNotasDePedido.Columns.Add("fechaEmision");
                tablaNotasDePedido.Columns.Add("codigoEstado");
                tablaNotasDePedido.Columns.Add("codigoContratoMarco");
                tablaNotasDePedido.Columns.Add("descripcionContratoMarco");
                tablaNotasDePedido.Columns.Add("codigoCliente");
                tablaNotasDePedido.Columns.Add("razonSocialCliente");
                tablaNotasDePedido.Columns.Add("fechaHoraProximaEntrega");
                tablaNotasDePedido.Columns.Add("observaciones");

                List<NotaDePedido> listaNotasDePedido;
                if (soloVigentes)
                {
                    listaNotasDePedido = CatalogoNotaDePedido.RecuperarLista(x => x.CodigoEstado == Constantes.Estados.VIGENTE, nhSesion);
                }
                else
                {
                    listaNotasDePedido = CatalogoNotaDePedido.RecuperarTodos(nhSesion);
                }

                foreach (NotaDePedido notaPedido in listaNotasDePedido.OrderByDescending(x => x.CodigoEstado))
                {
                    int codigoEstado = 0;
                    DateTime fechaHoraProximaEntrega = DateTime.MinValue;

                    if (notaPedido.ItemsNotaDePedido.Count > 0)
                    {
                        List<Entrega> listaEntregas = CatalogoEntrega.RecuperarLista(x => x.NotaDePedido.Codigo == notaPedido.Codigo && x.CodigoEstado != Constantes.Estados.ANULADA, nhSesion);

                        switch (notaPedido.CodigoEstado)
                        {
                            case Constantes.Estados.VIGENTE:
                                List<ItemNotaDePedido> listaItemsNotaDePedidoVencidos = (from n in notaPedido.ItemsNotaDePedido where n.FechaEntrega < DateTime.Now select n).ToList();

                                if (listaEntregas.Count > 0) //valido que no haya alguna entrega que cumpla el item nota de pedido
                                {
                                    List<ItemNotaDePedido> listaBorrar = new List<ItemNotaDePedido>();

                                    foreach (ItemNotaDePedido itemNP in listaItemsNotaDePedidoVencidos)
                                    {
                                        List<ItemEntrega> listaItemsEntrega = (from e in listaEntregas where (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault() != null select (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault()).ToList();
                                        int cantidadAEntregarTotal = (from e in listaItemsEntrega select e.CantidadAEntregar).Sum();

                                        if (cantidadAEntregarTotal >= itemNP.CantidadPedida)
                                        {
                                            listaBorrar.Add(itemNP);
                                        }
                                    }

                                    foreach (ItemNotaDePedido itemBorrar in listaBorrar)
                                    {
                                        listaItemsNotaDePedidoVencidos.Remove(itemBorrar);
                                    }
                                }

                                if (listaItemsNotaDePedidoVencidos.Count > 0)
                                {
                                    codigoEstado = Constantes.Estados.VENCIDA;
                                    fechaHoraProximaEntrega = listaItemsNotaDePedidoVencidos.OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                }
                                else
                                {
                                    List<ItemNotaDePedido> listaItemsNotaDePedidoProximosAVencer = (from n in notaPedido.ItemsNotaDePedido where n.FechaEntrega < DateTime.Now.AddDays(5) select n).ToList();

                                    if (listaEntregas.Count > 0) //valido que no haya alguna entrega que cumpla el item nota de pedido
                                    {
                                        List<ItemNotaDePedido> listaBorrar = new List<ItemNotaDePedido>();

                                        foreach (ItemNotaDePedido itemNP in listaItemsNotaDePedidoProximosAVencer)
                                        {
                                            List<ItemEntrega> listaItemsEntrega = (from e in listaEntregas where (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault() != null select (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault()).ToList();
                                            int cantidadAEntregarTotal = (from e in listaItemsEntrega select e.CantidadAEntregar).Sum();

                                            if (cantidadAEntregarTotal >= itemNP.CantidadPedida)
                                            {
                                                listaBorrar.Add(itemNP);
                                            }
                                        }

                                        foreach (ItemNotaDePedido itemBorrar in listaBorrar)
                                        {
                                            listaItemsNotaDePedidoProximosAVencer.Remove(itemBorrar);
                                        }
                                    }

                                    if (listaItemsNotaDePedidoProximosAVencer.Count > 0)
                                    {
                                        codigoEstado = Constantes.Estados.PROXIMA_VENCER;
                                        fechaHoraProximaEntrega = listaItemsNotaDePedidoProximosAVencer.OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                    }
                                    else
                                    {
                                        codigoEstado = Constantes.Estados.VIGENTE;
                                        List<ItemNotaDePedido> listaEntregadas = (from n in notaPedido.ItemsNotaDePedido where n.FechaEntrega < DateTime.Now.AddDays(5) select n).ToList();
                                        listaEntregadas.AddRange((from n in notaPedido.ItemsNotaDePedido where n.FechaEntrega < DateTime.Now select n).ToList());

                                        fechaHoraProximaEntrega = notaPedido.ItemsNotaDePedido.Where(x => !listaEntregadas.Select(c => c.Codigo).ToList().Contains(x.Codigo)).OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                    }
                                }

                                break;
                            case Constantes.Estados.ANULADA:
                                codigoEstado = Constantes.Estados.ANULADA;
                                break;

                            case Constantes.Estados.ENTREGADA:
                                codigoEstado = Constantes.Estados.ENTREGADA;
                                break;
                        }
                    }

                    tablaNotasDePedido.Rows.Add(new object[] { notaPedido.Codigo, notaPedido.NumeroInternoCliente, notaPedido.FechaEmision, codigoEstado, notaPedido.ContratoMarco != null ? notaPedido.ContratoMarco.Codigo : 0, 
                        notaPedido.ContratoMarco != null ? notaPedido.ContratoMarco.Descripcion : "", notaPedido.Cliente.Codigo, notaPedido.Cliente.RazonSocial, fechaHoraProximaEntrega == DateTime.MinValue ? "" : fechaHoraProximaEntrega.ToString(), notaPedido.Observaciones});
                }

                DataView dv = tablaNotasDePedido.DefaultView;
                dv.Sort = "codigoEstado desc";

                return dv.ToTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        /// <summary>
        /// Columnas del DataTabla tablaItemsNotaDePedido: codigoItemNotaDePedido, codigoArticulo, cantidad, fechaEntrega
        /// Devuelve un string.Empty si está todo OK, si algun item nota de pedido tiene asociado un remito, devuelve "TieneAsociadoRemito"
        /// </summary>
        public static string InsertarActualizarNotaDePedido(int codigoNotaDePedido, string numeroInternoCliente, DateTime fechaEmision, string observaciones, int codigoContratoMarco, int codigoCliente, DataTable tablaItemsNotaDePedido)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction transaccion = nhSesion.BeginTransaction();

            string rta = string.Empty;

            try
            {
                NotaDePedido notaDePedido;

                if (codigoNotaDePedido == 0)
                {
                    notaDePedido = new NotaDePedido();
                    notaDePedido.CodigoEstado = Constantes.Estados.VIGENTE;
                }
                else
                {
                    notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion);
                }

                notaDePedido.Cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);
                notaDePedido.ContratoMarco = codigoContratoMarco == 0 ? null : CatalogoContratoMarco.RecuperarPorCodigo(codigoContratoMarco, nhSesion);
                notaDePedido.FechaEmision = fechaEmision;
                notaDePedido.NumeroInternoCliente = numeroInternoCliente;
                notaDePedido.Observaciones = observaciones;

                foreach (DataRow filaItemNotaDePedido in tablaItemsNotaDePedido.Rows)
                {
                    int codigoItemNotaDePedido = Convert.ToInt32(filaItemNotaDePedido["codigoItemNotaDePedido"]);
                    ItemNotaDePedido item;

                    if (codigoItemNotaDePedido < 1)
                    {
                        item = new ItemNotaDePedido();
                        notaDePedido.ItemsNotaDePedido.Add(item);
                    }
                    else
                    {
                        item = (from n in notaDePedido.ItemsNotaDePedido where n.Codigo == codigoItemNotaDePedido select n).SingleOrDefault();

                        //Me fijo si el item esta eliminado
                        if (!Convert.IsDBNull(filaItemNotaDePedido["isEliminada"]) && Convert.ToBoolean(filaItemNotaDePedido["isEliminada"]))
                        {
                            //Valido que el item nota de pedido no tenga asociado un remito
                            if (CatalogoEntrega.TieneRemito(item.Codigo, nhSesion)) //POR AHORA QUEDA COMENTADO POR QUE EL METODO DEL CATALOGO NO FUNCIONA
                            {
                                notaDePedido.ItemsNotaDePedido.Remove(item);
                            }
                            else
                            {
                                rta = "TieneAsociadoRemito";
                            }
                        }
                    }

                    item.Articulo = CatalogoArticulo.RecuperarPorCodigo(Convert.ToInt32(filaItemNotaDePedido["codigoArticulo"]), nhSesion);
                    item.CantidadPedida = Convert.ToInt32(filaItemNotaDePedido["cantidad"]);
                    item.FechaEntrega = Convert.ToDateTime(filaItemNotaDePedido["fechaEntrega"]);
                    item.Precio = Convert.ToDouble(filaItemNotaDePedido["precio"]);
                    item.Posicion = Convert.ToInt32(filaItemNotaDePedido["posicion"]);
                }

                CatalogoNotaDePedido.InsertarActualizar(notaDePedido, nhSesion);
                transaccion.Commit();

                return rta;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void ActivarAnularNotaDePedido(int codigoNotaDePedido, string observaciones)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                NotaDePedido notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion);

                if (notaDePedido.CodigoEstado == Constantes.Estados.ANULADA)
                {
                    notaDePedido.CodigoEstado = Constantes.Estados.VIGENTE;
                }
                else
                {
                    notaDePedido.CodigoEstado = Constantes.Estados.ANULADA;
                }

                notaDePedido.Observaciones = observaciones;

                CatalogoNotaDePedido.InsertarActualizar(notaDePedido, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Proveedores

        public static void InsertarActualizarProveedor(int codigoProveedor, string razonSocial, string provincia, string localidad, string direccion, string telefono, string fax, string mail, string numeroDocumento, string personaContacto, string numeroCuenta, string banco, string cbu, string observaciones, int numeroInterno, int codigoTipoDocumento)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Proveedor proveedor;

                if (codigoProveedor == 0)
                {
                    proveedor = new Proveedor();
                }
                else
                {
                    proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);
                }

                proveedor.RazonSocial = razonSocial;
                proveedor.Provincia = provincia;
                proveedor.Localidad = localidad;
                proveedor.Direccion = direccion;
                proveedor.Telefono = telefono;
                proveedor.Mail = mail;
                proveedor.NumeroDocumento = numeroDocumento;
                proveedor.PersonaContacto = personaContacto;
                proveedor.NumeroCuenta = numeroCuenta;
                proveedor.Banco = banco;
                proveedor.Fax = fax;
                proveedor.Cbu = cbu;
                proveedor.Observaciones = observaciones;
                proveedor.IsInactivo = false;
                proveedor.NumeroInterno = numeroInterno;
                proveedor.TipoDocumento = CatalogoTipoDocumento.RecuperarPorCodigo(codigoTipoDocumento, nhSesion);

                CatalogoProveedor.InsertarActualizar(proveedor, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosProveedores(bool isInactivos)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaProveedores = new DataTable();
                tablaProveedores.Columns.Add("codigoProveedor");
                tablaProveedores.Columns.Add("razonSocial");
                tablaProveedores.Columns.Add("provincia");
                tablaProveedores.Columns.Add("localidad");
                tablaProveedores.Columns.Add("direccion");
                tablaProveedores.Columns.Add("telefono");
                tablaProveedores.Columns.Add("mail");
                tablaProveedores.Columns.Add("cuil");
                tablaProveedores.Columns.Add("tipoDocumento");
                tablaProveedores.Columns.Add("codigoTipoDocumento");
                tablaProveedores.Columns.Add("personaContacto");
                tablaProveedores.Columns.Add("numeroCuenta");
                tablaProveedores.Columns.Add("banco");
                tablaProveedores.Columns.Add("cbu");
                tablaProveedores.Columns.Add("observaciones");
                tablaProveedores.Columns.Add("fax");

                List<Proveedor> listaProveedores = CatalogoProveedor.RecuperarLista(x => x.IsInactivo == isInactivos, nhSesion);

                listaProveedores.Aggregate(tablaProveedores, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.RazonSocial, r.Provincia, r.Localidad, r.Direccion, r.Telefono, r.Mail, r.NumeroDocumento,
                        r.TipoDocumento.Descripcion, r.TipoDocumento.Codigo,
                        r.PersonaContacto, r.NumeroCuenta, r.Banco, r.Cbu, r.Observaciones, r.Fax); return dt;
                });

                return tablaProveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void ActivarInactivarProveedor(int codigoProveedor)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Proveedor proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);

                if (proveedor.IsInactivo)
                {
                    proveedor.IsInactivo = false;
                }
                else
                {
                    proveedor.IsInactivo = true;
                }

                CatalogoProveedor.InsertarActualizar(proveedor, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarProveedor(int codigoProveedor)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Proveedor proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);

                CatalogoProveedor.Eliminar(proveedor, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region UnidadMedida

        public static DataTable RecuperarTodasUnidadesMedida()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUnidadesMedida = new DataTable();
                tablaUnidadesMedida.Columns.Add("codigo");
                tablaUnidadesMedida.Columns.Add("descripcion");
                tablaUnidadesMedida.Columns.Add("abreviatura");

                List<UnidadMedida> listaUnidadesMedida = CatalogoUnidadMedida.RecuperarTodos(nhSesion);

                listaUnidadesMedida.Aggregate(tablaUnidadesMedida, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion, r.Abreviatura); return dt; });

                return tablaUnidadesMedida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Usuarios

        public static void InsertarActualizarUsuario(int codigoUsuario, string nombreUsuario, string contraseña)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Usuario usuario;

                if (codigoUsuario == 0)
                {
                    usuario = new Usuario();
                }
                else
                {
                    usuario = CatalogoUsuario.RecuperarPorCodigo(codigoUsuario, nhSesion);
                }

                usuario.NombreUsuario = nombreUsuario;
                usuario.Contraseña = contraseña;

                CatalogoUsuario.InsertarActualizar(usuario, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarLogueoUsuario(string nombreUsuario, string contraseña)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario.Columns.Add("codigoUsuario");
                tablaUsuario.Columns.Add("nombreUsuario");
                tablaUsuario.Columns.Add("contraseña");

                Usuario usuarioActual = CatalogoUsuario.RecuperarPorUsuarioYContraseña(nombreUsuario, contraseña, nhSesion);

                if (usuarioActual == null)
                {
                    tablaUsuario = null;
                }
                else
                {
                    tablaUsuario.Rows.Add(new object[] { usuarioActual.Codigo, usuarioActual.NombreUsuario, usuarioActual.Contraseña });
                }

                return tablaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosUsuarios()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuarios = new DataTable();
                tablaUsuarios.Columns.Add("codigoUsuario");
                tablaUsuarios.Columns.Add("nombreUsuario");
                tablaUsuarios.Columns.Add("contraseña");

                List<Usuario> listaUsuarios = CatalogoUsuario.RecuperarTodos(nhSesion);

                listaUsuarios.Aggregate(tablaUsuarios, (dt, r) => { dt.Rows.Add(r.Codigo, r.NombreUsuario, r.Contraseña); return dt; });

                return tablaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region TipoDocumento

        public static DataTable RecuperarTodosTiposDocumentos()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaTiposDocumentos = new DataTable();
                tablaTiposDocumentos.Columns.Add("codigo");
                tablaTiposDocumentos.Columns.Add("descripcion");

                List<TipoDocumento> listaTiposDocumentos = CatalogoTipoDocumento.RecuperarTodos(nhSesion);

                listaTiposDocumentos.Aggregate(tablaTiposDocumentos, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion); return dt; });

                return tablaTiposDocumentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Factura

        public static DataTable RecuperarUltimaFactura()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaFacturas = new DataTable();
                tablaFacturas.Columns.Add("codigoFactura");
                tablaFacturas.Columns.Add("numeroFactura");
                tablaFacturas.Columns.Add("fechaFacturacion");
                tablaFacturas.Columns.Add("descripcionTipoComprobante");
                tablaFacturas.Columns.Add("descripcionTipoMoneda");
                tablaFacturas.Columns.Add("descripcionConcepto");
                tablaFacturas.Columns.Add("descripcionIVA");
                tablaFacturas.Columns.Add("subtotal");
                tablaFacturas.Columns.Add("total");
                tablaFacturas.Columns.Add("cae");
                tablaFacturas.Columns.Add("fechaVencimientoCAE");
                tablaFacturas.Columns.Add("codigoDireccion");
                tablaFacturas.Columns.Add("direccion");

                Factura factura = CatalogoFactura.RecuperarUltima(nhSesion);

                if (factura != null)
                {
                    tablaFacturas.Rows.Add(new object[] { factura.Codigo, factura.NumeroFactura,factura.FechaFacturacion,factura.TipoComprobante.Descripcion, factura.Moneda.Descripcion, 
                    factura.Concepto.Descripcion, factura.Iva.Descripcion,factura.Subtotal,factura.Total,factura.Cae,factura.FechaVencimiento, factura.Entregas[0].Direccion.Codigo,
                    factura.Entregas[0].Direccion.Descripcion +", "+factura.Entregas[0].Direccion.Localidad+", "+factura.Entregas[0].Direccion.Provincia});
                }

                return tablaFacturas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodasFacturas()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaFacturas = new DataTable();
                tablaFacturas.Columns.Add("codigoFactura");
                tablaFacturas.Columns.Add("numeroFactura");
                tablaFacturas.Columns.Add("fechaFacturacion");
                tablaFacturas.Columns.Add("descripcionTipoComprobante");
                tablaFacturas.Columns.Add("descripcionTipoMoneda");
                tablaFacturas.Columns.Add("descripcionConcepto");
                tablaFacturas.Columns.Add("descripcionIVA");
                tablaFacturas.Columns.Add("subtotal");
                tablaFacturas.Columns.Add("total");
                tablaFacturas.Columns.Add("cae");
                tablaFacturas.Columns.Add("fechaVencimientoCAE");
                tablaFacturas.Columns.Add("remitos");
                tablaFacturas.Columns.Add("condicionVenta");
                tablaFacturas.Columns.Add("codigoDireccion");
                tablaFacturas.Columns.Add("direccion");
                tablaFacturas.Columns.Add("domicilio");
                tablaFacturas.Columns.Add("localidad");
                tablaFacturas.Columns.Add("cotizacion");

                List<Factura> listaFacturas = CatalogoFactura.RecuperarTodos(nhSesion);

                listaFacturas.OrderByDescending(x => x.NumeroFactura).Aggregate(tablaFacturas, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.NumeroFactura, r.FechaFacturacion, r.TipoComprobante.Descripcion, r.Moneda.Descripcion,
                        r.Concepto.Descripcion, r.Iva.Descripcion, r.Subtotal, r.Total, r.Cae, r.FechaVencimiento, string.Join(", ", r.Entregas.Select(x => x.NumeroRemito)),
                        r.CondicionVenta, r.Entregas[0].Direccion.Codigo, r.Entregas[0].Direccion.Descripcion + ", " + r.Entregas[0].Direccion.Localidad + ", " +
                        r.Entregas[0].Direccion.Provincia, r.Entregas[0].Direccion.Descripcion, r.Entregas[0].Direccion.Localidad, r.Cotizacion); return dt;
                });

                return tablaFacturas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarFacturaPorCodigo(int codigoFactura)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                return Factura.RecuperarTabla(CatalogoGenerico<Factura>.RecuperarPorCodigo(codigoFactura, nhSesion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }


        public static int ConsultarUltimoNroComprobante(int ptoVenta, int tipoComptobanteAfip)
        {
            var clsFac = new clsFacturacion();

            var ultNroComprobante = clsFac.ConsultarUltNroOrden(ptoVenta, tipoComptobanteAfip);
            return ultNroComprobante;
        }

        public static string InsertarActualizarFactura(int codigoFactura, int numeroFactura, DateTime fechaFacturacion, List<int> listaCodigosEntrega, int codigoMoneda, int codigoConcepto, int codigoIva, double subtotal, double total, string condicionVenta, double cotizacion, DataTable tablaItemsEntrega)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Factura factura;

                if (codigoFactura == 0)
                {
                    factura = new Factura();
                }
                else
                {
                    factura = CatalogoFactura.RecuperarPorCodigo(codigoFactura, nhSesion);

                    if (!string.IsNullOrEmpty(factura.Cae))
                    {
                        return "TieneCAE";
                    }
                }

                factura.Concepto = CatalogoConcepto.RecuperarPorCodigo(codigoConcepto, nhSesion);

                //Borramos las entregas eliminadas en la pantalla
                List<Entrega> listaEntregasBorradas = (from e in factura.Entregas where !listaCodigosEntrega.Contains(e.Codigo) select e).ToList();
                foreach (Entrega entregaBorrar in listaEntregasBorradas)
                {
                    factura.Entregas.Remove(entregaBorrar);
                }

                //Agrego las entregas que no estaban en la factura hasta el momento
                foreach (int codigoEntrega in listaCodigosEntrega)
                {
                    Entrega ent = (from e in factura.Entregas where e.Codigo == codigoEntrega select e).SingleOrDefault();

                    if (ent == null)
                    {
                        factura.Entregas.Add(CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion));
                    }
                }

                //Editamos los precios de los items entrega
                foreach (DataRow row in tablaItemsEntrega.Rows)
                {
                    int codigoEntrega = Convert.ToInt32(row["codigoEntrega"]);
                    Entrega entrega = (from e in factura.Entregas where e.Codigo == codigoEntrega select e).SingleOrDefault();

                    int codigoItemEntrega = Convert.ToInt32(row["codigoItemEntrega"]);
                    ItemEntrega itemEntrega = (from i in entrega.ItemsEntrega where i.Codigo == codigoItemEntrega select i).SingleOrDefault();

                    double precio = Convert.ToDouble(row["precio"]);
                    if (itemEntrega.Precio != precio)
                    {
                        itemEntrega.Precio = precio;
                        CatalogoGenerico<ItemEntrega>.InsertarActualizar(itemEntrega, nhSesion);
                    }
                }


                factura.FechaFacturacion = fechaFacturacion;
                factura.Iva = CatalogoIva.RecuperarPorCodigo(codigoIva, nhSesion);
                factura.Moneda = CatalogoMoneda.RecuperarPorCodigo(codigoMoneda, nhSesion);
                factura.NumeroFactura = numeroFactura;
                factura.Subtotal = subtotal;// (double)decimal.Round((decimal)subtotal, 2);
                factura.TipoComprobante = CatalogoTipoComprobante.RecuperarPorCodigo(1, nhSesion);
                factura.Total = total;
                factura.FechaVencimiento = null;
                factura.CondicionVenta = condicionVenta;
                factura.Cotizacion = codigoMoneda == Constantes.Moneda.PESO ? 1 : cotizacion; //Si la moneda es peso guardamos 1 en cotizacion

                CatalogoFactura.InsertarActualizar(factura, nhSesion);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static string EmitirFactura(int codigoFactura)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Factura factura = CatalogoFactura.RecuperarPorCodigo(codigoFactura, nhSesion);

                FECAERequest request = new FECAERequest();

                FECAECabRequest cabeceraReq = new FECAECabRequest();
                cabeceraReq.CantReg = 1;
                cabeceraReq.CbteTipo = 1; //factura A
                cabeceraReq.PtoVta = 2;

                request.FeCabReq = cabeceraReq;

                FECAEDetRequest detalleReq = new FECAEDetRequest();
                detalleReq.CbteDesde = factura.NumeroFactura;
                detalleReq.CbteHasta = factura.NumeroFactura;
                detalleReq.CbteFch = ConvertirFechaAFIP(factura.FechaFacturacion);
                detalleReq.Concepto = factura.Concepto.Codigo;
                detalleReq.DocNro = Convert.ToInt64(factura.Entregas[0].NotaDePedido.Cliente.NumeroDocumento.Replace("-", ""));
                detalleReq.DocTipo = factura.Entregas[0].NotaDePedido.Cliente.TipoDocumento.Codigo;
                //detalleReq.CbtesAsoc = ??????

                if (factura.Concepto.Codigo != 1)
                {
                    detalleReq.FchServDesde = ConvertirFechaAFIP(factura.FechaFacturacion);
                    detalleReq.FchServHasta = ConvertirFechaAFIP(factura.FechaFacturacion);
                    detalleReq.FchVtoPago = ConvertirFechaAFIP(factura.FechaFacturacion);
                }

                double cotizacion = factura.Moneda.Codigo == Constantes.Moneda.PESO ? 1 : factura.Cotizacion; // Si la moneda es peso argentino se pone la cotizacion ingresada, sino va 1

                detalleReq.ImpIVA = (double)decimal.Round((decimal)(cotizacion * factura.Subtotal * 0.21), 2);
                detalleReq.ImpNeto = (double)decimal.Round((decimal)cotizacion * (decimal)factura.Subtotal, 2);
                detalleReq.ImpOpEx = 0; //por que??
                //detalleReq.ImpTotal = detalleReq.ImpIVA + detalleReq.ImpNeto;
                detalleReq.ImpTotal = (double)decimal.Round((decimal)detalleReq.ImpIVA + (decimal)detalleReq.ImpNeto, 2);
                //detalleReq.ImpTotal = (double)decimal.Round((decimal)cotizacion * (decimal)factura.Total, 2);
                detalleReq.ImpTotConc = 0; //por que ????
                detalleReq.ImpTrib = 0; //ver tributos

                AlicIva[] listaAlicIva = new AlicIva[1];

                var ls = new List<AlicIva>();
                AlicIva alicIva = new AlicIva();
                alicIva.Id = factura.Iva.Codigo;
                alicIva.BaseImp = (double)decimal.Round((decimal)cotizacion * (decimal)factura.Subtotal, 2);
                alicIva.Importe = (double)decimal.Round((decimal)cotizacion * (decimal)factura.Subtotal * (decimal)0.21, 2);
                ls.Add(alicIva);

                detalleReq.Iva = ls.ToArray();

                detalleReq.MonCotiz = 1; //siempre facturan en pesos ??
                detalleReq.MonId = "PES";// factura.Moneda.CodigoAFIP;
                //detalleReq.Opcionales = ?????
                //detalleReq.Tributos = new Tributo[0];
                detalleReq.ImpTrib = 0;

                request.FeDetReq = new FECAEDetRequest[] { detalleReq };

                clsFacturacion facturar = new clsFacturacion();
                ResultadoFacturarAFIP resultado = facturar.FacturarAFIP(request, true, true);

                string rta = string.Empty;
                if (resultado.ResultadoAFIP == WSFEv1.Logica.EnumResultadoAFIP.Facturado)
                {
                    rta = string.Format("CAE: {0}\nFecha Vto.: {1}", resultado.CAE, resultado.FechaVtoCAE.ToString()) + " Todo Correcto!";
                    factura.Cae = resultado.CAE;
                    factura.FechaVencimiento = resultado.FechaVtoCAE;
                    CatalogoFactura.InsertarActualizar(factura, nhSesion);
                }
                else
                {
                    rta = "Mensaje Afip/Error: " + resultado.MensajeAFIP + " Algo fallo!";
                }
                return rta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        private static string ConvertirFechaAFIP(DateTime fecha)
        {
            return string.Format("{0}{1}{2}", fecha.Year.ToString("0000"), fecha.Month.ToString("00"), fecha.Day.ToString("00"));
        }

        public static string ConvertirBarCode(string nroCae, DateTime fechaFactura, string nroComprobante, string ptoVenta)
        {
            //- C.U.I.T. (Clave Unica de Identificación Tributaria) del emisor (11 caracteres).
            //- Código de tipo de comprobante (2 caracteres).
            //- Punto de venta (4 caracteres).
            //- Código de Autorización de Impresión (14 caracteres).
            //- Fecha de vencimiento (8 caracteres).
            //- Dígito verificador (1 carácter).
            string nroCodeBar = "30711039704" + nroComprobante + ptoVenta + nroCae + fechaFactura.Year.ToString("0000") + fechaFactura.Month.ToString("00") + fechaFactura.Day.ToString("00");
            return nroCodeBar + GetCodigoVerificador(nroCodeBar);
        }

        private static string GetCodigoVerificador(string nroCodeBar)
        {
            //Se considera para efectuar el cálculo el siguiente ejemplo:
            //01234567890
            //Etapa 1: Comenzar desde la izquierda, sumar todos los caracteres ubicados en las posiciones impares.
            //0 + 2 + 4 + 6 + 8 + 0 = 20
            //Etapa 2: Multiplicar la suma obtenida en la etapa 1 por el número 3.
            //20 x 3 = 60
            //Etapa 3: Comenzar desde la izquierda, sumar todos los caracteres que están ubicados en las posiciones pares.
            //1 + 3 + 5+ 7 + 9 = 25
            //Etapa 4: Sumar los resultados obtenidos en las etapas 2 y 3.
            //60 + 25 = 85
            //Etapa 5: Buscar el menor número que sumado al resultado obtenido en la etapa 4 dé un número múltiplo de 10. Este será el valor del dígito verificador del módulo 10.
            //85 + 5 = 90
            //De esta manera se llega a que el número 5 es el dígito verificador módulo 10 para el código 01234567890
            string digitoVerificador = "";
            int sumaImpar = 0;
            int sumaPar = 0;
            for (int i = 0; i < nroCodeBar.Length; i++)
            {
                if ((Convert.ToInt32(nroCodeBar.Substring(i, 1)) % 2) == 0)
                    sumaPar = sumaPar + Convert.ToInt32(nroCodeBar.Substring(i, 1));
                else
                    sumaImpar = sumaImpar + Convert.ToInt32(nroCodeBar.Substring(i, 1));
            }
            int total = (sumaImpar * 3) + sumaPar;
            for (int i = 0; i < 10; i++)
                if (((total + i) % 10) == 0)
                { digitoVerificador = Convert.ToString(i); break; }
            return digitoVerificador;
        }

        public static string EliminarFactura(int codigoFactura)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Factura factura = CatalogoFactura.RecuperarPorCodigo(codigoFactura, nhSesion);

                if (string.IsNullOrEmpty(factura.Cae))
                {
                    CatalogoFactura.Eliminar(factura, nhSesion);
                    return "ok";
                }
                else
                {
                    return "TieneCAE";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarFacturasPorFechas(DateTime fechaHoraDesde, DateTime fechaHoraHasta)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaFacturas = new DataTable();
                tablaFacturas.Columns.Add("codigoFactura");
                tablaFacturas.Columns.Add("numeroFactura");
                tablaFacturas.Columns.Add("fechaFacturacion");
                tablaFacturas.Columns.Add("descripcionTipoComprobante");
                tablaFacturas.Columns.Add("descripcionTipoMoneda");
                tablaFacturas.Columns.Add("descripcionConcepto");
                tablaFacturas.Columns.Add("descripcionIVA");
                tablaFacturas.Columns.Add("subtotal");
                tablaFacturas.Columns.Add("total");
                tablaFacturas.Columns.Add("cae");
                tablaFacturas.Columns.Add("fechaVencimientoCAE");
                tablaFacturas.Columns.Add("remitos");
                tablaFacturas.Columns.Add("condicionVenta");
                tablaFacturas.Columns.Add("codigoDireccion");
                tablaFacturas.Columns.Add("direccion");
                tablaFacturas.Columns.Add("domicilio");
                tablaFacturas.Columns.Add("localidad");
                tablaFacturas.Columns.Add("cotizacion");
                tablaFacturas.Columns.Add("cliente");

                List<Factura> listaFacturas = CatalogoFactura.RecuperarLista(x => x.FechaFacturacion >= fechaHoraDesde && x.FechaFacturacion <= fechaHoraHasta, nhSesion);

                listaFacturas.OrderBy(x => x.NumeroFactura).Aggregate(tablaFacturas, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.NumeroFactura, r.FechaFacturacion.ToString("dd/MM/yyyy"), r.TipoComprobante.Descripcion, r.Moneda.Descripcion,
                        r.Concepto.Descripcion, r.Iva.Descripcion, r.Subtotal, r.Total, r.Cae, r.FechaVencimiento, string.Join(", ", r.Entregas.Select(x => x.NumeroRemito)),
                        r.CondicionVenta, r.Entregas[0].Direccion.Codigo, r.Entregas[0].Direccion.Descripcion + ", " + r.Entregas[0].Direccion.Localidad + ", " +
                        r.Entregas[0].Direccion.Provincia, r.Entregas[0].Direccion.Descripcion, r.Entregas[0].Direccion.Localidad, r.Cotizacion,
                        r.Entregas[0].NotaDePedido.Cliente.NumeroDocumento + " - " + r.Entregas[0].NotaDePedido.Cliente.RazonSocial); return dt;
                });

                return tablaFacturas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Concepto

        public static DataTable RecuperarTodosConceptos()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaConceptos = new DataTable();
                tablaConceptos.Columns.Add("codigoConcepto");
                tablaConceptos.Columns.Add("descripcion");

                List<Concepto> listaConceptos = CatalogoConcepto.RecuperarTodos(nhSesion);

                listaConceptos.Aggregate(tablaConceptos, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion); return dt; });

                return tablaConceptos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region TipoComprobante

        public static DataTable RecuperarTodosTipoComprobantes()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaTipoComprobantes = new DataTable();
                tablaTipoComprobantes.Columns.Add("codigoTipoComprobante");
                tablaTipoComprobantes.Columns.Add("descripcion");

                List<TipoComprobante> listaTipoComprobantes = CatalogoTipoComprobante.RecuperarTodos(nhSesion);

                listaTipoComprobantes.Aggregate(tablaTipoComprobantes, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion); return dt; });

                return tablaTipoComprobantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Transporte

        public static void InsertarActualizarTransporte(int codigoTransporte, string razonSocial, string provincia, string localidad, string direccion, string telefono, string fax, string mail, string numeroDocumento, string personaContacto, string numeroCuenta, string banco, string cbu, string observaciones, int codigoTipoDocumento)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Transporte transporte;

                if (codigoTransporte == 0)
                {
                    transporte = new Transporte();
                }
                else
                {
                    transporte = CatalogoTransporte.RecuperarPorCodigo(codigoTransporte, nhSesion);
                }

                transporte.RazonSocial = razonSocial;
                transporte.Provincia = provincia;
                transporte.Localidad = localidad;
                transporte.Direccion = direccion;
                transporte.Telefono = telefono;
                transporte.Fax = fax;
                transporte.Mail = mail;
                transporte.NumeroDocumento = numeroDocumento;
                transporte.PersonaContacto = personaContacto;
                transporte.NumeroCuenta = numeroCuenta;
                transporte.Banco = banco;
                transporte.Cbu = cbu;
                transporte.Observaciones = observaciones;
                transporte.IsInactivo = false;
                transporte.TipoDocumento = CatalogoTipoDocumento.RecuperarPorCodigo(codigoTipoDocumento, nhSesion);

                CatalogoTransporte.InsertarActualizar(transporte, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosTransportes(bool isInactivos)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaTransportes = new DataTable();
                tablaTransportes.Columns.Add("codigoTransporte");
                tablaTransportes.Columns.Add("razonSocial");
                tablaTransportes.Columns.Add("provincia");
                tablaTransportes.Columns.Add("localidad");
                tablaTransportes.Columns.Add("direccion");
                tablaTransportes.Columns.Add("telefono");
                tablaTransportes.Columns.Add("mail");
                tablaTransportes.Columns.Add("cuil");
                tablaTransportes.Columns.Add("personaContacto");
                tablaTransportes.Columns.Add("numeroCuenta");
                tablaTransportes.Columns.Add("banco");
                tablaTransportes.Columns.Add("cbu");
                tablaTransportes.Columns.Add("observaciones");
                tablaTransportes.Columns.Add("fax");
                tablaTransportes.Columns.Add("numeroDocumento");
                tablaTransportes.Columns.Add("tipoDocumento");
                tablaTransportes.Columns.Add("codigoTipoDocumento");


                List<Transporte> listaTransportes = CatalogoTransporte.RecuperarLista(x => x.IsInactivo == isInactivos, nhSesion);

                listaTransportes.Aggregate(tablaTransportes, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.RazonSocial, r.Provincia, r.Localidad, r.Direccion, r.Telefono, r.Mail, r.NumeroDocumento,
                        r.PersonaContacto, r.NumeroCuenta, r.Banco, r.Cbu, r.Observaciones, r.Fax, r.NumeroDocumento, r.TipoDocumento.Descripcion, r.TipoDocumento.Codigo); return dt;
                });

                return tablaTransportes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void ActivarInactivarTransporte(int codigoTransporte)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Transporte Transporte = CatalogoTransporte.RecuperarPorCodigo(codigoTransporte, nhSesion);

                if (Transporte.IsInactivo)
                {
                    Transporte.IsInactivo = false;
                }
                else
                {
                    Transporte.IsInactivo = true;
                }

                CatalogoTransporte.InsertarActualizar(Transporte, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarTransporte(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Transporte transporte = CatalogoTransporte.RecuperarPorCodigo(codigoCliente, nhSesion);

                CatalogoTransporte.Eliminar(transporte, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region DatosEmpresa

        public static void InsertarActualizarDatosEmpresa(int codigoDatosEmpresa, string razonSocial, string provincia, string localidad, string direccion, string telefono, string fax, string mail, string numeroDocumento, string personaContacto, string numeroCuenta, string banco, string cbu, string observaciones, int codigoTipoDocumento, string cai, DateTime fechaVencimientoCai)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DatosEmpresa datosEmpresa;

                if (codigoDatosEmpresa == 0)
                {
                    datosEmpresa = new DatosEmpresa();
                }
                else
                {
                    datosEmpresa = CatalogoDatosEmpresa.RecuperarPorCodigo(codigoDatosEmpresa, nhSesion);
                }

                datosEmpresa.RazonSocial = razonSocial;
                datosEmpresa.Provincia = provincia;
                datosEmpresa.Localidad = localidad;
                datosEmpresa.Direccion = direccion;
                datosEmpresa.Telefono = telefono;
                datosEmpresa.Fax = fax;
                datosEmpresa.Mail = mail;
                datosEmpresa.NumeroDocumento = numeroDocumento;
                datosEmpresa.PersonaContacto = personaContacto;
                datosEmpresa.NumeroCuenta = numeroCuenta;
                datosEmpresa.Banco = banco;
                datosEmpresa.Cbu = cbu;
                datosEmpresa.Observaciones = observaciones;
                datosEmpresa.IsInactivo = false;
                datosEmpresa.TipoDocumento = CatalogoTipoDocumento.RecuperarPorCodigo(codigoTipoDocumento, nhSesion);
                datosEmpresa.nroCai = cai;
                datosEmpresa.fechaVencimientoCai = fechaVencimientoCai;

                CatalogoDatosEmpresa.InsertarActualizar(datosEmpresa, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosDatosEmpresa(bool isInactivos)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaDatosEmpresa = new DataTable();
                tablaDatosEmpresa.Columns.Add("codigoDatosEmpresa");
                tablaDatosEmpresa.Columns.Add("razonSocial");
                tablaDatosEmpresa.Columns.Add("provincia");
                tablaDatosEmpresa.Columns.Add("localidad");
                tablaDatosEmpresa.Columns.Add("direccion");
                tablaDatosEmpresa.Columns.Add("telefono");
                tablaDatosEmpresa.Columns.Add("mail");
                tablaDatosEmpresa.Columns.Add("cuil");
                tablaDatosEmpresa.Columns.Add("personaContacto");
                tablaDatosEmpresa.Columns.Add("numeroCuenta");
                tablaDatosEmpresa.Columns.Add("banco");
                tablaDatosEmpresa.Columns.Add("cbu");
                tablaDatosEmpresa.Columns.Add("observaciones");
                tablaDatosEmpresa.Columns.Add("fax");
                tablaDatosEmpresa.Columns.Add("cai");
                tablaDatosEmpresa.Columns.Add("fechaVencimientoCai");

                List<DatosEmpresa> listaDatosEmpresa = CatalogoDatosEmpresa.RecuperarLista(x => x.IsInactivo == isInactivos, nhSesion);

                listaDatosEmpresa.Aggregate(tablaDatosEmpresa, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.RazonSocial, r.Provincia, r.Localidad, r.Direccion, r.Telefono, r.Mail, r.NumeroDocumento,
                        r.PersonaContacto, r.NumeroCuenta, r.Banco, r.Cbu, r.Observaciones, r.Fax, r.nroCai, r.fechaVencimientoCai); return dt;
                });

                return tablaDatosEmpresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void ActivarInactivarDatosEmpresa(int codigoDatosEmpresa)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DatosEmpresa datosEmpresa = CatalogoDatosEmpresa.RecuperarPorCodigo(codigoDatosEmpresa, nhSesion);

                if (datosEmpresa.IsInactivo)
                {
                    datosEmpresa.IsInactivo = false;
                }
                else
                {
                    datosEmpresa.IsInactivo = true;
                }

                CatalogoDatosEmpresa.InsertarActualizar(datosEmpresa, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarDatosEmpresa(int codigoDatosEmpresa)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DatosEmpresa datosEmpresa = CatalogoDatosEmpresa.RecuperarPorCodigo(codigoDatosEmpresa, nhSesion);

                CatalogoDatosEmpresa.Eliminar(datosEmpresa, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region ItemContratoMarco

        public static DataTable RecuperarItemsContratoMarco(int codigoContratoMarco)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaItemsContratoMarco = new DataTable();
                tablaItemsContratoMarco.Columns.Add("codigoItemCM");
                tablaItemsContratoMarco.Columns.Add("posicion");
                tablaItemsContratoMarco.Columns.Add("codigoArticuloCliente");
                tablaItemsContratoMarco.Columns.Add("descripcionCorta");
                tablaItemsContratoMarco.Columns.Add("codigoArticulo");
                tablaItemsContratoMarco.Columns.Add("precio");
                tablaItemsContratoMarco.Columns.Add("moneda");
                tablaItemsContratoMarco.Columns.Add("unidadMedida");

                ContratoMarco contratoMarco = CatalogoContratoMarco.RecuperarPorCodigo(codigoContratoMarco, nhSesion);

                contratoMarco.ItemsContratoMarco.Aggregate(tablaItemsContratoMarco, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.Posicion, r.Articulo.ArticulosClientes.Where(x => x.Cliente.Codigo == contratoMarco.Cliente.Codigo).SingleOrDefault() != null ?
                        r.Articulo.ArticulosClientes.Where(x => x.Cliente.Codigo == contratoMarco.Cliente.Codigo).SingleOrDefault().CodigoInterno.ToString() : string.Empty,
                        r.Articulo.DescripcionCorta, r.Articulo.Codigo, r.Precio, r.TipoMoneda.Abreviatura, r.Articulo.UnidadMedida.Descripcion); return dt;
                });

                return tablaItemsContratoMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Direccion

        public static DataTable RecuperarDireccionesPorCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaDirecciones = new DataTable();
                tablaDirecciones.Columns.Add("codigoDireccion");
                tablaDirecciones.Columns.Add("descripcion");
                tablaDirecciones.Columns.Add("localidad");
                tablaDirecciones.Columns.Add("provincia");

                Cliente cl = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);

                cl.Direcciones.Aggregate(tablaDirecciones, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion, r.Localidad, r.Provincia); return dt; });

                return tablaDirecciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void InsertarDireccionPorCliente(int codigoCliente, string direccion, string localidad, string provincia)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Cliente cl = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);

                Direccion dir = new Direccion();
                dir.Descripcion = direccion;
                dir.Localidad = localidad;
                dir.Provincia = provincia;

                cl.Direcciones.Add(dir);

                CatalogoCliente.InsertarActualizar(cl, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static string EliminarDireccionPorCliente(int codigoCliente, int codigoDireccion)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Cliente cl = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);

                Direccion dir = cl.Direcciones.Where(x => x.Codigo == codigoDireccion).SingleOrDefault();

                cl.Direcciones.Remove(dir);

                CatalogoCliente.InsertarActualizar(cl, nhSesion);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarDireccionesPorNotaDePedido(int codigoNotaDePedido)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaDirecciones = new DataTable();
                tablaDirecciones.Columns.Add("codigoDireccion");
                tablaDirecciones.Columns.Add("descripcion");
                tablaDirecciones.Columns.Add("localidad");
                tablaDirecciones.Columns.Add("provincia");

                Cliente cl = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion).Cliente;

                cl.Direcciones.Aggregate(tablaDirecciones, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion, r.Localidad, r.Provincia); return dt; });

                return tablaDirecciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region NotaDeCredito

        public static DataTable RecuperarTodasNotasDeCredito()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                return NotaDeCredito.RecuperarTabla(CatalogoGenerico<NotaDeCredito>.RecuperarTodos(nhSesion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarNotaDeCredito(int codigoNotaDeCredito)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                return NotaDeCredito.RecuperarTabla(CatalogoGenerico<NotaDeCredito>.RecuperarPorCodigo(codigoNotaDeCredito, nhSesion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        /// <summary>
        /// Columnas de la tablaItemsNotaDeCredito: codigoItemNotaDeCredito, codigoItemEntrega, cantidad
        /// </summary>
        /// <param name="codigoNotaDeCredito"></param>
        /// <param name="codigoFactura"></param>
        /// <param name="total"></param>
        /// <param name="isFacturaCompleta"></param>
        /// <param name="tablaItemsEntrega"></param>
        public static string InsertarActualizarNotaDeCreditoCompleta(int codigoNotaDeCredito, int numeroNotaDeCredito, int codigoFactura, double total, double subtotal, DateTime fechaHoraNotaDeCredito, int codigoTipoComprobante, int codigoEntrega)
        {

            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                NotaDeCredito notaDeCredito;

                if (codigoNotaDeCredito == 0)
                {
                    notaDeCredito = new NotaDeCredito();
                }
                else
                {
                    notaDeCredito = CatalogoGenerico<NotaDeCredito>.RecuperarPorCodigo(codigoNotaDeCredito, nhSesion);

                    if (!string.IsNullOrEmpty(notaDeCredito.CAE))
                    {
                        return "TieneCAE";
                    }
                }

                notaDeCredito.NumeroNotaDeCredito = numeroNotaDeCredito;
                notaDeCredito.Factura = CatalogoGenerico<Factura>.RecuperarPorCodigo(codigoFactura, nhSesion);
                notaDeCredito.IsFacturaCompleta = true;
                notaDeCredito.Total = total;
                notaDeCredito.Subtotal = subtotal;
                notaDeCredito.FechaHoraNotaDeCredito = fechaHoraNotaDeCredito;
                notaDeCredito.TipoComprobante = CatalogoGenerico<TipoComprobante>.RecuperarPorCodigo(codigoTipoComprobante, nhSesion);
                notaDeCredito.FechaHoraVencimientoCAE = null;

                //Si no es una nota de credito para una factura completa le creo sus items con sus cantidades, sino esta lista queda vacia ya que se puede acceder por la factura
                if (codigoNotaDeCredito== 0) //Si la nota de credito es nueva sino ya tendria los items creados
                {
                    Entrega ent = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega,nhSesion);
                    foreach (ItemEntrega item in ent.ItemsEntrega)
                    {
                        ItemNotaDeCredito itemNC = new ItemNotaDeCredito();
                        notaDeCredito.ItemsNotaDeCredito.Add(itemNC);
                        itemNC.Cantidad = item.CantidadAEntregar;
                        itemNC.ItemEntrega = item;
                    }
                }

                CatalogoGenerico<NotaDeCredito>.InsertarActualizar(notaDeCredito, nhSesion);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static string InsertarActualizarNotaDeCreditoIncompleta(int codigoNotaDeCredito, int numeroNotaDeCredito, int codigoFactura, double total, double subtotal, DateTime fechaHoraNotaDeCredito, int codigoTipoComprobante, DataTable tablaItemsNotaDeCredito)
        {

            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                NotaDeCredito notaDeCredito;

                if (codigoNotaDeCredito == 0)
                {
                    notaDeCredito = new NotaDeCredito();
                }
                else
                {
                    notaDeCredito = CatalogoGenerico<NotaDeCredito>.RecuperarPorCodigo(codigoNotaDeCredito, nhSesion);

                    if (!string.IsNullOrEmpty(notaDeCredito.CAE))
                    {
                        return "TieneCAE";
                    }
                }

                notaDeCredito.NumeroNotaDeCredito = numeroNotaDeCredito;
                notaDeCredito.Factura = CatalogoGenerico<Factura>.RecuperarPorCodigo(codigoFactura, nhSesion);
                notaDeCredito.IsFacturaCompleta = false;
                notaDeCredito.Total = total;
                notaDeCredito.Subtotal = subtotal;
                notaDeCredito.FechaHoraNotaDeCredito = fechaHoraNotaDeCredito;
                notaDeCredito.TipoComprobante = CatalogoGenerico<TipoComprobante>.RecuperarPorCodigo(codigoTipoComprobante, nhSesion);
                notaDeCredito.FechaHoraVencimientoCAE = null;

                //Si no es una nota de credito para una factura completa le creo sus items con sus cantidades, sino esta lista queda vacia ya que se puede acceder por la factura
                foreach (DataRow fila in tablaItemsNotaDeCredito.Rows)
                {
                    ItemNotaDeCredito item;
                    int codigoItemNotaDeCredito = Convert.ToInt32(fila["codigoItemNotaDeCredito"]);

                    if (codigoItemNotaDeCredito == 0)
                    {
                        item = new ItemNotaDeCredito();
                        notaDeCredito.ItemsNotaDeCredito.Add(item);
                    }
                    else
                    {
                        item = notaDeCredito.ItemsNotaDeCredito.Where(x => x.Codigo == codigoItemNotaDeCredito).SingleOrDefault();
                    }

                    item.Cantidad = Convert.ToInt32(fila["cantidad"]);
                    item.ItemEntrega = CatalogoGenerico<ItemEntrega>.RecuperarPorCodigo(Convert.ToInt32(fila["codigoItemEntrega"]), nhSesion);
                }

                CatalogoGenerico<NotaDeCredito>.InsertarActualizar(notaDeCredito, nhSesion);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarUltimaNotaDeCredito()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaNotaDeCreditos = new DataTable();
                tablaNotaDeCreditos.Columns.Add("codigoNotaDeCredito");
                tablaNotaDeCreditos.Columns.Add("numeroNotaDeCredito");
                tablaNotaDeCreditos.Columns.Add("fechaNotaDeCreditocion");
                tablaNotaDeCreditos.Columns.Add("descripcionTipoComprobante");
                tablaNotaDeCreditos.Columns.Add("descripcionTipoMoneda");
                tablaNotaDeCreditos.Columns.Add("descripcionConcepto");
                tablaNotaDeCreditos.Columns.Add("descripcionIVA");
                tablaNotaDeCreditos.Columns.Add("subtotal");
                tablaNotaDeCreditos.Columns.Add("total");
                tablaNotaDeCreditos.Columns.Add("cae");
                tablaNotaDeCreditos.Columns.Add("fechaVencimientoCAE");
                tablaNotaDeCreditos.Columns.Add("codigoDireccion");
                tablaNotaDeCreditos.Columns.Add("direccion");

                NotaDeCredito NotaDeCredito = CatalogoNotaDeCredito.RecuperarUltima(nhSesion);

                if (NotaDeCredito != null)
                {
                    tablaNotaDeCreditos.Rows.Add(new object[] { NotaDeCredito.Codigo, NotaDeCredito.NumeroNotaDeCredito,NotaDeCredito.FechaHoraNotaDeCredito,NotaDeCredito.TipoComprobante.Descripcion, NotaDeCredito.Factura.Moneda.Descripcion, 
                    NotaDeCredito.Factura.Concepto.Descripcion, NotaDeCredito.Factura.Iva.Descripcion,NotaDeCredito.Subtotal,NotaDeCredito.Total,NotaDeCredito.CAE,NotaDeCredito.FechaHoraVencimientoCAE, NotaDeCredito.Factura.Entregas[0].Direccion.Codigo,
                    NotaDeCredito.Factura.Entregas[0].Direccion.Descripcion +", "+NotaDeCredito.Factura.Entregas[0].Direccion.Localidad+", "+NotaDeCredito.Factura.Entregas[0].Direccion.Provincia});
                }

                return tablaNotaDeCreditos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region ItemNotaDeCredito

        public static DataTable RecuperarItemsNotaDeCredito(int codigoNotaDeCredito)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                NotaDeCredito nc = CatalogoGenerico<NotaDeCredito>.RecuperarPorCodigo(codigoNotaDeCredito, nhSesion);
                return ItemNotaDeCredito.RecuperarTabla(nc.ItemsNotaDeCredito.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        public static string EmitirNotaDeCredito(int codigoNotaDeCredito)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                NotaDeCredito notaDeCredito = CatalogoNotaDeCredito.RecuperarPorCodigo(codigoNotaDeCredito, nhSesion);

                FECAERequest request = new FECAERequest();

                FECAECabRequest cabeceraReq = new FECAECabRequest();
                cabeceraReq.CantReg = 1;
                cabeceraReq.CbteTipo = 3; //factura A
                cabeceraReq.PtoVta = 2;

                request.FeCabReq = cabeceraReq;

                FECAEDetRequest detalleReq = new FECAEDetRequest();
                detalleReq.CbteDesde = notaDeCredito.NumeroNotaDeCredito;
                detalleReq.CbteHasta = notaDeCredito.NumeroNotaDeCredito;
                detalleReq.CbteFch = ConvertirFechaAFIP(notaDeCredito.FechaHoraNotaDeCredito);
                detalleReq.Concepto = notaDeCredito.Factura.Concepto.Codigo;
                detalleReq.DocNro = Convert.ToInt64(notaDeCredito.Factura.Entregas[0].NotaDePedido.Cliente.NumeroDocumento.Replace("-", ""));
                detalleReq.DocTipo = notaDeCredito.Factura.Entregas[0].NotaDePedido.Cliente.TipoDocumento.Codigo;
                //detalleReq.CbtesAsoc = ??????

                if (notaDeCredito.Factura.Concepto.Codigo != 1)
                {
                    detalleReq.FchServDesde = ConvertirFechaAFIP(notaDeCredito.Factura.FechaFacturacion);
                    detalleReq.FchServHasta = ConvertirFechaAFIP(notaDeCredito.Factura.FechaFacturacion);
                    detalleReq.FchVtoPago = ConvertirFechaAFIP(notaDeCredito.Factura.FechaFacturacion);
                }

                double cotizacion = notaDeCredito.Factura.Moneda.Codigo == Constantes.Moneda.PESO ? 1 : notaDeCredito.Factura.Cotizacion; // Si la moneda es peso argentino se pone la cotizacion ingresada, sino va 1

                detalleReq.ImpIVA = (double)decimal.Round((decimal)(cotizacion * notaDeCredito.Subtotal * 0.21), 2);
                detalleReq.ImpNeto = (double)decimal.Round((decimal)cotizacion * (decimal)notaDeCredito.Subtotal, 2);
                detalleReq.ImpOpEx = 0; //por que??
                //detalleReq.ImpTotal = detalleReq.ImpIVA + detalleReq.ImpNeto;
                detalleReq.ImpTotal = (double)decimal.Round((decimal)detalleReq.ImpIVA + (decimal)detalleReq.ImpNeto, 2);
                //detalleReq.ImpTotal = (double)decimal.Round((decimal)cotizacion * (decimal)factura.Total, 2);
                detalleReq.ImpTotConc = 0; //por que ????
                detalleReq.ImpTrib = 0; //ver tributos

                AlicIva[] listaAlicIva = new AlicIva[1];

                var ls = new List<AlicIva>();
                AlicIva alicIva = new AlicIva();
                alicIva.Id = notaDeCredito.Factura.Iva.Codigo;
                alicIva.BaseImp = (double)decimal.Round((decimal)cotizacion * (decimal)notaDeCredito.Subtotal, 2);
                alicIva.Importe = (double)decimal.Round((decimal)cotizacion * (decimal)notaDeCredito.Subtotal * (decimal)0.21, 2);
                ls.Add(alicIva);

                detalleReq.Iva = ls.ToArray();

                detalleReq.MonCotiz = 1; //siempre facturan en pesos ??
                detalleReq.MonId = "PES";// factura.Moneda.CodigoAFIP;
                //detalleReq.Opcionales = ?????
                //detalleReq.Tributos = new Tributo[0];
                detalleReq.ImpTrib = 0;

                request.FeDetReq = new FECAEDetRequest[] { detalleReq };

                clsFacturacion facturar = new clsFacturacion();
                ResultadoFacturarAFIP resultado = facturar.FacturarAFIP(request, true, true);

                string rta = string.Empty;
                if (resultado.ResultadoAFIP == WSFEv1.Logica.EnumResultadoAFIP.Facturado)
                {
                    rta = string.Format("CAE: {0}\nFecha Vto.: {1}", resultado.CAE, resultado.FechaVtoCAE.ToString()) + " Todo Correcto!";
                    notaDeCredito.CAE = resultado.CAE;
                    notaDeCredito.FechaHoraVencimientoCAE = resultado.FechaVtoCAE;
                    CatalogoNotaDeCredito.InsertarActualizar(notaDeCredito, nhSesion);
                }
                else
                {
                    rta = "Mensaje Afip/Error: " + resultado.MensajeAFIP + " Algo fallo!";
                }
                return rta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static string EliminarNotaDeCredito(int codigoNotaDeCredito)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                NotaDeCredito nc = CatalogoNotaDeCredito.RecuperarPorCodigo(codigoNotaDeCredito, nhSesion);

                if (string.IsNullOrEmpty(nc.CAE))
                {
                    CatalogoNotaDeCredito.Eliminar(nc, nhSesion);
                    return "ok";
                }
                else
                {
                    return "TieneCAE";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }
    }
}
