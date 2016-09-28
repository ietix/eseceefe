<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="contrato.aspx.cs" Inherits="SCF.contrato_marco.contrato" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Contrato Marco <small>editar/nueva Contrato Marco</small></h1>
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
                    <a href="contrato.aspx">Contrato Marco</a>
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
                                <i class="fa icon-note"></i>Contrato Marco
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <%--<div class="form-body">
                                    <h3 class="form-section">Detalle del Contrato Marco</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Descripción</label>
                                                <dx:ASPxTextBox ID="txtDescripcion" runat="server" CssClass="form-control" Width="100%" placeholder="Descripcion"></dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Cliente</label>
                                                <dx:ASPxComboBox ID="cbCliente" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                    ValueField="codigoCliente" IncrementalFilteringMode="Contains" ValueType="System.Int32" TextFormatString="{0} ({1})" Width="100%" EnableTheming="True" Theme="Metropolis">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="codigoCliente" Width="100px" Visible="false" />
                                                        <dx:ListBoxColumn FieldName="cuil" Width="100px" />
                                                        <dx:ListBoxColumn FieldName="razonSocial" Width="300px" />
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>--%>
                                <!--/row-->

                                <%--                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Desde</label>
                                                <dx:ASPxDateEdit ID="txtFechaDesde" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>

                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Hasta</label>
                                                <dx:ASPxDateEdit ID="txtFechaHasta" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>

                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>--%>
                                <!--/row-->

                                <!-- BEGIN ROW -->
                                <h3 class="form-section">Items del Contrato Marco</h3>
                                <div class="row">
                                    <div class="col-md-12">
                                        <!-- BEGIN CHART PORTLET-->
                                        <div class="portlet light">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="icon-bar-chart font-green-haze"></i>
                                                    <span class="caption-subject bold uppercase font-green-haze">Ingrese los Artículos</span>
                                                </div>
                                                <div class="tools">
                                                    <a href="javascript:;" class="collapse"></a>
                                                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                    <a href="javascript:;" class="reload"></a>
                                                    <a href="javascript:;" class="fullscreen"></a>
                                                    <a href="javascript:;" class="remove"></a>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="chart_8" class="chart" style="height: auto">
                                                        <!-- GRID VIEW ARTICULOS-->
                                                        <dx:ASPxGridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="PLANTA" Theme="Metropolis" Width="100%">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="CM" VisibleIndex="1" Caption="Contrato Marco">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="POSICION" VisibleIndex="2" Caption="Posición">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="CLIENTE" VisibleIndex="3" Caption="Cliente">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="COMPRADOR" VisibleIndex="4" Caption="Comprador">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="INICIO" VisibleIndex="5" Caption="Fecha inicio">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="FIN" VisibleIndex="6" Caption="Fecha fin">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="PLANTA" VisibleIndex="7" Caption="Codigo articulo cliente">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="DESCRIPCION" VisibleIndex="8" Caption="Desc. Corta">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="PRECIO" Caption="Precio" VisibleIndex="9">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="MEDIDA" Caption="Unidad de medida" VisibleIndex="10">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="MONEDA" Caption="Moneda" VisibleIndex="11">
                                                                    <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedRow="True" />
                                                            <SettingsPager PageSize="10">
                                                            </SettingsPager>
                                                            <Settings ShowFilterRow="True" />
                                                        </dx:ASPxGridView>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- END CHART PORTLET-->
                                        </div>
                                    </div>
                                </div>
                                <!-- END ROW -->
                                <asp:FileUpload ID="fuExcel" CssClass="form-control" runat="server" AllowMultiple="false" />
                                <br />
                                <div class="form-actions top">
                                    <div class="btn-set pull-left">
                                        <asp:Button type="button" class="btn green" runat="server" ID="btnCargarGrilla" OnClick="btnCargarGrilla_Click" Text="Cargar grilla" />
                                    </div>
                                    <div class="btn-set pull-right">
                                        <button type="button" class="btn default" onclick="location.href='listado.aspx'">Cancelar</button>
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" />
                                    </div>
                                </div>
                        </div>
                        </form>
                            <!-- END FORM-->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END CONTENT -->
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
