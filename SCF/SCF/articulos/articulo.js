function OnClickAceptarCliente(s, e) {
    gvArticulos.GetRowValues(gvArticulos.GetFocusedRowIndex(), "codigoArticulo", OnCallBackArticuloCliente);
}

function OnCallBackArticuloCliente(s, e) {
    PageMethods.InsertarActualizarArticuloCliente(s, txtCodigoClienteArticuloPopUp.GetValue(), cbClientes.GetValue(), OnSucces, OnFail);
    pcNuevaRelacionArticuloCliente.Hide();
    pcRelacionArticuloCliente.Hide();
}

function OnClickAceptarProveedor(s, e) {
    gvArticulos.GetRowValues(gvArticulos.GetFocusedRowIndex(), "codigoArticulo", OnCallBackArticuloProveedor);
}

function OnCallBackArticuloProveedor(s, e) {
    PageMethods.InsertarActualizarArticuloProveedor(s, cbProveedores.GetValue(), txtCosto.GetValue(), cbMonedaCosto.GetValue(), OnSucces, OnFail);
    pcNuevaRelacionArticuloProveedor.Hide();
    pcRelacionArticuloProveedor.Hide();
}

function OnSucces(s, e) {
    alert("Se ha guardado la relación correctamente");
}

function OnFail(s, e) {
    alert("Error en guardar la relación");
}