<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="BookShop.View.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContant" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Categories
                </h3>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-md-4">
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Category Name"></asp:Label>
                    <asp:TextBox ID="txtName" type="text" placeholder="Name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Category Description"></asp:Label>
                    <asp:TextBox ID="txtDesc" type="text" placeholder="Description" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                
                 <div class="row">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row mt-2">
                    
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
                 <asp:GridView ID="dgvCategory" runat="server" CssClass="table-bordered table" AutoGenerateSelectButton="True" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvCategory_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="CategoryId" HeaderText="Category Id" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                        <asp:BoundField DataField="CategoryDesc" HeaderText="Category Description" />
                </Columns>
                    <SelectedRowStyle BackColor="#99FF99" ForeColor="Black" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
