<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="articulo.aspx.cs" Inherits="SCF.articulos.articulo" %>

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
                    <h1>Artículo <small>editar/nuevo Artículo</small></h1>
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
                    <a href="articulo.aspx">Artículo</a>
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
                                <i class="fa fa-user"></i>Articulo
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <form action="#" class="horizontal-form">
                                <div class="form-body">
                                    <h3 class="form-section">Info del Articulo</h3>
                                    <div class="row">
                                        <div class="col-md-12 ">
                                            <div class="form-group">
                                                <label>Descripción Corta</label>
                                                <textarea type="text" id="txtDescripcionCorta" style="resize: none" placeholder="Descripción Corta" runat="server" class="form-control" required rows="2" aria-required="true"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 ">
                                            <div class="form-group">
                                                <label>Descripción Larga</label>
                                                <textarea type="text" id="txtDescripcionLarga" style="resize: none" placeholder="Descripción Larga" runat="server" class="form-control" rows="2"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 ">
                                            <div class="form-group">
                                                <label>Marca</label>
                                                <input type="text" id="txtMarca" placeholder="Marca" runat="server" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-md-6 ">
                                            <div class="form-group">
                                                <label>Unidad de Medida</label>
                                                <dx:ASPxComboBox ID="cbUnidadMedida" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                    ValueField="codigo" IncrementalFilteringMode="Contains" ValueType="System.Int32" Width="100%" EnableTheming="True" Theme="Metropolis" TextField="descripcion">
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 ">
                                            <div class="form-group">
                                                <label>Precio</label>
                                                <input type="text" id="txtPrecio" placeholder="Precio" runat="server" class="form-control" required="required">
                                            </div>
                                        </div>
                                        <div class="col-md-6 ">
                                            <div class="form-group">
                                                <label>Tipo de Moneda</label>
                                                <dx:ASPxComboBox ID="cbMonedaPrecio" runat="server" DropDownStyle="DropDownList" CssClass="form-control"
                                                    ValueField="codigo" IncrementalFilteringMode="Contains" ValueType="System.Int32" Width="100%" EnableTheming="True" Theme="Metropolis" TextField="descripcion">
                                                    <ValidationSettings>
                                                        <RequiredField IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/row-->
                                </div>
                                <div class="form-actions right">
                                    <button type="button" class="btn default" onclick="location.href='listado.aspx'">Cancelar</button>
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

    <script type="text/javascript">
        function ShowArticuloProveedor() {
            pcArticuloProveedor.Show();
        }
        function ShowAddPrecio() {
            pcAddPrecio.Show();
            txtPrecio.focus();
        }

        function ShowAddCosto() {
            pcAddCosto.Show();
            txtCosto.focus();
        }
        function ShowConfirmarEliminarArticuloProveedor() {
            pcConfirmarEliminarArticuloProveedor.Show();
        }
    </script>
</asp:Content>

