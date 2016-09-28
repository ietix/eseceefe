<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="reporte_facturas.aspx.cs" Inherits="SCF.dashboard.reporte_facturas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Reporte Facturas <small>dashboard</small></h1>
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
                    <a href="reporte_facturas.aspx">Reporte Facturas</a>
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
                                <i class="fa fa-user"></i>Reporte Facturas
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Ingrese los filtros de fecha</h3>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Desde</label>
                                                <dx:ASPxDateEdit ID="deFechaDesde" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="Date" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <!--/span-->
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Hasta</label>
                                                <dx:ASPxDateEdit ID="deFechaHasta" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="Date" AutoPostBack="false">
                                                    <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:Button type="button" class="btn blue" runat="server" ID="btnGenerarReporte" Text="Generear Reporte" OnClick="btnGenerarReporte_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <h3 class="form-section">Reporte Factura</h3>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                <rsweb:ReportViewer Visible="true" ID="rvFacturas" Width="100%" Height="1200px" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                                                </rsweb:ReportViewer>
                                            </div>
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
    </div>
    <!-- END CONTENT -->
</asp:Content>
