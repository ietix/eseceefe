<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.facturas.listado" %>

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
                    <h1>Facturas <small>listado de facturas</small></h1>
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
                    <a href="../facturas/listado.aspx">Listado Facturas</a>
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
                                <i class="fa fa-bitcoin"></i>Listado de Facturas
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
                                    <asp:Button type="button" ID="btnEditar" Visible="false" runat="server" OnClick="btnEditar_Click" class="btn yellow" UseSubmitBehavior="false" Text="Editar" />
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarFactura()" UseSubmitBehavior="false" class="btn red" Text="Eliminar"/>
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="Button2" runat="server" OnClick="btnGenerarPDF_Click" UseSubmitBehavior="false" class="btn red" Text="PDF" />
                                    <asp:Button type="button" ID="btnDetalle" runat="server" OnClick="btnDetalle_Click" class="btn green" Text="Detalle" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->
                                <dx:ASPxGridView ID="gvFacturas" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoFactura" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoFactura" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroFactura" VisibleIndex="1" Caption="Numero Factura">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fechaFacturacion" VisibleIndex="2" Caption="Fecha Facturación">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionTipoComprobante" Visible="false" VisibleIndex="3" Caption="Tipo Comprobante">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionTipoMoneda" VisibleIndex="9" Caption="Tipo Moneda" Visible="true">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="remitos" VisibleIndex="5" Caption="Remito" Visible="true">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionConcepto" VisibleIndex="5" Caption="Concepto" Visible="false">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionIVA" VisibleIndex="6" Caption="IVA" Visible="false">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="subtotal" VisibleIndex="7" Caption="Sobtotal">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="total" VisibleIndex="8" Caption="Total">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cae" VisibleIndex="9" Caption="CAE">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="fechaVencimientoCAE" VisibleIndex="10" Caption="Fecha Venc. CAE" Visible="true">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="condicionVenta" Visible="false" VisibleIndex="9" Caption="Condición Venta">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="domicilio" Visible="false" VisibleIndex="9" Caption="Condición Venta">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="localidad" Visible="false" VisibleIndex="9" Caption="Condición Venta">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn FieldName="cotizacion" Visible="false" VisibleIndex="9" Caption="Cotizacion">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
                                    <SettingsPager PageSize="20">
                                    </SettingsPager>
                                </dx:ASPxGridView>

                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- END CONTENT -->

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
    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcConfirmarEliminarFactura" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarFactura"
        HeaderText="Eliminar Factura" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Desea eliminar la factura seleccionada?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" UseSubmitBehavior="false" OnClientClick="pcConfirmarEliminarFactura.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnConfirmarEliminarFactura" runat="server" OnClick="btnConfirmarEliminarFactura_Click" class="btn blue" Text="Aceptar" />
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

    <dx:ASPxPopupControl ID="pcDetalleComprobante" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcDetalleComprobante"
        HeaderText="Detalle Comprobante" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="1000"
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
                                                                <button type="button" onclick="pcDetalleComprobante.Hide();" class="btn default">Cancelar</button>
                                                                <asp:Button type="button" class="btn blue" Visible="false" runat="server" ID="btnEmitirComprobante" OnClick="btnEmitirComprobante_Click" Text="Emitir Comprobante" />
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

    <dx:ASPxPopupControl ID="pcMensaje" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcMensaje"
        HeaderText="Mensaje" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
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


    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarFactura() {
            pcConfirmarEliminarFactura.Show();
        }
    </script>
</asp:Content>


