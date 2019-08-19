using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VndBE100;
using Primavera.Extensibility.Sales.Editors;
using Primavera.Extensibility.BusinessEntities.ExtensibilityService.EventArgs;
using ErpBS100;
namespace Motor_vnd
{
    public class Vnd_artigo : EditorVendas
    {
        //GcpBEDocumentoVenda obj = new GcpBEDocumentoVenda();
       //VndBELinhaDocumentoVenda obj_lin_doc = new VndBELinhaDocumentoVenda();
       VndBEDocumentoVenda obj_cabec_doc = new VndBEDocumentoVenda();
        public override void AntesDeGravar(ref bool Cancel, ExtensibilityEventArgs e)
        {
            // base.AntesDeGravar(ref Cancel, e);
            obj_cabec_doc.Tipodoc = "FA";
            obj_cabec_doc.Serie = "2019";
            obj_cabec_doc.Moeda = "AKZ";
            obj_cabec_doc.TipoEntidade = "C";
            obj_cabec_doc.Entidade = "10124";
            //BSO.Comercial.VENDAS.PreencheDadosRelacionados obj_cabec_doc;

            BSO.Vendas.Documentos.PreencheDadosRelacionados(obj_cabec_doc);

            VndBELinhaDocumentoVenda obj_lin_doc = new VndBELinhaDocumentoVenda();

            obj_lin_doc.Artigo = "01.01.047";
            obj_lin_doc.Descricao = "Descricao do Artigo";
            obj_lin_doc.Quantidade = 2;
            obj_lin_doc.PrecUnit = 1000;
            obj_lin_doc.Unidade = "UN";
            obj_lin_doc.CodIva = "0";
            obj_lin_doc.TaxaIva = 0;
            obj_lin_doc.TipoLinha = "10";

            obj_cabec_doc.Linhas.Insere(obj_lin_doc);

            // VndBELinhaDocumentoVenda obj_lin_doc = new VndBELinhaDocumentoVenda();
            //BSO.Comercial.VENDAS.Actualiza obj
            BSO.Vendas.Documentos.Actualiza(obj_cabec_doc);

        }
    }
}
