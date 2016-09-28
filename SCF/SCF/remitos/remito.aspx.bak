<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="remito.aspx.cs" Inherits="SCF.remitos.remito" %>

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
                    <h1>Remito <small>editar/nuevo Remito</small></h1>
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
                    <a href="remito.aspx">Remito</a>
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
                                <i class="fa icon-note"></i>Remito
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Detalle del Remito</h3>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Nota de Pedido</label>
                                                <dx:ASPxComboBox ID="cbNotaDePedido" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                    ValueField="codigoNotaDePedido" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0} ({1})" Width="100%" EnableTheming="True" Theme="Metropolis" OnSelectedIndexChanged="cbNotaDePedido_SelectedIndexChanged" AutoPostBack="True">
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="numeroInternoCliente" Caption="Nro interno cliente" Width="30%" />
                                                        <dx:ListBoxColumn FieldName="razonSocialCliente" Caption="Cliente" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Dirección</label>
                                                <dx:ASPxComboBox ID="cbDireccion" runat="server" CssClass="form-control"
                                                    ValueField="codigoDireccion" IncrementalFilteringMode="Contains" ValueType="System.Int32" Width="100%" EnableTheming="True" Theme="Metropolis">
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                    <CaptionSettings ShowColon="false" />
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoDireccion" Visible="false" Width="30%" />
                                                        <dx:ListBoxColumn FieldName="provincia" Caption="Provincia" />
                                                        <dx:ListBoxColumn FieldName="localidad" Caption="Ciudad" />
                                                        <dx:ListBoxColumn FieldName="descripcion" Caption="Dirección" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
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
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Nro Remito</label>
                                                <dx:ASPxTextBox ID="txtCodigoRemito" runat="server" CssClass="form-control" Width="100%" placeholder="Codigo">
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Transporte</label>
                                                <dx:ASPxComboBox ID="cbTransporte" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                    ValueField="codigoTransporte" IncrementalFilteringMode="Contains" ValueType="System.Int32" Width="100%" EnableTheming="True" Theme="Metropolis" OnSelectedIndexChanged="cbNotaDePedido_SelectedIndexChanged" AutoPostBack="false">
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                    <CaptionSettings ShowColon="false" RequiredMarkDisplayMode="Hidden" />
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoTransporte" Visible="false" Width="30%" />
                                                        <dx:ListBoxColumn FieldName="razonSocial" Caption="Transporte" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                    </div>

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
                                                        <dx:ASPxGridView ID="gvItemsNotaDePedido" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoItemNotaDePedido" Theme="Metropolis" Width="100%">
                                                            <Columns>
                                                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Caption=" ">
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
                                                                <dx:GridViewDataTextColumn Caption="Precio" Visible="true" Width="40px" VisibleIndex="5" FieldName="precio">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Moneda" Visible="true" Width="40px" VisibleIndex="5" FieldName="descripcionMoneda">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Visible="false" VisibleIndex="5" FieldName="codigoMoneda">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Total Entregar" Visible="true" Width="50" VisibleIndex="6" FieldName="cantidad">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Entregada" Visible="true" Width="50" VisibleIndex="7" FieldName="cantidadEntregada">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Fecha Entrega" Visible="true" VisibleIndex="8" FieldName="fechaEntrega" PropertiesTextEdit-DisplayFormatString="d/MM/yyyy">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                    <PropertiesTextEdit DisplayFormatString="d/MM/yyyy" />
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
                                                        <span class="caption-subject bold uppercase font-green-haze">Items a Entregar</span>
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
                                                        <dx:ASPxGridView ID="gvItemsEntrega" runat="server" Theme="Metropolis" AutoGenerateColumns="False" KeyFieldName="codigoItemEntrega" Width="100%" ClientInstanceName="gvItemsEntrega"
                                                            OnRowUpdating="gvItemsEntrega_RowUpdating" OnHtmlRowPrepared="gvItemsEntrega_HtmlRowPrepared">
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
                                                                <dx:GridViewDataTextColumn VisibleIndex="5" FieldName="codigoItemNotaDePedido" Visible="false">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn VisibleIndex="6" FieldName="isEliminada" Visible="false" />

                                                                <dx:GridViewCommandColumn Caption="Opciones" ShowEditButton="True" VisibleIndex="6" />

                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <Settings ShowFilterRow="True" />
                                                            <SettingsPager PageSize="50">
                                                            </SettingsPager>
                                                        </dx:ASPxGridView>
                                                        <br />
                                                        <div>
                                                            <div class="btn-set pull-left">
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
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
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

</asp:Content>

