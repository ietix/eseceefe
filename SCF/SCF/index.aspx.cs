using BibliotecaSCF.Controladores;
using System;

namespace SCF
{
  
  public partial class index : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      CalcularKpis();
    }

    private void CalcularKpis()
    {
      var kpiEntregas = ControladorGeneral.CalcularKpisEntrega();

      lblEntregasEnTiempo.Value = Convert.ToInt32(kpiEntregas.Rows[0].ItemArray[0]);
      lblEntregasPorVencer.Value = Convert.ToInt32(kpiEntregas.Rows[0].ItemArray[1]);
      lblEntregasVencidas.Value = Convert.ToInt32(kpiEntregas.Rows[0].ItemArray[2]);
    }
  }
}