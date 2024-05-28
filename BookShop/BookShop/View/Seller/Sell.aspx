<%@ Page Title="" Language="C#" MasterPageFile="~/View/Seller/SellerMaster.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="BookShop.View.Seller.Sell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintBill() {
            var PGrid = document.getElementById('<%= dgvBill.ClientID %>');
            PGrid.border = 0;
            var PWin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=726,tollbar=0,scrollbar=1,status=0,resizable');
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            PWin.focus();
            PWin.print();
            PWin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContant" runat="server">
    
    <div class="container-fluid">
        <div class="row">
        </div>
        <div class="row">
            <div class="col-md-5">
                <h4 class="text center">Book Detail
                </h4>
                <div class="row">
                    <div class="col">
                        <div class="mt-2">
                            <label for="" class="col-form-label">Book Name </label>
                            <asp:TextBox ID="txtBook" runat="server" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-2">
                            <label for="" class="col-form-label">Price </label>
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="mt-2">
                            <label for="" class="col-form-label">Quantity </label>
                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        
                    </div>
                     
                </div>
                <div class ="row">
                    
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    
                </div>
                <div class="row">
                        <div class="col d-grid mt-2">
                           <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn-block btn" BackColor="#A0D0C0" OnClick="btnAdd_Click"/>
                        </div>
                    </div>
                <div class="row mt-2">
                    <h4 class="text-center">Book Detail
                    </h4>
                    <div class="col mt-2">
                        <asp:GridView ID="dgvBook" runat="server" AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" OnSelectedIndexChanged="dgvBook_SelectedIndexChanged" CssClass="table" Height="200px" AutoGenerateSelectButton="True">
                            <SelectedRowStyle BackColor="#a0d0c0" ForeColor="Black" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <h4 class="text-center mt-2" style="color: black; Background: #e0e0d8">Bill</h4>
                <div class="col">
                    <asp:GridView ID="dgvBill" CssClass ="table" runat="server" BorderColor="Black" BorderStyle="Solid" OnSelectedIndexChanged="dgvBook_SelectedIndexChanged" Height="200px">
                        <SelectedRowStyle BackColor="#a0d0c0" ForeColor="Black" />
                    </asp:GridView>
                    <div class="d-block col">
                        <asp:Label ID="Label2" runat="server" Text="Total = " CssClass="text-danger">Total = </asp:Label>
                        <asp:Label ID="lblTotal" CssClass="text-success" runat="server" Text="0"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text=" Kyats" CssClass="text-danger"> Kyats</asp:Label>
                    </div>
                    <div class="d-block col">
                        <asp:Button ID="btnPrint" runat="server" Text="Print Bill" OnClientClick="PrintBill()" CssClass="btn-block btn" BackColor="#A0D0C0" OnClick="btnPrint_Click"/>
                    </div>
               </div>
            </div>
        </div>
    </div>
</asp:Content>
