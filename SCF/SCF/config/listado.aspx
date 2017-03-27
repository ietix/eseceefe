<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.config.listado" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Puntos de Venta <small>listado de Puntos de Venta</small></h1>
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
                    <a href="listado.aspx">Listado Puntos de Venta</a>
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
                                <i class="fa icon-docs"></i>Listado de Puntos de Venta
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
                                    <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" UseSubmitBehavior="false" class="btn yellow" Text="Editar" />
                                    <asp:Button type="button" ID="btnEliminar"  runat="server" OnClientClick="ShowConfirmarEliminarPuntoDeVenta()" class="btn red" UseSubmitBehavior="false" Text="Eliminar" />
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnShowPopUpObservacion" Visible="false" runat="server" OnClientClick="ShowObservacion()" class="btn red" Text="Anular" />
                                    <asp:Button type="button" ID="btnVerDetalle" runat="server" class="btn green" Text="Detalle" OnClick="btnVerDetalle_Click" UseSubmitBehavior="false" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->

                                <dx:ASPxGridView ID="gvPuntosDeVenta" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="codigoPuntoDeVenta" EnableTheming="True" Theme="Metropolis" OnCellEditorInitialize="gvPuntosDeVenta_CellEditorInitialize" OnHtmlRowPrepared="gvPuntosDeVenta_HtmlRowPrepared" SettingsBehavior-AllowSort="true" SettingsBehavior-SortMode="Custom">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoPuntoDeVenta" ReadOnly="True" Visible="True" VisibleIndex="0">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroPuntoDeVenta" VisibleIndex="1" Visible="true" Caption="Punto de Venta">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="descripcion" VisibleIndex="2" Caption="Descripcion">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionTipoComprobante" Visible="True" VisibleIndex="3" Caption="Tipo de Comprobante">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cai" VisibleIndex="4" Visible="True" Caption="Cai">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="vencimientoCai" VisibleIndex="5" Visible="True" Caption="Fecha de Vencimiento Cai">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroInicial" VisibleIndex="6" Visible="False" Caption="Contrato marco">
                                            <Settings AllowSort="False" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroActual" VisibleIndex="9" Visible="false">
                                            <Settings AllowSort="False" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroFinal" VisibleIndex="10" Visible="False" Caption="Cliente">
                                            <Settings AllowSort="False" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoTipoComprobante" VisibleIndex="11" Visible="False" >
                                            <Settings AllowSort="False" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionTipoComprobante" VisibleIndex="11" Visible="False" >
                                            <Settings AllowSort="False" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoPuntoDeVentaParent" VisibleIndex="12" Visible="False" Caption="Observaciones">
                                            <Settings AllowSort="False" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionPuntoDeVentaParent" VisibleIndex="12" Visible="False" Caption="Observaciones">
                                            <Settings AllowSort="False" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
                                    <SettingsPager PageSize="15">
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

    <!-- BEGIN POPUP ELIMINAR PUNTO DE VENTA -->
    <dx:ASPxPopupControl ID="pcConfirmarEliminarPuntoDeVenta" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarPuntoDeVenta"
        HeaderText="Eliminar Punto de Venta" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Desea eliminar la Nota de Pedido seleccionada?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <button type="button" onclick="pcConfirmarEliminarPuntoDeVenta.Hide();" class="btn default">Cerrar</button>
                                        <asp:Button type="button" ID="btnAceptarEliminarPuntoDeVenta" UseSubmitBehavior="false" runat="server" OnClick="btnAceptarEliminarPuntoDeVenta_Click" class="btn blue" Text="Aceptar" />
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

    <dx:ASPxPopupControl ID="pcShowDetallePuntoDeVenta" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowDetallePuntoDeVenta"
        HeaderText="Detalle Punto de Venta" AllowDragging="True" EnableViewState="False" Width="800px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <div data-width="760">
                                <div class="modal-body">
                                    <!--INFO DEL ARTICULO-->
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <label style="font-size: medium"><strong>Info Punto de Venta</strong></label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Punto de Venta</label>
                                                            <dx:ASPxTextBox ID="txtCodigoPuntoDeVenta" runat="server" CssClass="form-control" Width="100%" ReadOnly="True"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Numero Punto de Venta</label>
                                                            <dx:ASPxTextBox ID="txtNumeroPuntoDeVenta" runat="server" CssClass="form-control" Width="100%" ReadOnly="True"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Descripcion</label>
                                                            <dx:ASPxTextBox ID="txtDescripcion" runat="server" CssClass="form-control" Width="100%" ReadOnly="True"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Tipo de Comprobante</label>
                                                            <dx:ASPxTextBox ID="txtTipoComprobante" runat="server" CssClass="form-control" Width="100%" ReadOnly="True"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Cai</label>
                                                            <dx:ASPxTextBox ID="txtCai" runat="server" CssClass="form-control" Width="100%" ReadOnly="True"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Punto de Venta Superior</label>
                                                            <dx:ASPxTextBox ID="txtPuntoVentaSuperior" runat="server" CssClass="form-control" Width="100%" ReadOnly="True"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/row-->
                                            </div>
                                        </form>
                                        <!-- END FORM-->
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
      function ShowConfirmarEliminarPuntoDeVenta() {
          pcConfirmarEliminarPuntoDeVenta.Show();
        }
        function ShowObservacion() {
            pcShowObservacion.Show();
        }
    </script>
</asp:Content>

