<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="nota_pedido.aspx.cs" Inherits="SCF.nota_pedido.nota_pedido" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;   
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Nota de Pedido <small>editar/nueva Nota de Pedido</small></h1>
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
                    <a href="nota_pedido.aspx">Nota de Pedido</a>
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
                                <i class="fa icon-note"></i>Nota de Pedido
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Detalle de la Nota de Pedido</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Nro. Interno Nota Pedido del Cliente</label>
                                                <dx:ASPxTextBox ID="txtNroInternoCliente" runat="server" CssClass="form-control" Width="100%" placeholder="Nro. Interno Nota Pedido Cliente">
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>

                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Emisión</label>
                                                <dx:ASPxDateEdit ID="txtFechaEmision" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>

                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Cliente</label>

                                                <dx:ASPxComboBox ID="cbClientes" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                    ValueField="codigoCliente" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0} ({1})" Width="100%" EnableTheming="True" Theme="Metropolis" AutoPostBack="True" OnSelectedIndexChanged="cbClientes_SelectedIndexChanged">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoCliente" Width="100px" Visible="false" />
                                                        <dx:ListBoxColumn FieldName="cuil" Width="100px" />
                                                        <dx:ListBoxColumn FieldName="razonSocial" Width="300px" />
                                                    </Columns>
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6" id="divContratoMarco">
                                            <div class="form-group">
                                                <label class="control-label">Contrato Marco</label>
                                                <dx:ASPxComboBox ID="cbContratoMarco" runat="server" DropDownStyle="DropDownList" Width="100%" CssClass="form-control" ValueField="codigoContratoMarco" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0} ({1})" EnableTheming="True" Theme="Metropolis">

                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoContratoMarco" Width="100px" Visible="false" />
                                                        <dx:ListBoxColumn FieldName="descripcion" Width="300px" />
                                                        <dx:ListBoxColumn FieldName="fechaInicio" Width="100px" />
                                                        <dx:ListBoxColumn FieldName="fechaFin" Width="100px" />
                                                    </Columns>

                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->

                                    <!-- BEGIN ROW -->
                                    <h3 class="form-section">Items de la Nota de Pedido</h3>
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
                                                        <dx:ASPxGridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoArticulo"
                                                            Theme="Metropolis" Width="100%">
                                                            <Columns>
                                                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Caption=" " Width="40">
                                                                </dx:GridViewCommandColumn>
                                                                <dx:GridViewDataTextColumn FieldName="codigoArticulo" Caption="Cod." Width="60" ReadOnly="True" VisibleIndex="1">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="descripcionCorta" VisibleIndex="2" Caption="Desc. Corta" Width="150">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="false" FieldName="descripcionLarga" VisibleIndex="3" Width="40">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn FieldName="marca" VisibleIndex="9" Visible="false">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Codigo articulo cliente" VisibleIndex="4" Width="130    " FieldName="codigoArticuloCliente">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn Caption="cantidad" Visible="false" VisibleIndex="5" Width="40" FieldName="cantidad">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="fechaEntrega" Visible="false" VisibleIndex="6" Width="40" FieldName="fechaEntrega">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="codigoItemNotaDePedido" Visible="false" Width="40" VisibleIndex="7" FieldName="codigoItemNotaDePedido">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Precio" VisibleIndex="8" FieldName="precio" Width="50">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="descripcionMoneda" Width="50" Caption="Moneda" VisibleIndex="9">
                                                                    <Settings AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>


                                                            </Columns>
                                                            <SettingsBehavior ColumnResizeMode="NextColumn" />
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager PageSize="40">
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
                                                        <span class="caption-subject bold uppercase font-green-haze">Items de la Nota de Pedido</span>
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
                                                        <dx:ASPxGridView ID="gvArticulosSeleccionados" runat="server" Theme="Metropolis" AutoGenerateColumns="False" KeyFieldName="posicion"
                                                            Width="100%" OnRowUpdating="gvItemsEntrega_RowUpdating" OnHtmlRowPrepared="gvItemsEntrega_HtmlRowPrepared" ClientInstanceName="gvArticulosSeleccionados">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Caption="codigoArticulo" VisibleIndex="0" FieldName="codigoArticulo"
                                                                    Visible="false">
                                                                    <Settings AllowSort="True" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Desc. Corta" VisibleIndex="1" FieldName="descripcionCorta">
                                                                    <Settings AllowSort="True" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="descripcionLarga" Visible="false" VisibleIndex="2" FieldName="descripcionLarga">
                                                                    <Settings AllowSort="True" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="marca" Visible="false" Caption="Marca" VisibleIndex="3">
                                                                    <Settings AllowSort="True" />
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Posicion" Visible="true" VisibleIndex="4" Width="40" FieldName="posicion">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Cantidad" FieldName="cantidad" Width="40px" VisibleIndex="5">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />

                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataDateColumn Caption="Entrega" PropertiesDateEdit-DisplayFormatString="d/MM/yyyy"
                                                                    VisibleIndex="5" FieldName="fechaEntrega" Width="100px">
                                                                    <Settings AllowSort="True" />
                                                                    <PropertiesDateEdit DisplayFormatString="d/MM/yyyy" />

                                                                </dx:GridViewDataDateColumn>

                                                                <dx:GridViewDataTextColumn Caption="codigoItemNotaDePedido" Visible="false" VisibleIndex="6" FieldName="codigoItemNotaDePedido">
                                                                    <Settings AllowSort="True" />
                                                                </dx:GridViewDataTextColumn>

                                                                <dx:GridViewDataTextColumn Caption="Precio" VisibleIndex="7" FieldName="precio">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="descripcionMoneda" Width="50" Caption="Moneda" VisibleIndex="9">
                                                                    <Settings AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn VisibleIndex="8" FieldName="isEliminada" Visible="false" />
                                                                <dx:GridViewCommandColumn Caption="Opciones" ShowEditButton="True" VisibleIndex="9" />
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <Settings ShowFilterRow="True" />
                                                            <SettingsPager PageSize="40">
                                                            </SettingsPager>
                                                        </dx:ASPxGridView>
                                                        <br />
                                                        <div>
                                                            <div class="btn-set pull-left">
                                                                <asp:Button type="button" class="btn red" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" Text="Eliminar" />
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
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label">Observación</label>
                                                <textarea id="txtObservacion" placeholder="Observación" runat="server" rows="3" class="form-control"></textarea>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-actions right">
                                        <button type="button" class="btn default" onclick="location.href='listado.aspx'">Cancelar</button>
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
    <!-- COMIENZO DE POP UP-->
    <dx:ASPxPopupControl ID="pcEditarItemsNotaDePedido" runat="server" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcEditarItemsNotaDePedido"
        HeaderText="Agregar/Editar Items de la Nota de Pedido" AllowDragging="True" EnableViewState="False" Width="700px"
        PopupAnimationType="Fade" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtCodigoInterno.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btnGuardarAticuloProveedor">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <div data-width="760">
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            Código Interno:
                                            <div class="input-group">
                                                <dx:ASPxTextBox ID="txtCodigoInterno" runat="server" CssClass="form-control" placeholder="Codigo Interno" ClientInstanceName="txtCodigoInterno"></dx:ASPxTextBox>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <dx:ASPxButton ID="btnGuardarItemsNotaDePedido" runat="server" Text="Guardar" AutoPostBack="False" class="btn blue">
                                        <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) pcEditarItemsNotaDePedido.Hide(); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="btnCancelarItemsNotaDePedido" runat="server" Text="Cancelar" AutoPostBack="False" class="btn btn-default">
                                        <ClientSideEvents Click="function(s, e) { pcEditarItemsNotaDePedido.Hide(); }" />
                                    </dx:ASPxButton>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>

            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

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


</asp:Content>
