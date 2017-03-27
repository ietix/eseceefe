<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="comprobante.aspx.cs" Inherits="SCF.comprobantes.comprobante" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxPopupControl" Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxPanel" Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxGridView" Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Datos del Punto de Venta <small>editar datos del punto de venta</small></h1>
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
                    <a href="comprobante.aspx">Datos del Comprobante</a>
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
                                <i class="fa fa-cloud"></i>Datos del Comprobante
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Info de comprobante</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Codigo de Comprobante</label>
                                                <input type="text" id="txtCodigo" runat="server" class="form-control" readonly="true" placeholder="0"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Nombre del comprobante</label>
                                                <input type="text" id="txtNombre" runat="server" class="form-control"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Path Comprobante 1</label>
                                                <input type="text" id="txtPath1" runat="server" class="form-control"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Path Comprobante 2</label>
                                                <input type="text" id="txtPath2" runat="server" class="form-control"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Path Comprobante 3</label>
                                                <input type="text" id="txtPath3" runat="server" class="form-control"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Puntos de Venta</label>
                                                <dx:ASPxGridView ID="gvPuntosDeVenta" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="codigoPuntoDeVenta" EnableTheming="True" Theme="Metropolis" OnCellEditorInitialize="gvPuntosDeVenta_CellEditorInitialize" OnHtmlRowPrepared="gvPuntosDeVenta_HtmlRowPrepared" SettingsBehavior-AllowSort="true" SettingsBehavior-SortMode="Custom">
                                                  <Columns>
                                                      <dx:GridViewDataTextColumn FieldName="codigoPuntoDeVenta" ReadOnly="True" Visible="False" VisibleIndex="0">
                                                          <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                          <EditFormSettings Visible="False" />
                                                      </dx:GridViewDataTextColumn>
                                                      <dx:GridViewDataTextColumn FieldName="numeroPuntoDeVenta" VisibleIndex="1" Visible="true" Caption="Punto de Venta">
                                                          <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                      </dx:GridViewDataTextColumn>
                                                      <dx:GridViewDataDateColumn FieldName="descripcion" VisibleIndex="2" Caption="Descripcion">
                                                          <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                      </dx:GridViewDataDateColumn>
                                                      <dx:GridViewDataTextColumn FieldName="descripcionTipoComprobante" Visible="False" VisibleIndex="3" Caption="Tipo de Comprobante">
                                                          <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                      </dx:GridViewDataTextColumn>
                                                      <dx:GridViewDataTextColumn FieldName="cai" VisibleIndex="4" Visible="False" Caption="Cai">
                                                          <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                      </dx:GridViewDataTextColumn>
                                                      <dx:GridViewDataTextColumn FieldName="vencimientoCai" VisibleIndex="5" Visible="False" Caption="Fecha de Vencimiento Cai">
                                                          <Settings AllowSort="True" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                      </dx:GridViewDataTextColumn>
                                                      <dx:GridViewDataTextColumn FieldName="numeroInicial" VisibleIndex="6" Visible="False" Caption="Contrato marco">
                                                          <Settings AllowSort="False" AutoFilterCondition="Contains" FilterMode="DisplayText" />
                                                      </dx:GridViewDataTextColumn>
                                                      <dx:GridViewDataTextColumn FieldName="numeroActual" VisibleIndex="9" Visible="False">
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
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                              &nbsp;
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6" align="right">
                                            <div class="form-group">
                                              <asp:Button type="button" class="btn blue" runat="server" ID="btnAgregar" OnClientClick="ShowAsociarPuntoDeVenta()" Text="Agregar" UseSubmitBehavior="false" />
                                              <asp:Button type="button" class="btn default" runat="server" ID="btnEliminarPV" OnClientClick="ShowConfirmarDisociarPuntoDeVenta()" Text="Eliminar" UseSubmitBehavior="false" />
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->
                                    <div class="form-actions right">
                                        <button type="button" class="btn default" onclick="location.href='listado.aspx'">Volver</button>
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" />
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

    <!-- BEGIN POPUP PUNTOS DE VENTA -->
    <dx:ASPxPopupControl ID="pcPickPuntoDeVenta" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcPickPuntoDeVenta"
        HeaderText="Puntos de Venta" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="400"
        EnableViewState="False" Theme="Metropolis" OnLoad="pcPickPuntoDeVenta_Load">
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
                                        <h3 class="form-section">Punto de Venta a Asociar</h3>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <dx:ASPxComboBox id="cbPuntoDeVenta" runat="server" dropdownstyle="DropDownList" cssclass="form-control" textfield="descripcion"
                                                      valuefield="codigoPuntoDeVenta" incrementalfilteringmode="Contains" valuetype="System.Int32" width="100%" enabletheming="True" theme="Metropolis" autopostback="False">
                                                      <ClientSideEvents SelectedIndexChanged="function(s, e) {
	Session[&quot;PuntoDeVentaAgregar&quot;]=cbPuntoDeVenta.SelectedItem.Value;
}" />
                                                    </dx:ASPxComboBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button2" runat="server" OnClientClick="pcPickPuntoDeVenta.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAsociarPuntoDeVenta" UseSubmitBehavior="false" runat="server" OnClick="btnAsociarPuntoDeVenta_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    
    <!-- BEGIN POPUP ELIMINAR COMPROBANTE -->
    <dx:ASPxPopupControl ID="pcConfirmarDisociarPuntoDeVenta" runat="server" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarDisociarPuntoDeVenta"
        HeaderText="Disociar Punto de Venta" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Desea disociar el Punto de Venta seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <button type="button" onclick="pcConfirmarDisociarPuntoDeVenta.Hide();" class="btn default">Cerrar</button>
                                        <asp:Button type="button" ID="btnAceptarDisociarPuntoDeVenta" UseSubmitBehavior="false" runat="server" OnClick="btnAceptarDisociarPuntoDeVenta_Click" class="btn blue" Text="Aceptar" />
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
    function ShowAsociarPuntoDeVenta() {
      pcPickPuntoDeVenta.Show();
    }
    function ShowConfirmarDisociarPuntoDeVenta() {
      pcConfirmarDisociarPuntoDeVenta.Show();
    }
  </script>
</asp:Content>

