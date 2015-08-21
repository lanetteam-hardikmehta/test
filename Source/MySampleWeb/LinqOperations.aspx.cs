using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
      

public partial class LinqOperations : System.Web.UI.Page
{
    #region Global Var
    MySampleWebDataContext db = new MySampleWebDataContext();
    #endregion

    #region Page Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        ////Get Prod List By tblObj
        //getProdListUsingtblObj();

        ////Get Prod List By tblObj With ID
        //getProdListUsingtblObjWithID(1);

        //Get Prod List By SP
        getProdListUsingSP(2);
    }
    #endregion

    #region Control Events
    #endregion

    #region Private Methods

    //Get Prod List By tblObj
    private void getProdListUsingtblObj()
    { 
        
        var prod= (from Prd in db.tblProducts orderby Prd.ProdName
                   select Prd).ToList();
        if(prod!=null)
        {
            grdLinqSample.DataSource = prod;
            grdLinqSample.DataBind();
        }
    }

    //Get Prod List By tblObj With ID
    private void getProdListUsingtblObjWithID(int ProdID)
    {

        var prod = (from Prd in db.tblProducts
                    where Prd.ProdId == ProdID
                    orderby Prd.ProdName
                    select Prd).ToList();
        if (prod != null)
        {
            grdLinqSample.DataSource = prod;
            grdLinqSample.DataBind();
        }
    }

    //Get Prod List By SP
    private void getProdListUsingSP(int ProdID)
    {

        var prod = db.GetProductList(ProdID).ToList();
        if (prod != null)
        {
            grdLinqSample.DataSource = prod;
            grdLinqSample.DataBind();
        }
    }
    #endregion

}