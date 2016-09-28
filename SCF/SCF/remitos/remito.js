function focus(s, e) {
    gvEntregas.GetRowValues(gvEntregas.GetFocusedRowIndex(), "codigoEstado", OnCallBack);
}

function OnCallBack(s, e) {
    if (s == 1) {
        document.getElementById("ContentPlaceHolder1_btnAnulada").value = "Anular";
        document.getElementById("ContentPlaceHolder1_btnEntregada").value = "Entregada";
    }
    else if (s == 2) {
        document.getElementById("ContentPlaceHolder1_btnAnulada").value = "Anular";
        document.getElementById("ContentPlaceHolder1_btnEntregada").value = "Pendiente";
    }
    else if (s == 3) {
        document.getElementById("ContentPlaceHolder1_btnAnulada").value = "Deshacer";
        document.getElementById("ContentPlaceHolder1_btnEntregada").value = "Entregada";
    }
}