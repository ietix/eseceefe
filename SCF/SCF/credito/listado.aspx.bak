<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.credito.listado" %>

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
                    <h1>Nota de Credito <small>listado de Notas de Credito</small></h1>
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
                    <a href="../credito/listado.aspx">Listado de Remitos</a>
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
                                <i class="fa fa-car"></i>Listado de Nota de Credito
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
                                    <button type="button" id="btnEliminar" runat="server" onclick="ShowConfirmarEliminarNotaCredito()" class="btn red" text="Eliminar">Eliminar</button>
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnGenerarPDF" runat="server" OnClick="btnGenerarPDF_Click" UseSubmitBehavior="false" class="btn red" Text="PDF" />
                                    <asp:Button type="button" ID="btnVerDetalle" runat="server" OnClick="btnVerDetalle_Click" class="btn green" Text="Detalle" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress
                                    /* cotizacion */
                                    -->
                                <dx:ASPxGridView ID="gvNotaCredito" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoNotaDeCredito" Theme="Metropolis" ClientInstanceName="gvNotaCredito">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="razonSocialCliente" VisibleIndex="6" Visible="false" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="domicilio" VisibleIndex="6" Visible="false" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="localidad" VisibleIndex="6" Visible="false" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="nroDocumentoCliente" VisibleIndex="6" Visible="false" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="remitos" VisibleIndex="6" Visible="false" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="condicionVenta" VisibleIndex="6" Visible="false" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroNotaDePedido" VisibleIndex="6" Visible="false" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoSCF" VisibleIndex="6" Visible="false" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoNotaDeCredito" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroNotaDeCredito" VisibleIndex="6" Caption="N° Nota Credito">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fechaEmisionNotaDeCredito" VisibleIndex="6" Caption="Fecha Emision">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoFactura" Visible="false" VisibleIndex="6" Caption="N° Factura">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroFactura" VisibleIndex="6" Caption="N° Factura">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionTipoMoneda" VisibleIndex="6" Caption="Tipo Moneda">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionTipoComprobante" Visible="false" VisibleIndex="6" Caption="Tipo Moneda">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cotizacion" VisibleIndex="6" Caption="Cotización">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="subtotal" VisibleIndex="6" Caption="Subtotal">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="total" VisibleIndex="6" Caption="Total">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cae" VisibleIndex="12" Caption="CAE" Visible="true">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fechaHoraVencimientoCAE" VisibleIndex="12" Caption="Vencimiento CAE" Visible="true">
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
    <dx:ASPxPopupControl ID="pcConfirmarEliminarNotaCredito" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarNotaCredito"
        HeaderText="Eliminar Nota Credito" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Desea eliminar la Nota de Credito seleccionada?
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" OnClientClick="pcConfirmarEliminarNotaCredito.Hide();" UseSubmitBehavior="false" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAceptarEliminarNotaCredito" runat="server" OnClick="btnAceptarEliminarNotaCredito_Click" UseSubmitBehavior="false" class="btn blue" Text="Aceptar" />
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

    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarNotaCredito() {
            pcConfirmarEliminarNotaCredito.Show();
        }
    </script>
</asp:Content>
