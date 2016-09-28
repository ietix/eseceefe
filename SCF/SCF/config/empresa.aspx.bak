<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="empresa.aspx.cs" Inherits="SCF.config.empresa" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEAD -->
            <div class="page-head">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Datos de la Empresa <small>editar datos de la empresa</small></h1>
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
                    <a href="empresa.aspx">Datos de la Empresa</a>
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
                                <i class="fa fa-cloud"></i>Datos de la Empresa
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Info de la empresa</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Razón Social</label>
                                                <input type="text" id="txtRazonSocial" runat="server" class="form-control" placeholder="Razón Social">
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Persona de Contacto</label>
                                                <input type="text" id="txtPersonaContacto" runat="server" class="form-control" placeholder="Persona de Contacto">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Tipo Documento</label>
                                                <dx:ASPxComboBox id="cbTipoDocumento" runat="server" dropdownstyle="DropDownList" cssclass="form-control" textfield="descripcion"
                                                    valuefield="codigo" incrementalfilteringmode="Contains" valuetype="System.Int32" width="100%" enabletheming="True" theme="Metropolis" autopostback="false">
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Nro Documento</label>
                                                <input type="text" id="txtNroDocumento" runat="server" class="form-control" placeholder="Cuil" required>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Dirección</label>
                                                <input type="text" id="txtDireccion" runat="server" class="form-control" placeholder="Direccion">
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Email</label>
                                                <input type="text" id="txtMail" placeholder="Mail" runat="server" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Provincia</label>
                                                <input type="text" id="txtProvincia" runat="server" class="form-control" placeholder="Provincia">
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Ciudad</label>
                                                <input type="text" id="txtCiudad" runat="server" class="form-control" placeholder="Ciudad">
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Teléfono</label>
                                                <input type="text" id="txtTelefono" runat="server" class="form-control" placeholder="Telefono">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Fax</label>
                                                <input type="text" id="txtFax" runat="server" class="form-control" placeholder="Fax">
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                    <h3 class="form-section">Datos Bancarios</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Banco</label>
                                                <input type="text" id="txtBanco" placeholder="Banco" runat="server" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">CBU</label>
                                                <input type="text" id="txtCBU" runat="server" class="form-control" placeholder="CBU">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Nro. de Cuenta</label>
                                                <input type="text" id="txtNroCuentaBancaria" placeholder="Nro. de Cuenta Bancaria" runat="server" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                    <h3 class="form-section">Datos del Remito Impreso</h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>CAI</label>
                                                <input type="text" id="txtCai" placeholder="Nro Cai" runat="server" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label">Fecha Vencimiento CAI</label>
                                                <%--<input type="text" id="txtFechaVencimientoCai" runat="server" class="form-control" placeholder="Vencimiento Cai">--%>
                                                <dx:ASPxDateEdit ID="txtFechaVencimientoCai" runat="server" CssClass="form-control" Theme="Metropolis" Width="100%" EditFormat="DateTime" AutoPostBack="false">
                                                      <TimeSectionProperties Visible="True">
                                                    </TimeSectionProperties>
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>
                                    </div>
                                    <h3>Observación</h3>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <textarea type="text" id="txtObservacion" placeholder="Observación" runat="server" class="form-control" rows="5"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                    <div class="form-actions right">
                                        <button type="button" class="btn default" onclick="location.href='../index.aspx'">Volver</button>
                                        <asp:Button type="button" class="btn blue" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" />
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

