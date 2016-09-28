<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado2.aspx.cs" Inherits="SCF.articulos.listado2" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Articulos <small>listado de articulos</small></h1>
                </div>
                <!-- END PAGE TITLE -->
            </div>
            <!-- END PAGE HEAD -->

            <!-- BEGIN PAGE BREADCRUMB -->
            <ul class="page-breadcrumb breadcrumb">
                <li>
                    <a href="../index.aspx">Inicio</a>
                    <i class="fa fa-circle"></i>
                </li>
                <li>
                    <a href="listado.aspx">Listado Articulos</a>
                    <i class="fa fa-circle"></i>
                </li>
            </ul>
            <!-- END PAGE BREADCRUMB -->
            <!-- END PAGE HEADER-->
            <div class="row">
                <div class="col-md-12">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-users"></i>Listado de Artículos
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <div class="form-actions top">
                                <div class="btn-set pull-left">
                                    <asp:Button type="button" ID="btnNuevo" runat="server" OnClientClick="location.href='articulo.aspx'" class="btn blue" Text="Nuevo" />
                                    <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" class="btn yellow" Text="Editar" />
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarArticulo()" UseSubmitBehavior="false" class="btn red" Text="Eliminar" />
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnVerDetalle" runat="server" OnClientClick="ShowDetalleArticulo()" UseSubmitBehavior="false" class="btn green" Text="Detalle" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <dx:ASPxGridView ID="gvArticulos" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoArticulo" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoArticulo" ReadOnly="True" Visible="false" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionCorta" Caption="Desc. Corta" VisibleIndex="1">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionLarga" Visible="false" Caption="Desc. Larga" VisibleIndex="2">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="marca" Caption="Marca" VisibleIndex="3">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
                                </dx:ASPxGridView>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- END CONTENT -->

    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcConfirmarEliminarArticulo" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarArticulo"
        HeaderText="Eliminar Articulo" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtPrecio.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="Panel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                ¿Decea eliminar el artículo seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" UseSubmitBehavior="false" OnClientClick="pcConfirmarEliminarArticulo.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="Button2" runat="server" OnClick="btnAceptarEliminarArticulo_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcShowDetalleArticulo" runat="server" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowDetalleArticulo"
        HeaderText="Detalle del Artículo" AllowDragging="True" EnableViewState="False" Width="600px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtCodigoInterno.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <div data-width="760">
                                <div class="modal-body">
                                    <!--INFO DEL ARTICULO-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <h3 class="form-section">Info del Articulo</h3>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Descripción Corta</label>
                                                            <textarea type="text" id="txtDescripcionCorta" placeholder="Descripción Corta" runat="server" class="form-control" required rows="5"></textarea>
                                                        </div>
                                                    </div>
                                                
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Descripción Larga</label>
                                                            <textarea type="text" id="txtDescripcionLarga" placeholder="Descripción Larga" runat="server" class="form-control" required rows="5"></textarea>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label>Marca</label>
                                                            <input type="text" id="txtMarca" placeholder="Marca" runat="server" class="form-control">
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label>Precio:</label>
                                                        <div class="input-group">
                                                            <input type="text" id="txtPrecioActual" placeholder="Precio" runat="server" class="form-control">
                                                            <span class="input-group-btn">
                                                    <button class="btn blue" type="button" onclick="ShowHistoricoPrecio()"><span class="md-click-circle md-click-animate" style="height: 49px; width: 49px; top: -8.5px; left: -20.5px;"></span>Ver</button>
                                                </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/row-->
                                            </div>
                                        </form>
                                        <!-- END FORM-->
                                    </div>
                                    <!--INFO DEL PROVEEDOR-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <h3 class="form-section">Info de Proveedores</h3>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <dx:ASPxGridView runat="server" ID="gvArticuloProveedores" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigo" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="razonSocial" Caption="Razon Social" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="cuit" Caption="CUIT" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="cantidad" Caption="Cantidad" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="costo" Caption="Costo" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                            </dx:ASPxGridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <!--END POPUP-->

    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarArticulo() {
            pcConfirmarEliminarArticulo.Show();
        }
        function ShowDetalleArticulo() {
            pcShowDetalleArticulo.Show();
        }
    </script>
</asp:Content>

