<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="credito.aspx.cs" Inherits="SCF.credito.credito" %>

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
                    <h1>Nota de Credito <small>editar/nuevo Nota de Credito</small></h1>
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
                    <a href="credito.aspx">Nota de Credito</a>
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
                                <i class="fa icon-note"></i>Nota de Credito
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <div class="form-actions top">
                                <div class="btn-set pull-left">
                                    <asp:Button type="button" ID="btnUltimoNroComprobante" runat="server" OnClick="btnUltimoNroComprobante_Click" UseSubmitBehavior="false" class="btn blue" Text="Ult. Nro Comprobante" />
                                </div>
                            </div>
                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Detalle del Nota de Credito</h3>
                                    <!--/row-->
                                    <h3 class="form-section">Seleccione la Factura</h3>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Nro de Factura</label>
                                                <dx:ASPxComboBox ID="cbFactura" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                    ValueField="codigoFactura" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0}" Width="100%" EnableTheming="True" Theme="Metropolis" OnSelectedIndexChanged="cbFactura_SelectedIndexChanged" AutoPostBack="True">
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="numeroFactura" Caption="Nro Factura" Width="100%" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Numero Nota de Credito</label>
                                                <dx:ASPxTextBox ID="txtNotaCredito" runat="server" CssClass="form-control" Width="100%">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Emisión</label>
                                                <dx:ASPxDateEdit ID="txtFechaEmision" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/span-->
                                    <!-- BEGIN ROW Detalle del cliente-->
                                    <h3 class="form-section">Detalle del cliente</h3>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Razon Social</label>
                                                <dx:ASPxTextBox ID="txtRazonSocial" runat="server" CssClass="form-control" Width="100%">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">CUIT</label>
                                                <dx:ASPxTextBox runat="server" ID="txtNroDocumento" CssClass="form-control" Width="100%">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Codigo con SCF</label>
                                                <dx:ASPxTextBox ID="txtCodigoConSCF" runat="server" CssClass="form-control" Width="100%">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- BEGIN ROW Detalle del cliente-->
                                    <h3 class="form-section">Detalle de la Factura</h3>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Nro Remito</label>
                                                <dx:ASPxTextBox ID="txtCodigoRemito" runat="server" CssClass="form-control" Width="100%" placeholder="Codigo">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Dirección</label>
                                                <dx:ASPxTextBox ID="txtDireccion" runat="server" CssClass="form-control" Width="100%" placeholder="Direccion">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Concepto</label>
                                                <dx:ASPxTextBox ID="txtConcepto" runat="server" AutoPostBack="true" CssClass="form-control" Width="100%" placeholder="Concepto">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Condición de Venta</label>
                                                <dx:ASPxTextBox ID="txtCondicionVenta" runat="server" AutoPostBack="true" CssClass="form-control" Width="100%" placeholder="Condicion Venta">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Tipo de Moneda</label>
                                                <dx:ASPxTextBox ID="txtTipoMoneda" runat="server" AutoPostBack="true" CssClass="form-control" Width="100%" placeholder="Tipo Moneda" Text="1">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Cotización</label>
                                                <dx:ASPxTextBox ID="txtCotizacion" runat="server" AutoPostBack="true" CssClass="form-control" Width="100%" placeholder="Cotizacón" Text="1">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->

                                        <!--/span-->
                                    </div>

                                    <!--/row-->
                                    <div class="row">

                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Transporte</label>
                                                <dx:ASPxTextBox ID="txtTransporte" runat="server" CssClass="form-control" Width="100%" placeholder="Transporte">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                    </div>



                                    <!-- BEGIN ROW -->
                                    <h3 class="form-section">Items de la Nota de Credito</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <!-- BEGIN CHART PORTLET-->
                                            <div class="portlet light">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="icon-bar-chart font-green-haze"></i>
                                                        <span class="caption-subject bold uppercase font-green-haze">Seleccione los Artículos de la Factura</span>
                                                    </div>
                                                    <div class="tools">
                                                        <a href="javascript:;" class="collapse"></a>
                                                        <a href="javascript:;" class="fullscreen"></a>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="chart_8" class="chart" style="height: auto">
                                                        <!-- GRID VIEW ARTICULOS-->
                                                        <dx:ASPxGridView ID="gvItemsFactura" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoItemEntrega" Theme="Metropolis" Width="100%">
                                                            <Columns>
                                                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Caption=" ">
                                                                </dx:GridViewCommandColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoItemEntrega" ReadOnly="True" Visible="False" VisibleIndex="0">
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
                                                                <dx:GridViewDataTextColumn Caption="Precio" Visible="true" Width="40px" VisibleIndex="5" FieldName="precioUnitario">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Cantidad" Visible="true" Width="50" VisibleIndex="6" FieldName="cantidad">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager PageSize="50">
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
                                                        <span class="caption-subject bold uppercase font-green-haze">Items</span>
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
                                                        <dx:ASPxGridView ID="gvItemsNotaDeCredito" runat="server" Theme="Metropolis" AutoGenerateColumns="False" KeyFieldName="codigoItemEntrega" Width="100%" ClientInstanceName="gvItemsEntrega"
                                                            OnHtmlRowPrepared="gvItemsEntrega_HtmlRowPrepared">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn VisibleIndex="0" FieldName="codigoItemEntrega" Visible="false">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="codigoArticulo" Visible="false">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Desc. Corta Articulo" VisibleIndex="2" FieldName="descripcionCorta" Visible="true">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Cantidad" FieldName="cantidad" Width="40px" VisibleIndex="5">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Precio Unitario" FieldName="precioUnitario" Width="40px" VisibleIndex="5">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Precio Total" FieldName="precioTotal" Width="40px" VisibleIndex="5">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn VisibleIndex="5" FieldName="codigoItemNotaDePedido" Visible="false">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn VisibleIndex="6" FieldName="isEliminada" Visible="false" />


                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <Settings ShowFilterRow="True" />
                                                            <SettingsPager PageSize="50">
                                                            </SettingsPager>
                                                        </dx:ASPxGridView>
                                                        <br />
                                                        <div>
                                                            <div style="display: none" class="btn-set pull-left">
                                                                <asp:Button type="button" class="btn red" runat="server" ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" />
                                                            </div>
                                                            <div class="btn-set pull-right">
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END CHART PORTLET-->
                                        </div>
                                    </div>
                                    <!-- END ROW -->
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="icon-calculator font-green-haze"></i>
                                                <span class="caption-subject bold uppercase font-green-haze">Total</span>
                                                <asp:Button type="button" class="btn blue" runat="server" ID="btnUpdateImporte" UseSubmitBehavior="false" Text="Actualizar Importe" OnClick="btnUpdateImporte_Click" />
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">SUBTOTAL</label>
                                                        <div class="col-md-9">
                                                            <dx:ASPxLabel ID="txtSubtotal" runat="server" Text=" "></dx:ASPxLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">
                                                            <dx:ASPxComboBox ID="cbCondicionIVA" runat="server" DropDownStyle="DropDownList"
                                                                EnableTheming="True" Theme="Metropolis" CssClass="form-control" Width="80">
                                                                <Items>
                                                                    <dx:ListEditItem Text="0 %" Value="3" />
                                                                    <dx:ListEditItem Text="10,5 %" Value="4" />
                                                                    <dx:ListEditItem Selected="true" Text="21 %" Value="5" />
                                                                    <dx:ListEditItem Text="27 %" Value="6" />
                                                                    <dx:ListEditItem Text="5 %" Value="8" />
                                                                    <dx:ListEditItem Text="2,50 %" Value="9" />
                                                                </Items>
                                                            </dx:ASPxComboBox>
                                                        </label>
                                                        <div class="col-md-9">
                                                            <dx:ASPxLabel ID="txtImporteIVA" runat="server" Text=" "></dx:ASPxLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">TOTAL</label>
                                                        <div class="col-md-9">
                                                            <dx:ASPxLabel ID="txtTotal" runat="server" Text=" "></dx:ASPxLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="form-actions right">
                                        <button type="button" class="btn default" onclick="location.href='listado.aspx'">Cancelar</button>
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnEmitir" Text="Emitir" OnClick="btnEmitir_Click" />
                                    </div>
                                </div>
                            </form>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- END CONTENT -->
    <!-- COMIENZO DE POP UP-->

    <script type="text/javascript">
        function ShowEditarItemsNotaDePedido() {
            pcEditarItemsNotaDePedido.Show();
        }
    </script>

    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcError" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcError"
        HeaderText="Error" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                <dx:ASPxLabel ID="lblError" Text="Hola" runat="server">
                                                </dx:ASPxLabel>
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


    <dx:ASPxPopupControl ID="pcUltimoComprobanteAfip" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcUltimoComprobanteAfip"
        HeaderText="Ultimo Comprobante AFIP" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="650"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <div>
                                <div class="modal-body">
                                    <h3 class="form-section">Datos Enviados</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-12">CUIT Contribuyente: 30-71103970-4</label>

                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-12">Punto de Venta: 002</label>

                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-12">Tipo de Comprobante: Nota Credito Tipo A</label>

                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                    <h3 class="form-section">Ultimo Nro. de comprobante: &nbsp;&nbsp; <strong>
                                        <asp:Label ID="lblUltimoNroComprobante" runat="server" Text="0001-00002345"></asp:Label></strong></h3>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcValidarComprobante" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcValidarComprobante"
        HeaderText="Validar Comprobante" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="1000"
        EnableViewState="False" Theme="Metropolis">
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
                                                        <div class="form-body">
                                                            <h3 class="form-section">Detalle Nota de Credito Nro. &nbsp;&nbsp;<asp:Label ID="lblNroFacturaAEmitir" runat="server" Text=" "></asp:Label></h3>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">Cliente: &nbsp;&nbsp;<asp:Label ID="lblNombreApellidoCliente" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">Domicilio: &nbsp;&nbsp;<asp:Label ID="lblDomicilio" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">Localidad: &nbsp;&nbsp;<asp:Label ID="lblLocalidad" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">CUIT: &nbsp;&nbsp;<asp:Label ID="lblNumeroDocumento" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">Condición de Venta: &nbsp;&nbsp;<asp:Label ID="lblCondicionVenta" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">Remito: &nbsp;&nbsp;<asp:Label ID="lblNroRemitos" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">Tipo Moneda: &nbsp;&nbsp;<asp:Label ID="lblTipoMoneda" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">Cotización: &nbsp;&nbsp;<asp:Label ID="lblCotizacion" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                        </div>
                                                        <div class="form-group">
                                                            <dx:ASPxGridView ID="gvDetalleNotaDeCredito" runat="server" Width="100%" Theme="Metropolis" KeyFieldName="codigoItemEntrega" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn VisibleIndex="0" FieldName="codigoItemEntrega" Visible="false">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="codigoArticulo" Visible="false">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Desc. Corta Articulo" VisibleIndex="2" FieldName="descripcionCorta" Visible="true">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Cantidad" FieldName="cantidad" Width="40px" VisibleIndex="5">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Precio Unitario" FieldName="precioUnitario" Width="40px" VisibleIndex="5">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Precio Total" FieldName="precioTotal" Width="40px" VisibleIndex="5">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn VisibleIndex="5" FieldName="codigoItemNotaDePedido" Visible="false">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn VisibleIndex="6" FieldName="isEliminada" Visible="false" />

                                                                </Columns>
                                                            </dx:ASPxGridView>
                                                        </div>
                                                        <div class="form-body">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">CAE: &nbsp;&nbsp;<asp:Label ID="lblNroCAE" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">SUBTOTAL: &nbsp;&nbsp;<asp:Label ID="lblSubtotal" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">FECHA VENC. CAE: &nbsp;&nbsp;<asp:Label ID="lblFechaVencimientoCAE" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">IVA: &nbsp;&nbsp;<asp:Label ID="lblImporteIVA" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                </div>
                                                                <!--/span-->
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">TOTAL: &nbsp;&nbsp;<asp:Label ID="lblImporteTotal" runat="server"></asp:Label></label>
                                                                    </div>
                                                                </div>
                                                                <!--/span-->
                                                            </div>
                                                            <!--/row-->
                                                        </div>
                                                        <div class="form-actions top">
                                                            <div class="btn-set pull-right">
                                                                <button type="button" onclick="pcValidarComprobante.Hide();" class="btn default">Cancelar</button>
                                                                <asp:Button type="button" class="btn blue" runat="server" ID="btnEmitirComprobante" UseSubmitBehavior="false" OnClick="btnEmitirComprobante_Click" Text="Emitir Comprobante" />
                                                            </div>
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


</asp:Content>

