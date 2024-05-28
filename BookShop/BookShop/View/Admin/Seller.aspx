<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="BookShop.View.Admin.Seller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContant" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Sellers
                </h3>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-md-4">
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Seller Name"></asp:Label>
                    <asp:TextBox ID="txtName" type="text" placeholder="Name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" type="email" placeholder="Email" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" type="password" placeholder="Password" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label4" runat="server" Text="Phone Number"></asp:Label>
                    <asp:TextBox ID="txtPhNo" placeholder="Ph No." runat="server" CssClass="form-control" type="Phone"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtAddress" placeholder="Address" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
                
                <div class="row">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row">
                    
                    <div class="d-block col">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-success btn-block btn" OnClick="btnSave_Click" />
                    </div>
                    <div class="d-block col">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-success btn-block btn" OnClick="btnUpdate_Click" />
                    </div>
                    <div class="d-block col">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-danger btn-block btn" OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <asp:GridView ID="dgvSeller" runat="server" CssClass="table-bordered table" AutoGenerateSelectButton="True" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvSeller_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="SId" HeaderText="Seller Id" />
                        <asp:BoundField DataField="SName" HeaderText="Seller Name" />
                        <asp:BoundField DataField="SEmail" HeaderText="Seller Email" />
                        <asp:BoundField DataField="SPassword" HeaderText="Seller Password" />
                        <asp:BoundField DataField="SPhone" HeaderText="Seller PhoneNo." />
                        <asp:BoundField DataField="SAddress" HeaderText="Seller Address" />
                </Columns>
                    <SelectedRowStyle BackColor="#99FF99" ForeColor="Black" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
