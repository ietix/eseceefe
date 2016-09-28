<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.nota_pedido.listado" %>

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
                    <h1>Notas de Pedido <small>listado de Notas de Pedido</small></h1>
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
                    <a href="listado.aspx">Listado Notas de Pedido</a>
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
                                <i class="fa icon-docs"></i>Listado de Notas de Pedido
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
                                    <asp:Button type="button" ID="btnEliminar"  runat="server" OnClientClick="ShowConfirmarEliminarNotaPedido()" class="btn red" Text="Eliminar" OnClick="btnEliminar_Click" />
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnShowPopUpObservacion" Visible="false" runat="server" OnClientClick="ShowObservacion()" class="btn red" Text="Anular" />
                                    <asp:Button type="button" ID="btnVerDetalle" runat="server" class="btn green" Text="Detalle" OnClick="btnVerDetalle_Click" UseSubmitBehavior="false" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->

                                <dx:ASPxGridView ID="gvNotasPedido" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="codigoNotaDePedido" EnableTheming="True" Theme="Metropolis" OnCellEditorInitialize="gvNotasPedido_CellEditorInitialize" OnHtmlRowPrepared="gvNotasPedido_HtmlRowPrepared" SettingsBehavior-AllowSort="true" SettingsBehavior-SortMode="Custom">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoNotaDePedido" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroInternoCliente" VisibleIndex="1" Visible="true" Caption="Nro nota de pedido">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="fechaEmision" VisibleIndex="2" Caption="Fecha Emisión">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoEstado" Visible="false" VisibleIndex="3">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="colorEstado" VisibleIndex="4" Visible="False">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoContratoMarco" VisibleIndex="5" Visible="False">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="descripcionContratoMarco" VisibleIndex="6" Visible="true" Caption="Contrato marco">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoCliente" VisibleIndex="9" Visible="false">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="razonSocialCliente" VisibleIndex="10" Visible="true" Caption="Cliente">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fechaHoraProximaEntrega" VisibleIndex="11" Visible="true" Caption="Próxima entrega">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="observaciones" VisibleIndex="12" Visible="true" Caption="Observaciones">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
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

    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
    <dx:ASPxPopupControl ID="pcConfirmarEliminarNotaPedido" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarNotaPedido"
        HeaderText="Eliminar Nota de Pedido" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                        <button type="button" onclick="pcConfirmarEliminarNotaPedido.Hide();" class="btn default">Cerrar</button>
                                        <asp:Button type="button" ID="btnAceptarEliminarNotaPedido" UseSubmitBehavior="false" runat="server" OnClick="btnAceptarEliminarNotaPedido_Click" class="btn blue" Text="Aceptar" />
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

    <!-- BEGIN POPUP OBSERVACION DE LA NOTA DE PEDIDO -->
    <dx:ASPxPopupControl ID="pcShowObservacion" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowObservacion"
        HeaderText="Observacion" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="400"
        EnableViewState="False" Theme="Metropolis" OnLoad="pcShowObservacion_Load">
        <ClientSideEvents PopUp="function(s, e) {  txtPrecio.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <div>
                                <!-- BEGIN FORM-->
                                <form action="#" class="horizontal-form">
                                    <div class="form-body">
                                        <h3 class="form-section">Observación de la Nota de Pedido</h3>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <textarea type="text" id="txtObservacion" placeholder="Observación" runat="server" class="form-control" required rows="5"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button2" runat="server" OnClientClick="pcShowObservacion.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnGuardarObservacion" UseSubmitBehavior="false" runat="server" OnClick="btnGuardarObservacion_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>


    <dx:ASPxPopupControl ID="pcShowDetalleNotaPedido" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowDetalleNotaPedido"
        HeaderText="Detalle Nota de Pedido" AllowDragging="True" EnableViewState="False" Width="800px"
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
                                                <label style="font-size: medium"><strong>Info Nota de Pedido</strong></label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Nota de Pedido Cliente</label>
                                                            <dx:ASPxTextBox ID="txtNotaDePedido" runat="server" CssClass="form-control" Width="100%" placeholder="Nota de Pedido"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Fecha Emisión</label>
                                                            <dx:ASPxDateEdit ID="txtFechaEmision" runat="server" CssClass="form-control" DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                                <TimeSectionProperties Visible="True">
                                                                </TimeSectionProperties>
                                                            </dx:ASPxDateEdit>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Nombre Cliente</label>
                                                            <dx:ASPxTextBox ID="txtNombreCliente" runat="server" CssClass="form-control" Width="100%" placeholder="Cliente"></dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Contrato Marco</label>
                                                            <dx:ASPxTextBox ID="txtContratoMarco" runat="server" CssClass="form-control" Width="100%" placeholder="Contrato Marco"></dx:ASPxTextBox>
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
                                                            <dx:ASPxGridView runat="server" ID="gvDetalleNotaPedido" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" EnableTheming="True">
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="codigoNotaDePedido" ReadOnly="True" Visible="False" VisibleIndex="0">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                                        <EditFormSettings Visible="False" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="numeroInternoCliente" VisibleIndex="1" Visible="false" Caption="Nro nota de pedido">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataDateColumn FieldName="descripcionCorta" VisibleIndex="2" Caption="Desc. Corta">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                                    </dx:GridViewDataDateColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="posicion" Visible="true" VisibleIndex="3" Caption="Posicion">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="cantidad" VisibleIndex="4" Visible="true" Caption="Cantidad">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="fechaEntrega" VisibleIndex="5" Visible="true" Caption="Fecha Entrega">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="descripcionMoneda" VisibleIndex="6" Visible="true" Caption="Moneda">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="precio" VisibleIndex="9" Visible="true" Caption="Precio">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                                    </dx:GridViewDataTextColumn>
                                                                     <dx:GridViewDataTextColumn FieldName="subtotal" VisibleIndex="10" Visible="true" Caption="Subtotal">
                                                                        <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
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
                                                            <textarea id="txtDetalleObservacion" runat="server" rows="3" class="form-control" readonly="readonly" style="resize: none;"></textarea>
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
        function ShowConfirmarEliminarNotaPedido() {
            pcConfirmarEliminarNotaPedido.Show();
        }
        function ShowObservacion() {
            pcShowObservacion.Show();
        }
    </script>
</asp:Content>

