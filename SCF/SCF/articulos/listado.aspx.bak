<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.articulos.listado" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <script src="articulo.js" type="text/javascript"></script>
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
                                    <asp:Button type="button" ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn blue" Text="Nuevo" UseSubmitBehavior="false" />
                                    <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" class="btn yellow" Text="Editar" UseSubmitBehavior="false" />
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarArticulo()" UseSubmitBehavior="false" class="btn red" Text="Eliminar" />
                                    <%--<asp:CheckBox runat="server" ID="chkBuscarPorNroCliente" Text="Buscar por Cliente" OnClick="chkBuscarPorNroCliente(this.checked)" />--%>
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnRelacionArticuloProvevedor" runat="server" OnClick="btnRelacionArticuloProvevedor_Click" UseSubmitBehavior="false" class="btn blue" Text="Relación Proveedor" />
                                    <asp:Button type="button" ID="btnRelacionArticuloCliente" runat="server" OnClick="btnRelacionArticuloCliente_Click" UseSubmitBehavior="false" class="btn red" Text="Relación Cliente" />
                                    <asp:Button type="button" ID="btnVerDetalle" runat="server" OnClick="btnVerDetalle_Click" UseSubmitBehavior="false" class="btn green" Text="Detalle" />
                                </div>
                            </div>
                            <div id="divBuscarPorNroCliente" class="form-actions top">
                                <div class="col-md-6">
                                    <label>Buscar por Código Cliente:</label>
                                    <div class="input-group">
                                        <asp:TextBox type="text" ID="txtCodigoCliente" placeholder="Ingrese el Código del cliente" runat="server" class="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button class="btn blue" type="button" runat="server" ID="btnBuscarPorCodigoCliente" OnClick="btnBuscarPorCodigoCliente_Click" UseSubmitBehavior="false" Text="Buscar" />
                                            <asp:Button class="btn red" type="button" runat="server" ID="btnBorrar" OnClick="btnBorrar_Click" UseSubmitBehavior="false" Text="Borrar" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <dx:ASPxGridView ID="gvArticulos" ClientInstanceName="gvArticulos" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoArticulo" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoArticulo" ReadOnly="True" Visible="true" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoArticuloCliente" Visible="false" Caption="Codigo interno" VisibleIndex="1">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionCorta" Caption="Desc. Corta" VisibleIndex="2">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionLarga" Visible="false" Caption="Desc. Larga" VisibleIndex="3">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="marca" Caption="Marca" VisibleIndex="4">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="precio" Caption="Precio" VisibleIndex="5">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionMoneda" Caption="Moneda" VisibleIndex="5">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoCliente" Visible="false" VisibleIndex="6">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="razonSocialCliente" Caption="Cliente" VisibleIndex="7" Visible="false">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoUnidadMedida" VisibleIndex="7" Visible="false">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="unidadMedidad" Caption="Unidad de Medida" VisibleIndex="7" Visible="false">
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
    <dx:ASPxPopupControl ID="pcConfirmarEliminarArticulo" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
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
                                                ¿Desea eliminar el artículo seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" OnClientClick="pcConfirmarEliminarArticulo.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="Button2" runat="server" UseSubmitBehavior="false" OnClick="btnAceptarEliminarArticulo_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <!-- BEGIN POPUP DETALLE ARTICULO -->

    <dx:ASPxPopupControl ID="pcShowDetalleArticulo" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowDetalleArticulo"
        HeaderText="Detalle del Artículo" AllowDragging="True" EnableViewState="False" Width="800px"
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
                                                <label style="font-size: medium"><strong>Info del Artículo</strong></label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Desc. Corta</label>
                                                            <div class="col-md-9">
                                                                <textarea type="text" id="txtDescripcionCorta" placeholder="Descripción Corta" runat="server" class="form-control" rows="2"></textarea>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Desc. Larga</label>
                                                            <div class="col-md-9">
                                                                <textarea type="text" id="txtDescripcionLarga" placeholder="Descripción Larga" runat="server" class="form-control" rows="2"></textarea>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Marca</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtMarca" placeholder="Marca" runat="server" class="form-control">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Unidad</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtUnidadDeMedida" placeholder="Unidad de Medida" runat="server" class="form-control">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <label class="control-label col-md-3">Precio:</label>
                                                        <div class="col-md-9">
                                                            <div class="input-group">
                                                                <input type="text" id="txtPrecioActual" placeholder="Precio" runat="server" class="form-control">
                                                                    <span class="input-group-btn">
                                                                        <button class="btn blue" type="button" onclick="ShowHistoricoPrecio()">
                                                                            <span class="md-click-circle md-click-animate" style="height: 49px; width: 49px; top: -8.5px; left: -20.5px;"></span>Ver</button>
                                                                    </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Moneda</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtTipoDeCambio" placeholder="Tipo de Cambio" runat="server" class="form-control">
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <!--/row-->
                                            </div>
                                        </form>
                                        <!-- END FORM-->
                                    </div>

                                    <!--INFO DEL CLIENTE-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label style="font-size: medium"><strong>Info del Cliente</strong></label>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <dx:ASPxGridView runat="server" ID="gvCliente" KeyFieldName="codigoArticuloCliente" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoArticuloCliente" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoInterno" Caption="Codigo Interno" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="razonSocialCliente" Caption="Razon Social" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoCliente" Visible="false" VisibleIndex="3">
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
                                    <!--FIN INFO DEL CLIENTE-->

                                    <!--INFO DEL PROVEEDOR-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label style="font-size: medium"><strong>Info del Proveedor</strong></label>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div>
                                                            <div class="btn-set pull-right" style="padding-bottom: 3px">
                                                                <%--<asp:Button class="btn blue" type="button" runat="server" ID="btnShowHistoricoCosto" UseSubmitBehavior="false" OnClick="btnShowHistoricoCosto_Click" Text="Ver" />--%>
                                                                <dx:ASPxButton ID="btnShowHistoricoCosto" runat="server" Text="Aceptar" AutoPostBack="False" CssClass="btn blue" class="btn blue" ClientSideEvents-Click="OnClickShowHistoricoCosto">
                                                                </dx:ASPxButton>

                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <dx:ASPxGridView runat="server" ID="gvArticuloProveedores" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoArticuloProveedor">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoArticuloProveedor" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="razonSocialProveedor" Caption="Proveedor" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoProveedor" Visible="false" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="costoActual" Caption="Costo" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                                <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                                                <SettingsBehavior AllowFocusedRow="True" />
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

    <dx:ASPxPopupControl ID="pcHistoricoPrecio" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcHistoricoPrecio"
        HeaderText="Historico Precio" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="450"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label><strong>Historico de Precios</strong></label>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <dx:ASPxGridView ID="gvHistoricoPrecio" runat="server" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigo" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="precio" Caption="Precio" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="descripcionMoneda" Caption="Moneda" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaDesde" Caption="Fec. Desde" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaHasta" Caption="Fec. Hasta" VisibleIndex="3">
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

    <dx:ASPxPopupControl ID="pcHistoricoCosto" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcHistoricoCosto"
        HeaderText="Historico Costo" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="450"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label><strong>Historico de Costo</strong></label>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <dx:ASPxGridView ID="gvHistoricoCosto" runat="server" Width="100%" Theme="Metropolis" KeyFieldName="codigoHistorialCosto" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoHistorialCosto" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="costo" Caption="Precio" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaDesde" Caption="Fec. Desde" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaHasta" Caption="Fec. Hasta" VisibleIndex="3">
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

    <!--END POPUP RELACION ARTICULO - CLIENTE-->

    <dx:ASPxPopupControl ID="pcRelacionArticuloCliente" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcRelacionArticuloCliente"
        HeaderText="Relación Artículo Cliente" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="650"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  pcRelacionArticuloCliente.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                <dx:ASPxPanel ID="ASPxPanel3" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent5" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="btn-set pull-left" style="padding-bottom: 5px">
                                                            <%--<asp:Button type="button" ID="btnNuevaRelacionArticuloCliente" runat="server" OnClientClick="ShowNuevaRelacionArticuloCliente()" class="btn blue" Text="Nuevo" UseSubmitBehavior="false" />--%>
                                                            <button type="button" onclick="ShowNuevaRelacionArticuloCliente()" class="btn blue">Nuevo</button>
                                                            <%--<button type="button" onclick="ShowEliminarRelacionArticuloCliente()" class="btn red">Eliminar</button>--%>
                                                            <asp:Button type="button" ID="btnEliminarRelacionArticuloCliente" runat="server" UseSubmitBehavior="false" CssClass="btn red" Text="Eliminar" OnClick="btnEliminarRelacionArticuloCliente_Click" />
                                                        </div>
                                                        <div class="form-group">
                                                            <dx:ASPxGridView ID="gvArticuloCliente" ClientInstanceName="gvArticuloCliente" runat="server" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoArticuloCliente">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoArticuloCliente" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoInterno" Caption="Codigo Interno" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoCliente" Caption="Codigo Cliente" VisibleIndex="1" Visible="false">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="razonSocialCliente" Caption="Cliente" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" />
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

    <dx:ASPxPopupControl ID="pcNuevaRelacionArticuloCliente" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcNuevaRelacionArticuloCliente"
        HeaderText="Nueva Relacion" AllowDragging="True" EnableViewState="False" Width="400px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  pcNuevaRelacionArticuloCliente.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl6" runat="server">
                <dx:ASPxPanel ID="ASPxPanel4" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent6" runat="server">
                            <div data-width="760">
                                <div class="modal-body">

                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <label>Codigo Cliente</label>
                                                            <dx:ASPxComboBox ID="cbClientes" runat="server" DropDownStyle="DropDownList" CssClass="form-control" ClientInstanceName="cbClientes"
                                                                ValueField="codigoCliente" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0} ({1})" Width="100%" EnableTheming="True" Theme="Metropolis">
                                                                <Columns>
                                                                    <dx:ListBoxColumn FieldName="codigoCliente" Width="100px" Visible="false" />
                                                                    <dx:ListBoxColumn FieldName="cuil" Width="100px" />
                                                                    <dx:ListBoxColumn FieldName="razonSocial" Width="300px" />
                                                                </Columns>
                                                            </dx:ASPxComboBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <label>Codigo Articulo</label>
                                                            <dx:ASPxTextBox ID="txtCodigoClienteArticuloPopUp" ClientInstanceName="txtCodigoClienteArticuloPopUp" runat="server" CssClass="form-control" Width="100%"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <dx:ASPxButton ID="btnGuardarRelacionArticuloCliente" runat="server" Text="Aceptar" AutoPostBack="False" CssClass="btn blue" class="btn blue" ClientSideEvents-Click="OnClickAceptarCliente">
                                            <ClientSideEvents Click="OnClickAceptarCliente"></ClientSideEvents>
                                        </dx:ASPxButton>
                                        <%--<asp:Button type="button" ID="btnGuardarRelacionArticuloCliente" runat="server" UseSubmitBehavior="false" OnClick="OnClickAceptarCliente" OnClientClick="OnClickAceptarCliente" class="btn blue" Text="Aceptar" />--%>
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcConfirmarEliminarRelacionArticuloCliente" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarRelacionArticuloCliente"
        HeaderText="Eliminar Relacion Artículo Cliente" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  pcConfirmarEliminarRelacionArticuloCliente.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl7" runat="server">
                <dx:ASPxPanel ID="ASPxPanel5" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent7" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                ¿Desea eliminar la relación del articulo seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <button type="button" onclick="pcConfirmarEliminarRelacionArticuloCliente.Hide();" class="btn default">Cerrar</button>
                                        <asp:Button type="button" ID="btnConfirmarEliminarRelacionArticuloCliente" runat="server" OnClick="btnConfirmarEliminarRelacionArticuloCliente_Click" UseSubmitBehavior="false" class="btn blue" Text="Aceptar" />
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


    <!--END POPUP RELACION ARTICULO - PROVEEDOR-->
    <dx:ASPxPopupControl ID="pcRelacionArticuloProveedor" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcRelacionArticuloProveedor"
        HeaderText="Relación Artículo Proveedor" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="650"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server">
                <dx:ASPxPanel ID="ASPxPanel6" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent8" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="btn-set pull-left" style="padding-bottom: 5px">
                                                            <%--<asp:Button type="button" ID="btnNuevaRelacionArticuloCliente" runat="server" OnClientClick="ShowNuevaRelacionArticuloCliente()" class="btn blue" Text="Nuevo" UseSubmitBehavior="false" />--%>
                                                            <button type="button" onclick="ShowNuevaRelacionArticuloProveedor()" class="btn blue">Nuevo</button>
                                                            <button type="button" onclick="ShowEliminarRelacionArticuloProveedor()" class="btn red">Eliminar</button>

                                                        </div>
                                                        <div class="form-group">
                                                            <dx:ASPxGridView ID="gvArticuloProveedor" runat="server" SettingsBehavior-AllowFocusedRow="true" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoArticuloProveedor">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoArticuloProveedor" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoProveedor" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="razonSocialProveedor" Caption="Proveedor" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="tipoMoneda" Caption="Moneda" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="costoActual" Caption="Costo" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="tipoDocumento" Caption="Tipo Documento" VisibleIndex="1" Visible="false">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="nroDocumento" Caption="Nro Documento" VisibleIndex="1" Visible="false">
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

    <dx:ASPxPopupControl ID="pcNuevaRelacionArticuloProveedor" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcNuevaRelacionArticuloProveedor"
        HeaderText="Nueva Relacion" AllowDragging="True" EnableViewState="False" Width="400px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  pcNuevaRelacionArticuloProveedor.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl9" runat="server">
                <dx:ASPxPanel ID="ASPxPanel7" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent9" runat="server">
                            <div data-width="760">
                                <div class="modal-body">

                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <label>Proveedor</label>
                                                            <dx:ASPxComboBox ID="cbProveedores" runat="server" DropDownStyle="DropDownList" CssClass="form-control" ClientInstanceName="cbProveedores"
                                                                ValueField="codigoProveedor" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0} ({1})" Width="100%" EnableTheming="True" Theme="Metropolis">
                                                                <Columns>
                                                                    <dx:ListBoxColumn FieldName="codigoProveedor" Width="100px" Visible="false" />
                                                                    <dx:ListBoxColumn FieldName="cuil" Width="100px" />
                                                                    <dx:ListBoxColumn FieldName="razonSocial" Width="300px" />
                                                                </Columns>
                                                            </dx:ASPxComboBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <label>Costo:</label>
                                                            <dx:ASPxTextBox ID="txtCosto" ClientInstanceName="txtCosto" runat="server" CssClass="form-control" Width="100%"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row hidden">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label>Cantidad</label>
                                                            <asp:TextBox type="text" ID="txtCantidad" placeholder="Cantidad" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label>Tipo de Moneda</label>
                                                            <dx:ASPxComboBox ID="cbMonedaCosto" runat="server" DropDownStyle="DropDownList" CssClass="form-control" ClientInstanceName="cbMonedaCosto"
                                                                ValueField="codigo" IncrementalFilteringMode="Contains" ValueType="System.Int32" Width="100%" EnableTheming="True" Theme="Metropolis" TextField="descripcion">
                                                            </dx:ASPxComboBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <dx:ASPxButton ID="btnGuardarRelacionArticuloProveedor" runat="server" Text="Aceptar" AutoPostBack="False" CssClass="btn blue" class="btn blue" ClientSideEvents-Click="OnClickAceptarProveedor">
                                            <ClientSideEvents Click="OnClickAceptarProveedor"></ClientSideEvents>
                                        </dx:ASPxButton>
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcConfirmarEliminarRelacionArticuloProveedor" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarRelacionArticuloProveedor"
        HeaderText="Eliminar Relacion Artículo Proveedor" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  pcConfirmarEliminarRelacionArticuloProveedor.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl10" runat="server">
                <dx:ASPxPanel ID="ASPxPanel8" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent10" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                ¿Desea eliminar la relación del articulo con el proveedor seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <button type="button" onclick="pcConfirmarEliminarRelacionArticuloProveedor.Hide();" class="btn default">Cerrar</button>
                                        <asp:Button type="button" ID="btnConfirmarEliminarRelacionArticuloProveedor" runat="server" OnClick="btnConfirmarEliminarRelacionArticuloProveedor_Click" UseSubmitBehavior="false" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>


    <!--END POPUP RELACION ARTICULO - CLIENTE-->

    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcError" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcError"
        HeaderText="Mensaje" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl11" runat="server">
                <dx:ASPxPanel ID="ASPxPanel9" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent11" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                <dx:ASPxLabel ID="lblMensaje" runat="server" Text=""></dx:ASPxLabel>
                                            </div>
                                        </div>
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
        function ShowHistoricoPrecio() {
            pcHistoricoPrecio.Show();
        }
        function ShowHistoricoCosto() {
            pcHistoricoCosto.Show();
        }
        //function chkBuscarPorNroCliente(isCheck) {
        //    if (isCheck == true)
        //        document.getElementById('divBuscarPorNroCliente').style.display = 'block';
        //    else
        //        document.getElementById('divBuscarPorNroCliente').style.display = 'none';
        //}
        function ShowNuevaRelacionArticuloCliente() {
            pcNuevaRelacionArticuloCliente.Show();

        }
        function ShowEliminarRelacionArticuloCliente() {
            pcConfirmarEliminarRelacionArticuloCliente.Show();
        }
        function ShowRelacionArticuloCliente() {
            pcRelacionArticuloCliente.Show();
        }
        function ShowEliminarRelacionArticuloProveedor() {
            pcConfirmarEliminarRelacionArticuloProveedor.Show();
        }
        function ShowRelacionArticuloProveedor() {
            pcRelacionArticuloProveedor.Show();
        }
        function ShowNuevaRelacionArticuloProveedor() {
            pcNuevaRelacionArticuloProveedor.Show();

        }
    </script>
</asp:Content>

