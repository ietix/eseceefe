<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.remitos.listado" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="remito.js" type="text/javascript"></script>
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Remitos <small>listado de remitos</small></h1>
                </div>
                <!-- END PAGE TITLE -->
            </div>
            <!-- END PAGE HEAD -->
            <!-- BEGIN PAGE BREADCRUMB -->
            <ul class="page-breadcrumb breadcrumb">
                <li>
                    <a href="index.aspx">Inicio</a>
                    <i class="fa fa-circle"></i>
                </li>
                <li>
                    <a href="../remitos/listado.aspx">Listado de Remitos</a>
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
                                <i class="fa fa-car"></i>Listado de Remitos
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <div class="form-actions top">
                                <div class="btn-set pull-left">
                                    <asp:Button type="button" ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" UseSubmitBehavior="false" class="btn blue" Text="Nuevo" />
                                    <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" class="btn yellow" UseSubmitBehavior="false" Text="Editar" />
                                    <button type="button" id="btnEliminar2" runat="server" onclick="ShowConfirmarEliminarRemito()" class="btn red" text="Eliminar">Eliminar</button>
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnGenerarPDF" runat="server" OnClick="btnGenerarPDF_Click" UseSubmitBehavior="false" class="btn red" Text="PDF" />
                                    <asp:Button type="button" ID="btnEntregada" runat="server" OnClick="btnEntregada_Click" class="btn green" Text="Entregada" CommandName="bb" />
                                    <asp:Button type="button" ID="btnDevolucion" runat="server" OnClick="btnDevolucion_Click" class="btn red" Text="Devolución" Visible="false" />
                                    <asp:Button type="button" ID="btnVerDetalle" runat="server" OnClick="btnVerDetalle_Click" class="btn green" Text="Detalle" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->
                                <dx:ASPxGridView ID="gvEntregas" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoEntrega" Theme="Metropolis" OnHtmlRowPrepared="gvEntregas_HtmlRowPrepared" ClientInstanceName="gvEntregas">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoEntrega" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoNotaDePedido" VisibleIndex="1" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoCliente" VisibleIndex="2" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="razonSocialCliente" VisibleIndex="3" Caption="Cliente">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoDireccion" VisibleIndex="4" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="direccion" VisibleIndex="5" Caption="Dirección">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fechaEmision" VisibleIndex="6" Caption="Fecha Emision">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroNotaDePedido" VisibleIndex="7" Caption="Nota de pedido">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroRemito" VisibleIndex="8" Caption="Numero Remito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoEstado" VisibleIndex="9" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="razonSocialTransporte" VisibleIndex="10" Visible="true" Caption="Transporte">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoTransporte" VisibleIndex="11" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="observaciones" VisibleIndex="12" Caption="Observaciones">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="domicilio" VisibleIndex="12" Caption="Observaciones" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="localidad" VisibleIndex="12" Caption="Observaciones" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cai" VisibleIndex="12" Caption="CAI" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fechaVencimientoCai" VisibleIndex="12" Caption="Vencimiento Cai" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
                                    <ClientSideEvents FocusedRowChanged="focus" />
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
    <dx:ASPxPopupControl ID="pcConfirmarEliminarRemito" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarRemito"
        HeaderText="Eliminar Remito" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
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
                                                ¿Desea eliminar el remito seleccionado?
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" OnClientClick="pcConfirmarEliminarRemito.Hide();" UseSubmitBehavior="false" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAceptarEliminarRemito" runat="server" OnClick="btnAceptarEliminarRemito_Click" UseSubmitBehavior="false" class="btn blue" Text="Aceptar" />
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

    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcError" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcError"
        HeaderText="Mensaje" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
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

    <dx:ASPxPopupControl ID="pcShowDetalleRemito" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowDetalleRemito"
        HeaderText="Detalle de Remito" AllowDragging="True" EnableViewState="False" Width="800px"
        PopupAnimationType="Fade" Theme="Metropolis">
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
                                                <label style="font-size: medium"><strong>Info del Remito</strong></label>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Nota de Pedido</label>
                                                            <dx:ASPxTextBox ID="txtNotaDePedido" runat="server" CssClass="form-control" Width="100%" placeholder="Nota de Pedido"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Fecha Remito</label>
                                                            <dx:ASPxDateEdit ID="txtFechaRemito" runat="server" CssClass="form-control" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                                <TimeSectionProperties Visible="True">
                                                                </TimeSectionProperties>
                                                            </dx:ASPxDateEdit>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Código</label>
                                                            <dx:ASPxTextBox ID="txtCodigo" runat="server" CssClass="form-control" Width="100%" placeholder="Código"></dx:ASPxTextBox>
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
                                                <label style="font-size: medium"><strong>Items</strong></label>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <div class="form-group">
                                                            <dx:ASPxGridView runat="server" ID="gvItemsRemito" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoItemEntrega" ReadOnly="True" Visible="false" VisibleIndex="0">
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoArticulo" Visible="false" VisibleIndex="1">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="descripcionCorta" Caption="Desc. Corta" VisibleIndex="2">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="cantidad" Caption="Cantidad" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoProveedor" Visible="false" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="razonSocialProveedor" Visible="false" Caption="Proveedor" VisibleIndex="3">
                                                                        <Settings AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoItemNotaDePedido" Visible="false" VisibleIndex="3">
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
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label class="control-label">Observación</label>
                                                            <textarea id="txtObservacion" runat="server" rows="3" class="form-control" readonly="readonly" style="resize: none;"></textarea>
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



    <dx:ASPxPopupControl ID="pcDevolucionItemsRemito" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDevolucionItemsRemito"
        HeaderText="Cargar Devolución de un Remito" AllowDragging="True" EnableViewState="False" Width="800px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
                            <div data-width="760">
                                <div class="modal-body">
                                    <!--INFO DEL REMITO-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <h3 class="form-section">Info del Remito</h3>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Nota de Pedido</label>
                                                            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" CssClass="form-control" Width="100%" placeholder="Nota de Pedido"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Fecha Remito</label>
                                                            <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" CssClass="form-control" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                                <TimeSectionProperties Visible="True">
                                                                </TimeSectionProperties>
                                                            </dx:ASPxDateEdit>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">Código</label>
                                                            <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" CssClass="form-control" Width="100%" placeholder="Código"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/row-->
                                            </div>
                                        </form>
                                        <!-- END FORM-->
                                    </div>
                                    <!--FIN INFO DEL REMITO-->

                                    <!----ITEMS-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <!-- BEGIN ROW -->
                                                <h3 class="form-section">Items a devolver de un Remito</h3>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <!-- BEGIN CHART PORTLET-->
                                                        <div class="portlet light">
                                                            <div class="portlet-title">
                                                                <div class="caption">
                                                                    <i class="icon-bar-chart font-green-haze"></i>
                                                                    <span class="caption-subject bold uppercase font-green-haze">Seleccione los Artículos</span>
                                                                </div>
                                                                <div class="tools">
                                                                    <a href="javascript:;" class="collapse"></a>
                                                                    <a href="javascript:;" class="fullscreen"></a>
                                                                </div>
                                                            </div>
                                                            <div class="portlet-body">
                                                                <div id="chart_8" class="chart" style="height: auto">
                                                                    <!-- GRID VIEW ARTICULOS-->
                                                                    <dx:ASPxGridView ID="gvItemsNotaDePedido" runat="server" AutoGenerateColumns="False" EnableTheming="True"
                                                                        KeyFieldName="codigoItemNotaDePedido" Theme="Metropolis" Width="100%">
                                                                        <Columns>
                                                                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Caption=" " Width="10">
                                                                            </dx:GridViewCommandColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="codigoItemNotaDePedido" ReadOnly="True" Visible="False" VisibleIndex="0">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                                <EditFormSettings Visible="False" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="codigoArticulo" ReadOnly="True" Visible="False" VisibleIndex="1">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                                <EditFormSettings Visible="False" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="descripcionCorta" VisibleIndex="2" Visible="true" Caption="Desc. Corta" Width="150">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="false" FieldName="descripcionLarga" VisibleIndex="3">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="marca" Visible="false" Width="55px" VisibleIndex="4" Caption="Marca">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Precio" Visible="false" Width="40px" VisibleIndex="5" FieldName="precio">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Total Entregar" Visible="true" Width="50" VisibleIndex="6" FieldName="cantidad">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Entregada" Visible="true" Width="50" VisibleIndex="7" FieldName="cantidadEntregada">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Fecha Entrega" Visible="false" VisibleIndex="8" FieldName="fechaEntrega" PropertiesTextEdit-DisplayFormatString="d/MM/yyyy">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                                <PropertiesTextEdit DisplayFormatString="d/MM/yyyy" />
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                        <SettingsBehavior AllowFocusedRow="True" />
                                                                        <SettingsPager PageSize="10">
                                                                        </SettingsPager>
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <br />
                                                                    <div>
                                                                        <div class="btn-set pull-right">
                                                                            <asp:Button type="button" class="btn green" runat="server" ID="btnSeleccionarArticulos" OnClick="btnSeleccionarArticulos_Click" Text="Seleccionar" />
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <!-- END CHART PORTLET-->
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <!-- BEGIN CHART PORTLET-->
                                                        <div class="portlet light">
                                                            <div class="portlet-title">
                                                                <div class="caption">
                                                                    <i class="icon-bar-chart font-green-haze"></i>
                                                                    <span class="caption-subject bold uppercase font-green-haze">Items a Devolver</span>
                                                                    <span class="caption-helper">cargar items</span>
                                                                </div>
                                                                <div class="tools">
                                                                    <a href="javascript:;" class="collapse"></a>
                                                                    <a href="javascript:;" class="fullscreen"></a>
                                                                </div>
                                                            </div>
                                                            <div class="portlet-body">
                                                                <div id="chart_9" class="chart" style="height: auto">
                                                                    <!-- GRID VIEW ITEMS SELECCIONADOS-->
                                                                    <dx:ASPxGridView ID="gvItemsEntrega" runat="server" Theme="Metropolis" AutoGenerateColumns="False" KeyFieldName="codigoItemEntrega"
                                                                        Width="100%" ClientInstanceName="gvItemsEntrega"
                                                                        OnRowUpdating="gvItemsEntrega_RowUpdating" OnHtmlRowPrepared="gvItemsEntrega_HtmlRowPrepared">
                                                                        <Columns>
                                                                            <dx:GridViewDataTextColumn VisibleIndex="0" FieldName="codigoItemEntrega" Visible="false">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="codigoArticulo" Visible="false">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Desc. Corta" VisibleIndex="2" Width="150" FieldName="descripcionCorta" Visible="true">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                                <EditFormSettings Visible="False" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Visible="false" VisibleIndex="3" FieldName="codigoProveedor">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="razonSocialProveedor" Visible="false" VisibleIndex="4" Caption="Proveedor">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                                <EditFormSettings Visible="False" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Cantidad" FieldName="cantidad" Width="40px" VisibleIndex="5">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn VisibleIndex="5" FieldName="codigoItemNotaDePedido" Visible="false">
                                                                                <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn VisibleIndex="6" FieldName="isEliminada" Visible="false" />

                                                                            <dx:GridViewCommandColumn Caption="Opciones" ShowEditButton="True" VisibleIndex="6" />

                                                                        </Columns>
                                                                        <SettingsBehavior AllowFocusedRow="True" />
                                                                        <Settings ShowFilterRow="True" />
                                                                    </dx:ASPxGridView>
                                                                    <%--<br />
                                                                    <div>
                                                                        <div class="btn-set pull-left">
                                                                            <asp:Button type="button" class="btn red" runat="server" ID="btnEliminarArticulos" Text="Eliminar" OnClick="btnEliminarArticulos_Click" />
                                                                        </div>
                                                                        <div class="btn-set pull-right">
                                                                        </div>
                                                                    </div>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- END CHART PORTLET-->
                                                    </div>
                                                </div>
                                                <!-- END ROW -->

                                            </div>


                                            <div class="form-actions right">
                                                <button type="button" class="btn default" onclick="location.href='listado.aspx'">Cancelar</button>
                                                <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
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



    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarRemito() {
            pcConfirmarEliminarRemito.Show();
        }
    </script>
</asp:Content>

