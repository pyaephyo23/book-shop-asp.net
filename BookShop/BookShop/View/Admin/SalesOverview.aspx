<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SalesOverview.aspx.cs" Inherits="BookShop.View.Admin.SalesOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContant" runat="server">
    <div class="row">
        <div class="mt-2 col">
            <h3 class="text-center">Sale Overview
            </h3>
        </div>
    </div>
    <div class="mt-3 row">
        <div class="col-6">
            <asp:Button ID="btnShowAll" runat="server" Text="Show All Bill" CssClass="form-control" OnClick="btnShowAll_Click" />
        </div>
        <div class="col-6">
            <asp:Button ID="btnShowToday" runat="server" Text="Show Today Bill" CssClass="form-control" OnClick="btnShowToday_Click" />
        </div>
    </div>
    <div class="row">
        <div class="mt-2 col-md-2">
            
           <asp:Label ID="lblMessage" runat="server" Text=" " CssClass="text-success"></asp:Label>
        </div>
    </div>
    <div class="row mt-4" >
        <div class="col">
            <asp:GridView ID="dgvBill" runat="server" AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" CssClass="table" Height="200px">
                            <SelectedRowStyle BackColor="#a0d0c0" ForeColor="Black" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
