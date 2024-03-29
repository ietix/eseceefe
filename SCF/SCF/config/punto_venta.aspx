﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="punto_venta.aspx.cs" Inherits="SCF.config.puntoDeVenta" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

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
                    <a href="punto_venta.aspx">Datos del Punto de Venta</a>
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
                                <i class="fa fa-cloud"></i>Datos del Punto de Venta
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Info de punto de venta</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Codigo de Punto de Venta</label>
                                                <input type="text" id="txtCodigo" runat="server" class="form-control" readonly="true" placeholder="0"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Número de Punto de Venta</label>
                                                <input type="text" id="txtNumero" runat="server" class="form-control"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Punto de Venta Superior</label>
                                                <dx:ASPxComboBox id="cbPuntoDeVentaParent" runat="server" dropdownstyle="DropDownList" cssclass="form-control" textfield="descripcion"
                                                    valuefield="codigoPuntoDeVenta" incrementalfilteringmode="Contains" valuetype="System.Int32" width="100%" enabletheming="True" theme="Metropolis" autopostback="false">
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Descripción</label>
                                                <input type="text" id="txtDescripcion" runat="server" class="form-control" required/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Número Inicial</label>
                                                <input type="text" id="txtNroInicial" runat="server" class="form-control" placeholder="0"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Número Final</label>
                                                <input type="text" id="txtNroFinal" runat="server" class="form-control" placeholder="999999"/>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="contol-label">Número Actual</label>
                                                <input type="text" id="txtNroActual" runat="server" class="form-control" placeholder="0"/>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Tipo de Comprobante</label>
                                                <dx:ASPxComboBox id="cbTipoComprobante" runat="server" dropdownstyle="DropDownList" cssclass="form-control" textfield="descripcion"
                                                    valuefield="codigoTipoComprobante" incrementalfilteringmode="Contains" valuetype="System.Int32" width="100%" enabletheming="True" theme="Metropolis" autopostback="false">
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Cai</label>
                                                <input type="text" id="txtCai" runat="server" class="form-control"/>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Fecha de Vencimiento Cai</label>
                                                <dx:ASPxDateEdit ID="deFechaVencimiento" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                  <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
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


</asp:Content>

