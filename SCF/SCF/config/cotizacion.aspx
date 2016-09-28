<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="cotizacion.aspx.cs" Inherits="SCF.config.cotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
            <div class="page-content">
                <!-- BEGIN PAGE HEAD -->
                <div class="page-head">
                    <!-- BEGIN PAGE TITLE -->
                    <div class="page-title">
                        <h1>Cotización <small>editar cotizacion</small></h1>
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
                        <a href="cotizacion.aspx">Cotización</a>
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
                                    <i class="fa fa-dollar"></i>Cotización
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="fullscreen"></a>
                                </div>
                            </div>
                            <div class="portlet-body form">
                                
                                <!-- BEGIN FORM-->
                                <form action="#" class="horizontal-form">
                                    <div class="form-body">
                                        <h3 class="form-section">Cotización Dolar</h3>                                        
                                        <div class="row">
                                            <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Compra</label>
                                                    <input type="text" id="txtCompraDolar" placeholder="Cotizacion Actual" runat="server" class="form-control" required>
                                                </div>
                                            </div>
                                            <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Venta</label>
                                                    <input type="text" id="txtVentaDolar" placeholder="Cotizacion Actual" runat="server" class="form-control" required>
                                                </div>
                                            </div>
                                        </div>
                                       <h3 class="form-section">Cotización Euro</h3>                                        
                                        <div class="row">
                                            <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Compra</label>
                                                    <input type="text" id="txtCompraEuro" placeholder="Cotizacion Actual" runat="server" class="form-control" required>
                                                </div>
                                            </div>
                                            <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Venta</label>
                                                    <input type="text" id="txtVentaEuro" placeholder="Cotizacion Actual" runat="server" class="form-control" required>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>
                                    <div class="form-actions right">
                                        <button type="button" class="btn default" onclick="location.href='../index.aspx'">Volver</button>
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar"  OnClick="btnGuardar_Click" Text="Guardar" />
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

