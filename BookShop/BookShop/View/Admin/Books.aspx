<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BookShop.View.Admin.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContant" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Books
                </h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Book Title"></asp:Label>
                    <asp:TextBox ID="txtName" placeholder="Title" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label5" runat="server" Text="Author"></asp:Label>
                    <asp:DropDownList ID="cboAuthor" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Categories"></asp:Label>
                    <asp:DropDownList ID="cboCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
                    <asp:TextBox ID="txtPrice" placeholder="Price" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label4" runat="server" Text="Quantity"></asp:Label>
                    <asp:TextBox ID="txtQty" placeholder="Quantity" runat="server" CssClass="form-control"></asp:TextBox>
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
                <asp:GridView ID="dgvBook" runat="server" CssClass="table-bordered table" AutoGenerateSelectButton="True" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvBook_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="BookId" HeaderText="Book Id" />
                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                        <asp:BoundField DataField="BookAuthor" HeaderText="Book Author" />
                        <asp:BoundField DataField="BookCategory" HeaderText="Book Category" />
                        <asp:BoundField DataField="BookQty" HeaderText="Book Qty" />
                        <asp:BoundField DataField="BookPrice" HeaderText="Book Price" />
                </Columns>
                    <SelectedRowStyle BackColor="#99FF99" ForeColor="Black" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
