<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="SCF.proveedores.listado" %>

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
                    <h1>Proveedores <small>listado de proveedores</small></h1>
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
                    <a href="listado.aspx">Listado Proveedores</a>
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
                                <i class="fa fa-users"></i>Listado de Proveedores
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="fullscreen"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <div class="form-actions top">
                                <div class="btn-set pull-left">
                                    <asp:Button type="button" ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn blue" UseSubmitBehavior="false" Text="Nuevo" />
                                    <asp:Button type="button" ID="btnEditar" runat="server" OnClick="btnEditar_Click" class="btn yellow" UseSubmitBehavior="false" Text="Editar" />
                                    <asp:Button type="button" ID="btnEliminar" runat="server" OnClientClick="ShowConfirmarEliminarProveedor()" class="btn red" Text="Eliminar"/>
                                </div>
                                <div class="btn-set pull-right">
                                    <asp:Button type="button" ID="btnInactivarProveedor" runat="server" OnClientClick="ShowInactivarProveedor()" UseSubmitBehavior="false" class="btn red-intense" Text="Inactivar" />
                                    <asp:Button type="button" ID="btnActivarProveedor" runat="server" OnClick="btnActivarProveedor_Click" UseSubmitBehavior="false" class="btn blue" Text="Activar" />
                                    <asp:Button type="button" ID="btnVerDetalleProveedor" runat="server" OnClick="btnVerDetalleProveedor_Click" UseSubmitBehavior="false" class="btn green" Text="Detalle" />
                                </div>
                            </div>
                            <div class="form-body" style="height: 600px">
                                <!-- devexpress-->
                                <div class="btn-set pull-right">
                                    <asp:RadioButton type="radio" Text="Activo" ID="rbActivoSi" GroupName="EstadoProveedor" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="rbActivoSi_CheckedChanged" />
                                    <asp:RadioButton type="radio" Text="Inactivo" ID="rbActivoNo" GroupName="EstadoProveedor" runat="server" AutoPostBack="true" OnCheckedChanged="rbActivoNo_CheckedChanged" />
                                </div>
                                <dx:ASPxGridView ID="gvProveedores" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoProveedor" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoProveedor" ReadOnly="True" Visible="false" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="tipoDocumento" Caption="Tipo Documento" VisibleIndex="1">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="codigoTipoDocumento" Visible="false" VisibleIndex="1">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cuil" Caption="Nro Documento" VisibleIndex="1">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="razonSocial" Caption="Proveedor" VisibleIndex="2">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="provincia" Caption="Provincia" VisibleIndex="3">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="localidad" Caption="Localidad" VisibleIndex="4">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="direccion" Caption="Dirección" VisibleIndex="5">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="telefono" Caption="Teléfono" VisibleIndex="6">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="mail" Caption="Mail" VisibleIndex="7">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="personaContacto" Caption="Contacto" Visible="false" VisibleIndex="8">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="banco" Caption="Banco" Visible="false" VisibleIndex="9">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cbu" Caption="CBU" Visible="false" VisibleIndex="10">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="numeroCuenta" Caption="Nro cuenta" Visible="false" VisibleIndex="11">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="observacion" Caption="Observacion" Visible="false" VisibleIndex="12">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="fax" Caption="Fax" Visible="false" VisibleIndex="13">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
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
    <dx:ASPxPopupControl ID="pcConfirmarEliminarProveedor" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcConfirmarEliminarProveedor"
        HeaderText="Eliminar Proveedor" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
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
                                                ¿Desea eliminar el Proveedor seleccionado?
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button1" runat="server" OnClientClick="pcConfirmarEliminarProveedor.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAceptarEliminarProveedor" UseSubmitBehavior="false" runat="server" OnClick="btnAceptarEliminarProveedor_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcShowInactivarProveedor" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowInactivarProveedor"
        HeaderText="Inactivar Proveedor" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ClientSideEvents PopUp="function(s, e) {  txtPrecio.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <div>
                                <form action="#" class="horizontal-form">
                                    <div class="form-body">
                                        <label>¿Desea inactivar el Proveedor seleccionado? Usted puede ingresar una observación.</label>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <textarea type="text" id="txtObservacion" placeholder="Observación" runat="server" class="form-control" required rows="5"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                                <div class="modal-footer">
                                    <div class="btn-set pull-right">
                                        <asp:Button type="button" ID="Button2" runat="server" OnClientClick="pcShowInactivarProveedor.Hide();" class="btn default" Text="Cerrar" />
                                        <asp:Button type="button" ID="btnAceptarInactivarProveedor" UseSubmitBehavior="false" runat="server" OnClick="btnAceptarInactivarProveedor_Click" class="btn blue" Text="Aceptar" />
                                    </div>
                                </div>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcShowDetalleProveedor" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcShowDetalleProveedor"
        HeaderText="Detalle del Proveedor" AllowDragging="True" EnableViewState="False" Width="800px"
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
                                                <label><strong>Info del Proveedor</strong></label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Razon Social</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtRazonSocial" placeholder="Razon Social" runat="server" class="form-control">
                                                            &nbsp;</input> </input>
