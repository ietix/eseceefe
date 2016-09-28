<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="factura.aspx.cs" Inherits="SCF.facturas.factura" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridLookup" TagPrefix="dx" %>

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
                    <h1>Factura <small>editar/nuevo Factura</small></h1>
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
                    <a href="factura.aspx">Factura</a>
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
                                <i class="fa icon-note"></i>Factura
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
                                    <h3 class="form-section">Seleccione el Remito</h3>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="input-group">
                                                <dx:ASPxGridLookup ID="gluRemito" runat="server" SelectionMode="Multiple" CssClass="form-control"
                                                    ClientInstanceName="gridLookup" Theme="Metropolis" AutoPostBack="false"
                                                    KeyFieldName="codigoEntrega" Width="100%" TextFormatString="{1}" MultiTextSeparator=", ">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" Width="100%" Caption=" " />
                                                        <dx:GridViewDataColumn FieldName="codigoEntrega" Visible="false" Caption="Remito" Width="100%" />
                                                        <dx:GridViewDataColumn FieldName="numeroRemito" Caption="Remito" Width="100%" />
                                                        <dx:GridViewDataColumn FieldName="razonSocialCliente" Caption="Cliente" Width="100%" />
                                                        <dx:GridViewDataColumn FieldName="cuitCliente" Caption="CUIT" Width="100%" />
                                                        <dx:GridViewDataColumn FieldName="codigoSCF" Caption="Codigo conSCF" Width="100%" />
                                                    </Columns>
                                                    <GridViewProperties>
                                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                    </GridViewProperties>
                                                </dx:ASPxGridLookup>
                                                <span class="input-group-btn">
                                                    <asp:Button class="btn blue" type="button" runat="server" ID="btnObtenerDatosRemito" OnClick="btnObtenerDatosRemito_Click" UseSubmitBehavior="false" Text="Ir" />
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <h3 class="form-section">Detalle de la Factura</h3>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Tipo de Comprobante</label>
                                                <dx:ASPxComboBox ID="cbTipoComprobante" runat="server" ValueField="codigoTipoComprobante" TextField="descripcion" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" CssClass="form-control" Width="100%">
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Nro. Factura</label>
                                                <dx:ASPxTextBox ID="txtNroFactura" runat="server" CssClass="form-control" Width="100%" placeholder="Nro Factura">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Facturación</label>
                                                <dx:ASPxDateEdit ID="txtFechaFacturacion" runat="server" CssClass="form-control" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Condición de Venta</label>
                                                <dx:ASPxComboBox ID="cbCondicionVenta" runat="server" ValueField="codigoCondicionVenta" TextField="descripcion" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" CssClass="form-control" Width="100%">
                                                    <Items>
                                                        <dx:ListEditItem Selected="true" Text="15 Días" Value="1" />
                                                        <dx:ListEditItem Text="30 Días" Value="2" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Tipo de Moneda</label>
                                                <dx:ASPxComboBox ID="cbTipoMoneda" runat="server" DropDownStyle="DropDownList" EnableTheming="True"
                                                    Theme="Metropolis" CssClass="form-control" Width="100%" ValueField="codigo" IncrementalFilteringMode="Contains">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigo" Width="100px" Visible="false" />
                                                        <dx:ListBoxColumn FieldName="descripcion" Width="100px" Caption="Descripción" />
                                                        <dx:ListBoxColumn FieldName="abreviatura" Width="300px" Caption="Abreviatura" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Concepto</label>
                                                <dx:ASPxComboBox ID="cbConcepto" runat="server" DropDownStyle="DropDownList" EnableTheming="True"
                                                    Theme="Metropolis" CssClass="form-control" Width="100%" ValueField="codigoConcepto" IncrementalFilteringMode="Contains">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoConcepto" Width="100px" Visible="false" />
                                                        <dx:ListBoxColumn FieldName="descripcion" Width="100px" Caption="Descripción" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Cotización</label>
                                                <dx:ASPxTextBox ID="txtCotizacion" runat="server" OnTextChanged="txtCotizacion_TextChanged" AutoPostBack="true" CssClass="form-control" Width="100%" placeholder="Cotizacón" Text="1">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>

                                    <!-- BEGIN ROW Detalle del cliente
                                    <h3 class="form-section">Detalle del cliente</h3>-->
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

                                    <!-- BEGIN ROW -->
                                    <h3 class="form-section">Items de la Factura</h3>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <!-- BEGIN CHART PORTLET-->
                                            <div class="portlet light">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="icon-bar-chart font-green-haze"></i>
                                                        <span class="caption-subject bold uppercase font-green-haze">Artículos</span>
                                                    </div>
                                                    <div class="tools">
                                                        <a href="javascript:;" class="collapse"></a>
                                                        <a href="javascript:;" class="fullscreen"></a>
                                                        <a href="javascript:;" class="remove"></a>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="chart_8" class="chart" style="height: auto">
                                                        <!-- GRID VIEW ARTICULOS-->
                                                        <dx:ASPxGridView ID="gvItemsFactura" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoItemEntrega" OnRowUpdating="gvItemsFactura_RowUpdating"  Theme="Metropolis" Width="100%">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="codigoItemEntrega" ReadOnly="True" Visible="False" VisibleIndex="0">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoEntrega" ReadOnly="True" Visible="False" VisibleIndex="1">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="descripcionCorta" VisibleIndex="2" Visible="true" Caption="Desc. Corta">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="cantidad" VisibleIndex="2" Visible="true" Caption="Cantidad">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoProveedor" VisibleIndex="2" Visible="true" Caption="Cod. Prov">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="razonSocialProveedor" VisibleIndex="2" Visible="true" Caption="Proveedor">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoItemNotaDePedido" VisibleIndex="2" Visible="false" Caption="Cod. Item NP">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="posicion" VisibleIndex="2" Visible="true" Caption="Posición">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoArticuloCliente" VisibleIndex="2" Visible="true" Caption="Cod. Articulo Cliente">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoNotaDePedido" VisibleIndex="2" Width="100px" Visible="false" Caption="Codigo NP">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="numeroNotaDePedido" VisibleIndex="2" Width="150px" Visible="true" Caption="N° Nota Pedido">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="precioUnitario" VisibleIndex="2" Width="150px" Visible="true" Caption="Precio Unitario">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="precioTotal" VisibleIndex="2" Width="150px" Visible="true" Caption="Precio Total">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="True" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewCommandColumn Caption="Opciones" ShowEditButton="true" Visible="true" VisibleIndex="8" />
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager PageSize="20">
                                                            </SettingsPager>
                                                            <Settings ShowFilterRow="True" />
                                                        </dx:ASPxGridView>

                                                    </div>
                                                </div>
                                                <!-- END CHART PORTLET-->
                                            </div>
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
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnEmitir" UseSubmitBehavior="false" Text="Emitir Factura" OnClick="btnEmitir_Click" />
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
    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcError" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
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
                                                            <h3 class="form-section">Detalle Factura &nbsp;&nbsp;<asp:Label ID="lblNroFacturaAEmitir" runat="server" Text=" "></asp:Label></h3>
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
                                                            <dx:ASPxGridView ID="gvDetalleFactura" runat="server" Width="100%" Theme="Metropolis" KeyFieldName="codigoItemEntrega" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoItemEntrega" ReadOnly="True" Visible="False" VisibleIndex="1">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="descripcionCorta" VisibleIndex="2" Visible="true" Caption="Desc. Corta">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="cantidad" VisibleIndex="2" Visible="true" Caption="Cantidad">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoProveedor" VisibleIndex="2" Visible="true" Caption="Cod. Prov">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="razonSocialProveedor" VisibleIndex="2" Visible="true" Caption="Proveedor">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoItemNotaDePedido" VisibleIndex="2" Visible="false" Caption="Cod. Item NP">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="posicion" VisibleIndex="2" Visible="true" Caption="Posición">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoArticuloCliente" VisibleIndex="2" Visible="true" Caption="Cod. Articulo Cliente">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoNotaDePedido" VisibleIndex="2" Width="100px" Visible="false" Caption="Codigo NP">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="numeroNotaDePedido" VisibleIndex="2" Width="150px" Visible="true" Caption="N° NP">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="precioUnitario" VisibleIndex="2" Width="150px" Visible="true" Caption="Precio Unitario">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="precioTotal" VisibleIndex="2" Width="150px" Visible="true" Caption="Precio Total">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
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
                                                <label class="control-label col-md-12">Tipo de Comprobante: Factura Tipo A</label>

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



</asp:Content>



