<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="tipo_comprobante.aspx.cs" Inherits="SCF.facturas.tipo_comprobante" %>

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
                    <h1>Facturación <small>Tipos de Comprobante</small></h1>
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
                    <a href="tipo_comprobante.aspx">Tipos de Comprobante</a>
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
                                <i class="fa fa-bitcoin"></i>Tipos de Comprobante
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
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarTipoComprobante()" UseSubmitBehavior="false" class="btn red" Text="Eliminar" />
                                </div>
                                <%--<div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnVer" runat="server" OnClick="btnVer_Click" class="btn green" Text="Detalle" />
                                </div>--%>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->
                                <dx:ASPxGridView ID="gvFacturas" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="idTipoComprobante" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="idTipoComprobante" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="ptoDeVenta" VisibleIndex="1" Caption="Punto de Venta">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="letraComprobante" VisibleIndex="1" Caption="Letra">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="descripcionComprobante" VisibleIndex="1" Caption="Descr">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
                                    <SettingsPager PageSize="10">
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
    <dx:ASPxPopupControl ID="pcConfirmarEliminarTipoComprobante" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarTipoComprobante"
        HeaderText="Eliminar Tipo Comprobante" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Desea eliminar el tipo de comprobante seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" UseSubmitBehavior="false" OnClientClick="pcConfirmarEliminarTipoComprobante.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnConfirmarEliminarTipoComprobante" runat="server" OnClick="btnConfirmarEliminarTipoComprobante_Click" class="btn blue" Text="Aceptar" />
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

    <dx:ASPxPopupControl ID="pcTipoComprobante" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcTipoComprobante"
        HeaderText="Tipo de Comprobante" AllowDragging="True" EnableViewState="False" Width="850px"
        PopupAnimationType="Fade" Theme="Metropolis" ScrollBars="Auto">
        <ClientSideEvents PopUp="function(s, e) {  txtNroProveedor.Focus(); }" />
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
                                                <h3 class="form-section">Info del Tipo de Comprobante</h3>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Comprobante</label>
                                                            <div class="col-md-9">
                                                                <dx:ASPxComboBox ID="cbTipoComprobanteAFIP" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                                    ValueField="codigoComprobanteAFIP" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0} ({1})" 
                                                                    Width="100%" EnableTheming="True" Theme="Metropolis">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn FieldName="codigoComprobanteAFIP" Width="100px" Visible="false" />
                                                                        <dx:ListBoxColumn FieldName="codigoAFIP" Width="100px" />
                                                                        <dx:ListBoxColumn FieldName="descripcionAFIP" Width="300px" />
                                                                    </Columns>
                                                                </dx:ASPxComboBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Punto de Venta</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtPuntoVenta" placeholder="Punto de Venta" runat="server" class="form-control">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <label class="control-label col-md-3">Letra</label>
                                                        <div class="col-md-9">
                                                            <input type="text" id="txtLetra" placeholder="Letra Tipo de Comprobante" runat="server" class="form-control">
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Descripción</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtDescripcion" placeholder="Descripcion Tipo de Comprobante" runat="server" class="form-control">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/row-->
                                            </div>
                                            <div class="modal-footer">
                                                <div class="btn-set pull-right">
                                                    <button type="button" id="Button3" onclick="pcTipoComprobante.Hide();" class="btn default">Cerrar</button>
                                                    <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" />
                                                </div>
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


    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarTipoComprobante() {
            pcConfirmarEliminarTipoComprobante.Show();
        }
        function ShowTipoComprobante() {
            pcTipoComprobante.Show();
        }
    </script>
</asp:Content>