&nbsp;</input></input></input></input></input></input></input>&nbsp; </input></input>
                                                                </input>
                                                                &nbsp;&nbsp;</input></input></input></div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label ID="lblTipoDoc" runat="server" class="control-label col-md-3">CUIL</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtCUIL" placeholder="CUIL" runat="server" class="form-control">
                                                            &nbsp;</input> </input>
&nbsp;</input></input></input></input></input></input></input>&nbsp; </input></input>
                                                                </input>
                                                                &nbsp;&nbsp;</input></input></input></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <label class="control-label col-md-3">Email</label>
                                                        <div class="col-md-9">
                                                            <input type="text" id="txtEmail" placeholder="Email" runat="server" class="form-control">
                                                        &nbsp;</input> </input>
&nbsp;</input></input></input></input></input></input></input>&nbsp; </input></input>
                                                            </input>
                                                            &nbsp;&nbsp;</input></input></input></div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Tel. / Fax.</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtTelFax" placeholder="Tel. / Fax" runat="server" class="form-control">
                                                            &nbsp;</input> </input>
&nbsp;</input></input></input></input></input></input></input>&nbsp; </input></input>
                                                                </input>
                                                                &nbsp;&nbsp;</input></input></input></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Contacto</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtPersonaCantacto" placeholder="Persona de Contacto" runat="server" class="form-control">
                                                            &nbsp;</input> </input>
&nbsp;</input></input></input></input></input></input></input>&nbsp; </input></input>
                                                                </input>
                                                                &nbsp;&nbsp;</input></input></input></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/row-->
                                                <label><strong>Datos Bancarios</strong></label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Banco</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtBanco" placeholder="Banco" runat="server" class="form-control">
                                                            &nbsp;</input> </input>
&nbsp;</input></input></input></input></input></input></input>&nbsp; </input></input>
                                                                </input>
                                                                &nbsp;&nbsp;</input></input></input></div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">CBU</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtCBU" placeholder="CBU" runat="server" class="form-control">
                                                            &nbsp;</input> </input>
&nbsp;</input></input></input></input></input></input></input>&nbsp; </input></input>
                                                                </input>
                                                                &nbsp;&nbsp;</input></input></input></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label col-md-3">Nro. de Cuenta</label>
                                                            <div class="col-md-9">
                                                                <input type="text" id="txtNroCuenta" placeholder="Nro. Cuenta" runat="server" class="form-control">
                                                            &nbsp;</input> </input>
&nbsp;</input></input></input></input></input></input></input>&nbsp; </input></input>
                                                                </input>
                                                                &nbsp;&nbsp;</input></input></input></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <div class="btn-set pull-right">
                                                    <button type="button" id="Button3" onclick="pcShowDetalleProveedor.Hide();" class="btn default">Cerrar</button>
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

    <!--Inicio PopUp Mensaje-->
    <dx:ASPxPopupControl ID="pcMensaje" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcMensaje"
        HeaderText="Mensaje" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="300"
        EnableViewState="False" Theme="Metropolis">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" DefaultButton="">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent4" runat="server">
                            <div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                <dx:ASPxLabel ID="lblMensaje" runat="server" Text=""></dx:ASPxLabel>
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

    <script lang="javascript" type="text/javascript">
        function ShowConfirmarEliminarProveedor() {
            pcConfirmarEliminarProveedor.Show();
        }
        function ShowInactivarProveedor() {
            pcShowInactivarProveedor.Show();
        }

    </script>
</asp:Content>
